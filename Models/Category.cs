using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Row { get; set; }

        public int Count { get; set; }

        //public bool isNew { get; set; }

        public List<ArticleCategory> ArticleCategory { get; set; } 
    }
}