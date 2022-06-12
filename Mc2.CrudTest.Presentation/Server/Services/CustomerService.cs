using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Models;
using Mc2.CrudTest.Presentation.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    public class CustomerService: ICustomerService
    {
        private Context _context;

        public CustomerService(Context context)
        {
            _context = context;
        }


        public async Task<Customer> GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        [HttpPost]
        public async Task<Customer> AddCustomer(Customer customer)
        {
            

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CustomerExists(int id)
        {
            return await _context.Customers.AnyAsync(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public async Task<int> CountCustomer()
        {
            return await _context.Customers.CountAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _context.Customers.SingleAsync(c => c.Id == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public bool IsExistUserName(string firstName, string lastName, DateTime birthDate)
        {
            return _context.Customers.Any(c =>
                c.FirstName == firstName && c.LastName == lastName && c.DateOfBirth == birthDate);
        }
    }
}
