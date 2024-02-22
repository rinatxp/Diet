namespace Diet.Models
{
    public class Etalon : Summary
    {
        public void CalculateByWeight(double weight)
        {
            Calories += 33 * weight + 600;
            Proteins += 1.5 * weight * 1000 * 1000;
            Fats += Calories * 0.3 / 9 * 1000 * 1000;
            Carbohydrats += (Calories * 0.55) / 4 * 1000 * 1000;
            DieteryFiber += Calories / 72 * 1000 * 1000;
            A += 5 * 1000;
            B1 += Calories / 1000 * 600;
            B2 += Calories / 1000 * 750;
            B3 += Calories / 1000 * 8000;
            B5 += 5 * 1000;
            B6 += 2000;
            B7 += 50;
            B9 += 400;
            B12 += 3;
            C += 95 * 1000;
            D += 12;
            E += 15 * 1000;
            K += 120;
            Potassium += 3400 * 1000;
            Phosphorus += 800 * 1000;
            Magnesium += 400 * 1000;
            Omega3 += 1.6 * 1000 * 1000;
            Omega6 += Omega3 * 4.5;
            Sulfur += 13 * 1000 * weight;
            Chlorine += 2300 * 1000;
            Calcium += 1000 * 1000;
            Sodium += 1300 * 1000;
            Iron += 8 * 1000;
            Zink += 11 * 1000;
            Manganese += 2300;
            Copper += 900;
            Molybdenum += 60;
            Fluorine += 3500;
            Selenium += 60;
            Chromium += 40;
            Iodine += 150;
        }
    }
}
