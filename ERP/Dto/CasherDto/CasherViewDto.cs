using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto.CasherDto
{
    public class CasherViewDto
    {
        public int Id { get; set; }
        public string FrindlyName { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Salary { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Delete { get; set; }
    }
}
