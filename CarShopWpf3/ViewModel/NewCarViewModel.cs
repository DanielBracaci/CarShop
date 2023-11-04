using CarShopWpf3.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CarShopWpf3.ViewModel
{
    public class NewCarViewModel
    {
        public DelegateCommand<Car> AddCarCommand { get; }
        private ObservableCollection<Car> Cars; // Asigurați-vă că aveți o colecție pentru mașini

        public NewCarViewModel()
        {
            AddCarCommand = new DelegateCommand<Car>(AddCar);
            Cars = new ObservableCollection<Car>(); // Inițializați colecția mașinilor (sau utilizați-o dacă ați creat-o deja)
        }

        public void AddCar(Car car)
        {
            using (var context = new MyDbContext())
            {
                car.ClientId = 1;  // valoarea predefinita pana la o logica mai complexa
                context.Cars.Add(car);
                context.SaveChanges();
                Cars.Add(car); // Adăugați mașina la colecția locală
            }
        }
    }
}
