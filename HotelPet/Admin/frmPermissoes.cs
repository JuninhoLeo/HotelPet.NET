using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            ckAltSenha.Visible = false;
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
            Contexto contexto = new Contexto();
            Usuario usuario = new Usuario();
            Funcionario funcionario = new Funcionario();
            Permicoes permicao = new Permicoes();

            string pass = txtSenha.Text.Trim();
            byte[] passtohash = Encoding.UTF8.GetBytes(pass);
            string pwd = txtSenhaUser.Text;

            if (ckAltSenha.Checked)
            {
                pwd = Hash(passtohash);
            }

            usuario.id = Convert.ToInt32(txtUserId.Text);
            usuario.usuario = txtUser.Text.Trim();
            usuario.senha = pwd;

            funcionario.id = Convert.ToInt32(txtFuncId.Text);
            funcionario.nome = txtNome.Text;
            funcionario.rg = txtRG.Text;
            funcionario.cpf = txtCPF.Text;
            funcionario.endereco = txtEndereco.Text;
            funcionario.uf = txtUF.Text;
            funcionario.Permicoes_id = Convert.ToInt32(txtPermId.Text);
            funcionario.Usuario_id = Convert.ToInt32(txtUserId.Text);

            permicao.id = Convert.ToInt32(txtPermId.Text);
            permicao.tipo = txtUser.Text.Trim();
            permicao.frmVenda = (rdbVendSim.Checked) ? true : false;
            permicao.frmCliente = (rdbCliSim.Checked) ? true : false;
            permicao.frmAddCliente = (rdbAddCliSim.Checked) ? true : false;
            permicao.frmConfiguracoes = (rdbConfigSim.Checked) ? true : false;
            permicao.frmHotel = (rdbHotelSim.Checked) ? true : false;
            permicao.frmClinica = (rdbClinSim.Checked) ? true : false;
            permicao.frmPainel = (rdbDashSim.Checked) ? true : false;
            permicao.frmProdutos = (rdbProdSim.Checked) ? true : false;

            contexto.Entry(funcionario).State = EntityState.Deleted;
            contexto.SaveChanges();

            contexto.Entry(permicao).State = EntityState.Deleted;
            contexto.SaveChanges();

            contexto.Entry(usuario).State = EntityState.Deleted;
            contexto.SaveChanges();

            LimpaCampos();
            AtualizaView();
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
            AtualizaView();
            Atualizabtn(true);
            HabilitaCampos(false);

            txtFuncId.Visible = false;
            txtUserId.Visible = false;
            txtPermId.Visible = false;
            txtSenhaUser.Visible = false;
            ckAltSenha.Visible = false;
            ckAltSenha.Checked = false;
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
            gpbAddClientes.Enabled = campo;
            gpbDash.Enabled = campo;
            gpbHotel.Enabled = campo;
            gpbClinica.Enabled = campo;
            gpbConfig.Enabled = campo;
            gpbProd.Enabled = campo;
        }

        private void dgvPermicoes_DoubleClick(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            ckAltSenha.Visible = true;
            ckAltSenha.Checked = false;
            
            HabilitaCampos(true);
            btnConfirm.Enabled = true;
            btnBusca.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;

            txtFuncId.Text = dgvPermicoes.SelectedRows[0].Cells["id"].Value.ToString();
            string X = dgvPermicoes.SelectedRows[0].Cells["Usuario_id"].Value.ToString();
            txtUserId.Text = X;
            int A = Convert.ToInt32(X);
            Usuario usuario = contexto.Usuario.FirstOrDefault(x => x.id == A);
            txtSenhaUser.Text = usuario.senha;
            txtPermId.Text = dgvPermicoes.SelectedRows[0].Cells["Permicoes_id"].Value.ToString();

            int id = Convert.ToInt32(dgvPermicoes.SelectedRows[0].Cells["id"].Value.ToString());
            Funcionario funcionario = contexto.Funcionario.FirstOrDefault(x => x.id == id);
          
            lblAviso.Text = "*Vazio para manter a mesma senha, ou digite uma nova para redefinir";
            txtUser.Text = funcionario.Usuario.usuario;
            txtNome.Text = dgvPermicoes.SelectedRows[0].Cells["Funcionário"].Value.ToString();
            txtRG.Text = dgvPermicoes.SelectedRows[0].Cells["RG"].Value.ToString();
            txtCPF.Text = dgvPermicoes.SelectedRows[0].Cells["CPF"].Value.ToString();
            txtEndereco.Text = dgvPermicoes.SelectedRows[0].Cells["Endereço"].Value.ToString();
            txtUF.Text = dgvPermicoes.SelectedRows[0].Cells["UF"].Value.ToString();
            AtualizaRdb(funcionario.Permicoes);
            txtSenha.Enabled = false;
            checkPwd.Enabled = false;
        }

        private void AtualizaRdb(Permicoes permicao)
        {
            _ = permicao.frmVenda == true ? rdbVendSim.Checked = true : rdbVendNao.Checked = true;
            _ = permicao.frmCliente == true ? rdbCliSim.Checked = true : rdbCliNao.Checked = true;
            _ = permicao.frmAddCliente == true ? rdbAddCliSim.Checked = true : rdbAddCliNao.Checked = true;
            _ = permicao.frmConfiguracoes == true ? rdbConfigSim.Checked = true : rdbConfigNao.Checked = true;
            _ = permicao.frmHotel == true ? rdbHotelSim.Checked = true : rdbHotelNao.Checked = true;
            _ = permicao.frmClinica == true ? rdbClinSim.Checked = true : rdbClinNao.Checked = true;
            _ = permicao.frmPainel == true ? rdbDashSim.Checked = true : rdbDashNao.Checked = true;
            _ = permicao.frmProdutos == true ? rdbProdSim.Checked = true : rdbProdNao.Checked = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            Usuario usuario = new Usuario();
            Funcionario funcionario = new Funcionario();
            Permicoes permicao = new Permicoes();

            string pass = txtSenha.Text.Trim();
            byte[] passtohash = Encoding.UTF8.GetBytes(pass);
            string pwd = txtSenhaUser.Text;

            if (ckAltSenha.Checked)
            {
                pwd = Hash(passtohash);
            }

            usuario.id = Convert.ToInt32(txtUserId.Text);
            usuario.usuario = txtUser.Text.Trim();
            usuario.senha = pwd;

            funcionario.id = Convert.ToInt32(txtFuncId.Text);
            funcionario.nome = txtNome.Text;
            funcionario.rg = txtRG.Text;
            funcionario.cpf = txtCPF.Text;
            funcionario.endereco = txtEndereco.Text;
            funcionario.uf = txtUF.Text;
            funcionario.Permicoes_id = Convert.ToInt32(txtPermId.Text);
            funcionario.Usuario_id = Convert.ToInt32(txtUserId.Text);

            permicao.id = Convert.ToInt32(txtPermId.Text);
            permicao.tipo = txtUser.Text.Trim();
            permicao.frmVenda = (rdbVendSim.Checked) ? true : false;
            permicao.frmCliente = (rdbCliSim.Checked) ? true : false;
            permicao.frmAddCliente = (rdbAddCliSim.Checked) ? true : false;
            permicao.frmConfiguracoes = (rdbConfigSim.Checked) ? true : false;
            permicao.frmHotel = (rdbHotelSim.Checked) ? true : false;
            permicao.frmClinica = (rdbClinSim.Checked) ? true : false;
            permicao.frmPainel = (rdbDashSim.Checked) ? true : false;
            permicao.frmProdutos = (rdbProdSim.Checked) ? true : false;

            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();

            contexto.Entry(funcionario).State = EntityState.Modified;
            contexto.SaveChanges();

            contexto.Entry(permicao).State = EntityState.Modified;
            contexto.SaveChanges();

            AtualizaView();
            ckAltSenha.Checked = false;
            ckAltSenha.Visible = false;
            LimpaCampos();
        }

        private void AtualizaView()
        {
            Contexto contexto = new Contexto();

            dgvPermicoes.Visible = true;
            dgvPermicoes.DataSource = "";

            var lista = from func in contexto.Funcionario.Where(x => x.nome != "").ToList()
                        orderby func.nome
                        select new
                        {
                            func.id,
                            Funcionário = func.nome,
                            CPF = func.cpf.Replace(",", "."),
                            RG = func.rg.Replace(",", "."),
                            Endereço = func.endereco,
                            UF = func.uf,
                            Usuário = func.Usuario.usuario,
                            func.Permicoes_id,
                            func.Usuario_id
                        };

            dgvPermicoes.DataSource = lista.ToList();
            dgvPermicoes.Columns["Permicoes_id"].Visible = false;
            dgvPermicoes.Columns["Usuario_id"].Visible = false;

            HabilitaCampos(true);
            checkPwd.Checked = false;
        }

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Atualizabtn(true);
            HabilitaCampos(false);
            LimpaCampos();

            ckAltSenha.Checked = false;
            ckAltSenha.Visible = false;

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

            rdbVendNao.Checked = true;
            rdbCliNao.Checked = true;
            rdbAddCliNao.Checked = true;
            rdbConfigNao.Checked = true;
            rdbHotelNao.Checked = true;
            rdbClinNao.Checked = true;
            rdbDashNao.Checked = true;
            rdbProdNao.Checked = true;

            checkPwd.Checked = false;

            ckAltSenha.Checked = false;
            ckAltSenha.Visible = false;
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
                for(int cont = txtUser.Text.Length; cont > 0; cont--)
                {
                    s = txtUser.Text.Substring(txtUser.Text.Length -cont, 1);
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

            Contexto contexto = new Contexto();
            List<Usuario> lst = contexto.Usuario.ToList();
            int i = 0;

            foreach (var User in lst)
            {
                i += (User.usuario.ToUpper() == txtUser.Text.ToUpper()) ? 1 : 0;
            }

            if (i > 0)
            {
                lblWarning.Text = "Esse nome de usuário já está em uso!";
            }

        }

        private void ValidarCampos(string campo)
        {        
            MessageBox.Show("O campo: " + campo + " está vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string pass = txtSenha.Text.Trim();
            byte[] passtohash = Encoding.UTF8.GetBytes(pass);

            Usuario usuario = new Usuario();
            Funcionario funcionario = new Funcionario();
            Permicoes permicao = new Permicoes();

            string pwd = Hash(passtohash);

            usuario.usuario = txtUser.Text;
            usuario.senha = pwd;

            funcionario.nome = txtNome.Text;
            funcionario.rg = txtRG.Text;
            funcionario.cpf = txtCPF.Text;
            funcionario.endereco = txtEndereco.Text;
            funcionario.uf = txtUF.Text;

            permicao.tipo = txtUser.Text.Trim();
            permicao.frmVenda= (rdbVendSim.Checked) ? true : false;
            permicao.frmCliente = (rdbCliSim.Checked) ?  true : false;
            permicao.frmAddCliente= (rdbAddCliSim.Checked) ? true : false;
            permicao.frmConfiguracoes = (rdbConfigSim.Checked) ? true : false;
            permicao.frmHotel= (rdbHotelSim.Checked) ? true : false;
            permicao.frmClinica= (rdbClinSim.Checked) ? true : false;
            permicao.frmPainel= (rdbDashSim.Checked) ? true : false;
            permicao.frmProdutos = (rdbProdSim.Checked) ? true : false;

            Contexto contexto = new Contexto();
            List<Usuario> lstuser = new List<Usuario>();
            lstuser = contexto.Usuario.ToList();
            int cont = 0;
            string estiver ="OK";

            if (txtNome.Text.Trim() == "")
            {
                ValidarCampos("Nome");
                estiver = "Nao";
            }
            else
            {
                if (txtRG.Text.Trim() == "")
                {
                    ValidarCampos("RG");
                    estiver = "Nao";
                }
                else
                {
                    if (txtCPF.Text.Trim() == "")
                    {
                        ValidarCampos("CPF");
                        estiver = "Nao";
                    }
                    else
                    {
                        if (txtEndereco.Text.Trim() == "")
                        {
                            ValidarCampos("Endereço");
                            estiver = "Nao";
                        }
                        else
                        {
                            if (txtUF.Text.Trim() == "")
                            {
                                ValidarCampos("UF");
                                estiver = "Nao";
                            }
                            else
                            {
                                if (txtUser.Text.Trim() == "")
                                {
                                    ValidarCampos("User");
                                    estiver = "Nao";
                                }
                                else
                                {
                                    if (txtSenha.Text.Trim() == "")
                                    {
                                        ValidarCampos("Senha");
                                        estiver = "Nao";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (estiver == "OK")
            {
                foreach (var USER in lstuser)
                {
                    cont += (USER.usuario == txtUser.Text) ? 1 : 0;
                }

                if (cont == 0)
                {
                    //bllFunc.Insert(funcionario, usuario, permicao);
                    contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();

                    contexto.Permicao.Add(permicao);
                    contexto.SaveChanges();

                    Usuario user = contexto.Usuario.FirstOrDefault(x => x.usuario == usuario.usuario);
                    Permicoes perm = contexto.Permicao.FirstOrDefault(x => x.tipo == usuario.usuario);

                    funcionario.Usuario_id = user.id;
                    funcionario.Permicoes_id = perm.id;

                    contexto.Funcionario.Add(funcionario);
                    contexto.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Não foi possivel inserir os dados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LimpaCampos();
            }

            AtualizaView();

        }

        private void ckAltSenha_Click(object sender, EventArgs e)
        {
            if (ckAltSenha.Checked)
            {
                txtSenha.Enabled = true;
                checkPwd.Enabled = true;
            }
            else
            {
                txtSenha.Enabled = false;
                checkPwd.Enabled = false;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();

            dgvPermicoes.DataSource = "";

            var lista = from func in contexto.Funcionario.Where(x => x.nome == txtBusca.Text).ToList()
                        orderby func.nome
                        select new
                        {
                            func.id,
                            Funcionário = func.nome,
                            CPF = func.cpf.Replace(",", "."),
                            RG = func.rg.Replace(",", "."),
                            Endereço = func.endereco,
                            UF = func.uf,
                            Usuário = func.Usuario.usuario,
                            func.Permicoes_id,
                            func.Usuario_id
                        };

            dgvPermicoes.DataSource = lista.ToList();
            dgvPermicoes.Columns["Permicoes_id"].Visible = false;
            dgvPermicoes.Columns["Usuario_id"].Visible = false;
        }

        private void txtCPF_KeyUp(object sender, KeyEventArgs e)
        {
            //000.000.000-00                        
        }

        private void txtFuncId_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAviso_Click(object sender, EventArgs e)
        {

        }
    }
}