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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnSair.DialogResult = DialogResult.Cancel;
            AcceptButton = btnEntrar;
            CancelButton = btnSair;
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] passtohash = Encoding.UTF8.GetBytes(txtSenha.Text.ToString());
            Camadas.BLL.Usuario bllUser = new Camadas.BLL.Usuario();

            string user = txtUsuario.Text;
            string pwd = Hash(passtohash);

            string ConfUser =bllUser.SelectUsr(user);
            string ConfSenha =bllUser.SelectPwd(user);

            if(txtUsuario.Text == "" && txtSenha.Text == "")
            {
                txtUsuario.Text = "";
                txtSenha.Text = "";
                lblErrUser.Text = "Usuario Nao Encontrado!";
                DialogResult = DialogResult.None;
            }
            else
            {
                if (ConfSenha == pwd && ConfUser == user)
                {
                    btnEntrar.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (ConfUser == user && ConfSenha != pwd)
                    {
                        txtUsuario.Text = "";
                        txtSenha.Text = "";
                        lblErrUser.Text = "Usuario Nao Encontrado!";
                        DialogResult = DialogResult.None;
                    }
                    else
                    {
                        txtUsuario.Text = "";
                        txtSenha.Text = "";
                        lblErrUser.Text = "Usuario Nao Encontrado!";
                        DialogResult = DialogResult.None;
                    }
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

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
