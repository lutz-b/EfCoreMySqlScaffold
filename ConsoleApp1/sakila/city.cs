using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class city
    {
        public city()
        {
            address = new HashSet<address>();
        }

        [Column("city_id")]
        public ushort CityId { get; set; }
        [Required]
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Column("country_id")]
        public ushort CountryId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("CountryId")]
        [InverseProperty("city")]
        public country Country { get; set; }
        [InverseProperty("City")]
        public ICollection<address> address { get; set; }
    }
}
