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
    public class ProdutosDAL
    {
        public void Insert(Produtos produtos)
        {
            Contexto contexto = new Contexto();
            contexto.Produto.Add(produtos);
            contexto.SaveChanges();
            contexto.Entry(produtos).Reload();
            contexto.Dispose();
        }

        public void Update(Produtos produtos)
        {
            Contexto contexto = new Contexto();
            contexto.Entry(produtos).State = EntityState.Modified;
            contexto.SaveChanges();
            contexto.Entry(produtos).Reload();
            contexto.Dispose();
        }

        public void Delete(Produtos produtos)
        {
            Contexto contexto = new Contexto();
            var prod = contexto.Produto.FirstOrDefault(x => x.codigo == produtos.codigo);

            if (prod != null)
            {
                contexto.Produto.Remove(prod);
                contexto.SaveChanges();
            }

            contexto.Dispose();
        }
    }
}
