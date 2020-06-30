using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Dto.CasherDto
{
    public class ActiveCashersDto
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int OrdersCount { get; set; }
    }
}
