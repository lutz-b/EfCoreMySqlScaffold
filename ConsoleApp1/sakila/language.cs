using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class language
    {
        public language()
        {
            filmLanguage = new HashSet<film>();
            filmOriginalLanguage = new HashSet<film>();
        }

        [Column("language_id")]
        public byte LanguageId { get; set; }
        [Required]
        [Column("name", TypeName = "char(20)")]
        public string Name { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [InverseProperty("Language")]
        public ICollection<film> filmLanguage { get; set; }
        [InverseProperty("OriginalLanguage")]
        public ICollection<film> filmOriginalLanguage { get; set; }
    }
}
