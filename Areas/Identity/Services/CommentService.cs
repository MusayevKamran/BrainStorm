using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models;
using BrainStorm.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public class CommentService : GenericService<Comment>, IComment
    {
        public CommentService(BrainStormDbContext context) : base(context)
        { }

        public BrainStormDbContext context
        {
            get { return _context as BrainStormDbContext; }
        }
    }
}
