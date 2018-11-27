using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Models.Interface
{
    interface IComment
    {
        void CreateComment();

        Comment GetCommentById();

        IList<Comment> GetAllComments();

        Comment UpdateComment(string id);

        void DeletCommonet(string id);
    }
}
