using ClothingStoreFranchise.NetCore.Employees.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace ClothingStoreFranchise.NetCore.Employees
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {
        }

        public DbSet<FranchiseEmployee> Empoyees { get; set; }
        
        public DbSet<Shop> Shops { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().ToTable("Buildings");
            
            modelBuilder.Entity<ShopEmployee>()
                .HasOne(s => s.Shop)
                .WithMany(e => e.ShopEmployees)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WarehouseEmployee>()
                .HasOne(s => s.Warehouse)
                .WithMany(e => e.WarehouseEmployees)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);

        }
    }

    public class CatalogContextFactory : IDesignTimeDbContextFactory<EmployeesContext>
    {
        public EmployeesContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeesContext>()
                .UseSqlServer(@"data source=localhost\SQLEXPRESS; initial catalog=Employee;
                Trusted_Connection=True;MultipleActiveResultSets=true")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory());

            return new EmployeesContext(optionsBuilder.Options);
        }
    }
}
