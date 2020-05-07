using HotelPet.Camadas.DAL;
using HotelPet.Camadas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class FuncionarioBLL
    {
        public void Insert(Funcionario funcionario, Usuario usuario, Permicoes permicoes)
        {
            FuncionarioDAL dalFunc = new FuncionarioDAL();
            UsuariosDAL dalUser = new UsuariosDAL();
            PermicoesDAL dalPerm = new PermicoesDAL();

            dalUser.Insert(usuario);
            usuario = dalUser.Select(usuario);

            permicoes.tipo = usuario.usuario;

            dalPerm.Insert(permicoes);
            permicoes = dalPerm.Select(permicoes);

            funcionario.permicaoID = permicoes.id;
            funcionario.userID = usuario.id;

            dalFunc.Insert(funcionario);

        }

        public List<Funcionario> Select()
        {
            FuncionarioDAL dal = new FuncionarioDAL();
            List<Funcionario> lst = dal.Select();

            return lst;
        }

        public void SelectUpd(MODEL.Funcionario funcionario)
        {
            MODEL.Funcionario func = new MODEL.Funcionario();
            DAL.FuncionarioDAL dalFunc = new DAL.FuncionarioDAL();
            func = dalFunc.Select(funcionario);

            if (func.id == 0)
            {                
                dalFunc.Insert(funcionario);
            }
            else
            {
                func.nome = funcionario.nome;
                func.rg = funcionario.rg;
                func.cpf = funcionario.cpf;
                func.endereco = funcionario.endereco;
                func.uf = funcionario.uf;
                func.permicaoID = funcionario.permicaoID;
                func.userID = funcionario.userID;

                dalFunc.Update(func);
            }

        }
    }
}
