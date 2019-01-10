using BrainStorm.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStorm.Components
{
    public class CategoryComponent : ViewComponent
    {
        ICategory _category;
        public CategoryComponent(ICategory category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            return View( _category.GetAll());
        }
    }
}
