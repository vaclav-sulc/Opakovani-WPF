using System.ComponentModel;
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

namespace Opakovani_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string appData;
        string appPath;
        string filePath;
        BindingList<User> users = new BindingList<User>();
        public MainWindow()
        {
            appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appPath = System.IO.Path.Combine(appData, "3_kv_users");
            filePath = System.IO.Path.Combine(appPath, "users.csv");
            InitializeComponent();
            if (!System.IO.Directory.Exists(appPath))
            {
                System.IO.Directory.CreateDirectory(appPath);
            }
            if (System.IO.File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(';');
                        users.Add(new User(line[0], line[2]));
                    }
                }
            }

            listBoxUzivatele.ItemsSource = users;
        }
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            listBoxUzivatele.ItemsSource = users;
        }

        private void btnShowAdmin_Click(object sender, RoutedEventArgs e)
        {
            var admins = new BindingList<User>();
            foreach (User user in users)
            {
                if (user.Role == "admin") admins.Add(user);
            }
            listBoxUzivatele.ItemsSource = admins;
        }

        private void btnShowEditor_Click(object sender, RoutedEventArgs e)
        {
            var editors = new BindingList<User>();
            foreach (User user in users)
            {
                if (user.Role == "editor") editors.Add(user);
            }
            listBoxUzivatele.ItemsSource = editors;
        }

        private void btnShowCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customers = new BindingList<User>();
            foreach (User user in users)
            {
                if (user.Role == "customer") customers.Add(user);
            }
            listBoxUzivatele.ItemsSource = customers;

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxUzivatele.SelectedItem is User user)
            {
                users.Remove(user);
            }
            else
            {
                MessageBox.Show("Vyberte uzivatele");
            }

        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserAddWindow userAddWindow = new UserAddWindow();
            if (userAddWindow.ShowDialog() == true)
            {
                users.Add(userAddWindow.user);
            }
        }

        private void btnUserSave_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (User user in users)
                {
                    writer.WriteLine(user.ToString());
                    writer.Flush();
                }
            }
        }
    }
}