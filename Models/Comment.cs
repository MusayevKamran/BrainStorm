using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public Article Article { get; set; }

        public BrainStormUser BrainStormUser { get; set; }

    }
}
