using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Interfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
