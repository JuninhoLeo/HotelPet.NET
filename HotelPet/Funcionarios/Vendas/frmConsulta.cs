using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Funcionarios.Vendas
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();
            if (rdProduto.Checked)
            {
                try
                {
                    long id = Convert.ToInt64(textBox1.Text.Trim());
                    var item = from prod in contexto.Produto.Where(x => x.codigo == id).ToList()
                               select new
                               {
                                   Código = prod.codigo,
                                   Descrição = prod.descricao,
                                   Qtde = prod.quantidade,
                                   Valor = prod.valor
                               };
                    dgvProdutos.DataSource = item.ToList();
                }
                catch (Exception)
                {
                    var item = from prod in contexto.Produto.Where(x => x.descricao.Contains(textBox1.Text.Trim().ToUpper())).ToList()
                               select new
                               {
                                   Código = prod.codigo,
                                   Descrição = prod.descricao,
                                   Qtde = prod.quantidade,
                                   Valor = prod.valor
                               };
                    dgvProdutos.DataSource = item.ToList();
                }

                dgvProdutos.Columns["Valor"].DefaultCellStyle.Format = "c";

            }
            else
            {
                try
                {
                    long id = Convert.ToInt64(textBox1.Text.Trim());
                    var item = from serv in contexto.Servico.Where(x => x.id == id && x.isQuarto == false).ToList()
                               select new
                               {
                                   Código = serv.id,
                                   Descrição = serv.descricao,
                                   Valor = serv.valor
                               };
                    dgvProdutos.DataSource = item.ToList();
                }
                catch (Exception)
                {
                    var item = from serv in contexto.Servico.Where(x => x.descricao.Contains(textBox1.Text.Trim().ToUpper()) && x.isQuarto == false).ToList()
                               select new
                               {
                                   Código = serv.id,
                                   Descrição = serv.descricao,
                                   Valor = serv.valor
                               };
                    dgvProdutos.DataSource = item.ToList();
                }

                dgvProdutos.Columns["Valor"].DefaultCellStyle.Format = "c";
            }
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            rdProduto.Checked = true;
        }
    }
}
