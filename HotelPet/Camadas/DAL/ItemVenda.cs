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
    public class ItemVenda
    {
        private string strCon = Conexao.getConexao();

        public List<MODEL.Itemvenda> Select()
        {
            List<MODEL.Itemvenda> listaMovi = new List<MODEL.Itemvenda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM ITEMVENDA";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Itemvenda movimentacao = new MODEL.Itemvenda();
                    movimentacao.Id = Convert.ToInt32(dados["id"].ToString());
                    movimentacao.Id_venda = Convert.ToInt32(dados["id_venda"].ToString());
                    movimentacao.id_produto = Convert.ToInt32(dados["id_produto"].ToString());
                    movimentacao.quantidade = Convert.ToDouble(dados["quantidade"].ToString());
                    movimentacao.valor = Convert.ToDouble(dados["valor"].ToString());
                    listaMovi.Add(movimentacao);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO ITEM da VENDA");
            }
            finally
            {
                conexao.Close();
            }

            return listaMovi;
        }// FIM DO SELECT NORMAL

        public int SelectId()
        {
            List<MODEL.Itemvenda> listaMovi = new List<MODEL.Itemvenda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT ID FROM ITEMVENDA";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            int ID = 0;

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Itemvenda movimentacao = new MODEL.Itemvenda();
                    ID = Convert.ToInt32(dados["id"].ToString());                    
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO ITEM da VENDA");
            }
            finally
            {
                conexao.Close();
            }

            return ID;
        }// FIM DO SELECT ID

        public List<MODEL.Itemvenda> SelectMovi()
        {
            List<MODEL.Itemvenda> listaMovi = new List<MODEL.Itemvenda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT itemvenda.id_produto, prodserv.descricao, itemvenda.quantidade, (prodserv.valor* itemvenda.quantidade) "+
                         "FROM itemvenda " +
                         "INNER join prodserv on(itemvenda.id_produto = prodserv.id)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);


            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Itemvenda movimentacao = new MODEL.Itemvenda();
                    movimentacao.Id_venda = Convert.ToInt32(dados["Codigo"].ToString());
                    movimentacao.descricao = dados["Descricao"].ToString();
                    movimentacao.quantidade = Convert.ToDouble(dados["Quantidade"].ToString());
                    movimentacao.valor = Convert.ToDouble(dados["Valor"].ToString());
                    listaMovi.Add(movimentacao);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO LISTA DE MOVIMENTAÇÕES");
            }
            finally
            {
                conexao.Close();
            }

            return listaMovi;
        }// FIM DO SELECT MOVIMENTAÇÃO

        public double SelectTot(int cod)
        {
            List<MODEL.Itemvenda> listaMovi = new List<MODEL.Itemvenda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT SUM(prodserv.valor* itemvenda.quantidade) as Valor " +
                         "FROM itemvenda " +
                         "INNER join prodserv on(itemvenda.id_produto = prodserv.id) " +
                         "WHERE id_venda =@cod";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cod", cod);
            double total = 0;

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    total = Convert.ToDouble(dados["Valor"].ToString());
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO ITEM da VENDA");
            }
            finally
            {
                conexao.Close();
            }

            return total;
        }// FIM DO SELECT TOTAL

        public int SelectCount(int cod)
        {
            List<MODEL.Itemvenda> listaMovi = new List<MODEL.Itemvenda>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT SUM(QUANTIDADE) as quantidade " +
                         "FROM itemvenda " +
                         "WHERE id_venda =@cod";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@cod", cod);
            int total = 0;

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    total = Convert.ToInt32(dados["quantidade"].ToString());
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DA QUATIDADE");
            }
            finally
            {
                conexao.Close();
            }

            return total;
        }// FIM DO SELECT QUANTIDADE

        public void Insert(MODEL.Itemvenda movimentacao)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO ITEMVENDA(ID_VENDA, ID_PRODUTO, QUANTIDADE, VALOR) " +
                         "VALUES(@id_venda, @id_produto, @quantidade, @valor)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_venda", movimentacao.Id_venda);
            cmd.Parameters.AddWithValue("@id_produto", movimentacao.id_produto);
            cmd.Parameters.AddWithValue("@quantidade", movimentacao.quantidade);
            cmd.Parameters.AddWithValue("@valor", movimentacao.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DO ITEM");
            }
            finally
            {
                conexao.Close();
            }
        }// fim do insert 

        public void Update(MODEL.Itemvenda movimentacao)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE ITEMVENDA " +
                         "SET ID_VENDA =@id_venda, ID_PRODUTO =@id_produto, QUANTIDADE =@quantidade, VALOR =@valor " +
                         "WHERE ID= @id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", movimentacao.Id);
            cmd.Parameters.AddWithValue("@id_venda", movimentacao.Id_venda);
            cmd.Parameters.AddWithValue("@id_produto", movimentacao.id_produto);
            cmd.Parameters.AddWithValue("@quantidade", movimentacao.quantidade);
            cmd.Parameters.AddWithValue("@valor", movimentacao.valor);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE do ITEM");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM ITEMVENDA " +
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
                Console.WriteLine("ERRO NO DELETE DO ITEM");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do delete
    }
}
