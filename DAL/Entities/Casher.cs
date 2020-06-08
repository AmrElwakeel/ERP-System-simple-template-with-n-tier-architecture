using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL.Entities
{
    public class Casher:Person
    {

        [Key]
        public int Id { get; set; }
        public DateTime HiredDate { get; set; }
        public decimal Salary { get; set; }
        public int Dept_Id { get; set; }
        [ForeignKey("Dept_Id")]
        public Department Department { get; set; }
        public string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
