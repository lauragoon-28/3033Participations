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

namespace JSON___Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon").Result;

                PokemonAPI results  = JsonConvert.DeserializeObject<PokemonAPI>(json);

                foreach (var item in results.results)
                {
                    cboPokemon.Items.Add(item);
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Result selectedItem = (Result)cboPokemon.SelectedItem;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/pikachu").Result;

                PokeAPI result = JsonConvert.DeserializeObject<PokeAPI>(json);

                txtHeight.Text = Convert.ToString(result.height);
                txtWeight.Text = Convert.ToString(result.weight);

                var uri = new Uri(result.sprite.front_default);
                var img = new BitmapImage(uri);
                imgfront.Source = img;

                //var uri = new Uri(result.sprite.back_default);
                //var img = new BitmapImage(uri);
                //imgBack.Source = img;
            }

        }
    }
}
