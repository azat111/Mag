using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditTov.xaml
    /// </summary>
    public partial class EditTov : Window
    {
        sakila.MagazContext magazContext=new sakila.MagazContext();
        sakila.Товар товар = new sakila.Товар();
        byte[] a = null;
        byte[] image_bytes;
        public EditTov()
        {
            InitializeComponent();
            EditTovar.ItemsSource=magazContext.Товарs.ToList();
        }
        private void GetTov(object sender, MouseButtonEventArgs e)
        {
            using (magazContext)
            {
                товар = (sakila.Товар)EditTovar.SelectedItem;
                TovName.Text = товар.Название;
                TovStoim.Text = товар.Стоимость.ToString();
                TovKat.Text = товар.Категория;
                TovKol.Text = товар.Количество.ToString();
                
                MemoryStream memorystream = new MemoryStream();
                memorystream.Write(товар.Фото, 0, (int)товар.Фото.Length);
                if (memorystream.Length != 0)
                {
                    memorystream.Seek(0, SeekOrigin.Begin);
                    BitmapImage imgsource = new BitmapImage();
                    imgsource.BeginInit();
                    imgsource.StreamSource = memorystream;
                    imgsource.EndInit();
                    TovPhoto.Source = imgsource;
                    a = товар.Фото;
                }
                
                //TovPhoto.Source = imgsource;
                
            }
        }

        private void TovDelBtn(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext ma = new sakila.MagazContext())
            {
                ma.Remove(товар);
                ma.SaveChanges();
                EditTovar.ItemsSource = ma.Товарs.ToList();
                TovName.Text = "";
                TovStoim.Text = "";
                TovKat.Text = "";
                TovKol.Text = "";
                TovPhoto.Source = null;
            }
        }

        private void AddTovBtn(object sender, RoutedEventArgs e)
        { 
            using (sakila.MagazContext contexta = new sakila.MagazContext())
            {
                sakila.Товар товар = new sakila.Товар() { Название = TovName.Text, Стоимость = Convert.ToInt32(TovStoim.Text), Категория = TovKat.Text, Количество = Convert.ToInt32(TovKol.Text), Фото = a };
                contexta.Add(товар);
                contexta.SaveChanges();
                EditTovar.ItemsSource = contexta.Товарs.ToList();
            }
        }

        private void TovPhotoBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.jpg)|*.jpg|(*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                a = File.ReadAllBytes(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                ms.Write(a, 0, (int)a.Length);
                ms.Seek(0, SeekOrigin.Begin);
                BitmapImage imgsource = new BitmapImage();
                imgsource.BeginInit();
                imgsource.StreamSource = ms;
                imgsource.EndInit();
                TovPhoto.Source = imgsource;
            }

        }

        private void EditTovBtn(object sender, RoutedEventArgs e)
        {
            using (sakila.MagazContext m = new sakila.MagazContext())
            {
                var good = m.Товарs.FirstOrDefault(x => x.IdТовар == товар.IdТовар);
                if (good == null)
                    return;


                good.Название = TovName.Text;
                good.Стоимость = Convert.ToInt32(TovStoim.Text);
                good.Категория = TovKat.Text;
                good.Количество = Convert.ToInt32(TovKol.Text);
                good.Фото = a;
                m.SaveChanges();
                EditTovar.ItemsSource = m.Товарs.ToList();
            }
        }

        private void ChekZakaziBtn(object sender, MouseButtonEventArgs e)
        {
            Zakazi zakazi=new Zakazi();
            zakazi.Show();
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
