using CarShopWpf3.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShopWpf3
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

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            // Deschideți secțiunea pentru clienți
            ClientView clientView = new ClientView();
            clientView.ShowDialog();
        }

        private void CarButton_Click(object sender, RoutedEventArgs e)
        {
            // Deschideți secțiunea pentru mașini
            Window1 carView = new Window1();
            carView.ShowDialog();
        }
    }
}
