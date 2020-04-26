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
        private int childFormNumber = 0;

        public frmMenu()
        {
            InitializeComponent();
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
                this.Close();
                // }
            }
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            frmDashboard dashboard = new frmDashboard();
            dashboard.MdiParent = this;
            dashboard.Show();
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashboard vendas = new frmDashboard();
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
            frmCliente cliente = new frmCliente();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPermissoes permissao = new frmPermissoes();
            permissao.MdiParent = this;
            permissao.Show();
        }
    }
}
