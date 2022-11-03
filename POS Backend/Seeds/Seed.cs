using POS_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace POS_Backend.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> customerManager,
            RoleManager<AppRole> roleManager)
        {
            if (await customerManager.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Seeds/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;
                
            var roles = new List<AppRole>
            {
                new AppRole{Name= "SuperAdmin"},
                new AppRole{Name= "Admin"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {


                user.UserName = user.UserName.ToLower();


                await customerManager.CreateAsync(user, "Kolikoje3");
                await customerManager.AddToRoleAsync(user, "Admin");
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            await customerManager.CreateAsync(admin, "Kolikoje3");
            await customerManager.AddToRolesAsync(admin, new[] { "SuperAdmin" });

        }
    }
}
