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
        private int UsuarioId { get; set; }

        public frmMenu(int Usuario, frmLogin login)
        {
            login.Visible = false;
            InitializeComponent();

            UsuarioId = Usuario;
            Contexto contexto = new Contexto();

            Permicoes permicoes = contexto.Permicao.FirstOrDefault(x => x.id == UsuarioId);

            btnDash.Visible = false;
            btnCadastros.Visible = permicoes.frmCliente;
            btnConfig.Visible = permicoes.frmConfiguracoes;
            btnHotel.Visible = permicoes.frmHotel;
            btnAdmin.Visible = permicoes.frmProdutos;
            btnVendas.Visible = permicoes.frmVenda;

            if (permicoes.frmPainel)
            {
                frmDashboard frm = new frmDashboard();
                frm.MdiParent = this;
                frm.Show();
            }

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
            frm.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmVenda vendas = new frmVenda(UsuarioId);
            vendas.ShowDialog();
        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnimais animais = new frmAnimais();
            animais.ShowDialog();
        }

        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotel hotel = new frmHotel(UsuarioId);
            hotel.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddCliente cliente = new frmAddCliente(UsuarioId);
            cliente.ShowDialog();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermissoes permissao = new frmPermissoes();
            permissao.ShowDialog();
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

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadServicos frm = new frmCadServicos();
            frm.ShowDialog();
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuartos frm = new frmQuartos();
            frm.ShowDialog();
        }

        private void animaisCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesCadstradosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
