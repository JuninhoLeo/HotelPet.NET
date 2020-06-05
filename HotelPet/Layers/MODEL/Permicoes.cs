using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Permicoes")]
    public class Permicoes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        public string tipo { get; set; }
        public bool frmVenda { get; set; }
        public bool frmCliente { get; set; }
        public bool frmAddCliente { get; set; }
        public bool frmConfiguracoes { get; set; }
        public bool frmHotel { get; set; }
        public bool frmClinica { get; set; }
        public bool frmPainel { get; set; }
        public bool frmProdutos { get; set; }
    }
}
