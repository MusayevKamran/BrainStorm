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

        public ImageHelper(BrainStormDbContext context)
        {
            this._context = context;
        }

        public void UpdateImage<T>(Guid Id, IFormFile files, string path, T model)
        {
            var filePath = Path.GetTempFileName();
            var staticPath = Path.Combine("wwwroot", "images", path);
            var staticPathDB = Path.Combine("images", path);
            var fullPath = Path.Combine(staticPathDB, GetUniqueFileName(files.FileName));
            var fullPathCreate = Path.Combine("wwwroot", fullPath);
            var fullPathDB = fullPath.Replace('\\', '/');
            if (model.GetType() == typeof(Article))
            {
                var article = _context.Articles.FirstOrDefault(item => item.Id == Id);
                article.Picture = fullPathDB;
                _context.Update(article);
            }
            else if (model.GetType() == typeof(BrainStormUser))
            {
                var BrainStormUser = _context.BrainStormUser.FirstOrDefault(item => item.Id == Id);
                BrainStormUser.AvatarImage = fullPathDB;
                _context.Update(BrainStormUser);
            }

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
