using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace MyPaymentsCrossPlatform.EF
{
    public class PaymentsContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MeterReading> MeterReadings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UtilityBill> Bills { get; set; }

        private string databasePath;
        public PaymentsContext(string path)
        {
            databasePath = path;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>().HasKey(t => t.Id);

            //modelBuilder.Entity<UtilityBill>().HasOne(t => t.Address)
            //    .WithMany(s => s.Bills).HasForeignKey(q => q.IdAddress);

            //modelBuilder.Entity<MeterReading>().HasOne(t => t.UtilityBill)
            //    .WithMany(s => s.MeterReadings).HasForeignKey(q => q.IdUtilityBill)
            //    .HasPrincipalKey(u => u.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
