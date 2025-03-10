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
using System.Windows.Shapes;

namespace Opakovani_WPF
{
    /// <summary>
    /// Interaction logic for UserAddWindow.xaml
    /// </summary>
    public partial class UserAddWindow : Window
    {
        public User user = new User();
        public UserAddWindow()
        {
            InitializeComponent();
        }

        private void btnUserAddWindowConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxUsername.Text) && !string.IsNullOrWhiteSpace(txtBoxRole.Text))
            {
                user.Username = txtBoxUsername.Text;
                user.Role = txtBoxRole.Text;

                this.DialogResult = true;
            }
            else { this.DialogResult = false; }
        }

        private void btnUserAddWindowBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
