using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Customer : Person
    {

        [Key]
        public int Id { get; set; }
        public decimal TotalTransactionsAmount { get; set; }
        public DateTime LastAttendDate { get; set; }
        [StringLength(14)]
        public int CridetCardNum { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
