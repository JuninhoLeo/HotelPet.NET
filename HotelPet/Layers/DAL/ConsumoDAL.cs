using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.DAL
{
    public class ConsumoDAL
    {
        public void Insert(Consumo consumo)
        {
            Contexto contexto = new Contexto();

            consumo.Reserva_id = consumo.Reserva.id;
            consumo.Reserva = null;
            consumo.Servicos_id = consumo.Servicos.id;
            consumo.Servicos = null;

            contexto.Consumo.Add(consumo);
            contexto.SaveChanges();
            contexto.Dispose();

        }

    }
}
