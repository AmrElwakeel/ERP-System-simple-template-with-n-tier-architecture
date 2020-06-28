using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class ProductRepository:Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context):base(context)
        { }

        ApplicationDbContext Context => (ApplicationDbContext)_context;
    }
}
