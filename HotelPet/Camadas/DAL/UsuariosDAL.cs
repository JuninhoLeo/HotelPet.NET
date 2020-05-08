using HotelPet.Camadas.MODEL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.DAL
{
    public class UsuariosDAL
    {
        private string strCon = ConexaoDAL.getConexao();

        public List<MODEL.Usuario> Select()
        {
            List<MODEL.Usuario> listUsers = new List<MODEL.Usuario>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM USUARIOS";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Usuario usuario = new MODEL.Usuario();
                    usuario.id = Convert.ToInt32(dados["id"].ToString());
                    usuario.usuario = dados["usuario"].ToString();
                    usuario.senha = dados["senha"].ToString();
                    listUsers.Add(usuario);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO USUARIO");
            }
            finally
            {
                conexao.Close();
            }

            return listUsers;
        }//fim do select

        public Usuario Select(Usuario user)
        {
            Usuario listUsers = new Usuario();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM USUARIOS " +
                         "WHERE usuario=@user";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@user", user.usuario);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        usuario = dados["usuario"].ToString(),
                        senha = dados["senha"].ToString()
                    };
                    listUsers = usuario;
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO USUARIO");
            }
            finally
            {
                conexao.Close();
            }

            return listUsers;
        }//fim do select


        public Usuario Select(int userId)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM USUARIOS " +
                         "WHERE ID = @user";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@user", userId);
            MODEL.Usuario usuario = new MODEL.Usuario();

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    usuario.id = Convert.ToInt32(dados["id"].ToString());
                    usuario.usuario = dados["usuario"].ToString();
                    usuario.senha = dados["senha"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO USUARIO");
            }
            finally
            {
                conexao.Close();
            }

            return usuario;
        }//fim do select

        public string SelectUsr(string usr)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM USUARIOS " +
                         "WHERE USUARIO =@usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@usuario", usr);
            string usuario = "";

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    usuario = dados["usuario"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO USUARIO");
            }
            finally
            {
                conexao.Close();
            }
            return usuario;
        }//fim do selectUsr

        public string SelectPwd(string usr)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM USUARIOS " +
                         "WHERE USUARIO =@usuario";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@usuario", usr);
            string senha = "";

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    senha = dados["senha"].ToString();
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO USUARIO");
            }
            finally
            {
                conexao.Close();
            }
            return senha;
        }//fim do selectPwd

        public void Insert(MODEL.Usuario usuario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO USUARIOS (USUARIO, SENHA)" +
                         "VALUES(@usuario, @senha)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);

            //try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            //catch
            {
             //   Console.WriteLine("ERRO NO INSERT DO USUARIO");
            }
            //finally
            {
                conexao.Close();
            }
        }//fim do insert

        public void Update(MODEL.Usuario usuario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE USUARIOS SET USUARIO =@usuario, SENHA =@senha " +
                         "WHERE ID =@id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", usuario.id);
            cmd.Parameters.AddWithValue("@usuario", usuario.usuario);
            cmd.Parameters.AddWithValue("@senha", usuario.senha);

           // try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
           // catch
            {
           //     Console.WriteLine("ERRO NO UPDATE DO USUARIO");
            }
           // finally
            {
                conexao.Close();
            }
        }//fim do Update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM USUARIOS " +
                         "WHERE ID=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id",id);

           // try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
           // catch
            {
           //     Console.WriteLine("ERRO NO DELETE DO USUARIO");
            }
           // finally
            {
                conexao.Close();
            }
        }//fim do Delete
    }
}
