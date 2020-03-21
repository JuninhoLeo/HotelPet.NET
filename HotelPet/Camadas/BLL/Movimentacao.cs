using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class Movimentacao
    {
        public List<MODEL.Itemvenda> Select()
        {
            DAL.ItemVenda itemvenda = new DAL.ItemVenda();
            return itemvenda.Select();
        }

        public double SelectTotal(int cod)
        {
            DAL.ItemVenda total = new DAL.ItemVenda();
            return total.SelectTot(cod);
        }

        public int SelectCount(int cod)
        {
            DAL.ItemVenda itens = new DAL.ItemVenda();
            return itens.SelectCount(cod);
        }

        public int SelectId()
        {
            DAL.ItemVenda lista = new DAL.ItemVenda();
            return lista.SelectId();
        }

        public void Finaliza(int id)
        {
            DAL.ItemVenda lista = new DAL.ItemVenda();
            lista.Delete(id);
        }

    }
}
