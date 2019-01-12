using BrainStorm.Models.Interface;
using System;


namespace BrainStorm.Models.Interface
{
    public interface IUnitService : IDisposable
    {
        IArticle Article { get; }
        ICategory Category { get; }
        IComment Comment { get; }
        IUser User { get; }

        int SaveChanges();
    }
}
