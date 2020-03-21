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
    class Quarto
    {
        private string strcon = Conexao.getConexao();

        public List<MODEL.Quarto> Select()
        {
            List<MODEL.Quarto> listQuartos = new List<MODEL.Quarto>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM QUARTOS";
            
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Quarto quarto = new MODEL.Quarto();
                    quarto.id = Convert.ToInt32(dados["id"].ToString());
                    quarto.descricao = dados["descricao"].ToString();
                    quarto.valor = Convert.ToDouble(dados["valor"].ToString());
                    listQuartos.Add(quarto);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO QUARTO");
            }
            finally
            {
                conexao.Close();
            }

            return listQuartos;
        }//FIM DO  SELECT

        public void Insert(MODEL.Quarto quarto)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO QUARTO (DESCRICAO, VALOR) " +
                         "VALUES(@descricao, @valor)";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", quarto.descricao);
            cmd.Parameters.AddWithValue("@valor", quarto.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DO QUARTO");
            }
            finally
            {
                conexao.Close();
            }
            
        }//FIM DO INSERT

        public void Update(MODEL.Quarto quarto)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE QUARTO SET DESCRICAO =@descricao, VALOR =@valor " +
                         "WHERE ID =@id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", quarto.id);
            cmd.Parameters.AddWithValue("@descricao", quarto.descricao);
            cmd.Parameters.AddWithValue("@valor", quarto.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DO QUARTO");
            }
            finally
            {
                conexao.Close();
            }

        }//FIM DO UPDATE

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM QUARTO " +
                         "WHERE ID =@id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO DELETE DO QUARTO");
            }
            finally
            {
                conexao.Close();
            }

        }// FIM DO DELETE

    }
}
