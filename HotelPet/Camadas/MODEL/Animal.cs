using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    class Animal
    {
        public int id { get; set; }
        public int idcli { get; set; }
        public DateTime nascimento { get; set; }
        public DateTime nascpai { get; set; }
        public DateTime nascmae { get; set; }
        public string especie { get; set; }
        public string raca { get; set; }
        public string pelagem { get; set; }
        public string cor { get; set; }
        public string porte { get; set; }
        public string sexo { get; set; }
        public string apelido { get; set; }
        public string nome { get; set; }
        public string pai { get; set; }
        public string mae { get; set; }
        public string observacoes { get; set; }
        public string cuidados { get; set; }

    }
}
