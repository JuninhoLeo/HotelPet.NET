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
    public class Reserva
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Reserva> Select()
        {
            List<MODEL.Reserva> listReserva = new List<MODEL.Reserva>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM RESERVA";
            MySqlCommand cmd = new MySqlCommand(sql,conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Reserva reserva = new MODEL.Reserva();
                    reserva.id = Convert.ToInt32(dados["id"].ToString());
                    reserva.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    reserva.entrada = Convert.ToDateTime(dados["entrada"].ToString());
                    reserva.saida = Convert.ToDateTime(dados["saida"].ToString());
                    reserva.id_funcionario = Convert.ToInt32(dados["id_funcionario"].ToString());
                    listReserva.Add(reserva);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DA RESERVA");
            }
            finally
            {
                conexao.Close();
            }

            return listReserva;
        }//fim do select

        public void Insert(MODEL.Reserva reserva)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO RESERVA(ID_CLIENTE, ENTRADA, SAIDA, ID_FUNCIONARIO)" +
                         "VALUES(@id_cliente, @entrada, @saida, @id_funcionario)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_cliente", reserva.id_cliente);
            cmd.Parameters.AddWithValue("@entrada", reserva.entrada);
            cmd.Parameters.AddWithValue("@saida", reserva.saida);
            cmd.Parameters.AddWithValue("@id_funcionario", reserva.id_funcionario);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DA RESERVA");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do insert

        public void Update(MODEL.Reserva reserva)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE Reserva " +
                         "SET ID_CLIENTE =@id_cliente, ENTRADA =@entrada, SAIDA =@saida, ID_FUNCIONARIO =@id_funcionario " +
                         "WHERE ID =@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", reserva.id);
            cmd.Parameters.AddWithValue("@id_cliente", reserva.id_cliente);
            cmd.Parameters.AddWithValue("@entrada", reserva.entrada);
            cmd.Parameters.AddWithValue("@saida", reserva.saida);
            cmd.Parameters.AddWithValue("@id_funcionario", reserva.id_funcionario);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DA RESERVA");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM RESERVA " +
                         "WHERE ID =@id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO DELETE DA RESERVA");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Delete
    }
}
