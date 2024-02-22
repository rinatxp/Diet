using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Diet
{
    /// <summary>
    /// Interaction logic for Weight.xaml
    /// </summary>
    public partial class Weight : Window
    {
        public Weight()
        {
            InitializeComponent();
        }

        private MainWindow _mainWindow = new MainWindow();

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TryGetWeight();
        }

        private void TryGetWeight()
        {
            if (double.TryParse(tbox.Text, out var weight) && weight > 0)
            {
                _mainWindow.SetWeight(weight);
                _mainWindow.Show();
                this.Close();
            }
        }
    }
}
