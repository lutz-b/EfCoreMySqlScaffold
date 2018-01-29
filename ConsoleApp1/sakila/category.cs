using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class category
    {
        public category()
        {
            film_category = new HashSet<film_category>();
        }

        [Column("category_id")]
        public byte CategoryId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(25)]
        public string Name { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [InverseProperty("Category")]
        public ICollection<film_category> film_category { get; set; }
    }
}
