using System.ComponentModel;

namespace Diet.Models
{
    public class Summary : INotifyPropertyChanged
    {
        public void AddValues(Food food, double value)
        {
            Calories += food.Calories * value;
            Proteins += food.Proteins * value;
            Fats += food.Fats * value;
            Carbohydrats += food.Carbohydrats * value;
            DieteryFiber += food.DieteryFiber * value;
            A += food.A * value;
            B1 += food.B1 * value;
            B2 += food.B2 * value;
            B3 += food.B3 * value;
            B5 += food.B5 * value;
            B6 += food.B6 * value;
            B7 += food.B7 * value;
            B9 += food.B9 * value;
            B12 += food.B12 * value;
            C += food.C * value;
            D += food.D * value;
            E += food.E * value;
            K += food.K * value;
            Potassium += food.Potassium * value;
            Phosphorus += food.Phosphorus * value;
            Magnesium += food.Magnesium * value;
            Omega3 += food.Omega3 * value;
            Omega6 += food.Omega6 * value;
            Sulfur += food.Sulfur * value;
            Chlorine += food.Chlorine * value;
            Calcium += food.Calcium * value;
            Sodium += food.Sodium * value;
            Iron += food.Iron * value;
            Zink += food.Zink * value;
            Manganese += food.Manganese * value;
            Copper += food.Copper * value;
            Molybdenum += food.Molybdenum * value;
            Fluorine += food.Fluorine * value;
            Selenium += food.Selenium * value;
            Chromium += food.Chromium * value;
            Iodine += food.Iodine * value;
        }

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
