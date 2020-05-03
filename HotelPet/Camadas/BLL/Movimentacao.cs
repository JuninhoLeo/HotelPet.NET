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
            DAL.ItemVendaDAL itemvenda = new DAL.ItemVendaDAL();
            return itemvenda.Select();
        }

        public double SelectTotal(int cod)
        {
            DAL.ItemVendaDAL total = new DAL.ItemVendaDAL();
            return total.SelectTot(cod);
        }

        public int SelectCount(int cod)
        {
            DAL.ItemVendaDAL itens = new DAL.ItemVendaDAL();
            return itens.SelectCount(cod);
        }

        public int SelectId()
        {
            DAL.ItemVendaDAL lista = new DAL.ItemVendaDAL();
            return lista.SelectId();
        }

        public void Finaliza(int id)
        {
            DAL.ItemVendaDAL lista = new DAL.ItemVendaDAL();
            lista.Delete(id);
        }

    }
}
