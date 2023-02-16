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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void RegesBtn(object sender, RoutedEventArgs e)
        {
            using(sakila.MagazContext context = new sakila.MagazContext())
            {
                sakila.Пользователь пользователь = new sakila.Пользователь() { Логин=RegLog.Text, Пароль=RegPas.Text, Роль="Клиент" };
                context.Add(пользователь);
                context.SaveChanges();
                MessageBox.Show("Успешно");
                MainWindow mainWindow=new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void BackBtn(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
