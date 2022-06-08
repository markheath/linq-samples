namespace LinqEfExample
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart
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
}
