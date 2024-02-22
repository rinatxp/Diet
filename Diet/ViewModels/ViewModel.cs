using Diet.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Data;

namespace Diet.ViewModels
{
    public class ViewModel
    {
        public ViewModel()
        {
            LoadData();
            BindingOperations.EnableCollectionSynchronization(Foods, _locker);
        }

        public Summary Summary { get; set; } = new();
        public Etalon Etalon { get; set; } = new();
        public IEnumerable<Food> Foods => _foods;
        private ObservableCollection<Food> _foods = null!;
        private readonly object _locker = new object();
        private readonly string _dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "diet.json");

        public void LoadData()
        {
            try
            {
                var data = File.ReadAllText(_dataPath);
                _foods = JsonConvert.DeserializeObject<ObservableCollection<Food>>(data)!;
            }
            catch (Exception)
            {
                _foods = new ObservableCollection<Food>();
            }
        }

        public async Task SaveData()
        {
            try
            {
                var obj = JsonConvert.SerializeObject(_foods, Formatting.Indented);
                await File.WriteAllTextAsync(_dataPath, obj);
            }
            catch { }
        }

        public void AddFood(Food food)
        {
            _foods.Add(food);
        }

        public void RemoveFood(string name)
        {
            var food = _foods.FirstOrDefault(f => f.Name == name);
            if (food != null)
                _foods.Remove(food);
        }
    }
}
