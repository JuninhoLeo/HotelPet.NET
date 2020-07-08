using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.MODEL
{
    [Table("Historico")]
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double valor { get; set; }
        public DateTime data { get; set; }

        [StringLength(35)]
        public string descricao { get; set; }
    }
}
