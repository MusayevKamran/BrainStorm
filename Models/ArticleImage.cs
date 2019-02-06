using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models
{
    public class ArticleImages
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
