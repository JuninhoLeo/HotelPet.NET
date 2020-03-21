using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HotelPet.Camadas.DAL
{
    public class Conexao
    {
        public static string getConexao()
        {
            return "server=localhost;user id=root;persistsecurityinfo=True;database=hotel";
        }
    }
}
