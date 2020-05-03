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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblSeparador.Text = "-";

            Camadas.DAL.ClienteDAL cliente = new Camadas.DAL.ClienteDAL();
            cmbCli.DisplayMember = "nome";
            cmbCli.ValueMember = "id";
            cmbCli.DataSource = cliente.Select();

            Camadas.DAL.FuncionarioDAL funcionario = new Camadas.DAL.FuncionarioDAL();
            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "id";
            cmbFunc.DataSource = funcionario.Select();

            AtualizaView();
            LimpaCampos();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void Data_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();

        }

        private void LblData_Click(object sender, EventArgs e)
        {

        }

        private void LblHora_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
 
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

        private void Label22_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Camadas.MODEL.Venda venda = new Camadas.MODEL.Venda();
            Camadas.DAL.VendaDAL dalVenda = new Camadas.DAL.VendaDAL();

            Camadas.MODEL.Itemvenda listCompra = new Camadas.MODEL.Itemvenda();
            Camadas.DAL.ItemVendaDAL movimentacao = new Camadas.DAL.ItemVendaDAL();

            venda.id_funcionario = 1;
            venda.id_cliente = cmbCli.SelectedIndex;
            venda.id_funcionario = cmbFunc.SelectedIndex;
            dalVenda.Insert(venda);
            
            int Qtde = Convert.ToInt32(txtQuantidade.Text);
            double Unt = Convert.ToDouble(txtValorUnt.Text);
            double Desc = Convert.ToDouble(txtDesc.Text);
            double total = (Qtde * Unt) - Desc;

            listCompra.Id_venda = dalVenda.SelectId();
            listCompra.id_produto = Convert.ToInt64(txtCod.Text);
            listCompra.quantidade = Convert.ToInt32(txtQuantidade.Text);
            listCompra.valor = total;

            movimentacao.Insert(listCompra);
            LimpaCampos();
            AtualizaView();
        }

        public void LimpaCampos()
        {
            txtCod.Text = "";
            cmbCli.Text = "";
            txtQuantidade.Text = "";
            txtValorUnt.Text = "";
            txtDesc.Text = "";
            txtQtde.Text = "00";
            txtValUnt.Text = "R$";
            txtdesconto.Text = "R$";
            txtTotal.Text = "R$";
        }

        private void Txtdesconto_Click(object sender, EventArgs e)
        {
            txtdesconto.Text = "R$: " + txtDesc.Text;
        }

        private void TxtQtde_Click(object sender, EventArgs e)
        {
            txtQtde.Text = txtQuantidade.Text;
        }

        private void TxtTotal_Click(object sender, EventArgs e)
        {
            int Qtde = Convert.ToInt32(txtQuantidade.Text);
            int Unt = Convert.ToInt32(txtValorUnt.Text);
            double Desc = Convert.ToDouble(txtDesc.Text);
            txtTotal.Text = "R$: " + Convert.ToString((Qtde * Unt) - Desc);
        }

        private void TxtValUnt_Click(object sender, EventArgs e)
        {
            txtValUnt.Text = "R$: " + txtValorUnt;
        }

        public void AtualizaView()
        {
            Camadas.BLL.Movimentacao lista = new Camadas.BLL.Movimentacao();
            dgvCompra.DataSource = "";
            dgvCompra.DataSource = lista.Select();
            dgvCompra.Columns["id"].Visible = false;
            dgvCompra.Columns["id_venda"].Visible = false;
            dgvCompra.Columns["id_produto"].DisplayIndex = 1;
            dgvCompra.Columns["id_produto"].Width = 180;
            dgvCompra.Columns["descricao"].DisplayIndex = 2;
            dgvCompra.Columns["descricao"].Width = 300;
            dgvCompra.Columns["quantidade"].DisplayIndex = 3;
            dgvCompra.Columns["quantidade"].Width = 120;
            dgvCompra.Columns["valor"].DisplayIndex = 4;
            dgvCompra.Columns["valor"].Width = 100;
        }

        private void TxtCod_Leave(object sender, EventArgs e)
        {

        }

        private void TxtQuantidade_Leave(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txtQuantidade.Text);
            string Qtde = valor.ToString();
            txtQtde.Text = Qtde;
        }

        private void TxtValorUnt_Leave(object sender, EventArgs e)
        {
            
        }

        private void TxtDesc_Leave(object sender, EventArgs e)
        {
            int unt = Convert.ToInt32(txtValorUnt.Text);
            int Quantidade = Convert.ToInt32(txtQuantidade.Text);
            int desc = Convert.ToInt32(txtDesc.Text);

            string Qtde = unt.ToString("C");
            string total = (unt * Quantidade).ToString("C");
            string desctxt = ((unt * Quantidade) - desc).ToString("C");

            txtValUnt.Text = Qtde;
            txtTotal.Text = desctxt;
            txtdesconto.Text = total;
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Camadas.BLL.Movimentacao movimentacao = new Camadas.BLL.Movimentacao();
            int id = movimentacao.SelectId();
            movimentacao.Finaliza(id);
            AtualizaView();
        }

        private void lbldesconto_Click(object sender, EventArgs e)
        {

        }

        private void cmbCli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
