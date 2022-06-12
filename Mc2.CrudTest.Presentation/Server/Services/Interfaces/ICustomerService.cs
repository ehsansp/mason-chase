using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Mc2.CrudTest.Presentation.Server.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<bool> CustomerExists(int id);
        IEnumerable<Customer> GetAll();
        Task<int> CountCustomer();
        Task<Customer> Update(Customer customer);
        Task<Customer> Remove(int id);
        bool IsExistUserName(string firstName,string lastName,DateTime birthDate);
    }
}
