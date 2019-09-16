using AddressBook.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Api.DataContext
{
    public class SqlExpressContext : DbContext
    {
        public SqlExpressContext(DbContextOptions<SqlExpressContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AddressInfo> AddressBook { get; set; }
        public DbSet<Seriloger> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var userBuilder = modelBuilder.Entity<User>();

            userBuilder.HasKey(h => h.Id);
            userBuilder.Property(p => p.Email).IsRequired();
            userBuilder.Property(p => p.Firstname).IsRequired();
            userBuilder.Property(p => p.Lastname).IsRequired();
            userBuilder.HasMany(x => x.Addresses)
                       .WithOne(u => u.User)
                       .HasForeignKey(b => b.UserId)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
