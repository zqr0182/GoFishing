using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFishing.Domain.Models
{
    public partial class Trip : IEntity
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }
        [Column("boat_name", TypeName = "nvarchar")]
        [MaxLength(50)]
        public string BoatName { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("creation_date", TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
    }
}
