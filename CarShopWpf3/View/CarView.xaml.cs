using CarShopWpf3.Model;
using CarShopWpf3.ViewModel;
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

namespace CarShopWpf3.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Car selectedCar = new Car();


        public Window1()
        {

            InitializeComponent();
            DataContext = new CarViewModel();

            //selectCarGrid.DataContext = selectedCar;

        }

        private void NewCarButton_Click(object sender, RoutedEventArgs e)
        {
            // Deschideți secțiunea pentru mașini
            NewCar ncarView = new NewCar();
            ncarView.ShowDialog();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
               CarViewModel removeCar = new CarViewModel();

            Button button = (Button)sender;
            if (button.Tag is int carId)
            {
                removeCar.DeleteCar(carId);
            }
        }
    }
}
