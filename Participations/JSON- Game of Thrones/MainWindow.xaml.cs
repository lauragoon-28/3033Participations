using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace JSON__Game_of_Thrones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<GOTapi> quotes = new List<GOTapi>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string url = " https://got-quotes.herokuapp.com/quotes";

                string jsonData = client.GetStringAsync(url).Result;

                GOTapi api = JsonConvert.DeserializeObject<GOTapi>(jsonData);

                txtQuote.Text = api.ToString();
                quotes.Add(api);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(quotes);

            File.WriteAllText("GOT_Quotes.json", json);


        }
    }
}
