using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class store
    {
        public store()
        {
            customer = new HashSet<customer>();
            inventory = new HashSet<inventory>();
            staff = new HashSet<staff>();
        }

        [Column("store_id")]
        public byte StoreId { get; set; }
        [Column("manager_staff_id")]
        public byte ManagerStaffId { get; set; }
        [Column("address_id")]
        public ushort AddressId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("store")]
        public address Address { get; set; }
        [ForeignKey("ManagerStaffId")]
        [InverseProperty("store")]
        public staff ManagerStaff { get; set; }
        [InverseProperty("Store")]
        public ICollection<customer> customer { get; set; }
        [InverseProperty("Store")]
        public ICollection<inventory> inventory { get; set; }
        [InverseProperty("Store")]
        public ICollection<staff> staff { get; set; }
    }
}
