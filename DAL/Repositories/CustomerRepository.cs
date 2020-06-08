using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context):base(context)
        { }
        public IEnumerable<Customer> GetActiveCustomers()
        {
            throw new NotImplementedException();
        }
        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
