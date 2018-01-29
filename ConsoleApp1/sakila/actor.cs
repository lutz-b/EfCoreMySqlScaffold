using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class actor
    {
        public actor()
        {
            film_actor = new HashSet<film_actor>();
        }

        [Column("actor_id")]
        public ushort ActorId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(45)]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(45)]
        public string LastName { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [InverseProperty("Actor")]
        public ICollection<film_actor> film_actor { get; set; }
    }
}
