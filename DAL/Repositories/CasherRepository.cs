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
        public override IEnumerable<Casher> GetAll()
        {
            return Context.Cashers.Include(c => c.Department).Include(c => c.ApplicationUser);
        }
        public void ChangeCasherDepartment(int Casher, int Dept)
        {
            var casher = Context.Cashers.Find(Casher);
            var department = Context.Departments.Find(Dept);
            casher.Department = department;
        }

        public IEnumerable<Casher> GetActiveCashers(int count)
        {
            return Context.Cashers
                .Include(a => a.Department)
                .Include(a => a.Orders.Select(a => a.Id))
                .OrderByDescending(a=>a.Orders.Sum(x=>x.TotalPrice))
                .Take(count);
        }

        public IEnumerable<Casher> GetCasherAllData()
        {
            return Context.Cashers.Include(c => c.Orders).ThenInclude(o => o.OrderDetials).ThenInclude(ot => ot.Product)
                .Include(c => c.Orders).ThenInclude(o => o.Customer)
                .OrderBy(c => c.Name)
                .ToList();
        }

        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
