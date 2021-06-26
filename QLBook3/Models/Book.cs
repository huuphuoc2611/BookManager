namespace QLBook3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public Book(int v1, string v2, string v3, string v4, string v5, int v6)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
            V6 = v6;
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(225)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(225)]
        public string Description { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(225)]
        public string Author { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(225)]
        public string Images { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Price { get; set; }
        public int V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public string V4 { get; }
        public string V5 { get; }
        public int V6 { get; }
    }
}
