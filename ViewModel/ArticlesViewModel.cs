using BrainStorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.ViewModel
{
    public class ArticlesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Row { get; set; }

        public List<Category> Category { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public PostCategory PostCategory { get; set; }
    }
}
