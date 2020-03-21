using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    public class Consumo
    {
        public int id { get; set; }
        public int id_reserva { get; set; }
        public int id_produto { get; set; }
        public int id_quarto { get; set; }
        public double total { get; set; }

    }
}
