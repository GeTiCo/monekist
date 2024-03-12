using monekist.Classes;
using monekist.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace monekist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.Helper.DBSport = new Model.ooomakinekoEntities123();
        }

        public void goCatalog()
        {
            Catalog catalog = new Catalog();
            this.Hide();
            catalog.ShowDialog();
            this.Show();
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {

                App.userName = "Гость";
                App.userStatus = "Гость";
                goCatalog();

        }

        private void buttonUser_Click(object sender, RoutedEventArgs e)
        {
            String check_login = textBoxLogin.Text;
            String check_password = textBlockPassword.Text;

            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(check_login) || String.IsNullOrEmpty(check_password))
            {
                sb.AppendLine("Неверный логин или пароль");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            //получение всех пользователей
            List<Model.user> users = new List<Model.user>();
            users = Helper.DBSport.user.ToList();

            Model.user user = Helper.DBSport.user.Where(u => u.userLogin == check_login && u.userPassword == check_password).FirstOrDefault();
            if (user != null)
            {

                    App.userName = user.userFullName;
                    App.userStatus = user.role.roleName;
                    goCatalog();

            }
            else
            {
                MessageBox.Show("Нет пользователей");
            }
        }

    }
}
