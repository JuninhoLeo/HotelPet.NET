using HotelPet.Camadas.DAL;
using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    public class ClienteBLL
    {
        public void Delete(Cliente cli)
        {
            Contexto contexto = new Contexto();
            var lista = contexto.Animal.Where(x => x.Cliente_id == cli.id).ToList();

            if (lista == null)
            {
                contexto.Entry(cli).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
            else
            {
                contexto.Dispose();

                foreach(var animais in lista)
                {
                    AnimalDAL dalAni = new AnimalDAL();
                    dalAni.Delete(animais);
                }

                ClienteDAL dalCli = new ClienteDAL();
                dalCli.Delete(cli);
            }

        }
    }
}
