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
    class Consumo
    {
        private string strcon = Conexao.getConexao();

        public List<MODEL.Consumo> Select()
        {
            List<MODEL.Consumo> listconsumos = new List<MODEL.Consumo>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM CONSUMO";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Consumo consumo = new MODEL.Consumo();
                    consumo.id = Convert.ToInt32(dados["id"].ToString());
                    consumo.id_reserva = Convert.ToInt32(dados["id_cliente"].ToString());
                    consumo.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    consumo.id_quarto = Convert.ToInt32(dados["id_quarto"].ToString());
                    consumo.total = Convert.ToDouble(dados["total"].ToString());
                    listconsumos.Add(consumo);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO CONSUMO");
            }
            finally
            {
                conexao.Close();
            }
            return listconsumos;
        }//FIM DO SELECT

        public void Insert(MODEL.Consumo consumo)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO CONSUMO (ID_RESERVA, ID_PRODUTO, ID_QUARTO, TOTAL) " +
                         "VALUES(@id_reserva, @id_produto, @id_quarto, @total)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_reserva", consumo.id_reserva);
            cmd.Parameters.AddWithValue("@id_produto", consumo.id_produto);
            cmd.Parameters.AddWithValue("@id_quarto", consumo.id_quarto);
            cmd.Parameters.AddWithValue("@total", consumo.total);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DO CONSUMO");
            }
            finally
            {
                conexao.Close();
            }
        }// FIM DO INSERT

        public void Update(MODEL.Consumo consumo)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE CONSUMO SET " +
                         "ID_RESERVA= @id_reserva, ID_PRODUTO= @id_produto, ID_QUARTO= @id_quarto, TOTAL= @total " +
                         "WHERE id= @id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", consumo.id);
            cmd.Parameters.AddWithValue("@id_cliente", consumo.id_reserva);
            cmd.Parameters.AddWithValue("@id_produto", consumo.id_produto);
            cmd.Parameters.AddWithValue("@id_quarto", consumo.id_quarto);
            cmd.Parameters.AddWithValue("@total", consumo.total);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DO CONSUMO");
            }
            finally
            {
                conexao.Close();
            }
        }// FIM DO UPDATE

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM CONSUMO WHERE ID= @id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO DELETE DO CONSUMO");
            }
            finally
            {
                conexao.Close();
            }
        }


    }
}
