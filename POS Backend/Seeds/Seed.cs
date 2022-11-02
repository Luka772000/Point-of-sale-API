using POS_Backend.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POS_Backend.Seeds
{
    public class Seed
    {

        public static async Task SeedUsers(RoleManager<AppRole> roleManager)
        {
            // SEED za roles, ovdje definiramo koliko i koje cemo rolove imati te se ova
            // funkcija koristi u PROGRAM gdje se pokrece i podatci se ubacuju u bazu podataka
            var roles = new List<AppRole>
            {
            //Osoba koja kupuje filmove
            new AppRole{Name = "Member"},
            //Administartor
            new AppRole{Name = "Admin" },
            //Osoba koja prodaje filmove
            new AppRole{Name = "Moderator" }
            };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
