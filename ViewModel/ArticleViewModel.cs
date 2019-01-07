using BrainStorm.Models;
using System.Collections.Generic;


namespace BrainStorm.ViewModel
{
    public class ArticleViewModel
    {
        public List<Category> ArticleCategory { get; set; }

        public Article Article { get; set; }
    }
}