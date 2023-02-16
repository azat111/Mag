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

namespace Kurs2
{
    /// <summary>
    /// Логика взаимодействия для EditUsers.xaml
    /// </summary>
    public partial class EditUsers : Window
    {
        sakila.MagazContext magazContext=new sakila.MagazContext();
        sakila.Пользователь пользователь = new sakila.Пользователь();
        public EditUsers()
        {
            InitializeComponent();
            ListUser.ItemsSource=magazContext.Пользовательs.ToList();
        }

        private void ListUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using(magazContext)
            {
                пользователь = (sakila.Пользователь)ListUser.SelectedItem;
                TLogin.Text = пользователь.Логин;
                TRole.Text = пользователь.Роль;
                TPass.Text = пользователь.Пароль;
                
            }                 
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext m = new sakila.MagazContext())
            {
                пользователь.Логин = TLogin.Text;
                пользователь.Роль = TRole.Text;
                пользователь.Пароль = TPass.Text;
                m.Update(пользователь);
                m.SaveChanges();
                ListUser.ItemsSource = m.Пользовательs.ToList();
            }
            
        }

        private void DelUser(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext ma = new sakila.MagazContext())
            {               
                ma.Remove(пользователь);
                ma.SaveChanges();
                ListUser.ItemsSource = ma.Пользовательs.ToList();
                TLogin.Text="";
                TRole.Text = "";
                TPass.Text = "";
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext contexta = new sakila.MagazContext())
            {
                sakila.Пользователь пользователь = new sakila.Пользователь() { Логин = TLogin.Text, Пароль = TPass.Text, Роль = TRole.Text };
                contexta.Add(пользователь);
                contexta.SaveChanges();
                ListUser.ItemsSource = contexta.Пользовательs.ToList();
            }
        }

		private void ToVihodBtn(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow= new MainWindow();
            mainWindow.Show();
            this.Close();
		}

		private void ToTovari(object sender, MouseButtonEventArgs e)
		{
            EditTovAdm editTov=new EditTovAdm();
            editTov.Show();
            this.Close();
		}
	}
}
