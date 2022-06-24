using Microsoft.EntityFrameworkCore;
namespace MusicStore;

public class MusicStoreDb : DbContext
{

    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // https://docs.microsoft.com/en-us/ef/core/logging-events-diagnostics/simple-logging
        optionsBuilder.LogTo(msg => {
            var n = msg.IndexOf("Executing DbCommand");
            if (n >= 0)
            {
                n += msg.Substring(n).IndexOf("\n");
                Console.WriteLine("SQL: " + msg.Substring(n+1));
            }                
        });
            
        
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Database=MvcMusicStore;Integrated Security=SSPI");
            //Trusted_Connection=True");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>()
            .Property(e => e.Price)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Album>()
            .HasMany(e => e.Carts)
            .WithOne(e => e.Album)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Album>()
            .HasMany(e => e.OrderDetails)
            .WithOne(e => e.Album)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Artist>()
            .HasMany(e => e.Albums)
            .WithOne(e => e.Artist)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Cart>()
            .Property(e => e.CartId)
            .IsUnicode(false);

        modelBuilder.Entity<Genre>()
            .HasMany(e => e.Albums)
            .WithOne(e => e.Genre)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<OrderDetail>()
            .Property(e => e.UnitPrice)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Order>()
            .Property(e => e.Total)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Order>()
            .HasMany(e => e.OrderDetails)
            .WithOne(e => e.Order)
            .OnDelete(DeleteBehavior.NoAction);
    }
}