using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterBlazor.WPF.UC.RestForm
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ComboSettings1 : UserControl
    {
        private string jsonFilePath = "data.json";
        private List<ComboBoxItemData> items;
        public ComboSettings1()
        {
            InitializeComponent();
            LoadComboBoxData();
        }
        private void LoadComboBoxData()
        {
            try
            {
                if (File.Exists(jsonFilePath))
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    items = JsonConvert.DeserializeObject<List<ComboBoxItemData>>(jsonData);
                    comboBox.ItemsSource = items;//.Select(i => i.DisplayValue);
                }
                else
                {
                    items = new List<ComboBoxItemData>();
                    MessageBox.Show("Data file not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        public void AddItem(string siteUrl, string apiUrl)
        {
            int id = 1;
            if (items == null) items = new();
            if (items.Count > 0)
            {
                id = items.Max(i => i.Id) + 1;
            }
            var newItem = new ComboBoxItemData { Id = id, SiteUrl = siteUrl, ApiUrl = apiUrl };
            items.Add(newItem);
            comboBox.ItemsSource = items.Select(i => i.DisplayValue).ToList(); // Update ComboBox items

            SaveItems();
        }

        public void SaveItems()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(items, Formatting.Indented);
                File.WriteAllText(jsonFilePath, jsonData);
                MessageBox.Show("Items saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }





        private void SaveItems_Click(object sender, RoutedEventArgs e)
        {
            SaveItems();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedItem is ComboBoxItemData selectedItem)
            {
                OnComboBoxItemSelected(selectedItem);
            }
        }

        public event EventHandler<ComboBoxItemData> ComboBoxItemSelected;

        protected virtual void OnComboBoxItemSelected(ComboBoxItemData e)
        {
            ComboBoxItemSelected?.Invoke(this, e);
        }
    }

}
