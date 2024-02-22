using Diet.Models;
using Diet.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Diet
{
    public interface IFoodBuilder
    {
        Food Food { get; }
    }

    /// <summary>
    /// Interaction logic for CreateFood.xaml
    /// </summary>
    public partial class ManualFoodBuilder : Window, IFoodBuilder
    {
        public Food Food => _food;
        private Food _food = null!;
        private readonly List<string> _units = new() { Resource.Gramm, Resource.Milligramm, Resource.Microgramm };
        private readonly static char[] allowedSymbols = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ','];
        private bool isAllValid = false;

        public ManualFoodBuilder()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    Create(); break;
                case Key.Escape:
                    Close(); break;
            }
        }

        private void Create()
        {
            if (string.IsNullOrWhiteSpace(foodName.Content as string) ||
                string.IsNullOrWhiteSpace(foodMax.Content as string))
                return;

            isAllValid = true;

            var food = new Food
            {
                Name = GetTextBoxContent(foodName),
                Max = Convert.ToInt32(GetValue(foodMax)) * 100,

                Calories = GetValue(calories),
                Proteins = GetValue(proteins),
                Fats = GetValue(fats),
                Carbohydrats = GetValue(carbohydrats),
                DieteryFiber = GetValue(dieteryFiber),

                A = GetValue(a),
                B1 = GetValue(b1),
                B2 = GetValue(b2),
                B3 = GetValue(b3),
                B5 = GetValue(b5),
                B6 = GetValue(b6),
                B7 = GetValue(b7),
                B9 = GetValue(b9),
                B12 = GetValue(b12),
                C = GetValue(c),
                D = GetValue(d),
                E = GetValue(e),
                K = GetValue(k),

                Potassium = GetValue(potassium),
                Phosphorus = GetValue(phosphorus),
                Magnesium = GetValue(magnesium),
                Omega3 = GetValue(omega3),
                Omega6 = GetValue(omega6),
                Sulfur = GetValue(sulfur),
                Chlorine = GetValue(chlorine),
                Calcium = GetValue(calcium),
                Sodium = GetValue(sodium),
                Iron = GetValue(iron),
                Zink = GetValue(zink),
                Manganese = GetValue(manganese),
                Copper = GetValue(copper),
                Molybdenum = GetValue(molybdenum),
                Fluorine = GetValue(fluorine),
                Selenium = GetValue(selenium),
                Chromium = GetValue(chromium),
                Iodine = GetValue(iodine),
            };

            if (isAllValid)
            {
                _food = food;
                Close();
            }
        }

        private double GetValue(Button but)
        {
            var text = GetTextBoxContent(but).Replace(',', '.');
            if (!double.TryParse(text, out var value))
            {
                if (text.Length > 0)
                {
                    isAllValid = false;
                    MakeTextBoxRed(but);
                }
            }

            return GetValueWithKoef(value, GetUnitValue(but));
        }

        private string GetTextBoxContent(Button but)
        {
            return (but.Template.FindName("tbox", but) as TextBox)?.Text ?? null!;
        }

        private string GetUnitValue(Button but)
        {
            return (but.Template.FindName("unit", but) as TextBlock)?.Text ?? null!;
        }

        private void MakeTextBoxRed(Button foodElement)
        {
            _ = Dispatcher.InvokeAsync(async () =>
            {
                var backColor = foodElement.Background as SolidColorBrush;
                var redColor = new SolidColorBrush(Colors.Red);
                if (backColor!.Color == redColor.Color)
                    return;
                foodElement.Background = redColor;
                await Task.Delay(2000);
                foodElement.Background = backColor;
            });
        }

        private double GetValueWithKoef(double val, string type)
        {
            if (type == Resource.Milligramm)
            {
                return val * 1000 / 100;
            }
            else if (type == Resource.Gramm)
            {
                return val * 1000 * 1000 / 100;
            }
            else
            {
                return val / 100;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            e.Handled = false;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            if (string.IsNullOrEmpty(tb!.Text))
                return;
            int index = _units.IndexOf(tb.Text);
            tb.Text = _units[(index + 1) % _units.Count];
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox)!.Tag as string == Resource.NumbersAndWords)
                return;

            if (e.Text.Any(a => !allowedSymbols.Contains(a)))
                e.Handled = true;
        }
    }
}
