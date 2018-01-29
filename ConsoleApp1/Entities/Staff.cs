using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.Entities
{
    [Table("staff")]
    public partial class Staff
    {
        public Staff()
        {
            Payment = new HashSet<Payment>();
            Rental = new HashSet<Rental>();
        }

        [Column("staff_id")]
        public byte StaffId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(45)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(45)]
        public string LastName { get; set; }
        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Column("picture", TypeName = "blob")]
        public byte[] Picture { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("store_id")]
        public byte StoreId { get; set; }
        [Column("active", TypeName = "tinyint(1)")]
        public sbyte Active { get; set; }
        [Required]
        [Column("username")]
        [StringLength(16)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(40)]
        public string Password { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("Staff")]
        public Address Address { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("Staff")]
        public Store Store { get; set; }
        [InverseProperty("ManagerStaff")]
        public Store StoreNavigation { get; set; }
        [InverseProperty("Staff")]
        public ICollection<Payment> Payment { get; set; }
        [InverseProperty("Staff")]
        public ICollection<Rental> Rental { get; set; }
    }
}
