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

namespace Wpf_Contact_List
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

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            string[] contents = File.ReadAllLines("contacts.txt");

            for (int i = 1; i < contents.Length; i++)
            {
                string line = contents[i];

                string[] pieces = line.Split("|");

                string id = pieces[0];
                string firstName = pieces[1];
                string lastName = pieces[2];
                string email = pieces[3];
                string url = pieces[4];

                Contacts c = new Contacts();
                c.id = Convert.ToInt32(id);
                c.FirstName = firstName;
                c.LastName = lastName;
                c.Email = email;
                c.URL = url;

                lstContacts.Items.Add(c);
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Contacts selectedContact = (Contacts)lstContacts.SelectedItem;
            txtFirstName.Text = selectedContact.FirstName;
            txtLastName.Text = selectedContact.LastName;
            txtEmail.Text = selectedContact.Email;
            var uri = new Uri(selectedContact.URL);
            var img = new BitmapImage(uri);
            imgURL.Source = img;
        }
    }
}
