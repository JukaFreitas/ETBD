

using Microsoft.AspNetCore.Identity;

namespace ETBDApp.Data.Seeds
{
    public static class ContextSeeder
    {
        public static async Task SeedRolesAsync (RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RoleType.Admin.ToString())); 
            await roleManager.CreateAsync(new IdentityRole(RoleType.Customer.ToString()));
        }

        public static async Task SeedAdminAsync (UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminUser = new User
            {
                FirstName = "Joana",
                LastName = "Freitas",
                UserName = "adminETBD",
                Email = "adminETBD@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "912405903", 
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u=> u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(adminUser, "108Fermentoes.");
                    await userManager.AddToRoleAsync(adminUser, RoleType.Admin.ToString());
                }

            }

        }
    }
}
