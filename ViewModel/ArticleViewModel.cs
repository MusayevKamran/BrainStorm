using BrainStorm.Models;
using System.Collections.Generic;


namespace BrainStorm.ViewModel
{
    public class ArticleViewModel
    {
        public List<Category> Category { get; set; }

        public Article Article { get; set; }
    }
}