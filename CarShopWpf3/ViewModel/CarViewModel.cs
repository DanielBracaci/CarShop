using CarShopWpf3.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarShopWpf3.ViewModel
{
    public class CarViewModel : ViewModelBase
    {
        private Car selectedCar;

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;

            }
        }

        public DelegateCommand<Car> AddCarCommand { get; }


        public CarViewModel()
        {
            AddCarCommand = new DelegateCommand<Car>(AddCar);
            using (var context = new MyDbContext())
            {
                Cars = new ObservableCollection<Car>(context.Cars.ToList());
            }
        }

        public void AddCar(Car car)
        {
            using (var context = new MyDbContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
                Cars.Add(car);
            }
        }

        public void UpdateCar()
        {
            using (var context = new MyDbContext())
            {
                context.Entry(selectedCar).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCar(int carId)
        {
            var carToDelete = Cars.FirstOrDefault(car => car.Id == carId);

            if (carToDelete != null)
            {
                using (var context = new MyDbContext())
                {
                    var existingCar = context.Cars.Find(carId);
                    if (existingCar != null)
                    {
                        context.Cars.Remove(existingCar);
                        context.SaveChanges();
                    }
                }

                Cars.Remove(carToDelete);

            }
        }



        private void RefreshDataGrid()
        {


            carDataGrid.ItemsSource = null; // Dezactivează temporar sursa de date
            carDataGrid.ItemsSource = myModel.Cars; // Actualizează sursa de date
        }

    }
}
