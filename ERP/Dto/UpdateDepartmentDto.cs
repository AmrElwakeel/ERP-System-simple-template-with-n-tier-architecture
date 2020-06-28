using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto
{
    public class UpdateDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
