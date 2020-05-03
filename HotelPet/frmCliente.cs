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
                Camadas.DAL.ClienteDAL lista = new Camadas.DAL.ClienteDAL();
                Camadas.MODEL.Cliente cliente = new Camadas.MODEL.Cliente();
                cliente.nome = txtNome.Text;
                cliente.cpf = txtCPF.Text;
                cliente.rg = txtRG.Text;
                cliente.cidade = txtCidade.Text;
                cliente.uf = txtUF.Text;
                cliente.telefone = txtTelefone.Text;
                cliente.email = txtEmail.Text;
                lista.Insert(cliente);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
