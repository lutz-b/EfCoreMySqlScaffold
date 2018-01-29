using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class customer
    {
        public customer()
        {
            payment = new HashSet<payment>();
            rental = new HashSet<rental>();
        }

        [Column("customer_id")]
        public ushort CustomerId { get; set; }
        [Column("store_id")]
        public byte StoreId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(45)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(45)]
        public string LastName { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Column("active", TypeName = "tinyint(1)")]
        public sbyte Active { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset? LastUpdate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("customer")]
        public address Address { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("customer")]
        public store Store { get; set; }
        [InverseProperty("Customer")]
        public ICollection<payment> payment { get; set; }
        [InverseProperty("Customer")]
        public ICollection<rental> rental { get; set; }
    }
}
