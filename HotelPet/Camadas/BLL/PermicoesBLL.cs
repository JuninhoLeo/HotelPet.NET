using HotelPet.Camadas.DAL;
using HotelPet.Camadas.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPet.Camadas.BLL
{
    class PermicoesBLL
    {
        public List<Permicoes> Select()
        {
            PermicoesDAL dal = new PermicoesDAL();
            List<Permicoes> lst = dal.Select();

            return lst;
        }

        public int Insert(Permicoes permicoes)
        {
            PermicoesDAL dal = new PermicoesDAL();
            dal.Insert(permicoes);
            permicoes = dal.Select(permicoes);

            return permicoes.id;
        }

        public Permicoes Select(Funcionario func, Permicoes lst)
        {
            PermicoesDAL permicoes = new PermicoesDAL();
            FuncionarioDAL dalfunc = new FuncionarioDAL();
            Funcionario funcionario = dalfunc.Select(func);

            if (funcionario.id != 0)
            {
                permicoes.Update(funcionario, lst);
                return permicoes.Select(funcionario);
            }
            else
            {
                lst.tipo = func.nome;
                lst.frmclientes = true;
                lst.frmConfig = true;
                lst.frmfuncionarios = true;
                lst.frmprodutos = true;
                lst.frmservicos = true;
                lst.frmvendas = true;
                lst.frmhotel = true;
                lst.frmclinica = true;

                permicoes.Insert(lst);
                return permicoes.Select(func);
            }
        }

        public Permicoes Select(Funcionario func)
        {
            PermicoesDAL permicoes = new PermicoesDAL();
            FuncionarioDAL dalfunc = new FuncionarioDAL();
            Funcionario funcionario = dalfunc.Select(func);
            Permicoes lst = new Permicoes();

            if (funcionario.id != 0)
            {
                return permicoes.Select(funcionario);
            }
            else
            {
                lst.tipo = func.nome;
                lst.frmclientes = true;
                lst.frmConfig = true;
                lst.frmfuncionarios = true;
                lst.frmprodutos = true;
                lst.frmservicos = true;
                lst.frmvendas = true;
                lst.frmhotel = true;
                lst.frmclinica = true;

                permicoes.Insert(lst);
                return permicoes.Select(func);
            }
        }

        public Permicoes Select(int id)
        {
            PermicoesDAL dal = new PermicoesDAL();
            return dal.Select(id);
        }

    }
}
