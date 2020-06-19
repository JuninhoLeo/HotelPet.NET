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
                    var item = contexto.Produto.Where(x => x.codigo == id).ToList();
                    dgvProdutos.DataSource = item;
                }
                catch (Exception)
                {
                    var item = contexto.Produto.Where(x => x.descricao.Contains(textBox1.Text.Trim().ToUpper())).ToList();
                    dgvProdutos.DataSource = item;
                }
            }
            else
            {
                try
                {
                    long id = Convert.ToInt64(textBox1.Text.Trim());
                    var item = contexto.Servico.Where(x => x.id == id).ToList();
                    dgvProdutos.DataSource = item;
                }
                catch (Exception)
                {
                    var item = contexto.Servico.Where(x => x.descricao.Contains(textBox1.Text.Trim().ToUpper())).ToList();
                    dgvProdutos.DataSource = item;
                }
            }
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            rdProduto.Checked = true;
        }
    }
}
