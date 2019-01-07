using BrainStorm.Models;
using System.Collections.Generic;


namespace BrainStorm.ViewModel
{
    public class ArticlesViewModel
    {
        public IList<Category> ArticleCategory { get; set; }

        public Article Article { get; set; }
    }
}