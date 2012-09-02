using System.Collections.Generic;
using System.Linq;
using SIGRE.Data.Interfaces;

namespace SIGRE.Data.DataRepository
{
    public class CustomerDataRepository: BaseDataRepository, ICustomerDataRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = from c in DataContext.Customers
                            select c;

            return customers;
        }

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="idCustomer">The id customer.</param>
        /// <returns></returns>
        public Customer GetCustomerById(string idCustomer)
        {
            var customer = (from c in DataContext.Customers
                            where c.IdCustomer.Equals(idCustomer)
                            select c).SingleOrDefault();
            return customer;
        }

        /// <summary>
        /// Saves the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        public void SaveCustomer(Customer customer)
        {
            DataContext.Customers.InsertOnSubmit(customer);
            DataContext.SubmitChanges();
        }
    }
}
