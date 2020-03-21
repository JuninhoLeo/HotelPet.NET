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
    public class Venda
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Venda> Select()
        {
            List<MODEL.Venda> listaVenda = new List<MODEL.Venda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM VENDAS";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Venda venda = new MODEL.Venda();
                    venda.id = Convert.ToInt32(dados["id"].ToString());
                    venda.id_funcionario = Convert.ToInt32(dados["id_funcionario"].ToString());
                    venda.id_cliente = Convert.ToInt32(dados["id_cliente"].ToString());
                    venda.data = Convert.ToDateTime(dados["data"].ToString());
                    listaVenda.Add(venda);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DA VENDA");
            }
            finally
            {
                conexao.Close();
            }

            return listaVenda;
        }// fim do select

        public int SelectId()
        {
            int idVenda = 0;
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT id, MAX(data) FROM VENDAS";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                idVenda = Convert.ToInt32(dados["id"].ToString());
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DA VENDA");
            }
            finally
            {
                conexao.Close();
            }

            return idVenda;
        }// fim do selectId

        public void Insert(MODEL.Venda venda)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO VENDAS(ID_FUNCIONARIO, ID_CLIENTE, DATA) " +
                         "VALUES(@id_funcionario, @id_cliente, @data)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_funcionario", venda.id_funcionario);
            cmd.Parameters.AddWithValue("@id_cliente", venda.id_cliente);
            cmd.Parameters.AddWithValue("@data", venda.data);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DA VENDA");
            }
            finally
            {
                conexao.Close();
            }
        }// fim do insert 

        public void Update(MODEL.Venda venda)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE VENDAS SET ID_FUNCIONARIO =@id_funcionario, ID_CLIENTE =@idcliente, DATA =@data " +
                         "WHERE ID =@id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", venda.id);
            cmd.Parameters.AddWithValue("@id_funcionario", venda.id_funcionario);
            cmd.Parameters.AddWithValue("@id_cliente", venda.id_cliente);
            cmd.Parameters.AddWithValue("@data", venda.data);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DA VENDA");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM VENDAS " +
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
                Console.WriteLine("ERRO NO DELETE DA VENDA");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do delete
    }
}
