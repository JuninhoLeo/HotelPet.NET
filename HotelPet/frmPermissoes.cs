using HotelPet.Camadas.DAL;
using HotelPet.Camadas.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmPermissoes : Form
    {
        public delegate void InvokeDelegate();

        public frmPermissoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HabilitaCampos(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPermissoes_Load(object sender, EventArgs e)
        {
            //frmLogin login = new frmLogin();
            //login.ShowDialog();
            
            //if (login.DialogResult == DialogResult.Cancel)
            {
              //  BeginInvoke(new InvokeDelegate(confirm));
            }

            FuncionarioDAL dal = new FuncionarioDAL();
            dgvPermicoes.DataSource = "";
            dgvPermicoes.DataSource = dal.Select();

            HabilitaCampos(true);
            checkPwd.Checked = true;

        }

        private void confirm()
        {
            MdiParent.MainMenuStrip.Enabled = true;
            this.Visible = false;
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            PermicoesDAL dal = new PermicoesDAL();
            Permicoes permicoes = new Permicoes();



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkPwd.Checked)
            {
                txtSenha.PasswordChar = '*';
            }
            else
            {
                txtSenha.PasswordChar = '\0';
            }
        }

        public void HabilitaCampos(bool campo)
        {
            txtUser.Enabled = campo;
            txtSenha.Enabled = campo;
            txtNome.Enabled = campo;
            txtRG.Enabled = campo;
            txtCPF.Enabled = campo;
            txtEndereco.Enabled = campo;
            txtUF.Enabled = campo;
            checkPwd.Enabled = campo;

            gpbVendas.Enabled = campo;
            gpbClientes.Enabled = campo;
            gpbProdutos.Enabled = campo;
            gpbServicos.Enabled = campo;
            gpbFuncionarios.Enabled = campo;
            gpbHotel.Enabled = campo;
            gpbClinica.Enabled = campo;
            gpbConfig.Enabled = campo;
        }

        private void dgvPermicoes_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["userID"].Value.ToString());
            
            UsuariosDAL dal = new UsuariosDAL();
            Usuario usuario = dal.Select(id);

            txtUser.Text = usuario.usuario;
            txtNome.Text = dgvPermicoes.SelectedRows[0].Cells["nome"].Value.ToString();
            txtRG.Text = dgvPermicoes.SelectedRows[0].Cells["rg"].Value.ToString();
            txtCPF.Text = dgvPermicoes.SelectedRows[0].Cells["cpf"].Value.ToString();
            txtEndereco.Text = dgvPermicoes.SelectedRows[0].Cells["endereco"].Value.ToString();
            txtUF.Text = dgvPermicoes.SelectedRows[0].Cells["uf"].Value.ToString();
            checkPwd.Enabled = true;

        }

    }
}
