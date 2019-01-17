using BrainStorm.Areas.Identity.Data;
using BrainStorm.Models.Interface;
using System;

namespace BrainStorm.Areas.Identity.Services
{
    public class UnitService : IUnitService
    {
        private readonly BrainStormDbContext _context;
        public UnitService(BrainStormDbContext context)
        {
            _context = context ?? throw new ArgumentException("db context can not be null");
        }
        private IArticle _article;
        public ICategory _category;
        public IArticleCategory _articleCategory;
        public IComment _comment;
        public IUser _user;

        public IArticle Article
        {
            get
            {
                return _article ?? (_article = new ArticleService(_context));
            }
        }
        public ICategory Category
        {
            get
            {
                return _category ?? (_category = new CategoryService(_context));
            }
        }
        public IArticleCategory ArticleCategory
        {
            get
            {
                return _articleCategory ?? (_articleCategory = new ArticleCategoryService(_context));
            }
        }
        public IComment Comment
        {
            get
            {
                return _comment ?? (_comment = new CommentService(_context));
            }
        }
        public IUser User
        {
            get
            {
                return _user ?? (_user = new UserService(_context));
            }
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}