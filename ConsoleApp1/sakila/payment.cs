using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class payment
    {
        [Column("payment_id")]
        public ushort PaymentId { get; set; }
        [Column("customer_id")]
        public ushort CustomerId { get; set; }
        [Column("staff_id")]
        public byte StaffId { get; set; }
        [Column("rental_id", TypeName = "int(11)")]
        public int? RentalId { get; set; }
        [Column("amount", TypeName = "decimal(5,2)")]
        public decimal Amount { get; set; }
        [Column("payment_date", TypeName = "datetime")]
        public DateTime PaymentDate { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset? LastUpdate { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("payment")]
        public customer Customer { get; set; }
        [ForeignKey("RentalId")]
        [InverseProperty("payment")]
        public rental Rental { get; set; }
        [ForeignKey("StaffId")]
        [InverseProperty("payment")]
        public staff Staff { get; set; }
    }
}
