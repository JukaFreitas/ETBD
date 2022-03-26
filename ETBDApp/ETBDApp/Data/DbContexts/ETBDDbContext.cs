namespace ETBDApp.Data
{
    public class ETBDDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Food> Foods { get; set; }  

        public ETBDDbContext(DbContextOptions<ETBDDbContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(p => p.CategoryName).HasMaxLength(50); 
            modelBuilder.Entity<Action>().Property(p => p.ActionName).HasMaxLength(50);
            modelBuilder.Entity<Food>().Property(p => p.FoodName).HasMaxLength(50);
        
        }
    }
}