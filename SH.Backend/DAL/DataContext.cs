using Microsoft.EntityFrameworkCore;
using SH.Share.Models;

namespace SH.Backend.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        private DbSet<Employee> Employees { get; set; }
        private DbSet<Tool> Tools { get; set; }
        private DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}