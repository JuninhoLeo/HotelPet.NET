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
    class AnimalDAL
    {
        private string strcon = ConexaoDAL.getConexao();

        public List<MODEL.Animal> Select()
        {
            List<MODEL.Animal> listAnimal = new List<MODEL.Animal>();
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "SELECT * FROM ANIMAIS";
            
            MySqlCommand cmd = new MySqlCommand(sql, conexao);

            try
            {
                conexao.Open();
                MySqlDataReader dados = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dados.Read())
                {
                    MODEL.Animal animal = new MODEL.Animal();
                    animal.id = Convert.ToInt32(dados["id"].ToString());
                    animal.idcli = Convert.ToInt32(dados["id_cliente"].ToString());
                    animal.nascimento = Convert.ToDateTime(dados["nascimento"].ToString());
                    animal.nascpai = Convert.ToDateTime(dados["nascpai"].ToString());
                    animal.nascmae = Convert.ToDateTime(dados["nascmae"].ToString());
                    animal.especie = dados["especie"].ToString();
                    animal.raca = dados["raca"].ToString();
                    animal.pelagem = dados["pelagem"].ToString();
                    animal.cor = dados["cor"].ToString();
                    animal.porte = dados["porte"].ToString();
                    animal.sexo = dados["sexo"].ToString();
                    animal.apelido = dados["apelido"].ToString();
                    animal.nome = dados["nome"].ToString();
                    animal.pai = dados["pai"].ToString();
                    animal.mae = dados["mae"].ToString();
                    animal.observacoes = dados["observacoes"].ToString();
                    animal.cuidados = dados["cuidados"].ToString();
                    listAnimal.Add(animal);
                }
            }
            catch
            {
                Console.WriteLine("Deu erro no SELECT DO ANIMAL....");
            }
            finally
            {
                conexao.Close();
            }

            return listAnimal;
        }// FIM DO SELECT.....

        public void Insert(MODEL.Animal animal)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "INSERT INTO ANIMAIS (ID_CLIENTE, NASCIMENTO, NASCPAI, NASCMAE, ESPECIE, RACA, PELAGEM, COR, PORTE, SEXO, APELIDO, NOME, PAI, MAE, OBSERVACOES, CUIDADOS) " +
                         "values (@id_cliente, @nascimento, @nascpai, @nascmae, @especie, @raca, @pelagem, @cor, @porte, @sexo, @apelido, @nome, @pai, @mae, @observacoes, @cuidados) ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id_cliente", animal.idcli);
            cmd.Parameters.AddWithValue("@nascimento", animal.nascimento);
            cmd.Parameters.AddWithValue("nascpai", animal.nascpai);
            cmd.Parameters.AddWithValue("@nascmae", animal.nascmae);
            cmd.Parameters.AddWithValue("@especie", animal.especie);
            cmd.Parameters.AddWithValue("@raca", animal.raca);
            cmd.Parameters.AddWithValue("@pelagem", animal.pelagem);
            cmd.Parameters.AddWithValue("@cor", animal.cor);
            cmd.Parameters.AddWithValue("@porte", animal.porte);
            cmd.Parameters.AddWithValue("@sexo", animal.sexo);
            cmd.Parameters.AddWithValue("@apelido", animal.apelido);
            cmd.Parameters.AddWithValue("@nome", animal.nome);
            cmd.Parameters.AddWithValue("@pai", animal.pai);
            cmd.Parameters.AddWithValue("@mae", animal.mae);
            cmd.Parameters.AddWithValue("@observacoes", animal.observacoes);
            cmd.Parameters.AddWithValue("@cuidados", animal.cuidados);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO NO INSERT DO ANIMAL......");
            }
            finally
            {
                conexao.Close();
            }
        } //FIM DO INSERT

        public void Update(MODEL.Animal animal)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "UPDATE ANIMAIS " +
                         "SET id_cliente=@id_cliente, nascimento=@nascimento, nascpai=@nascpai, nascmae=@nascmae, especie=@especie, raca=@raca, pelagem=@pelagem, cor=@cor, porte=@porte, sexo=@sexo, apelido=@apelido, nome=@nome, pai=@pai, mae=@mae, observacoes=@observacoes, cuidados=@cuidados " +
                         "WHERE ID = @id";
            
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", animal.id);
            cmd.Parameters.AddWithValue("@id_cliente", animal.idcli);
            cmd.Parameters.AddWithValue("@nascimento", animal.nascimento);
            cmd.Parameters.AddWithValue("nascpai", animal.nascpai);
            cmd.Parameters.AddWithValue("@nascmae", animal.nascmae);
            cmd.Parameters.AddWithValue("@especie", animal.especie);
            cmd.Parameters.AddWithValue("@raca", animal.raca);
            cmd.Parameters.AddWithValue("@pelagem", animal.pelagem);
            cmd.Parameters.AddWithValue("@cor", animal.cor);
            cmd.Parameters.AddWithValue("@porte", animal.porte);
            cmd.Parameters.AddWithValue("@sexo", animal.sexo);
            cmd.Parameters.AddWithValue("@apelido", animal.apelido);
            cmd.Parameters.AddWithValue("@nome", animal.nome);
            cmd.Parameters.AddWithValue("@pai", animal.pai);
            cmd.Parameters.AddWithValue("@mae", animal.mae);
            cmd.Parameters.AddWithValue("@observacoes", animal.observacoes);
            cmd.Parameters.AddWithValue("@cuidados", animal.cuidados);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO no UPDATE do ANIMAL......");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Update

        public void Delete(int id)
        {
            MySqlConnection conexao = new MySqlConnection(strcon);
            string sql = "DELETE FROM ANIMAIS" +
                         "WHERE id=@id ";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("DEU ERRO no DELETE do ANIMAL");
            }
            finally
            {
                conexao.Close();
            }
        }//fim do Delete
    }
}
