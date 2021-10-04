using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_ChuckNorris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            cboCategory.Items.Add("All");

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;

                var results = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string category in results)
                {
                    cboCategory.Items.Add(category);
                }
            }
            
        }

        private void btnJoke_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = cboCategory.SelectedValue.ToString();

            using (var client = new HttpClient())
            {
                if (selectedItem == "All")
                {
                    string json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                    var result = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);
                    txtJoke.Text = result.value;
                }
                else
                {
                    string json = client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category={selectedItem}").Result;

                    var results = JsonConvert.DeserializeObject<ChuckNorrisAPI>(json);

                    txtJoke.Text = results.value;
                }
            }
        }
    }
}
