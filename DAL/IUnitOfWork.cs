using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork
    {
        ICasherRepository CasherRepository { get;}
        ICustomerRepository CustomerRepository { get;}
        IDepartmentRepository DepartmentRepository { get;}
        IOrderRepository OrderRepository { get;}
        IProductRepository ProductRepository { get;}
        bool SaveChanges();
    }
}
