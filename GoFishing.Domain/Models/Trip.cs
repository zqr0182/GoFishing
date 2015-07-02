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
        [Column("id")]
        public int Id { get; set; }
        [Column("boat_name")]
        [MaxLength(50)]
        public string BoatName { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
    }
}
