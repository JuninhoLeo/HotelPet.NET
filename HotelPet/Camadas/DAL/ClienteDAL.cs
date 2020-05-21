using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.DAL
{
    public class ClienteDAL
    {
        public void Delete(Cliente cliente)
        {
            Contexto contexto = new Contexto();
            contexto.Entry(cliente).State = EntityState.Deleted;
            contexto.SaveChanges();

            contexto.Dispose();
        }
    }
}
