using Kurs2.sakila;
using Mysqlx;
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
    /// Логика взаимодействия для OplataZakaza.xaml
    /// </summary>
    public partial class OplataZakaza : Window
    {
        sakila.Пользователь пользователь;
        sakila.Корзина карзина;
        sakila.КорзинаHasТовар haskor;
        string a = null;
        public OplataZakaza(int? cena, sakila.Пользователь польз)
        {
            InitializeComponent();
            ItogPrice.Content = Convert.ToInt32(cena);
            пользователь = польз;
        }

        private void OplataNalik(object sender, RoutedEventArgs e)
        {
            kar1.Visibility = Visibility.Hidden;
            kar2.Visibility = Visibility.Hidden;
            kar3.Visibility = Visibility.Hidden;
            kar4.Visibility = Visibility.Hidden;
            kar5.Visibility = Visibility.Hidden;
            kar6.Visibility = Visibility.Hidden;

        }

        private void OplataKarta(object sender, RoutedEventArgs e)
        {
            kar1.Visibility = Visibility.Visible;
            kar2.Visibility=Visibility.Visible;
            kar3.Visibility=Visibility.Visible;
            kar4.Visibility=Visibility.Visible;
            kar5.Visibility=Visibility.Visible;
            kar6.Visibility=Visibility.Visible;
        }

        private void kar2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OplataZakaz(object sender, RoutedEventArgs e)
        {
            using (MagazContext mag= new MagazContext())
            {
                sakila.Товар товар = new Товар();
                List<sakila.КорзинаHasТовар> list2 = карзина.КорзинаHasТоварs.ToList();
                foreach (var item in list2)
                {
                    a = a + item.Название + " " + item.Колво + " шт" + "; ";
                    товар = item.ТоварIdТоварNavigation;
                    товар.Количество = товар.Количество - item.Колво;
                    mag.Update(товар);
                }
                sakila.Заказ заказ = new Заказ() { Адрес = Adres.Text, СпособОплаты = SposobOplati.Text, ОбщаяСтоимость = Convert.ToInt32(ItogPrice.Content), IdПользователя = пользователь.IdПользователь, Товары = a };
                mag.Add(заказ);
                List<sakila.КорзинаHasТовар> Ф = mag.КорзинаHasТоварs.Where(x => x.КорзинаIdКорзина == карзина.IdКорзина).ToList();
                foreach(var item in Ф)
				{
                    mag.Remove(item);
                }
                mag.SaveChanges();
                MessageBox.Show("Заказ успешно офомлен",null,MessageBoxButton.OK);
                KlientTov klientTov = new KlientTov(пользователь);
                klientTov.Name(пользователь);
                klientTov.Show();
                this.Close();
            }

        }
        public void GetUser(sakila.Пользователь поль)
        {
            пользователь = поль;
        }
        public void GetCorz(sakila.Корзина поль)
        {
            карзина = поль;
        }
        private void BackToKorz(object sender, RoutedEventArgs e)
        {
            Corzina cor= new Corzina(пользователь, карзина);
            cor.GetCorz(карзина);
            cor.GetUser(пользователь);
            cor.Show();
            this.Close();
        }
        public void GetHasKorz(sakila.КорзинаHasТовар корз)
        {
            haskor = корз;
        }

		private void ToTovarBtn(object sender, MouseButtonEventArgs e)
		{
            KlientTov klientTov = new KlientTov(пользователь);
            klientTov.Show();
            this.Close();
		}

		private void ToHistoryBtn(object sender, MouseButtonEventArgs e)
		{
            History history = new History(пользователь, карзина);
            history.Show();
            this.Close();
		}

		private void ToVixodBtn(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow= new MainWindow();
            mainWindow.Show();
            this.Close();
		}
	}
}
