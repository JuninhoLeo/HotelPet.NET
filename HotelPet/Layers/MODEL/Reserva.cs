using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Reserva")]

    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime entrada { get; set; }
        public DateTime? saida { get; set; }
        public double pago { get; set; }

        // chaves estrangeiras

        [ForeignKey("Quarto")]
        public int Quarto_id { get; set; }
        virtual public Quarto Quarto { get; set; }

        [ForeignKey("Funcionario")]
        public int Funcionario_id { get; set; }
        virtual public Funcionario Funcionario { get; set; }

        [ForeignKey("Cliente")]
        public int Cliente_id { get; set; }
        virtual public Cliente Cliente { get; set; }

        [ForeignKey("Animal")]
        public int Animal_id { get; set; }
        virtual public Animal Animal { get; set; }
    }
}
