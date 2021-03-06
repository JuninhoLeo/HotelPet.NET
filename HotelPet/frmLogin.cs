﻿using HotelPet.Camadas.MODEL;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            btnSair.DialogResult = DialogResult.Cancel;
            AcceptButton = btnEntrar;
            CancelButton = btnSair;

            try
            {
                int qtde = contexto.Administrador.Count();
                if (qtde > 0)
                {
                    btnCadastro.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Erro Seu banco de dados está desligado. Por favor ligue-o antes de iniciar a aplicação", "O BANCO DE DADOS ESTÁ DESLIGADO.", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.Close();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            byte[] passtohash = Encoding.UTF8.GetBytes(txtSenha.Text.ToString());
            Contexto contexto = new Contexto(); 

            string user = txtUsuario.Text; 
             string pwd = Hash(passtohash);

            Usuario usuario = contexto.Usuario.FirstOrDefault(u => u.usuario == user && u.senha == pwd);

            if(txtUsuario.Text == "" && txtSenha.Text == "")
            {
                txtUsuario.Text = "";
                txtSenha.Text = "";
                lblErrUser.Text = " Nome de Usuario Nao informado!";
                DialogResult = DialogResult.None;
                
            }
            else
            {
                if (usuario != null)
                {
                    Administrador administrador = contexto.Administrador.FirstOrDefault(x => x.Usuario_id == usuario.id);
                    Funcionario funcionario = contexto.Funcionario.FirstOrDefault(x => x.Usuario_id == usuario.id);

                    btnEntrar.DialogResult = DialogResult.OK;

                    if(administrador != null)
                    {
                        frmMenu frm = new frmMenu(administrador.Permicoes_id, this);
                        frm.Show();
                    }
                    else
                    {
                        frmMenu frm = new frmMenu(funcionario.Permicoes_id, this);
                        frm.Show();
                    }
                }
                else
                {                    
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    lblErrUser.Text = "Usuário ou senha estão incorretos";
                    DialogResult = DialogResult.None;
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

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            frmCadastrarSe frm = new frmCadastrarSe();
            frm.Show();
        }
    }
}
