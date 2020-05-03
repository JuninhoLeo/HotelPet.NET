using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HotelPet.Camadas.DAL
{
    class AdministradorDAL
    {
        private string strcon = ConexaoDAL.getConexao();

        public List<MODEL.Administrador> Select()
        {
            List<MODEL.Administrador> listAdmin = new List<MODEL.Administrador>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM ADMINISTRADOR";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Administrador administrador = new MODEL.Administrador();
                    administrador.id = Convert.ToInt32(dados["id"].ToString());
                    administrador.id_permicao = Convert.ToInt32(dados["id_permicao"].ToString());
                    administrador.nome = dados["nome"].ToString();
                    administrador.rg = Convert.ToInt32(dados["rg"].ToString());
                    administrador.cpf = Convert.ToInt32(dados["cpf"].ToString());
                    administrador.email = dados["email"].ToString();
                    listAdmin.Add(administrador);
                }
            }
            catch
            {
                Console.WriteLine("DEU ERRO NO SELECT DO ADMINISTRADOR.");
            }
            finally
            {
                conexao.Close();
            }

            return listAdmin;
        }//FIM DO SELECT

        
        public void Insert(MODEL.Administrador administrador)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO ADMINISTRADOR (ID_PERMICAO, NOME, RG, CPF, EMAIL) " +
                         "VALUES(@id_permicao, @nome, @rg, @cpf, @email)";
            
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_permicao", administrador.id_permicao);
            cmd.Parameters.AddWithValue("@nome", administrador.nome);
            cmd.Parameters.AddWithValue("@rg", administrador.rg);
            cmd.Parameters.AddWithValue("@cpf", administrador.cpf);
            cmd.Parameters.AddWithValue("@email", administrador.email);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO NO INSERT DO ADMINISTRADOR");
            }
            finally
            {
                conexao.Close();
            }
        }//FIM DO INSERT

        public void Update(MODEL.Administrador administrador)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE ADMINISTRADOR SET id_permicao= @id_permmicao, nome= @nome, rg= @rg, cpf= @cpf, email= @email " +
                         "WHERE id= @id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", administrador.id);
            cmd.Parameters.AddWithValue("@id_permicao", administrador.id_permicao);
            cmd.Parameters.AddWithValue("@nome", administrador.nome);
            cmd.Parameters.AddWithValue("@rg", administrador.rg);
            cmd.Parameters.AddWithValue("@cpf", administrador.cpf);
            cmd.Parameters.AddWithValue("@email", administrador.email);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO NO UPDATE DO ADMINISTRADOR");
            }
            finally
            {
                conexao.Close();
            }
        
        }//FIM DO UPDATE

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM ADMINISTRADOR " +
                         "WHERE ID= @id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO NO DELETE DO ADMINISTRADOR");
            }
            finally
            {
                conexao.Close();
            }

        }// FIM DO DELETE

    }
}
    