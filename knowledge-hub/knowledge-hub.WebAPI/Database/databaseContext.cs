using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Database
{
   public partial class databaseContext : DbContext
   {
      public databaseContext(DbContextOptions<databaseContext> options)
           : base(options) {
      }
      public DbSet<Role> Roles { get; set; }
      public DbSet<UserRoles> UserRoles { get; set; }
      public DbSet<User> Users { get; set; }
      public DbSet<Login> Logins { get; set; }
      public DbSet<Book> Books { get; set; }
      public DbSet<Category> Categories { get; set; }
      public DbSet<Language> Languages { get; set; }
      public DbSet<Review> Reviews { get; set; }
      public DbSet<CardInfo> Cards { get; set; }
      public DbSet<City> Cities { get; set; }
      public DbSet<Order> Orders { get; set; }
      public DbSet<Transaction> Transactions { get; set; }
      public DbSet<BookUserWishlist> Whishlist { get; set; }
      public DbSet<Address> Addresses { get; set; }



      protected override void OnModelCreating(ModelBuilder modelBuilder) {
         modelBuilder.Entity<User>()
            .HasOne(u => u.Login)
            .WithOne(l => l.User)
            .HasForeignKey<Login>(x => x.UserId);

         OnModelCreatingPartial(modelBuilder);
      }

      partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
   }
}
