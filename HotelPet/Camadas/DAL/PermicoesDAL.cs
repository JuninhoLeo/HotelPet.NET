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
    class PermicoesDAL
    {
        private string strcon = ConexaoDAL.getConexao();

        public List<MODEL.Permicoes> Select()
        {
            List<MODEL.Permicoes> listPermicoes = new List<MODEL.Permicoes>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PERMICOES";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    Permicoes permicoes = new Permicoes
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        tipo = dados["tipo"].ToString(),
                        frmvendas = Convert.ToBoolean(dados["frmvenda"].ToString()),
                        frmclientes = Convert.ToBoolean(dados["frmcliente"].ToString()),
                        frmprodutos = Convert.ToBoolean(dados["frmprodutos"].ToString()),
                        frmservicos = Convert.ToBoolean(dados["frmservicos"].ToString()),
                        frmfuncionarios = Convert.ToBoolean(dados["frmfuncionarios"].ToString()),
                        frmConfig = Convert.ToBoolean(dados["frmConfiguracoes"].ToString()),
                        frmhotel = Convert.ToBoolean(dados["frmhotel"].ToString()),
                        frmclinica = Convert.ToBoolean(dados["frmclinica"].ToString())

                    };
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

        public Permicoes Select(int id)
        {
            Permicoes listPermicoes = new Permicoes();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PERMICOES " +
                         "WHERE id =@id";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    Permicoes permicoes = new Permicoes
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        tipo = dados["tipo"].ToString(),
                        frmvendas = Convert.ToBoolean(dados["frmvenda"].ToString()),
                        frmclientes = Convert.ToBoolean(dados["frmcliente"].ToString()),
                        frmprodutos = Convert.ToBoolean(dados["frmprodutos"].ToString()),
                        frmservicos = Convert.ToBoolean(dados["frmservicos"].ToString()),
                        frmfuncionarios = Convert.ToBoolean(dados["frmfuncionarios"].ToString()),
                        frmConfig = Convert.ToBoolean(dados["frmConfiguracoes"].ToString()),
                        frmhotel = Convert.ToBoolean(dados["frmhotel"].ToString()),
                        frmclinica = Convert.ToBoolean(dados["frmclinica"].ToString())
                        
                    };
                    listPermicoes = permicoes;
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

        public Permicoes Select(Permicoes permi)
        {
            Permicoes listPermicoes = new Permicoes();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PERMICOES " +
                         "WHERE tipo =@tipo";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@tipo", permi.tipo);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    Permicoes permicoes = new Permicoes
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        tipo = dados["tipo"].ToString(),
                        frmvendas = Convert.ToBoolean(dados["frmvenda"].ToString()),
                        frmclientes = Convert.ToBoolean(dados["frmcliente"].ToString()),
                        frmprodutos = Convert.ToBoolean(dados["frmprodutos"].ToString()),
                        frmservicos = Convert.ToBoolean(dados["frmservicos"].ToString()),
                        frmfuncionarios = Convert.ToBoolean(dados["frmfuncionarios"].ToString()),
                        frmConfig = Convert.ToBoolean(dados["frmConfiguracoes"].ToString()),
                        frmhotel = Convert.ToBoolean(dados["frmhotel"].ToString()),
                        frmclinica = Convert.ToBoolean(dados["frmclinica"].ToString())

                    };
                    listPermicoes = permicoes;
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

        public Permicoes Select(Funcionario func)
        {
            Permicoes listPermicoes = new Permicoes();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM PERMICOES " +
                         "Where id= @id or tipo=@nome";

            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", func.permicaoID);
            cmd.Parameters.AddWithValue("@nome", func.nome);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    Permicoes permicoes = new Permicoes
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        tipo = dados["tipo"].ToString(),
                        frmvendas = Convert.ToBoolean(dados["frmvenda"].ToString()),
                        frmclientes = Convert.ToBoolean(dados["frmcliente"].ToString()),
                        frmprodutos = Convert.ToBoolean(dados["frmprodutos"].ToString()),
                        frmservicos = Convert.ToBoolean(dados["frmservicos"].ToString()),
                        frmfuncionarios = Convert.ToBoolean(dados["frmfuncionarios"].ToString()),
                        frmConfig = Convert.ToBoolean(dados["frmConfiguracoes"].ToString()),
                        frmhotel = Convert.ToBoolean(dados["frmhotel"].ToString()),
                        frmclinica = Convert.ToBoolean(dados["frmclinica"].ToString())

                    };
                    listPermicoes = permicoes;
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


        public void Insert(MODEL.Permicoes permicoes)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO PERMICOES (TIPO, FRMVENDA, FRMCLIENTE, FRMPRODUTOS, FRMSERVICOS, FRMFUNCIONARIOS, FRMCONFIGURACOES, FRMHOTEL, FRMCLINICA) " +
                         "VALUES(@tipo, @frmvenda, @frmcliente, @frmprodutos, @frmservicos, @frmfuncionarios, @frmconfig, @frmhotel, @frmclinica)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@tipo", permicoes.tipo);
            cmd.Parameters.AddWithValue("@frmvenda", permicoes.frmvendas);
            cmd.Parameters.AddWithValue("@frmcliente", permicoes.frmclientes);
            cmd.Parameters.AddWithValue("@frmprodutos", permicoes.frmprodutos);
            cmd.Parameters.AddWithValue("@frmservicos", permicoes.frmservicos);
            cmd.Parameters.AddWithValue("@frmfuncionarios", permicoes.frmfuncionarios);
            cmd.Parameters.AddWithValue("@frmconfig", permicoes.frmConfig);
            cmd.Parameters.AddWithValue("@frmhotel", permicoes.frmhotel);
            cmd.Parameters.AddWithValue("@frmclinica", permicoes.frmclinica);

            //try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
           // catch
            {
              //  Console.WriteLine("ERRO NO INSERT DA PERMICAO");
            }
            //finally
            {
                conexao.Close();
            }
        }// FIM DO INSERT

        public void Update(MODEL.Permicoes permicoes)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE PERMICOES SET TIPO =@tipo, FRMVENDA =@frmvenda, FRMCLIENTE =@frmcliente, FRMPRODUTOS =@frmprodutos, FRMSERVICOS =@frmservicos, FRMFUNCIONARIOS =@frmfuncionarios, FRMCONFIGURACOES =@frmconfig, FRMHOTEL=@frmhotel, FRMCLINICA=@frmclinica " +
                         "WHERE ID =@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", permicoes.id);
            cmd.Parameters.AddWithValue("@tipo", permicoes.tipo);
            cmd.Parameters.AddWithValue("@frmvenda", permicoes.frmvendas);
            cmd.Parameters.AddWithValue("@frmcliente", permicoes.frmclientes);
            cmd.Parameters.AddWithValue("@frmprodutos", permicoes.frmprodutos);
            cmd.Parameters.AddWithValue("@frmservicos", permicoes.frmservicos);
            cmd.Parameters.AddWithValue("@frmfuncionarios", permicoes.frmfuncionarios);
            cmd.Parameters.AddWithValue("@frmconfig", permicoes.frmConfig);
            cmd.Parameters.AddWithValue("@frmhotel", permicoes.frmhotel);
            cmd.Parameters.AddWithValue("@frmclinica", permicoes.frmclinica);

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

        public void Update(Funcionario funcionario, Permicoes permicoes)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE PERMICOES SET TIPO =@tipo, FRMVENDA =@frmvenda, FRMCLIENTE =@frmcliente, FRMPRODUTOS =@frmprodutos, FRMSERVICOS =@frmservicos, FRMFUNCIONARIOS =@frmfuncionarios, FRMCONFIGURACOES =@frmconfig, FRMHOTEL=@frmhotel, FRMCLINICA=@frmclinica " +
                         "WHERE ID =@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", funcionario.permicaoID);
            cmd.Parameters.AddWithValue("@tipo", permicoes.tipo);
            cmd.Parameters.AddWithValue("@frmvenda", permicoes.frmvendas);
            cmd.Parameters.AddWithValue("@frmcliente", permicoes.frmclientes);
            cmd.Parameters.AddWithValue("@frmprodutos", permicoes.frmprodutos);
            cmd.Parameters.AddWithValue("@frmservicos", permicoes.frmservicos);
            cmd.Parameters.AddWithValue("@frmfuncionarios", permicoes.frmfuncionarios);
            cmd.Parameters.AddWithValue("@frmconfig", permicoes.frmConfig);
            cmd.Parameters.AddWithValue("@frmhotel", permicoes.frmhotel);
            cmd.Parameters.AddWithValue("@frmclinica", permicoes.frmclinica);

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
