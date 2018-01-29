using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class inventory
    {
        public inventory()
        {
            rental = new HashSet<rental>();
        }

        [Column("inventory_id", TypeName = "mediumint unsigned")]
        public uint InventoryId { get; set; }
        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Column("store_id")]
        public byte StoreId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("FilmId")]
        [InverseProperty("inventory")]
        public film Film { get; set; }
        [ForeignKey("StoreId")]
        [InverseProperty("inventory")]
        public store Store { get; set; }
        [InverseProperty("Inventory")]
        public ICollection<rental> rental { get; set; }
    }
}
