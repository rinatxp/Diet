using Diet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HtmlAgilityPack;
using System.Globalization;

namespace Diet
{
    /// <summary>
    /// Interaction logic for WebsiteFood.xaml
    /// </summary>
    public partial class WebsiteFoodBuilder : Window, IFoodBuilder
    {
        public WebsiteFoodBuilder()
        {
            InitializeComponent();
        }

        public Food Food => _food;
        private Food _food = null!;

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await GetFoodFromPage();
        }

        private async Task GetFoodFromPage()
        {
            if (string.IsNullOrEmpty(tbox.Text))
                return;
            if (!long.TryParse(tboxMax.Text, out var max))
                return;

            using HttpClient client = new HttpClient();
            var responce = await client.GetAsync(tbox.Text);
            if (!responce.IsSuccessStatusCode)
            {
                MessageBox.Show(Properties.Resource.WebsiteNotAvailable);
                return;
            }

            string html = await responce.Content.ReadAsStringAsync();
            try
            {
                _food = GetFood(html);
                _food.Max = max;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Food GetFood(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            string calories = @"<span itemprop=""calories"">([\d.]+\s*кКал)<\/span>";
            string proteins = @"<span itemprop=""proteinContent"">([\d.]+\s*г)<\/span>";
            string fats = @"<span itemprop=""fatContent"">([\d.]+\s*г)<\/span>";
            string carbohydrats = @"<span itemprop=""carbohydrateContent"">([\d.]+\s*г)<\/span>";
            string fibers = @"<span itemprop=""fiberContent"">([\d.]+\s*г)<\/span>";
            string aBetaCarotin = "//tr[td[@class='mzr-tc-chemical-level-1 mzr-tc-chemical-detailed' and text()='бета Каротин']]";
            string b1 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В1, тиамин']]";
            string b2 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В2, рибофлавин']]";
            string b3 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин РР, НЭ']]";
            string b5 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В5, пантотеновая']]";
            string b6 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В6, пиридоксин']]";
            string b7 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин Н, биотин']]";
            string b9 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В9, фолаты']]";
            string b12 = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин В12, кобаламин']]";
            string c = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин C, аскорбиновая']]";
            string d = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин D, кальциферол']]";
            string e = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин Е, альфа токоферол, ТЭ']]";
            string k = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Витамин К, филлохинон']]";
            string potassium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Калий, K']]";
            string phosphorous = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Фосфор, P']]";
            string magnesium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Магний, Mg']]";
            string sulfur = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Сера, S']]";
            string calcium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Кальций, Ca']]";
            string chlorine = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Хлор, Cl']]";
            string chromium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Хром, Cr']]";
            string copper = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Медь, Cu']]";
            string fluorine = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Фтор, F']]";
            string iodine = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Йод, I']]";
            string iron = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Железо, Fe']]";
            string manganese = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Марганец, Mn']]";
            string molybdenum = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Молибден, Mo']]";
            string selenium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Селен, Se']]";
            string sodium = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Натрий, Na']]";
            string zink = "//tr[td[@class='mzr-tc-chemical-level-1' and text()='Цинк, Zn']]";
            string omega3 = "//tr[td[@class='mzr-tc-chemical-level-3' and text()='Омега-3 жирные кислоты']]";
            string omega6 = "//tr[td[@class='mzr-tc-chemical-level-3' and text()='Омега-6 жирные кислоты']]";


            var food = new Food
            {
                Name = doc.DocumentNode.SelectSingleNode("//span[@itemprop='name']")?.InnerText ?? throw new ArgumentNullException("Can't extract the food's name"),
                Calories = GetBZHUValue(html, calories),
                Proteins = GetBZHUValue(html, proteins),
                Fats = GetBZHUValue(html, fats),
                Carbohydrats = GetBZHUValue(html, carbohydrats),
                DieteryFiber = GetBZHUValue(html, fibers),
                A = GetVitaminValue(doc, aBetaCarotin),
                B1 = GetVitaminValue(doc, b1),
                B2 = GetVitaminValue(doc, b2),
                B3 = GetVitaminValue(doc, b3),   
                B5 = GetVitaminValue(doc, b5),
                B6 = GetVitaminValue(doc, b6),
                B7 = GetVitaminValue(doc, b7),
                B9 = GetVitaminValue(doc, b9),
                B12 = GetVitaminValue(doc, b12),
                C = GetVitaminValue(doc, c),
                D = GetVitaminValue(doc, d),
                E = GetVitaminValue(doc, e),
                K = GetVitaminValue(doc, k),
                Potassium = GetVitaminValue(doc, potassium),
                Phosphorus = GetVitaminValue(doc, phosphorous),
                Magnesium = GetVitaminValue(doc, magnesium),
                Sulfur = GetVitaminValue(doc, sulfur),
                Calcium = GetVitaminValue(doc, calcium),
                Chlorine = GetVitaminValue(doc, chlorine),
                Chromium = GetVitaminValue(doc, chromium),
                Copper = GetVitaminValue(doc, copper),
                Fluorine = GetVitaminValue(doc, fluorine),
                Iodine = GetVitaminValue(doc, iodine),
                Iron = GetVitaminValue(doc, iron),
                Manganese = GetVitaminValue(doc, manganese),
                Molybdenum = GetVitaminValue(doc, molybdenum),
                Selenium = GetVitaminValue(doc, selenium),
                Sodium = GetVitaminValue(doc, sodium),
                Zink = GetVitaminValue(doc, zink),
                Omega3 = GetVitaminValue(doc, omega3),
                Omega6 = GetVitaminValue(doc, omega6),
            };

            return food;
        }

        private double GetBZHUValue(string html, string path)
        {
            var rawValue = Regex.Match(html, path).Groups[1].Value;
            return GetValueFromString(rawValue);
        }

        private double GetVitaminValue(HtmlDocument doc, string path)
        {
            var rawValue = GetNodeValue(doc, path);
            return GetValueFromString(rawValue);
        }

        private string GetNodeValue(HtmlDocument doc, string xpath)
        {
            HtmlNode trNode = doc.DocumentNode.SelectSingleNode(xpath);
            if (trNode == null)
                return null!;

            HtmlNode tdNode = trNode.SelectSingleNode("td[2]");
            return tdNode.InnerText.Trim();
        }

        private double GetValueFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            Unit unit;
            if (str.Contains(" г"))
                unit = Unit.Gramm;
            else if (str.Contains(" мг"))
                unit = Unit.Milligramm;
            else unit = Unit.Other;

            double value = double.Parse(str.Split()[0], NumberStyles.Any, CultureInfo.InvariantCulture);
            return value / 100 * (int)unit;
        }

        private enum Unit
        {
            Gramm = 1000 * 1000,
            Milligramm = 1000,
            Other = 1,
        }

        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                await GetFoodFromPage();
        }

        private void tbox_KeyDown(object sender, KeyEventArgs e)
        {
            var col = Color.FromArgb(0xFF, 0x37, 0x37, 0x37);
            (sender as TextBox)!.Background = new SolidColorBrush(col);
        }
    }
}
