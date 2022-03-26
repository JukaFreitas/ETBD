namespace ETBDApp.Data
{
    public class ETBDDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ETBDDbContext(DbContextOptions<ETBDDbContext> options)
            : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(50); 


        }
    }
}