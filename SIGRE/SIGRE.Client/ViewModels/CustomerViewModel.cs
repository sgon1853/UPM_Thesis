using System;
using System.Collections.Generic;
using System.Windows;
using SIGRE.Client.Commands;
using SIGRE.Data;
using SIGRE.Data.Interfaces;

namespace SIGRE.Client.ViewModels
{
    internal class CustomerViewModel : ViewModelBase
    {
        private IEnumerable<Customer> customers;
        private readonly ICustomerDataRepository customerDataRepository;
        private string idCustomer, name, lastName, address, city, postalCode, phoneNumber;

        public  CustomerViewModel(ICustomerDataRepository customerDataRepository)
        {
            this.customerDataRepository = customerDataRepository;
            Customers = customerDataRepository.GetAllCustomers();
        }

        public RelayCommand SaveCustomerCommand
        {
            get
            {
                return  new RelayCommand((o)=>
                {
                                                 try
                                                 {
                                                     if (this.ArefieldsValid())
                                                     {
                                                         customerDataRepository.SaveCustomer(new Customer()
                                                                                                 {
                                                                                                     IdCustomer = IdCustomer,
                                                                                                     Name = Name,
                                                                                                     LastName = LastName,
                                                                                                     Address = Address,
                                                                                                     City = city,
                                                                                                     PhoneNumber = PhoneNumber,
                                                                                                     PostalCode = PostalCode
                                                                                                 });
                                                         Customers = customerDataRepository.GetAllCustomers();
                                                     }
                                                     else
                                                     {
                                                         MessageBox.Show("Todos los campos deben rellenarse!");
                                                     }
                                                 }
                                                 catch (Exception exception)
                                                 {
                                                     MessageBox.Show(exception.Message);
                                                 }
                });
            }
        }

        public string IdCustomer { get { return idCustomer; } set { idCustomer = value; OnPropertyChanged("IdCustomer"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string LastName { get { return lastName; } set { lastName = value; OnPropertyChanged("LastName"); } }
        public string Address { get { return address; } set { address = value; OnPropertyChanged("Address"); } }
        public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }
        public string PostalCode { get { return postalCode; } set { postalCode = value; OnPropertyChanged("PostalCode"); } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); } }

        protected override bool ArefieldsValid()
        {
            var fieldsValid = true;
            if (string.IsNullOrEmpty(IdCustomer) ||
                string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Address) ||
                string.IsNullOrEmpty(City) ||
                string.IsNullOrEmpty(PhoneNumber) ||
                string.IsNullOrEmpty(PostalCode))
            {
                fieldsValid = false;
            }

            return fieldsValid;
        }

        public IEnumerable<Customer> Customers { get { return customers; } set { customers = value; OnPropertyChanged("Customers"); } }
    }
}
