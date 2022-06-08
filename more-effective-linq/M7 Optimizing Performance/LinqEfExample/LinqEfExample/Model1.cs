namespace LinqEfExample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicStoreDb : DbContext
    {
        public MusicStoreDb()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Album>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Album>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Album)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.CartId)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Albums)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
