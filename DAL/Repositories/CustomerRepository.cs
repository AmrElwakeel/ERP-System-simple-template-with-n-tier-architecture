using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        { }
        public IEnumerable<Customer> GetActiveCustomers()
        {
            return Context.Customers.Include(a => a.Orders.Select(o => o.TotalPrice).Count()).
              OrderBy(a => a.Orders.Select(o => o.TotalPrice).Count()).Take(10).ToList();
        }
        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
