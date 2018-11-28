using BrainStorm.Areas.Identity.Data;
using BrainStorm.Areas.Identity.Services;
using BrainStorm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BrainStorm.Helpers
{
    public class ImageHelper
    {
        BrainStormDbContext _context;
        ArticleService _articleService;

        public ImageHelper(BrainStormDbContext context)
        {
            this._context = context;
        }

        //public void SaveUserImage(List<IFormFile> files, string Id)
        //{
        //    _userService = new UserService(_context);

        //    List<TutorialUser> TutorialUser = _userService.GetUserById(Id);

        //    var filePath = Path.GetTempFileName();
        //    foreach (var formFile in files)
        //    {
        //        var staticPath = Path.Combine("wwwroot", "images", "user");
        //        var staticPathDB = Path.Combine("images", "user");
        //        var fullPath = Path.Combine(staticPathDB, GetUniqueFileName(formFile.FileName));
        //        var fullPathCreate = Path.Combine("wwwroot", fullPath);
        //        var fullPathDB = fullPath.Replace('\\', '/');

        //        var user = _context.TutorialUser.FirstOrDefault(item => item.Id == Id);
        //        user.AvatarImage = fullPathDB;
        //        _context.Update(user);
        //        _context.SaveChanges();

        //        formFile.CopyTo(new FileStream(fullPathCreate, FileMode.Create));
        //    }
        //}

        public void SaveArticleImage(Guid Id, IFormFile files)
        {
            _articleService = new ArticleService(_context);

            var filePath = Path.GetTempFileName();
            var staticPath = Path.Combine("wwwroot", "images", "article");
            var staticPathDB = Path.Combine("images", "article");
            var fullPath = Path.Combine(staticPathDB, GetUniqueFileName(files.FileName));
            var fullPathCreate = Path.Combine("wwwroot", fullPath);
            var fullPathDB = fullPath.Replace('\\', '/');

            var article = _context.Articles.FirstOrDefault(item => item.Id == Id);
            article.Picture = fullPathDB;
            _context.Update(article);
            _context.SaveChanges();

            files.CopyTo(new FileStream(fullPathCreate, FileMode.Create));
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 10)
                      + Path.GetExtension(fileName);
        }
    }
}
