
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
    /// Логика взаимодействия для KlientTov.xaml
    /// </summary>
    public partial class KlientTov : Window
    {
         sakila.Пользователь пользователь;
        List<sakila.Товар> aa = new List<sakila.Товар>();
        string name;
        int idd;
        sakila.MagazContext magazContext=new sakila.MagazContext();
        ICollection<Товар> aaa;
        ICollection<Корзина> aaaa;
        sakila.Товар товар=new sakila.Товар();
        sakila.Корзина корзина = new sakila.Корзина();
        
        sakila.Корзина alice;
        sakila.Корзина alice2;
        sakila.КорзинаHasТовар A = new sakila.КорзинаHasТовар();

        public KlientTov(sakila.Пользователь пользовательф)
        {
            InitializeComponent();
            ListTov.ItemsSource = magazContext.Товарs.ToList();
            пользователь = пользовательф;
        }
        public void Name(sakila.Пользователь user)
        {
            пользователь=user;
            name= пользователь.Логин;
            LogL.Content = LogL.Content + name;
        }


        private void AddTobBtn(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext magazContext = new sakila.MagazContext())
            {
                try
                {
                    alice = magazContext.Корзинаs.Where(x => x.IdПользователь == пользователь.IdПользователь).FirstOrDefault();
                    if (alice == null)
                    {
                        корзина.IdПользователь = пользователь.IdПользователь;
                        
                        magazContext.Add(корзина);
                        magazContext.SaveChanges();
                    }
                    alice = magazContext.Корзинаs.Where(x => x.IdПользователь == пользователь.IdПользователь).FirstOrDefault();
                    //var a = magazContext.Корзинаs.Include(x => x.ТоварIdТоварs).FirstOrDefault(x => x.IdКорзина == alice.IdКорзина);
                    товар = (sakila.Товар)(sender as Button).DataContext;
                    //sakila.Товар basics = magazContext.Товарs.FirstOrDefault(c => c.Название == товар.Название);
                    A.КорзинаIdКорзина = alice.IdКорзина;
                    A.ТоварIdТовар = товар.IdТовар;
                    A.Колво = 1;
                    A.ИтогЦена = товар.Стоимость;
                    alice.КорзинаHasТоварs.Add(A);
                    magazContext.SaveChanges();
                    MessageBox.Show("Товар добавлен в корзину");
                }
                catch
                {
                    MessageBox.Show("Такой товар уже есть в корзине");
                }
            }
        }

        public void CorzinaBtn(object sender, MouseButtonEventArgs e)
        {
            Corzina corzina=new Corzina(пользователь, alice2);
            try
            {
                using (sakila.MagazContext magazContextt = new sakila.MagazContext())
                {
                    alice = magazContextt.Корзинаs.Where(x => x.IdПользователь == пользователь.IdПользователь).FirstOrDefault();
                    alice2 = magazContext.Корзинаs.Include(x => x.КорзинаHasТоварs).FirstOrDefault(x => x.IdКорзина == alice.IdКорзина);
                }
                corzina.Tovar(товар);
                corzina.GetUser(пользователь);
                corzina.GetCorz(alice2);
                corzina.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Сначала добавьте что-нибудь в корзину");
            }
        }
        public void SetUser(sakila.Пользователь юзер)
        {
            пользователь = юзер;
        }
        public sakila.Пользователь GetCurrentUser()
        {
            return пользователь;
        }

        private void Caterory3(object sender, RoutedEventArgs e)
        {
            ListTov.ItemsSource = magazContext.Товарs.Where(x => x.Категория == "Жидкие игрушки").ToList();
        }

        private void Caterory1(object sender, RoutedEventArgs e)
        {
            ListTov.ItemsSource = magazContext.Товарs.Where(x => x.Категория == "Мягкие игрушки").ToList();
        }

        private void Caterory2(object sender, RoutedEventArgs e)
        {
            ListTov.ItemsSource = magazContext.Товарs.Where(x => x.Категория == "Твердые игрушки").ToList();
        }

        private void Caterory4(object sender, RoutedEventArgs e)
        {
            ListTov.ItemsSource = magazContext.Товарs.ToList();
        }

        private void ToHistoryBtn(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (sakila.MagazContext magazContextt = new sakila.MagazContext())
                {
                    alice = magazContextt.Корзинаs.Where(x => x.IdПользователь == пользователь.IdПользователь).FirstOrDefault();
                    alice2 = magazContext.Корзинаs.Include(x => x.КорзинаHasТоварs).FirstOrDefault(x => x.IdКорзина == alice.IdКорзина);
                }
                History history = new History(пользователь, alice2);
                history.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("История пуста");
            }
        }

		private void VixodBtn(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
		}
	}
}
