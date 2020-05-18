    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{

    [Table("Cliente")]

    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(255)]
        public string nome { get; set; }

        [StringLength(255)]
        public string cpf { get; set; }

        [StringLength(255)]
        public string rg { get; set; }

        [StringLength(255)]
        public string cidade { get; set; }

        [StringLength(255)]
        public string uf { get; set; }

        [StringLength(255)]
        public string telefone { get; set; }

        [StringLength(255)]
        public string email { get; set; }
    }
}
