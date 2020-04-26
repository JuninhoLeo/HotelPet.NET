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
    public class Funcionario
    {
        private string strCon = Conexao.getConexao();
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
                    MODEL.Funcionario funcionario = new MODEL.Funcionario();
                    funcionario.id = Convert.ToInt32(dados["id"].ToString());
                    funcionario.nome = dados["nome"].ToString();
                    funcionario.rg = dados["rg"].ToString();
                    funcionario.cpf = dados["cpf"].ToString();
                    funcionario.endereco = dados["endereco"].ToString();
                    funcionario.uf = dados["uf"].ToString();
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

        public void Insert(Camadas.MODEL.Funcionario funcionario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO FUNCIONARIOS(NOME, RG, CPF, ENDERECO, UF)" +
                         "VALUES (@nome, @rg, @cpf, @endereco, @uf)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@rg", funcionario.rg);
            cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
            cmd.Parameters.AddWithValue("@endereco", funcionario.endereco);
            cmd.Parameters.AddWithValue("@uf", funcionario.uf);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DO FUNCIONARIO");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do insert

        public void Update(Camadas.MODEL.Funcionario funcionario)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE FUNCIONARIOS " +
                         "SET NOME =@nome, RG =@rg, CPF =@cpf, ENDERECO= @endereco, UF=@uf " +
                         "WHERE id=@id";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", funcionario.id);
            cmd.Parameters.AddWithValue("@nome", funcionario.nome);
            cmd.Parameters.AddWithValue("@rg", funcionario.rg);
            cmd.Parameters.AddWithValue("@cpf", funcionario.cpf);
            cmd.Parameters.AddWithValue("@endereco", funcionario.endereco);
            cmd.Parameters.AddWithValue("@uf", funcionario.uf);

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
