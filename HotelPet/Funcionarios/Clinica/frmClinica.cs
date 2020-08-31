using HotelPet.Camadas.MODEL;
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

namespace HotelPet.Funcionarios.Clinica
{
    public partial class frmClinica : Form
    {
        private readonly int idFunc;
        public frmClinica(int idFunc)
        {
            InitializeComponent();
            this.idFunc = idFunc;
        }

        public frmClinica()
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private readonly Contexto contexto = new Contexto();

        private void frmClinica_Load(object sender, EventArgs e)
        {
            cmbClientes.Text = "";
            cmbClientes.DisplayMember = "nome";
            cmbClientes.ValueMember = "id";
            cmbClientes.DataSource = contexto.Cliente.Where(x=> x.nome.Trim() != "").ToList();
        }

        private void cmbClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbClientes.SelectedValue);
            var lstAni = contexto.Animal.Where(x=> x.Cliente_id == id).ToList();

            cmbAnimais.Text = "";
            cmbAnimais.DataSource = lstAni;
            cmbAnimais.DisplayMember = "nome";
            cmbAnimais.ValueMember = "id";
            cmbAnimais.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Contexto contexto = new Contexto();
                Funcionario funcionario = contexto.Funcionario.FirstOrDefault(x => x.Usuario_id == idFunc);
                int cliente = Convert.ToInt32(cmbClientes.SelectedValue);
                int animal = Convert.ToInt32(cmbAnimais.SelectedValue);
                string conteudo = txtConteudo.Text;
                string tipo = (rdbReceita.Checked) ? "RECEITUÁRIO" : "ATESTADO"; 

                frmTelaImpressao frm = new frmTelaImpressao(funcionario.nome, conteudo, cliente, animal, tipo);
                frm.ShowDialog();

            }
            catch
            {

            }
        }

        public int idCliente { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            Consulta frmConsulta = new Consulta(this);
            frmConsulta.ShowDialog();
            cmbClientes.SelectedValue = idCliente;
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void data_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vendas.frmConsultaProdutos frm = new Vendas.frmConsultaProdutos();
            frm.ShowDialog();
        }
    }
}
