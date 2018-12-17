using BrainStorm.Models.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BrainStorm.Areas.Identity.Data
{
    public static class DBInitializer
    {
        public static async Task InitializeAsync(BrainStormDbContext context,
            UserManager<BrainStormUser> userManager,
            RoleManager<BrainStormRole> roleManager)
        {
            context.Database.EnsureCreated();

            string adminId1 = "";
            string adminId2 = "";

            string role1 = "Admin";
            string desc1 = "This is adminstrator role";

            string role2 = "Member";
            string desc2 = "This is meembers role";

            string password = "password";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new BrainStormRole(role1, desc1, DateTime.Now));
            }
            if (await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new BrainStormRole(role2, desc2, DateTime.Now));
            }
            if (await userManager.FindByEmailAsync("aa@aa.aa") == null)
            {
                var user = new BrainStormUser
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    FirstName = "Kamran"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password.ToString());
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id.ToString();

            }
            if (await userManager.FindByEmailAsync("bb@bb.bb") == null)
            {
                var user = new BrainStormUser
                {
                    UserName = "bb@bb.bb",
                    Email = "bb@bb.bb",
                    FirstName = "Bayram"
                };
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password.ToString());
                    await userManager.AddToRoleAsync(user, role2);
                }
                adminId2 = user.Id.ToString();

            }
        }
    }
}
