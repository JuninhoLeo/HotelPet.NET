using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    [Table("Consumo")]

    public class Consumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double total { get; set; }

        //chaves estrangeiras
        [ForeignKey("Reserva")]
        public int Reserva_id { get; set; }
        virtual public Reserva Reserva { get; set; }

        [ForeignKey("Produtos")]
        public int Produtos_id { get; set; }
        virtual public Produtos Produtos { get; set; }

        [ForeignKey("Quarto")]
        public int Quarto_id { get; set; }
        virtual public Quarto Quarto { get; set; }

    }
}
