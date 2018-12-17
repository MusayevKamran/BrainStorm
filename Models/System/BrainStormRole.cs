using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models.System
{
    public class BrainStormRole : IdentityRole<Guid>
    {
        public BrainStormRole() : base() { }
        public BrainStormRole(string roleName) : base() { }
        public BrainStormRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            Description = description;
            CreationDate = creationDate;
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
