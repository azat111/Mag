using Kurs2.sakila;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Corzina.xaml
    /// </summary>
    public partial class Corzina : Window
    {
        sakila.MagazContext magazContext = new sakila.MagazContext();
        sakila.Товар тов = new sakila.Товар();
        sakila.Корзина корзина = new sakila.Корзина();
        sakila.Пользователь пользователь;
        sakila.КорзинаHasТовар haskor;
        int? TotalPrice = 0;
        int? TotalKolvo = 0;
        public Corzina(sakila.Пользователь польз,sakila.Корзина корз)
        {
            InitializeComponent();
            пользователь = польз;
            корзина = корз;
        }

        private void TovariBtn(object sender, MouseButtonEventArgs e)
        {
            KlientTov klientTov = new KlientTov(пользователь);
            klientTov.SetUser(this.пользователь);
            klientTov.Name(пользователь);
            klientTov.Show();
            this.Close();
        }
        
        //public void DAG()
        //{
        //    KlientTov klientTov = new KlientTov();
        //    this.пользователь = klientTov.GetCurrentUser();

        //    if (пользователь == null)
        //        return;
        //    this.Close();
        //    ListTovCorzina.ItemsSource = magazContext.Корзинаs.Where(d => d.IdПользователь == пользователь.IdПользователь).ToList();
        //}
        private void TovInCorz(object sender, MouseButtonEventArgs e)
        {
            using (sakila.MagazContext MC = new sakila.MagazContext())
            {
                //корзина = (sakila.Корзина)ListTovCorzina.SelectedItem;
                //корзина.Товарs.GetEnumerator();
                //MC.Update(корзина);
                //MC.SaveChanges();
                //ListTovCorzina.ItemsSource = MC.Корзинаs.Where(d => d.IdПользователь == пользователь.IdПользователь).ToList();


            }
        }

        public void Tovar(sakila.Товар Товар)
        {
            тов = Товар;
        }
        public void GetUser(sakila.Пользователь поль)
        {
            пользователь = поль;
        }
        
        public void GetCorz(sakila.Корзина корз)
        {
            корзина = корз;
            LoadInfo();
            UpdateInfo();
        }

        public void LoadInfo()
		{
            ListTovCorzina.ItemsSource = корзина.КорзинаHasТоварs.ToList();
        }
        public void UpdateInfo()
        {
            TotalPrice = 0;
            TotalKolvo = 0;
            foreach (var item in ListTovCorzina.Items)
            {
                haskor = (sakila.КорзинаHasТовар)item;
                if (haskor.ИтогЦена != null)
                {
                    TotalPrice = TotalPrice + haskor.ИтогЦена;
                    TotalKolvo = TotalKolvo + haskor.Колво;
                }
            }
            ItogPrice.Content = TotalPrice.ToString();
            TotalTov.Content = TotalKolvo.ToString();
        }

        private void PlusKolvo(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext MCA = new sakila.MagazContext())
            {
                haskor = (sakila.КорзинаHasТовар)ListTovCorzina.SelectedItem;
                int a = (int)(haskor.ИтогЦена / haskor.Колво);
                haskor.Колво++;
                haskor.ИтогЦена = haskor.ИтогЦена + a;
                MCA.Update(корзина);
                MCA.SaveChanges();
                ListTovCorzina.ItemsSource = корзина.КорзинаHasТоварs.ToList();
                UpdateInfo();
            }
        }

        private void MinusKolvo(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext MCA = new sakila.MagazContext())
            {
                haskor = (sakila.КорзинаHasТовар)ListTovCorzina.SelectedItem;
                int a = (int)(haskor.ИтогЦена / haskor.Колво);
                haskor.Колво--;
                haskor.ИтогЦена = haskor.ИтогЦена - a;
                if(haskor.Колво==0)
                {
                    MCA.Remove(haskor);
                    MCA.SaveChanges();
                    ListTovCorzina.ItemsSource = корзина.КорзинаHasТоварs.ToList();
                    UpdateInfo();
                    return;
                }
                MCA.Update(корзина);
                MCA.SaveChanges();
                ListTovCorzina.ItemsSource = корзина.КорзинаHasТоварs.ToList();
                UpdateInfo();
            }
        }


        private void OformlenieBtn(object sender, RoutedEventArgs e)
        {
            OplataZakaza oplata=new OplataZakaza(TotalPrice,пользователь);
            oplata.GetHasKorz(haskor);
            oplata.Show();
            oplata.GetUser(пользователь);
            oplata.GetCorz(корзина);
            this.Close();
        }

		private void DelTovar(object sender, RoutedEventArgs e)
		{
            using (sakila.MagazContext MCAA = new sakila.MagazContext())
            {
                haskor = (sakila.КорзинаHasТовар)ListTovCorzina.SelectedItem;
                MCAA.Remove(haskor);
                MCAA.SaveChanges();
                ListTovCorzina.ItemsSource = корзина.КорзинаHasТоварs.ToList();
                UpdateInfo();
            }
        }

		private void ToHistoryBtn(object sender, MouseButtonEventArgs e)
		{
            History history = new History(пользователь, корзина);
            history.Show();
            this.Close();
		}

		private void ToVihodBtn(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow=new MainWindow();
            mainWindow.Show();
            this.Close();
		}
	}
}
