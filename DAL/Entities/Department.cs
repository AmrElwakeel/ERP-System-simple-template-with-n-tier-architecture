using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Department:AuditableEntity
    {
        public Department()
        {
            this.Cashers = new List<Casher>();
        }

        public ICollection<Casher> Cashers { get; set; }
    }
}
