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
    public class ClienteDAL
    {
        private string strCon = ConexaoDAL.getConexao();

        public List<MODEL.Cliente> Select()
        {
            List<MODEL.Cliente> listaCliente = new List<MODEL.Cliente>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM CLIENTES";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Cliente cliente = new MODEL.Cliente();
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    cliente.rg = dados["rg"].ToString();
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.uf = dados["uf"].ToString();
                    cliente.email = dados["telefone"].ToString();
                    cliente.telefone = dados["email"].ToString();
                    listaCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO CLIENTE");
            }
            finally
            {
                conexao.Close();
            }

            return listaCliente;
        }// fim do select

        public List<MODEL.Cliente> SelectConf(Cliente Cli)
        {
            List<MODEL.Cliente> listaCliente = new List<MODEL.Cliente>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT * FROM CLIENTES " +
                         "WHERE NOME Like '%"+Cli.nome+"%' ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Cliente cliente = new MODEL.Cliente();
                    cliente.id = Convert.ToInt32(dados["id"].ToString());
                    cliente.nome = dados["nome"].ToString();
                    cliente.cpf = dados["cpf"].ToString();
                    cliente.rg = dados["rg"].ToString();
                    cliente.cidade = dados["cidade"].ToString();
                    cliente.uf = dados["uf"].ToString();
                    cliente.email = dados["telefone"].ToString();
                    cliente.telefone = dados["email"].ToString();
                    listaCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO CLIENTE");
            }
            finally
            {
                conexao.Close();
            }

            return listaCliente;
        }// fim do select


        public List<MODEL.Cliente> SelectNome()
        {
            List<MODEL.Cliente> listaCliente = new List<MODEL.Cliente>();
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "SELECT nome, FROM CLIENTES";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Cliente cliente = new MODEL.Cliente();
                    cliente.nome = dados["nome"].ToString();
                    listaCliente.Add(cliente);
                }
            }
            catch
            {
                Console.WriteLine("ERRO NO SELECT DO CLIENTE");
            }
            finally
            {
                conexao.Close();
            }

            return listaCliente;
        }// fim do select

        public void Insert(MODEL.Cliente cliente)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "INSERT INTO CLIENTES(NOME, CPF, RG, CIDADE, UF, TELEFONE, EMAIL) " +
                         "VALUES(@nome, @cpf, @rg, @cidade, @uf, @telefone, @email)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@rg", cliente.rg);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@uf", cliente.uf);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@email", cliente.email);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO INSERT DO CLIENTE");
            }
            finally
            {
                conexao.Close(); 
            }
        }// fim do insert 

        public void Update(MODEL.Cliente cliente)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "UPDATE CLIENTES " +
                         "SET NOME =@nome, CPF =@cpf, RG =@rg, CIDADE =@cidade, UF =@uf, TELEFONE =@telefone, EMAIL =@email " +
                         "where ID =@id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", cliente.id);
            cmd.Parameters.AddWithValue("@nome", cliente.nome);
            cmd.Parameters.AddWithValue("@cpf", cliente.cpf);
            cmd.Parameters.AddWithValue("@rg", cliente.rg);
            cmd.Parameters.AddWithValue("@cidade", cliente.cidade);
            cmd.Parameters.AddWithValue("@uf", cliente.uf);
            cmd.Parameters.AddWithValue("@telefone", cliente.telefone);
            cmd.Parameters.AddWithValue("@email", cliente.email);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("ERRO NO UPDATE DO CLIENTE");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strCon);
            string sql = "DELETE FROM Clientes " +
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
                Console.WriteLine("ERRO NO DELETE DO CLIENTE");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do delete

    }
}   
