using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long codigo { get; set; }

        [StringLength(255)]
        public string descricao { get; set; }

        public double quantidade { get; set; }

        public double valor { get; set; }

        public bool isQuarto { get; set; }

        public bool isServico { get; set; }
    }
}
