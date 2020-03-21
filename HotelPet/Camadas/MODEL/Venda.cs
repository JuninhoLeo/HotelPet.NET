using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    public class Venda
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_funcionario { get; set; }
        public DateTime data { get; set; }
    }
}
