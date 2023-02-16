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
    /// Логика взаимодействия для Zakazi.xaml
    /// </summary>
    public partial class Zakazi : Window
    {
        MagazContext magazContext= new MagazContext();
        public Zakazi()
        {
            InitializeComponent();
            DataGridZakaz.ItemsSource = magazContext.Заказs.ToList();

        }

		private void ToTovariBtn(object sender, MouseButtonEventArgs e)
		{
            EditTov editTov= new EditTov();
            editTov.Show();
            this.Close();
		}

		private void ToVihodBnt(object sender, MouseButtonEventArgs e)
		{
            MainWindow mainWindow=new MainWindow();
            mainWindow.Show();
            this.Close();
		}
	}
}
