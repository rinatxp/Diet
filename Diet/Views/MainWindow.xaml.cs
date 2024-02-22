using Diet.Models;
using Diet.ViewModels;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diet
{
    /// <summary>
    /// add foods from site
    /// save diet
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SetCultureInfo();
            InitializeComponent();
            _dataContext = new ViewModel();
            this.DataContext = _dataContext;
        }

        private readonly ViewModel _dataContext;
        private Food _selectedFood;

        public void SetWeight(double weight)
        {
            _dataContext.Etalon.CalculateByWeight(weight);
        }

        private void SetCultureInfo()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[1]);
        }

        private void AddFoodManually(object sender, RoutedEventArgs e)
        {
            AddFood<ManualFoodBuilder>();
        }

        private void AddFoodFromWebSite(object sender, RoutedEventArgs e)
        {
            AddFood<WebsiteFoodBuilder>();
        }

        private void AddFood<T>() where T : Window, IFoodBuilder, new()
        {
            var cf = new T();
            cf.ShowDialog();

            if (cf.Food == null)
                return;

            _dataContext.AddFood(cf.Food);
        }

        private void SwitchLanguage(object sender, RoutedEventArgs e)
        {
            bool isEng = Thread.CurrentThread.CurrentUICulture.Name.Contains("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(isEng ? "ru" : "en-Us");
            ProcessStartInfo psi = new()
            {
                Arguments = isEng ? "ru" : "en-Us",
                FileName = Application.ResourceAssembly.Location.Replace("dll", "exe")
            };
            Process.Start(psi);
            Application.Current.Shutdown();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _dataContext.Summary.AddValues(_selectedFood, e.NewValue - e.OldValue);
        }

        private void Slider_MouseEnter(object sender, MouseEventArgs e)
        {
            var foodName = (sender as Slider)!.Tag as string;
            _selectedFood = _dataContext.Foods.First(f => f.Name == foodName);
        }

        private void DeleteSliderButton_Click(object sender, RoutedEventArgs e)
        {
            var foodName = (sender as Button)!.Tag as string;
            _dataContext.RemoveFood(foodName!);
        }

        private async void Window_Closed(object sender, EventArgs e)
        {
            await _dataContext.SaveData();
        }
    }
}
