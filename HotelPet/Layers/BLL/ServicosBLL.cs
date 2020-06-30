using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Layers.BLL
{
    public class ServicosBLL
    {

        public void Delete(Servicos servico)
        {
            Contexto contexto = new Contexto();
            ConsumoDAL dal = new ConsumoDAL();
            var ListaConsumo = contexto.Consumo.Where(x => x.Servicos_id == servico.id).ToList();
            contexto.Dispose();
            

            foreach (var consumo in ListaConsumo)
            {
                dal.Delete(consumo);
            }

            Contexto contexto1 = new Contexto();
            contexto1.Entry(servico).State = EntityState.Deleted;
            contexto1.SaveChanges();
            contexto1.Dispose();
        }
    }
}
