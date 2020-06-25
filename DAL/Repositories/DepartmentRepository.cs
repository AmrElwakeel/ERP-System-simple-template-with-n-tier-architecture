using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context):base(context)
        { }

        public IEnumerable<Casher> GetCashersInDept(int Dept)
        {
            return GetSingleOrDefault(a => a.Id == Dept).Cashers;
        }
        public void AddCasherInDept(int Dept, int Casher)
        {
            FindById(Dept).Cashers.Add(Context.Cashers.Find(Casher));
        }
        public void RemoveCasherInDept(int Dept,int Casher)
        {
            FindById(Dept).Cashers.Remove(Context.Cashers.Find(Casher));
        }

        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
