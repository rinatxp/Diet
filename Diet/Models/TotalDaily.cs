namespace Diet.Models
{
    public class TotalDaily : FoodBase
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
    }
}
