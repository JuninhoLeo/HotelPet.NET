using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    class Administrador
    {
        public int id { get; set; }
        public int id_permicao { get; set; }
        public string nome { get; set; }
        public int rg { get; set; }
        public int cpf { get; set; }
        public string email { get; set; }
    }
}
