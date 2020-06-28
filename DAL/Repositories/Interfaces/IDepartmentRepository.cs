using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        public IEnumerable<Casher> GetCashersInDept(int Dept);
        public void RemoveCasherInDept(int Dept,int Casher);
        public void AddCasherInDept(int Dept,int Casher);
    }
}
