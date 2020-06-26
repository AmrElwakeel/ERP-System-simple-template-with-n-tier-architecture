using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class CasherRepository : Repository<Casher>, ICasherRepository
    {
        public CasherRepository(ApplicationDbContext context) : base(context)
        { }
        public void ChangeCasherDepartment(int Casher, int Dept)
        {
            var casher = Context.Cashers.Find(Casher);
            var department = Context.Departments.Find(Dept);
            casher.Department = department;
        }

        public IEnumerable<Casher> GetActiveCashers(int count)
        {
            return Context.Cashers.Include(a => a.Orders.Count())
                .OrderByDescending(a => a.Orders.Count()).Take(count);
        }

        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
