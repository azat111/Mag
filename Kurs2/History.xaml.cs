using Kurs2.sakila;
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
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        MagazContext magazContext=new MagazContext();
        sakila.Пользователь user;
        sakila.Корзина корзина;
        public History(sakila.Пользователь пользователь, sakila.Корзина корз)
        {
            InitializeComponent();
            user = пользователь;
            DataGridZakaz.ItemsSource=magazContext.Заказs.Where(x=>x.IdПользователя== user.IdПользователь).ToList();
            корзина = корз;
        }

		private void ToTovariBtn(object sender, MouseButtonEventArgs e)
		{
            KlientTov klientTov = new KlientTov(user);
            klientTov.Name(user);
            klientTov.Show();
            this.Close();
		}

		private void ToKorzBtn(object sender, MouseButtonEventArgs e)
		{
            Corzina corzina =new Corzina(user,корзина);
            corzina.GetCorz(корзина);
            corzina.Show();
            this.Close();
		}

		private void ToVihodBtn(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
		}
	}
}
