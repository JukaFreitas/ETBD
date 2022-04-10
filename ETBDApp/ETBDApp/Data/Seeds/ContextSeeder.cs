namespace ETBDApp.Data.Seeds
{
    public static class ContextSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(RoleType.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(RoleType.Customer.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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

            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(adminUser, "108Fermentoes.");
                    await userManager.AddToRoleAsync(adminUser, RoleType.Admin.ToString());
                }
            }
        }

        public static async Task SeedPortionType(ETBDDbContext eTBDDbContext)
        {
            if (!eTBDDbContext.PortionTypes.Any(p => p.Type == "Unity"))
            {
                var unityPortion = new PortionType { Type = "Unity" };
                eTBDDbContext.PortionTypes.Add(unityPortion);
                await eTBDDbContext.SaveChangesAsync();
            }
            if (!eTBDDbContext.PortionTypes.Any(p => p.Type == "Gram"))
            {
                var gramPortion = new PortionType { Type = "Gram" };
                eTBDDbContext.PortionTypes.Add(gramPortion);
                await eTBDDbContext.SaveChangesAsync();
            }
        }

        public static async Task SeedMealType(ETBDDbContext eTBDDbContext)
        {
            if(!eTBDDbContext.MealTypes.Any(m=> m.Type == "Breakfast"))
            {
                var breakfastMeal = new MealType { Type = "Breakfast" };
                eTBDDbContext.MealTypes.Add(breakfastMeal);
                await eTBDDbContext.SaveChangesAsync(); 
            }
            if (!eTBDDbContext.MealTypes.Any(m => m.Type == "Lunch"))
            {
                var lunchMeal = new MealType { Type = "Lunch" };
                eTBDDbContext.MealTypes.Add(lunchMeal);
                await eTBDDbContext.SaveChangesAsync();
            }
            if (!eTBDDbContext.MealTypes.Any(m => m.Type == "Dinner"))
            {
                var dinnerMeal = new MealType { Type = "Dinner" };
                eTBDDbContext.MealTypes.Add(dinnerMeal);
                await eTBDDbContext.SaveChangesAsync();
            }
            if (!eTBDDbContext.MealTypes.Any(m => m.Type == "Snack"))
            {
                var snackMeal = new MealType { Type = "Snack" };
                eTBDDbContext.MealTypes.Add(snackMeal);
                await eTBDDbContext.SaveChangesAsync();
            }

        }
    }
}