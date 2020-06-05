using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmCadastrarSe : Form
    {
        public frmCadastrarSe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] passtohash = Encoding.UTF8.GetBytes(txtSenha.Text.ToString());
            Contexto contexto = new Contexto();

            if (txtSenha.Text == txtConfSenha.Text)
            {
                DialogResult = MessageBox.Show("Salvar usuario?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (DialogResult == DialogResult.Yes)
                {
                    string user = txtUsuario.Text;
                    string pwd = Hash(passtohash);
                    
                    Usuario usuario = new Usuario();
                    usuario.usuario = user;
                    usuario.senha = pwd;
                    contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();

                    Permicoes permicao = new Permicoes();
                    permicao.tipo = user;
                    permicao.frmVenda = false;
                    permicao.frmCliente = false;
                    permicao.frmAddCliente = true;
                    permicao.frmConfiguracoes = true;
                    permicao.frmHotel = false;
                    permicao.frmClinica =  false;
                    permicao.frmPainel = true;
                    permicao.frmProdutos = true;
                    contexto.Permicao.Add(permicao);
                    contexto.SaveChanges();

                    Administrador admin = new Administrador();
                    admin.nome = txtNome.Text;
                    admin.rg = txtRG.Text;
                    admin.cpf = txtCPF.Text;
                    admin.email = txtEmail.Text;
                    admin.Usuario_id = usuario.id;
                    admin.Permicoes_id = permicao.id;
                    contexto.Administrador.Add(admin);
                    contexto.SaveChanges();

                    this.Close();
                }
            }   
        }

        public String Hash(byte[] val)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(val);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtConfSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text != txtConfSenha.Text)
            {
                MessageBox.Show("A confirmação de senha precisa ser igual a senha digitada");
                txtConfSenha.ForeColor = Color.Red;
            }
        }

        private void txtUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            string s = txtUsuario.Text;

            if (s != "")
            {
                for (int cont = txtUsuario.Text.Length; cont > 0; cont--)
                {
                    s = txtUsuario.Text.Substring(txtUsuario.Text.Length - cont, 1);
                    if (s == " ")
                    {
                        break;
                    }
                }
            }

            if (s == " ")
            {
                lblWarning.Text = "Nome de usuário não pode conter espaços!";
            }
            else
            {
                lblWarning.Text = "";
            }
        }
    }
}
