using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class address
    {
        public address()
        {
            customer = new HashSet<customer>();
            staff = new HashSet<staff>();
            store = new HashSet<store>();
        }

        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Required]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("address2")]
        [StringLength(50)]
        public string Address2 { get; set; }
        [Required]
        [Column("district")]
        [StringLength(20)]
        public string District { get; set; }
        [Column("city_id")]
        public ushort CityId { get; set; }
        [Column("postal_code")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("CityId")]
        [InverseProperty("address")]
        public city City { get; set; }
        [InverseProperty("Address")]
        public ICollection<customer> customer { get; set; }
        [InverseProperty("Address")]
        public ICollection<staff> staff { get; set; }
        [InverseProperty("Address")]
        public ICollection<store> store { get; set; }
    }
}
