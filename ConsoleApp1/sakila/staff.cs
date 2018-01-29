using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class staff
    {
        public staff()
        {
            payment = new HashSet<payment>();
            rental = new HashSet<rental>();
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
        [InverseProperty("staff")]
        public address Address { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("staff")]
        public store Store { get; set; }
        [InverseProperty("ManagerStaff")]
        public store store { get; set; }
        [InverseProperty("Staff")]
        public ICollection<payment> payment { get; set; }
        [InverseProperty("Staff")]
        public ICollection<rental> rental { get; set; }
    }
}
