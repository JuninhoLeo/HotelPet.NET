using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class Usuario
    {
        public string SelectUsr(string user)
        {
            DAL.UsuariosDAL usuario = new DAL.UsuariosDAL();
            string retorno;
            retorno = usuario.SelectUsr(user);

            if (retorno != string.Empty)
            {
                return retorno;
            }
            else
            {
                return null;
            }
        }

        public string SelectPwd(string user)
        {
            DAL.UsuariosDAL usuario = new DAL.UsuariosDAL();
            string retorno;
            retorno = usuario.SelectPwd(user);

            if (retorno != string.Empty)
            {
                return retorno;
            }
            else
            {
                return null;
            }
        }

    }
}
