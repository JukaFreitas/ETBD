namespace ETBDApp.Data
{
    public class ETBDDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Food> Foods { get; set; }  
        public DbSet<ActionFood> ActionFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodMeal> FoodMeals { get; set; }
        public DbSet<PortionType> PortionTypes { get; set; }

        public ETBDDbContext(DbContextOptions<ETBDDbContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(50); 
            modelBuilder.Entity<Action>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Food>().Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Entity<Meal>().Property(p => p.Name).HasMaxLength(50);
            //Fk
            modelBuilder.Entity<ActionFood>().HasKey(af => new { af.ActionId, af.FoodId });
            modelBuilder.Entity<FoodMeal>().HasKey(fm => new { fm.FoodId, fm.MealId });

            modelBuilder.Entity<FoodMeal>().Property(p => p.Portion).HasColumnType("decimal(5)"); 
            

        
        }
    }
}