using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.DAL
{
    public class ListaCompraDAL
    {
        public void Insert(ListaCompra compras)
        {
            Contexto contexto = new Contexto();
            contexto.ListaCompras.Add(compras);
            contexto.SaveChanges();

            contexto.Dispose();
        }
    }
}
