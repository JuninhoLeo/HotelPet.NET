using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.MODEL;
using System;
using System.Data.Entity;
using System.Linq;

namespace HotelPet.Layers.DAL
{
    public class ListaCompraDAL
    {
        public void Insert(ListaCompra compras)
        {
            Contexto contexto = new Contexto();
            contexto.ListaCompras.Add(compras);
            contexto.SaveChanges();

            try
            {
                Produtos Prod = contexto.Produto.FirstOrDefault(x=> x.codigo == compras.Codigo);
                Prod.quantidade -= compras.Quantidade;
                contexto.Entry(Prod).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            contexto.Dispose();
        }
    }
}
