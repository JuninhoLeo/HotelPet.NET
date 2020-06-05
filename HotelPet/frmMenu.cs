using HotelPet.Admin;
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

namespace HotelPet
{
    public partial class frmMenu : Form
    {
        public int UsuarioId = 0;

        public frmMenu(int Usuario, frmLogin login)
        {
            login.Visible = false;
            InitializeComponent();

            UsuarioId = Usuario;
            Contexto contexto = new Contexto();

            Permicoes permicoes = contexto.Permicao.FirstOrDefault(x => x.id == UsuarioId);

            btnCadastros.Visible = permicoes.frmAddCliente;
            btnConsultar.Visible = permicoes.frmCliente;
            //btnClinica.Visible = permicoes.frmClinica;
            btnConfig.Visible = permicoes.frmConfiguracoes;
            btnHotel.Visible = permicoes.frmHotel;
            btnDash.Visible = permicoes.frmPainel;
            btnAdmin.Visible = permicoes.frmProdutos;
            btnVendas.Visible = permicoes.frmVenda;

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
                desconectar();
        }
        private void desconectar()
        {
            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Fechar Aplicação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (confirm.ToString().ToUpper() == "YES")
            {
                frmLogin login = new frmLogin();

                // Utilizar esse metodo para Quando fazer o logout pedir a senha

                // if (login.ShowDialog() == DialogResult.OK)
                // {
                Application.Exit();
                // }
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportar frm = new frmImportar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenda vendas = new frmVenda();
            vendas.MdiParent = this;
            vendas.Show();
        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnimais animais = new frmAnimais();
            animais.MdiParent = this;
            animais.Show();
        }

        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotel hotel = new frmHotel();
            hotel.MdiParent = this;
            hotel.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCliente cliente = new frmAddCliente();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermissoes permissao = new frmPermissoes();
            permissao.MdiParent = this;
            permissao.Show();
        }

        private void painelDeControleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnCadastros_Click(object sender, EventArgs e)
        {

        }
    }
}
