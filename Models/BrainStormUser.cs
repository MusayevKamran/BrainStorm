using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models
{
    public class BrainStormUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string AvatarImage { get; set; }

        public string URL { get; set; }
        
        public string Education { get; set; }

        public string Job { get; set; }

        public string About { get; set; }

        public string Quote { get; set; }

        public int Like { get; set; }

        public int View { get; set; }

        public UserStatus UserStatus { get; set; }

        public virtual ICollection<Article> Article { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
    }
}
