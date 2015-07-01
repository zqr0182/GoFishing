using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFishing.Domain.Models
{
    public partial class Trophy : IEntity
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("trophy_id", TypeName = "int")]
        [ForeignKey("Trip")]
        public int TripId { get; set; }
        [Column("total", TypeName = "int")]
        public int Total { get; set; }
        [Column("creation_date", TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        public virtual Trip Trip { get; set; }

    }
}
