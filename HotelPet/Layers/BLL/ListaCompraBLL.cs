using HotelPet.Camadas.MODEL;
using HotelPet.Layers.DAL;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.BLL
{
    public class ListaCompraBLL
    {
        public void Insert(List<ListaCompra> lst, int id)
        {
            ListaCompraDAL dal = new ListaCompraDAL();

            foreach (var compras in lst)
            {
                compras.Vendas_id = id;
                dal.Insert(compras);
            }
        }
    }
}
