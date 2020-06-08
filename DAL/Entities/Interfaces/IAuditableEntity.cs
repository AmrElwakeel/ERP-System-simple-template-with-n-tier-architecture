using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities.Interfaces
{
    public interface IAuditableEntity
    {
        public int Id { get; set; }
        string CreateBy { get; set; }
        DateTime CreateDate { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        bool? Delete {get;set;}

    }   
}
