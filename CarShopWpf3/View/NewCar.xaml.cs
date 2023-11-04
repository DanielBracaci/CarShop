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
    /// Interaction logic for NewCar.xaml
    /// </summary>
    public partial class NewCar : Window
    {
        Car newCar1 = new Car();

        public NewCar()
        {
            InitializeComponent();
            AddNewCarGrid.DataContext = newCar1;

        }


        private void AddCarCommand(object sender, RoutedEventArgs e)
        {


            NewCarViewModel newCar = new NewCarViewModel();
            newCar.AddCar(newCar1);
        }
        
    }
}
