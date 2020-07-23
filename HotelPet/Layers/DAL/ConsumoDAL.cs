using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            consumo.Produtos_id = consumo.Produtos.id;
            consumo.Produtos = null;

            contexto.Consumo.Add(consumo);
            contexto.SaveChanges();
            contexto.Dispose();

        }

        public void Delete(Consumo consumo)
        {
            Contexto contexto = new Contexto();
            contexto.Entry(consumo).State = EntityState.Deleted;
            contexto.SaveChanges();
            contexto.Dispose();
        }

    }
}
