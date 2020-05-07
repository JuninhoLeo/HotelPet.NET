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
    public class FuncionarioDAL
    {
        private string strCon = ConexaoDAL.getConexao();
        public List<MODEL.Funcionario> Select()
        {
            List<MODEL.Funcionario> listFunc = new List<MODEL.Funcionario>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM FUNCIONARIOS";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Funcionario funcionario = new MODEL.Funcionario
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        nome = dados["nome"].ToString(),
                        rg = dados["rg"].ToString(),
                        cpf = dados["cpf"].ToString(),
                        endereco = dados["endereco"].ToString(),
                        uf = dados["uf"].ToString(),
                        permicaoID = Convert.ToInt32(dados["id_permicao"].ToString()),
                        userID = Convert.ToInt32(dados["id_user"].ToString())
                    };
                    listFunc.Add(funcionario);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO FUNCIONARIO");
            }
            finally
            {
                conexao.Close();
            }

            return listFunc;
        }// fim do select

        public MODEL.Funcionario Select(MODEL.Funcionario func)
        {
            MODEL.Funcionario listFunc = new MODEL.Funcionario();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM FUNCIONARIOS " +
                         "WHERE id= @id or nome= @nome or rg=@rg or cpf= @cpf or id_user= @id_user";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", func.id);
            cmd.Parameters.AddWithValue("@nome", func.nome);
            cmd.Parameters.AddWithValue("@rg", func.rg);
            cmd.Parameters.AddWithValue("@cpf", func.cpf);
            cmd.Parameters.AddWithValue("@id_user", func.userID);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Funcionario funcionario = new MODEL.Funcionario
                    {
                        id = Convert.ToInt32(dados["id"].ToString()),
                        nome = dados["nome"].ToString(),
                        rg = dados["rg"].ToString(),
                        cpf = dados["cpf"].ToString(),
                        endereco = dados["endereco"].ToString(),
                        uf = dados["uf"].ToString(),
                        permicaoID = Convert.ToInt32(dados["id_permicao"].ToString()),
                        userID = Convert.ToInt32(dados["id_user"].ToString())
                    };
                    listFunc = funcionario;
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO FUNCIONARIO");
            }
            finally
            {
                conexao.Close();
            }

            return listFunc;
        }// fim do select

        public void Insert(Camadas.MODEL.Funcionario funcionario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO FUNCIONARIOS(NOME, RG, CPF, ENDERECO, UF, ID_PERMICAO, ID_USER)" +
                         "VALUES (@nome, @rg, @cpf, @endereco, @uf, @id_permicao, @id_user)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@rg", funcionario.rg);
            cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
            cmd.Parameters.AddWithValue("@endereco", funcionario.endereco);
            cmd.Parameters.AddWithValue("@uf", funcionario.uf);
            cmd.Parameters.AddWithValue("@id_permicao", funcionario.permicaoID);
            cmd.Parameters.AddWithValue("@id_user", funcionario.userID);

            //try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            //catch
            {
           //     Console.WriteLine("ERRO NO INSERT DO FUNCIONARIO");
            }
           // finally
            {
                conexao.Close();
            }
        }//fim do insert

        public void Update(Camadas.MODEL.Funcionario funcionario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE FUNCIONARIOS " +
                         "SET NOME =@nome, RG =@rg, CPF =@cpf, ENDERECO= @endereco, UF=@uf, ID_PERMICAO= @permicao, ID_USER= @user " +
                         "WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", funcionario.id);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@rg", funcionario.rg);
            cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
            cmd.Parameters.AddWithValue("@endereco", funcionario.endereco);
            cmd.Parameters.AddWithValue("@uf", funcionario.uf);
            cmd.Parameters.AddWithValue("@permicao", funcionario.permicaoID);
            cmd.Parameters.AddWithValue("@user", funcionario.userID);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DO FUNCIONARIO");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM FUNCIONARIOS " +
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
                Console.WriteLine("ERRO NO DELETE DO FUNCIONARIO");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Delete
    }
}
