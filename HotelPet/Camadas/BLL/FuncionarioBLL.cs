using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class FuncionarioBLL
    {
        public void Select(MODEL.Funcionario funcionario)
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
