

namespace ETBDApp.Data.Seeds
{
    public static class ContextSeeder
    {
        public static async Task SeedRolesAsync (RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RoleType.Admin.ToString())); 
            await roleManager.CreateAsync(new IdentityRole(RoleType.Customer.ToString()));
        }
    }
}
