using System.Collections.Generic;

namespace SIGRE.Data.Interfaces
{
    public interface ICustomerDataRepository
    {
        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAllCustomers();

        /// <summary>
        /// Gets the customer by id.
        /// </summary>
        /// <param name="idCustomer">The id customer.</param>
        /// <returns></returns>
        Customer GetCustomerById(string idCustomer);

        /// <summary>
        /// Saves the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void SaveCustomer(Customer customer);
    }
}
