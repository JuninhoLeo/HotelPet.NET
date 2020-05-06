﻿using HotelPet.Camadas.BLL;
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
            Atualizabtn(false);
            btnExcluir.Enabled = false;
            btnConfirm.Enabled = false;
            LimpaCampos();
        }

        private void Atualizabtn(bool action)
        {
            dgvPermicoes.Visible = action;
            txtBusca.Enabled = action;
            btnExcluir.Enabled = action;
            btnConfirm.Enabled = !action;
            btnNovo.Enabled = action;
            btnBusca.Enabled = !action;
            btnConfirm.Enabled = !action;
            btnExcluir.Enabled = !action;
            btnGravar.Enabled = !action;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            AtualizaView();

            Atualizabtn(true);
            HabilitaCampos(false);

        }

        private void confirm()
        {
            MdiParent.MainMenuStrip.Enabled = true;
            this.Visible = false;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkPwd.Checked)
            {
                txtSenha.PasswordChar = 'x';
            }
            else
            {
                txtSenha.PasswordChar = '\0';
            }
        }

        private void HabilitaCampos(bool campo)
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
            HabilitaCampos(true);
            btnConfirm.Enabled = true;
            btnBusca.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;

            int idUsr = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["userID"].Value.ToString());
            int id = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["id"].Value.ToString());

            UsuariosDAL dal = new UsuariosDAL();
            Usuario usuario = dal.Select(idUsr);
            Funcionario func = new Funcionario
            {
                id = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["id"].Value.ToString()),
                nome = dgvPermicoes.SelectedRows[0].Cells["nome"].Value.ToString(),
                rg = dgvPermicoes.SelectedRows[0].Cells["rg"].Value.ToString(),
                cpf = dgvPermicoes.SelectedRows[0].Cells["cpf"].Value.ToString(),
                endereco = dgvPermicoes.SelectedRows[0].Cells["endereco"].Value.ToString(),
                uf = dgvPermicoes.SelectedRows[0].Cells["uf"].Value.ToString(),
                userID = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["userID"].Value.ToString()),
                permicaoID = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["permicaoID"].Value.ToString())
            };

            PermicoesBLL bll = new PermicoesBLL();
            Permicoes tipo = bll.Select(func.permicaoID);

            lblAviso.Text = "*Vazio para manter a mesma senha, ou digite uma nova para redefinir";
            txtUser.Text = usuario.usuario;
            txtNome.Text = dgvPermicoes.SelectedRows[0].Cells["nome"].Value.ToString();
            txtRG.Text = dgvPermicoes.SelectedRows[0].Cells["rg"].Value.ToString();
            txtCPF.Text = dgvPermicoes.SelectedRows[0].Cells["cpf"].Value.ToString();
            txtEndereco.Text = dgvPermicoes.SelectedRows[0].Cells["endereco"].Value.ToString();
            txtUF.Text = dgvPermicoes.SelectedRows[0].Cells["uf"].Value.ToString();
            AtualizaRdb(tipo);

        }

        private void AtualizaRdb(Permicoes permicao)
        {
            _ = permicao.frmvendas == true ? rdbVendSim.Checked = true : rdbVendNao.Checked = true;
            _ = permicao.frmclientes == true ? rdbCliSim.Checked = true : rdbCliNao.Checked = true;
            _ = permicao.frmprodutos == true ? rdbProdSim.Checked = true : rdbProdNao.Checked = true;
            _ = permicao.frmservicos == true ? rdbServSim.Checked = true : rdbServNao.Checked = true;
            _ = permicao.frmfuncionarios == true ? rdbFuncSim.Checked = true : rdbFuncNao.Checked = true;
            _ = permicao.frmConfig == true ? rdbConfigSim.Checked = true : rdbConfigNao.Checked = true;
            _ = permicao.frmhotel == true ? rdbHotelSim.Checked = true : rdbHotelNao.Checked = true;
            _ = permicao.frmclinica == true ? rdbClinSim.Checked = true : rdbClinNao.Checked = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string pass = txtSenha.Text.Trim();
            byte[] passtohash = Encoding.UTF8.GetBytes(pass);

            Usuario usuario = new Usuario();
            Funcionario funcionario = new Funcionario();
            Permicoes permicao = new Permicoes();

            UsuarioBLL bllUser = new UsuarioBLL();
            FuncionarioBLL bllFunc = new FuncionarioBLL();
            PermicoesBLL bllPerm = new PermicoesBLL();

            usuario.usuario = txtUser.Text;
            string pwd = Hash(passtohash);

            usuario.senha = pwd;

            funcionario.nome = txtNome.Text;
            funcionario.rg = txtRG.Text;
            funcionario.cpf = txtCPF.Text;
            funcionario.endereco = txtEndereco.Text;
            funcionario.uf = txtUF.Text;

            _ = rdbCliSim.Checked == true ? permicao.frmclientes = true : permicao.frmclientes = false;
            _ = rdbConfigSim.Checked == true ? permicao.frmConfig = true : permicao.frmConfig = false;
            _ = rdbFuncSim.Checked == true ? permicao.frmfuncionarios = true : permicao.frmfuncionarios = false;
            _ = rdbProdSim.Checked == true ? permicao.frmprodutos = true : permicao.frmprodutos = false;
            _ = rdbServSim.Checked == true ? permicao.frmservicos = true : permicao.frmservicos = false;
            _ = rdbVendSim.Checked == true ? permicao.frmvendas = true : permicao.frmvendas = false;
            _ = rdbClinSim.Checked == true ? permicao.frmclinica = true : permicao.frmclinica = false;
            _ = rdbHotelSim.Checked == true ? permicao.frmhotel = true : permicao.frmhotel = false;
                       
            Usuario user = bllUser.Select(usuario);
            funcionario.userID = user.id;

            Permicoes Perm = bllPerm.Select(funcionario, permicao);
            funcionario.permicaoID = Perm.id;
            
            bllFunc.Select(funcionario);

            AtualizaView();
        }

        private void AtualizaView()
        {
            FuncionarioDAL dal = new FuncionarioDAL();
            dgvPermicoes.DataSource = "";
            dgvPermicoes.DataSource = dal.Select();

            HabilitaCampos(true);
            checkPwd.Checked = false;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Atualizabtn(true);
            HabilitaCampos(false);
            LimpaCampos();
           
        }

        private void LimpaCampos()
        {
            txtUser.Text = "";
            txtSenha.Text = "";
            txtNome.Text = "";
            txtRG.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtUF.Text = "";

            txtSenha.PasswordChar = 'x';
            txtBusca.ForeColor = Color.DarkGray;
            txtBusca.Text = "Digite aqui o Nome do funcionario:";

            rdbVendSim.Checked = true;
            rdbCliSim.Checked = true;
            rdbProdSim.Checked = true;
            rdbServSim.Checked = true;
            rdbFuncSim.Checked = true;
            rdbHotelSim.Checked = true;
            rdbClinSim.Checked = true;
            rdbConfigSim.Checked = true;
            checkPwd.Checked = false;
        }

        private String Hash(byte[] val)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            string s = txtUser.Text;

            if (s != "")
            {                       
                for(int i = txtUser.Text.Length; i > 0; i--)
                {
                    s = txtUser.Text.Substring(txtUser.Text.Length -i, 1);
                    if (s == " ")
                    {
                        break;
                    }
                }
            }

            if (s == " ")
            {
                lblWarning.Text = "Nome de usuário Não pode conter espaços!";
            }
            else
            {
                lblWarning.Text = "";
            }
        }

        private void ValidarCampos()
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Nome de usuário não pode ser vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {

        }

        private void txtBusca_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "Digite aqui o Nome do funcionario:")
            {              
                txtBusca.ForeColor = Color.Black;
                txtBusca.Text = "";
            }
        }

        private void txtBusca_Leave(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                txtBusca.ForeColor = Color.DarkGray;
                txtBusca.Text = "Digite aqui o Nome do funcionario:";
            }
        }
    }
}