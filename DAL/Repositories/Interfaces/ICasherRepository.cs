using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface ICasherRepository:IRepository<Casher>
    {
        IEnumerable<Casher> GetActiveCashers(int count);
        IEnumerable<Casher> GetCasherAllData();
        void ChangeCasherDepartment(int Casher,int Dept);
    }
}
