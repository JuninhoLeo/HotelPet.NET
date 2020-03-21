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
    class ProdutoServicos
    {
        private string strcon = Conexao.getConexao();

        public List<MODEL.Produtos_Servicos> Select()
        {
            List<MODEL.Produtos_Servicos> listProdServ = new List<MODEL.Produtos_Servicos>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PRODSERV";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Produtos_Servicos prodServ = new MODEL.Produtos_Servicos();
                    prodServ.id = Convert.ToInt32(dados["id"].ToString());
                    prodServ.descricao = dados["descricao"].ToString();
                    prodServ.quantidade = Convert.ToDouble(dados["quantidade"].ToString());
                    prodServ.valor = Convert.ToDouble(dados["valor"].ToString());
                    listProdServ.Add(prodServ);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO PRODUTO OU SERVIÇO");
            }
            finally
            {
                conexao.Close();
            }

            return listProdServ;

        }//FIM DO SELECT

        public void Insert(MODEL.Produtos_Servicos ProdServ)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO PRODSERV (DESCRICAO, QUANTIDADE, VALOR) " +
                         "VALUES(@descricao, @quantidade, @valor) ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@descricao", ProdServ.descricao);
            cmd.Parameters.AddWithValue("@quantidade", ProdServ.descricao);
            cmd.Parameters.AddWithValue("@valor", ProdServ.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch 
            {
                Console.WriteLine("ERRO NO INSERT DO PRODUTO OU SERVIÇO");
            }
            finally
            {
                conexao.Close();
            }
        }//FIM DO INSERT

        public void Update(MODEL.Produtos_Servicos ProdServ)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE PRODSERV SET DESCRICAO =@descricao, QUANTIDADE =@quantidade, VALOR =@valor " +
                         "WHERE ID =@id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", ProdServ.id);
            cmd.Parameters.AddWithValue("@descricao", ProdServ.descricao);
            cmd.Parameters.AddWithValue("@quantidade", ProdServ.quantidade);
            cmd.Parameters.AddWithValue("@valor", ProdServ.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DO PRDUTO OU SERVIÇO");
            }
            finally
            {
                conexao.Close();
            }

        }// FIM DO UPDATE

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM PRODSERV " +
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
                Console.WriteLine("ERRO NO DELETE DO PRODUTO OU SERVIÇO");
            }
            finally
            {
                conexao.Close();
            }

        }// FIM DO DELETE

    }
}
