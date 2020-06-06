using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.BLL;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmVenda : Form
    {
        List<ListaCompra> ItemVenda = new List<ListaCompra>();
        List<ListaCompra> listaCompra = new List<ListaCompra>();

        public frmVenda(ToolStripMenuItem btnVendas)
        {
            btnVendas.Visible = false;
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblSeparador.Text = "-";
            txtValorUnt.Enabled = false;

            Contexto contexto = new Contexto();

            cmbCli.DisplayMember = "nome";
            cmbCli.ValueMember = "id";
            cmbCli.DataSource = contexto.Cliente.ToList();

            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "id";
            cmbFunc.DataSource = contexto.Funcionario.ToList();

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
            Contexto contexto = new Contexto();
            ListaCompra compras = new ListaCompra();

            ///fazer o verifica aqui
            ///----><---------

            int Qtde = Convert.ToInt32(txtQuantidade.Text);
            string valorSub = txtValorUnt.Text.Substring(3);
            double Unt = Convert.ToDouble(valorSub);
            double Desc = (txtDesc.Text == "") ? 0 : Convert.ToDouble(txtDesc.Text);
            double total = (Qtde * Unt) - Desc;

            compras.Codigo = Convert.ToInt32(txtCod.Text);
            compras.descricao = lblNomeProdutoServico.Text;
            compras.Quantidade = Qtde;
            compras.valor = total;
            listaCompra.Add(compras);

            ItemVenda = listaCompra;

            LimpaCampos();
            AtualizaView();
        }

        public void LimpaCampos()
        {
            txtCod.Text = "";
            //cmbCli.Text = "";
            txtQuantidade.Text = "";
            txtValorUnt.Text = "";
            txtDesc.Text = "";
            txtQtde.Text = "00";
            txtValUnt.Text = "R$";
            txtdesconto.Text = "R$";
            txtTotal.Text = "R$";
            lblNomeProdutoServico.Text = "";

            cmbCli.Visible = true;
            lblCli.Visible = true;
            lblCPF.Visible = false;
            txtCpf.Visible = false;
            CkNotInform.Checked = false;
            CkCPF.Checked = false;
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
            dgvCompra.DataSource = "";
            dgvCompra.DataSource = ItemVenda;

            dgvCompra.Columns["id"].Visible = false;
            dgvCompra.Columns["Vendas_id"].Visible = false;
            dgvCompra.Columns["Vendas"].Visible = false;

            dgvCompra.Columns["Codigo"].DisplayIndex = 1;
            dgvCompra.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCompra.Columns["Codigo"].Width = 90;

            dgvCompra.Columns["descricao"].DisplayIndex = 2;
            dgvCompra.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCompra.Columns["descricao"].Width = 390;

            dgvCompra.Columns["Quantidade"].DisplayIndex = 3;
            dgvCompra.Columns["Quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCompra.Columns["Quantidade"].Width = 90;

            dgvCompra.Columns["valor"].DisplayIndex = 4;
            dgvCompra.Columns["valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCompra.Columns["valor"].DefaultCellStyle.Format = "c";
            dgvCompra.Columns["valor"].Width = 90;

            txtValorTotal.Text = dgvCompra.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["valor"].Value ?? 0)).ToString("C");
        }

        private void TxtCod_Leave(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                Contexto contexto = new Contexto();
                try
                {
                    var prod = contexto.Produto.FirstOrDefault(x => x.codigo == txtCod.Text);
                    if (prod != null)
                    {
                        lblNomeProdutoServico.Text = prod.descricao;
                        txtValUnt.Text = prod.valor.ToString("C");
                        txtValorUnt.Text = prod.valor.ToString("C");
                    }
                }
                catch (Exception)
                {
                    var serv = contexto.Servico.FirstOrDefault(x => x.id == Convert.ToInt64(txtCod.Text));
                    lblNomeProdutoServico.Text = serv.descricao;
                    txtValUnt.Text = serv.valor.ToString("C");
                    txtValorUnt.Text = serv.valor.ToString("C");
                }
                finally
                {
                    if (lblNomeProdutoServico.Text == "")
                    {
                        MessageBox.Show("Produto não Encontrado!", "Sem Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpaCampos();
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("Informe o codigo do Produto");
            //}
        }

        private void TxtQuantidade_Leave(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != "")
            {
                int valor = Convert.ToInt32(txtQuantidade.Text);
                string Qtde = valor.ToString();
                txtQtde.Text = Qtde;
            }
            //else
            //{
            //    MessageBox.Show("Informe a quantidade!");
            //}
        }

        private void TxtValorUnt_Leave(object sender, EventArgs e)
        {
            
        }

        private void TxtDesc_Leave(object sender, EventArgs e)
        {
            if (txtValorUnt.Text != "" && txtQuantidade.Text != "")
            {
                string valorSub = txtValorUnt.Text.Substring(3);
                double unt = Convert.ToDouble(valorSub);
                double Quantidade = Convert.ToDouble(txtQuantidade.Text);
                double desc = (txtDesc.Text == "") ? 0 : Convert.ToDouble(txtDesc.Text);

                string Qtde = unt.ToString("C");
                string total = (unt * Quantidade).ToString("C");
                string desctxt = ((unt * Quantidade) - desc).ToString("C");

                txtValUnt.Text = Qtde;
                txtTotal.Text = desctxt;
                txtdesconto.Text = total;
            }
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Confirma pagamento?", "Obrigado pela preferência", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button3);

            if (DialogResult == DialogResult.Yes)
            {
                Contexto contexto = new Contexto();
                ListaCompraBLL bll = new ListaCompraBLL();
                Venda venda = new Venda();

                venda.data = DateTime.Now;
                venda.Cliente_id = cmbCli.SelectedIndex;
                venda.Funcionario_id = cmbFunc.SelectedIndex;
                contexto.Venda.Add(venda);
                contexto.SaveChanges();

                int id = venda.id;
                bll.Insert(ItemVenda, id);

                ItemVenda = null;
                AtualizaView();
            }
            else 
            {
                DialogResult = DialogResult.Retry;
                List<ListaCompra> Aux = new List<ListaCompra>();
                ItemVenda = Aux;
                AtualizaView();
            }
        }

        private void lbldesconto_Click(object sender, EventArgs e)
        {

        }

        private void cmbCli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CkCPF_Click(object sender, EventArgs e)
        {
            if (CkCPF.Checked == true)
            {
                cmbCli.Visible = false;
                lblCli.Visible = false;
                lblCPF.Visible = true;
                txtCpf.Visible = true;
            }
            else
            {
                cmbCli.Visible = true;
                lblCli.Visible = true;
                lblCPF.Visible = false;
                txtCpf.Visible = false;
            }

            CkNotInform.Checked = (CkNotInform.Checked == true) ? false : false;

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (CkNotInform.Checked == true)
            {
                cmbCli.Visible = false;
                lblCli.Visible = false;
                lblCPF.Visible = false;
                txtCpf.Visible = false;
            }
            else
            {
                cmbCli.Visible = true;
                lblCli.Visible = true;
                lblCPF.Visible = false;
                txtCpf.Visible = false;
            }
            CkCPF.Checked = (CkCPF.Checked == true) ? false : false;
        }
    }
}
