using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class film
    {
        public film()
        {
            film_actor = new HashSet<film_actor>();
            film_category = new HashSet<film_category>();
            inventory = new HashSet<inventory>();
        }

        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Required]
        [Column("title")]
        [StringLength(255)]
        public string Title { get; set; }
        [Column("description", TypeName = "text")]
        public string Description { get; set; }
        [Column("language_id")]
        public byte LanguageId { get; set; }
        [Column("original_language_id")]
        public byte? OriginalLanguageId { get; set; }
        [Column("rental_duration")]
        public byte RentalDuration { get; set; }
        [Column("rental_rate", TypeName = "decimal(4,2)")]
        public decimal RentalRate { get; set; }
        [Column("length")]
        public ushort? Length { get; set; }
        [Column("replacement_cost", TypeName = "decimal(5,2)")]
        public decimal ReplacementCost { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("LanguageId")]
        [InverseProperty("filmLanguage")]
        public language Language { get; set; }
        [ForeignKey("OriginalLanguageId")]
        [InverseProperty("filmOriginalLanguage")]
        public language OriginalLanguage { get; set; }
        [InverseProperty("Film")]
        public ICollection<film_actor> film_actor { get; set; }
        [InverseProperty("Film")]
        public ICollection<film_category> film_category { get; set; }
        [InverseProperty("Film")]
        public ICollection<inventory> inventory { get; set; }
    }
}
