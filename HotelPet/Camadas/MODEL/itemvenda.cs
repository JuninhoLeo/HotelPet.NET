using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.MODEL
{
    public class Itemvenda
    {
        public int Id { get; set; }
        public string descricao { get; set; }
        public int Id_venda { get; set; }
        public Int64 id_produto { get; set; }
        public double quantidade { get; set; }
        public double valor { get; set; }

    }
}
