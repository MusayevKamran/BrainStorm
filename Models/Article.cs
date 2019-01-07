using BrainStorm.Models.System;
using System;
using System.Collections.Generic;

namespace BrainStorm.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string URL { get; set; }

        public int Row { get; set; }

        public string Content { get; set; }

        public string Picture { get; set; }

        public string Like { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<ArticleCategory> ArticleCategory { get; set; } 

        public PostCategory PostCategory { get; set; }

        public ICollection<Comment> Comment { get; set; }

        public virtual BrainStormUser BrainStormUser { get; set; }
    }
}
