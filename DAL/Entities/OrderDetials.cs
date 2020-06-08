using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class OrderDetials
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public int Order_Id { get; set; }
        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
    }
}
