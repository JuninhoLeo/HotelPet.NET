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
    class Permicoes
    {
        private string strcon = Conexao.getConexao();

        public List<MODEL.Permissoes> Select()
        {
            List<MODEL.Permissoes> listPermicoes = new List<MODEL.Permissoes>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PERMICOES";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Permissoes permicoes = new MODEL.Permissoes();
                    permicoes.id = Convert.ToInt32(dados["id"].ToString());
                    permicoes.tipo = dados["tipo"].ToString();
                    permicoes.frmvendas = Convert.ToBoolean(dados["frmvenda"].ToString());
                    permicoes.frmclientes = Convert.ToBoolean(dados["frmcliente"].ToString());
                    permicoes.frmprodutos = Convert.ToBoolean(dados["frmprodutos"].ToString());
                    permicoes.frmservicos = Convert.ToBoolean(dados["frmservicos"].ToString());
                    permicoes.frmfuncionarios = Convert.ToBoolean(dados["frmfuncionarios"].ToString());
                    listPermicoes.Add(permicoes);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DA PERMICAO");
            }
            finally
            {
                conexao.Close();
            }

            return listPermicoes;
        }//FIM DO SELECT

        public void Insert(MODEL.Permissoes permicoes)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO PERMICOES (TIPO, FRMVENDA, FRMCLIENTE, FRMPRODUTOS, FRMSERVICOS, FRMFUNCIONARIOS) " +
                         "VALUES(@tipo, @frmvenda, @frmcliente, @frmprodutos, @frmservicos, @funcionarios)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@tipo", permicoes.tipo);
            cmd.Parameters.AddWithValue("@frmvenda", permicoes.frmvendas);
            cmd.Parameters.AddWithValue("@frmcliente", permicoes.frmclientes);
            cmd.Parameters.AddWithValue("@frmprodutos", permicoes.frmprodutos);
            cmd.Parameters.AddWithValue("@frmservicos", permicoes.frmservicos);
            cmd.Parameters.AddWithValue("@frmfuncionarios", permicoes.frmfuncionarios);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DA PERMICAO");
            }
            finally
            {
                conexao.Close();
            }
        }// FIM DO INSERT

        public void Update(MODEL.Permissoes permicoes)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE PERMICOES SET TIPO =@tipo, FRMVENDA =@frmvenda, FRMCLIENTE =@frmcliente, FRMPRODUTOS =@frmprodutos, FRMSERVICOS =@frmservicos, FRMFUNCIONARIOS =@frmfuncionarios " +
                         "WHERE ID =@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", permicoes.id);
            cmd.Parameters.AddWithValue("@tipo", permicoes.tipo);
            cmd.Parameters.AddWithValue("@frmvenda", permicoes.frmvendas);
            cmd.Parameters.AddWithValue("@frmcliente", permicoes.frmclientes);
            cmd.Parameters.AddWithValue("@frmprodutos", permicoes.frmprodutos);
            cmd.Parameters.AddWithValue("@frmservicos", permicoes.frmservicos);
            cmd.Parameters.AddWithValue("@frmfuncionarios", permicoes.frmfuncionarios);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DA PERMICAO");
            }
            finally
            {
                conexao.Close();
            }

        }//FIM DO UPDATE

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM PERMICOES " +
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
                Console.WriteLine("ERRO NO DELETE DA PERMICAO");
            }
            finally
            {
                conexao.Close();
            }
        }//FIM DO DELETE

    }
}
