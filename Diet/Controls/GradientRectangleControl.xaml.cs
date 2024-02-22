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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diet
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class GradientRectangle : UserControl
    {
        public static readonly DependencyProperty MinNormalValueProperty =
            DependencyProperty.Register("MinNormalValue", typeof(double), typeof(GradientRectangle),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty CurrentValueProperty =
            DependencyProperty.Register("CurrentValue", typeof(double), typeof(GradientRectangle),
                new PropertyMetadata(0.0, OnValueChanged));

        public string Header
        {
            get { return lbl.Text; }
            set { lbl.Text = value; }
        }

        public double MinNormalValue
        {
            get { return (double)GetValue(MinNormalValueProperty); }
            set { SetValue(MinNormalValueProperty, value); }
        }

        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        public GradientRectangle()
        {
            InitializeComponent();
            UpdateGradient();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((GradientRectangle)d).UpdateGradient();
        }

        private void UpdateGradient()
        {
            const double MAX_TRIANGLE_OFFSET = 0.6;
            var colorFocusOffset = MAX_TRIANGLE_OFFSET;
            double rectangleWidth = gradientRectangle.ActualWidth;
            double rectangleHeigth = gradientRectangle.ActualHeight;

            if (CurrentValue < MinNormalValue)
            {
                var maxValueInRectangle = MinNormalValue / MAX_TRIANGLE_OFFSET;
                var currentValueXPercent = CurrentValue / maxValueInRectangle;
                var currentValueXCoord = rectangleWidth * currentValueXPercent;
                triangle.Points[0] = new Point(currentValueXCoord, 0);
                triangle.Points[1] = new Point(currentValueXCoord - rectangleHeigth / 2, rectangleHeigth / 2);
                triangle.Points[2] = new Point(currentValueXCoord + rectangleHeigth / 2, rectangleHeigth / 2);
            }
            else
            {
                var minNormalPercentOfCurrent = MinNormalValue / (CurrentValue / 100);
                colorFocusOffset = colorFocusOffset * minNormalPercentOfCurrent / 100;
            }

            clr2.Offset = colorFocusOffset - 0.2;
            clr3.Offset = colorFocusOffset;
            clr4.Offset = colorFocusOffset + 0.2;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGradient();
        }
    }
}
