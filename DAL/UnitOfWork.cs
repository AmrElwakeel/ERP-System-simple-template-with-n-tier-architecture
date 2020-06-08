using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        ICasherRepository _casher;
        ICustomerRepository _customer;
        IDepartmentRepository _department;
        IOrderRepository _order;
        IProductRepository _product;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICasherRepository CasherRepository 
        {
            get
            {
                if (_casher == null)
                    _casher = new CasherRepository(_context);
                return _casher;
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_context);
                return _customer;
            }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get
            {
                if (_department == null)
                    _department = new DepartmentRepository(_context);
                return _department;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(_context);
                return _order;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(_context);
                return _product;
            }
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 1);
        }
    }
}
