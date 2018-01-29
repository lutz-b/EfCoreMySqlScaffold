using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class rental
    {
        public rental()
        {
            payment = new HashSet<payment>();
        }

        [Column("rental_id", TypeName = "int(11)")]
        public int RentalId { get; set; }
        [Column("rental_date", TypeName = "datetime")]
        public DateTime RentalDate { get; set; }
        [Column("inventory_id", TypeName = "mediumint unsigned")]
        public uint InventoryId { get; set; }
        [Column("customer_id")]
        public ushort CustomerId { get; set; }
        [Column("return_date", TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }
        [Column("staff_id")]
        public byte StaffId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("rental")]
        public customer Customer { get; set; }
        [ForeignKey("InventoryId")]
        [InverseProperty("rental")]
        public inventory Inventory { get; set; }
        [ForeignKey("StaffId")]
        [InverseProperty("rental")]
        public staff Staff { get; set; }
        [InverseProperty("Rental")]
        public ICollection<payment> payment { get; set; }
    }
}
