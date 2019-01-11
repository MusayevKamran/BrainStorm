using BrainStorm.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Services
{
    public interface IUnitService : IDisposable
    {
        IArticle Article { get; }
        ICategory Category { get; }

        int SaveChanges();
    }
}
