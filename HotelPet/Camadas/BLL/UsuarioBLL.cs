using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class UsuarioBLL
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

        public MODEL.Usuario Select(MODEL.Usuario usuario)
        {
            DAL.UsuariosDAL dalUsr = new DAL.UsuariosDAL();
            MODEL.Usuario user = dalUsr.Select(usuario);

            if (user.id == 0)
            {
                dalUsr.Insert(usuario);
                user = dalUsr.Select(usuario);
                return user;
            }
            else
            {
                if (usuario.senha != "2jmj7l5rSw0yVb/vlWAYkK/YBwk=") 
                { 
                    user.senha = usuario.senha; 
                }
                user.usuario = usuario.usuario;

                dalUsr.Update(user);
                user = dalUsr.Select(usuario);
                return user;
            }
            
        }

    }
}
