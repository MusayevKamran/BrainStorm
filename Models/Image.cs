using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string ImageLink { get; set; }

        public ArticleImages ArticleImages { get; set; }
    }
}
