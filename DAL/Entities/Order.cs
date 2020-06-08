using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Order:AuditableEntity
    {
        public decimal TotalPrice { get; set; }
        public decimal Discount { get; set; }
        public int Casher_Id { get; set; }
        [ForeignKey("Casher_Id")]
        public Casher Casher { get; set; }
        public int Customer_Id { get; set; }
        [ForeignKey("Customer_Id")]
        public Customer Customer { get; set; }
        public ICollection<OrderDetials> OrderDetials { get; set; }
    }
}
