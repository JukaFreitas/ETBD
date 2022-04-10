namespace ETBDApp.Data
{
    public class ETBDDbContext : IdentityDbContext<User>
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Food> Foods { get; set; }  
        public DbSet<ActionFood> ActionFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodMeal> FoodMeals { get; set; }
        public DbSet<PortionType> PortionTypes { get; set; }
        public DbSet<User> IdentityUsers { get; set; }
        public DbSet<BlackList> BlackLists { get; set;  }
        public DbSet<FavouriteList> FavouriteLists { get; set; }
        public DbSet<MealType> MealTypes { get; set;  }

        public ETBDDbContext(DbContextOptions<ETBDDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(50); 
            modelBuilder.Entity<Action>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Food>().Property(p => p.Name).HasMaxLength(50);

            modelBuilder.Entity<FoodMeal>().Property(p => p.Quantity).HasColumnType("decimal(5)");
            modelBuilder.Entity<User>().Property(p => p.Height).HasColumnType("decimal(5)");
            modelBuilder.Entity<User>().Property(p => p.Weight).HasColumnType("decimal(5)");
            //Fk
            modelBuilder.Entity<ActionFood>().HasKey(af => new { af.ActionId, af.FoodId });
            modelBuilder.Entity<FoodMeal>().HasKey(fm => new { fm.FoodId, fm.MealId });

        }
    }
}