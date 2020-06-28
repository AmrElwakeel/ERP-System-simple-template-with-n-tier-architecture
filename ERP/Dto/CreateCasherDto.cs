using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto
{
    public class CreateCasherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HiredDate { get; set; }
    }
}
