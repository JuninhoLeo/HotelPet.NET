using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Venda")]

    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime data { get; set; }

        //chaves estrangeiras
        [ForeignKey("Cliente")]
        public int Cliente_id { get; set; }
        virtual public Cliente Cliente { get; set; }

        [ForeignKey("Funcionario")]
        public int Funcionario_id { get; set; }
        virtual public Funcionario Funcionario { get; set; }
    }
}
