using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    public class Reserva
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public DateTime entrada { get; set; }
        public DateTime saida { get; set; }
        public int id_funcionario { get; set; }
    }
}
