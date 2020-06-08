using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class OrderRepository:Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context):base(context)
        { }
    }
}
