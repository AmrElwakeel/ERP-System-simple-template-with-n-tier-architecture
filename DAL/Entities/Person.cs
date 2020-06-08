using DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Person :IPerson
    {
        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string Address { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
    }
}
