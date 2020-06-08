using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FriendlyName { get {
                if ((int)this.Gender == 2)
                    return $"Ms.{this.UserName}";
                return $"Mr.{this.UserName}";
            }
        }
        public Gender Gender { get; set; }
        public virtual Casher Casher { get; set; }
    }
    public enum Gender
    {
        None,
        Male,
        Female
    }
}
