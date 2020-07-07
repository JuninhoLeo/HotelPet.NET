using HotelPet.Camadas.MODEL;
using HotelPet.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.BLL
{
    public class ConsumoBLL
    {
        public int Insert(List<Consumo> lstConsumo)
        {
            int id = 0;
            ConsumoDAL dal = new ConsumoDAL();
            foreach (var consumo in lstConsumo)
            {
                dal.Insert(consumo);
                id = consumo.Reserva_id;
            }
            return id;
        }

        public void Delete(Consumo consumo) 
        {
            ConsumoDAL dal = new ConsumoDAL();
            dal.Delete(consumo);
        } 
    }
}
