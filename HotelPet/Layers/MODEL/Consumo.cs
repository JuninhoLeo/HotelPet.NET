using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelPet.Camadas.MODEL
{
    [Table("Consumo")]
    public class Consumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double Quantidade { get; set; }
        public double valor { get; set; }
        public double total { get; set; }

        public DateTime data { get; set; }

        //chaves estrangeiras
        [ForeignKey("Reserva")]
        public int Reserva_id { get; set; }
        virtual public Reserva Reserva { get; set; }

        [ForeignKey("Servicos")]
        public long Servicos_id { get; set; }
        virtual public Servicos Servicos { get; set; }
    }
}

