using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1.sakila
{
    public partial class film_actor
    {
        [Column("actor_id")]
        public ushort ActorId { get; set; }
        [Column("film_id")]
        public ushort FilmId { get; set; }
        [Column("last_update", TypeName = "timestamp")]
        public DateTimeOffset LastUpdate { get; set; }

        [ForeignKey("ActorId")]
        [InverseProperty("film_actor")]
        public actor Actor { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("film_actor")]
        public film Film { get; set; }
    }
}
