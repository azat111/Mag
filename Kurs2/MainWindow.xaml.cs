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

namespace Kurs2
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

       

        private void VxodBtn(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext context = new sakila.MagazContext())
            {

                foreach(var item in context.Пользовательs)
                {
                    if(item.Логин==Login.Text && item.Пароль==Password.Text && item.Роль=="Клиент")
                    {
                        KlientTov klientTov=new KlientTov(item);
                        klientTov.Name(item);
                        klientTov.Show();
                        this.Close();
                        
                    }
                    else if (item.Логин == Login.Text && item.Пароль == Password.Text && item.Роль == "Администратор")
                    {
                        EditUsers editUsers = new EditUsers();
                        editUsers.Show();
                        this.Close();
                    }
                    else if (item.Логин == Login.Text && item.Пароль == Password.Text && item.Роль == "Менеджер")
                    {
                        EditTov editTov = new EditTov();
                        editTov.Show();
                        this.Close();
                    }
                }
            }
        }

        private void RegBtn(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
