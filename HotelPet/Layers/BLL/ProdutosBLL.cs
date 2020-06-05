using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.BLL
{
    public class ProdutosBLL
    {
        public void VerificaProduto(Produtos prod) {
            Contexto contexto = new Contexto();
            ProdutosDAL dal = new ProdutosDAL();

            Produtos produto = contexto.Produto.FirstOrDefault(x => x.codigo == prod.codigo);

            if (produto == null)
            {
                dal.Insert(prod);
            }
            else
            {
                prod.id = produto.id;
                prod.quantidade += produto.quantidade;

                dal.Update(prod);
            }
        }
    }
}
