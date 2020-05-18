using HotelPet.Camadas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja Salvar as alterações deste documento antes do fechar? " +
                                                   "Clique em Sim para salvar e fechar", "Deseja Salvar?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (confirm.ToString().ToUpper() == "YES")
            {
                //Camadas.DAL.ClienteDAL lista = new Camadas.DAL.ClienteDAL();
                Camadas.MODEL.Cliente cliente = new Camadas.MODEL.Cliente();
                cliente.nome = txtNome.Text;
                cliente.cpf = txtCPF.Text;
                cliente.rg = txtRG.Text;
                cliente.cidade = txtCidade.Text;
                cliente.uf = txtUF.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;
                //lista.Insert(cliente);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "Digite aqui o Nome do funcionario:")
            {
                txtBusca.ForeColor = Color.Black;
                txtBusca.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                txtBusca.ForeColor = Color.DarkGray;
                txtBusca.Text = "Digite aqui o Nome do funcionario:";
            }
        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            //ClienteDAL dal = new ClienteDAL();
            Cliente cliente = new Cliente();

            cliente.nome = txtBusca.Text;

            dgvCliente.DataSource = "";
            //dgvCliente.DataSource = dal.SelectConf(cliente);
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            //ClienteDAL dal = new ClienteDAL();

            dgvCliente.DataSource = "";
            //dgvCliente.DataSource = dal.Select();
        }
    }
}
