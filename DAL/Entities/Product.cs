using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product:AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool Active { get; set; }
        public ICollection<OrderDetials>  OrderDetials { get; set; }
    }
}
