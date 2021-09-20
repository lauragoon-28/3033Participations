using System;
using System.Collections.Generic;
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

namespace Wpf_Classes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddToy_Click(object sender, RoutedEventArgs e)
        {
            bool doubleCheck = true;
            if (string.IsNullOrWhiteSpace(txtManufacturer.Text)==true)
            {
                doubleCheck = false;
                MessageBox.Show("You must enter a valid Manufacturer Name");
            }
            if (string.IsNullOrWhiteSpace(txtName.Text) == true)
            {
                doubleCheck = false;
                MessageBox.Show("You must enter a valid Toy Name");
            }
            if (string.IsNullOrWhiteSpace(txtURL.Text) == true)
            {
                doubleCheck = false;
                MessageBox.Show("You must enter a valid toy URL");
            }
            double price;
            if (double.TryParse(txtPrice.Text, out price) == false)
            {
                doubleCheck = false;
                MessageBox.Show("You must enter a valid price");
            }
            Toy toy = new Toy();
            toy.Manufacturer = txtManufacturer.Text;
            toy.Name = txtName.Text;
            toy.Price = Convert.ToDouble(txtPrice.Text);
            toy.Image = txtURL.Text;
            lstToy.Items.Add(toy);
        }

        private void lstToy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selectedToy = (Toy)lstToy.SelectedItem;
            var uri = new Uri(txtURL.Text);
            var img = new BitmapImage(uri);

            MessageBox.Show($"The toy is on aisle: {selectedToy.GetAisle()}");
            imgToy.Source = img;
        }
    }
}
