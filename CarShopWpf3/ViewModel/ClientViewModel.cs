using CarShopWpf3.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWpf3.ViewModel
{
    public class ClientViewModel : ViewModelBase
    {
        private Client selectedClient;

        public ObservableCollection<Client> Clients { get; set; }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;

            }
        }

        public ClientViewModel()
        {
            using (var context = new MyDbContext())
            {
                Clients = new ObservableCollection<Client>(context.Clients.ToList());
            }
        }

        public void AddClient(Client client)
        {
            using (var context = new MyDbContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
                Clients.Add(client);
            }
        }

        public void UpdateClient()
        {
            using (var context = new MyDbContext())
            {
                context.Entry(selectedClient).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteClient()
        {
            if (selectedClient != null)
            {
                using (var context = new MyDbContext())
                {
                    context.Clients.Remove(selectedClient);
                    context.SaveChanges();
                    Clients.Remove(selectedClient);
                }
            }
        }
    }
}
