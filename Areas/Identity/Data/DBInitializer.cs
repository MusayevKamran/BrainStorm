﻿using BrainStorm.Models;
using BrainStorm.Models.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Data
{
    public class DBInitializer
    {
        public static async Task InitializeAsync(IApplicationBuilder app,
            BrainStormDbContext context,
            UserManager<BrainStormUser> userManager,
            RoleManager<BrainStormRole> roleManager)
        {
            context.Database.EnsureCreated();

            //app.ApplicationServices
            //    .GetRequiredService<BrainStormDbContext>().Database.Migrate();

            string roleADMIN = UserStatus.ADMIN;
            string descADMIN = "This is adminstrator role";

            string roleTEACHER = UserStatus.TEACHER;
            string descTEACHER = "This is TEACHER role";

            string roleUSER = UserStatus.USER;
            string descUSER = "This is USER role";

            if (await roleManager.FindByNameAsync(roleADMIN) == null)
            {
                await roleManager.CreateAsync(new BrainStormRole(roleADMIN, descADMIN, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(roleTEACHER) == null)
            {
                await roleManager.CreateAsync(new BrainStormRole(roleTEACHER, descTEACHER, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(roleUSER) == null)
            {
                await roleManager.CreateAsync(new BrainStormRole(roleUSER, descUSER, DateTime.Now));
            }

            if (await userManager.FindByEmailAsync("Kamran@gmail.com") == null)
            {
                var user = new BrainStormUser
                {
                    UserName = "Kamran@gmail.com",
                    Email = "Kamran@gmail.com",
                    Image = "images/user/default_user.png"
            };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, "Kamran123456");
                    await userManager.AddToRoleAsync(user, UserStatus.ADMIN);
                }
            }
        }
    }
}
