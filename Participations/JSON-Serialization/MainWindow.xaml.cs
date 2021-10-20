using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> platforms = new List<Game>();
        public MainWindow()
        {   
            InitializeComponent();

            cboPlatform.Items.Add("All");
            //name,platform,release_date,summary,meta_score,user_review

            string[] lines = File.ReadAllLines("all_games.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] pieces = line.Split(',');

                Game g = new Game();
                g.name = pieces[0].Trim();
                g.platform = pieces[1].Trim();
                g.release_date = Convert.ToDateTime(pieces[2]);
                g.summary = pieces[3].Trim();
                g.meta_score = Convert.ToInt32(pieces[4]);
                g.user_review = pieces[5].Trim();

                if (cboPlatform.Items.Contains(g.platform) == false)
                {
                    cboPlatform.Items.Add(g.platform);
                }
                platforms.Add(g);
                lstName.Items.Add(g);
            }

            lblCount.Content = $"Record Count: {lstName.Items.Count.ToString("N0")}";
        }

        private void cboPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string platform = cboPlatform.SelectedValue.ToString();

            lstName.Items.Clear();
            foreach (Game game in platforms)
            {
                if (game.platform == platform)
                {
                    lstName.Items.Add(game);
                }
            }
        }

        private void lstName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Game selected = (Game)lstName.SelectedItem;
            InfoWindow info = new InfoWindow();
            info.PopulateData(selected);

            info.ShowDialog();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            string json = JsonConvert.SerializeObject(lstName.Items);
            File.WriteAllText($"{cboPlatform.SelectedValue.ToString()} games.json", json);
        }

    }
}
