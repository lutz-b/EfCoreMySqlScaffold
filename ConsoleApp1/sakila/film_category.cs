using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class film_category
    {
        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Column("category_id")]
        public byte CategoryId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("film_category")]
        public category Category { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("film_category")]
        public film Film { get; set; }
    }
}
