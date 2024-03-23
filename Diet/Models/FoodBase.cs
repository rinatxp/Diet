using System.ComponentModel;

namespace Diet.Models
{
    public abstract class FoodBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public double Calories { get; set; }

        public double Proteins { get; set; }

        public double Fats { get; set; }

        public double Carbohydrats { get; set; }

        public double DieteryFiber { get; set; }

        public double A { get; set; }

        public double B1 { get; set; }

        public double B2 { get; set; }

        public double B3 { get; set; }

        public double B5 { get; set; }

        public double B6 { get; set; }

        public double B7 { get; set; }

        public double B9 { get; set; }

        public double B12 { get; set; }

        public double C { get; set; }

        public double D { get; set; }

        public double E { get; set; }

        public double K { get; set; }

        public double Potassium { get; set; }

        public double Phosphorus { get; set; }

        public double Magnesium { get; set; }

        public double Omega3 { get; set; }

        public double Omega6 { get; set; }

        public double Sulfur { get; set; }

        public double Chlorine { get; set; }

        public double Calcium { get; set; }

        public double Sodium { get; set; }

        public double Iron { get; set; }

        public double Zink { get; set; }

        public double Manganese { get; set; }

        public double Copper { get; set; }

        public double Molybdenum { get; set; }

        public double Fluorine { get; set; }

        public double Selenium { get; set; }

        public double Chromium { get; set; }

        public double Iodine { get; set; }
    }
}
