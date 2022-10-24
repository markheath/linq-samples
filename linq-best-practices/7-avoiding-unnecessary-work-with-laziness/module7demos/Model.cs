using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore;
public class Cart
{
    [Key]
    public int RecordId { get; set; }

    [Required]
    [StringLength(50)]
    public string CartId { get; set; }

    public int AlbumId { get; set; }

    public int Count { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Album Album { get; set; }
}

[Table("Album")]
public class Album
{
    public int AlbumId { get; set; }

    public int GenreId { get; set; }

    public int ArtistId { get; set; }

    [Required]
    [StringLength(160)]
    public string Title { get; set; }

    [Column(TypeName = "numeric")]
    public decimal Price { get; set; }

    [StringLength(1024)]
    public string AlbumArtUrl { get; set; }

    public virtual Artist Artist { get; set; }

    public virtual Genre Genre { get; set; }

    public virtual ICollection<Cart> Carts { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}

[Table("Genre")]
public class Genre
{
    public int GenreId { get; set; }

    [StringLength(120)]
    public string Name { get; set; }

    [StringLength(4000)]
    public string Description { get; set; }

    public virtual ICollection<Album> Albums { get; set; }
}

[Table("Artist")]
public class Artist
{
    public Artist()
    {
        Albums = new HashSet<Album>();
    }

    public int ArtistId { get; set; }

    [StringLength(120)]
    public string Name { get; set; }

    public virtual ICollection<Album> Albums { get; set; }
}

[Table("Order")]
public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    [StringLength(256)]
    public string Username { get; set; }

    [StringLength(160)]
    public string FirstName { get; set; }

    [StringLength(160)]
    public string LastName { get; set; }

    [StringLength(70)]
    public string Address { get; set; }

    [StringLength(40)]
    public string City { get; set; }

    [StringLength(40)]
    public string State { get; set; }

    [StringLength(10)]
    public string PostalCode { get; set; }

    [StringLength(40)]
    public string Country { get; set; }

    [StringLength(24)]
    public string Phone { get; set; }

    [StringLength(160)]
    public string Email { get; set; }

    [Column(TypeName = "numeric")]
    public decimal Total { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}

[Table("OrderDetail")]
public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int AlbumId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "numeric")]
    public decimal UnitPrice { get; set; }

    public virtual Album Album { get; set; }

    public virtual Order Order { get; set; }
}

[Table("User")]
public class User
{
    public int UserId { get; set; }

    [Required]
    [StringLength(200)]
    public string UserName { get; set; }

    [Required]
    [StringLength(200)]
    public string Email { get; set; }

    [Required]
    [StringLength(200)]
    public string Password { get; set; }

    [Required]
    [StringLength(50)]
    public string Role { get; set; }
}