using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Funcionarios.Vendas;
using HotelPet.Layers.BLL;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmVenda : Form
    {
        List<ListaCompra> ItemVenda = new List<ListaCompra>();
        //List<ListaCompra> listaCompra = new List<ListaCompra>();

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
            cmbCli.DataSource = contexto.Cliente.Where(x => x.nome != null).ToList();

            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "id";
            cmbFunc.DataSource = contexto.Funcionario.Where(x=> x.Permicoes.frmVenda == true).ToList();

            AtualizaView(dgvCompra);
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
            try
            {
                Contexto contexto = new Contexto();
                ListaCompra compras = new ListaCompra();

                double Qtde = Convert.ToDouble(txtQuantidade.Text.Replace(".",","));
                string valorSub = txtValorUnt.Text.Substring(3);
                double Unt = Convert.ToDouble(valorSub);
                double Desc = (txtDesc.Text == "") ? 0 : Convert.ToDouble(txtDesc.Text);
                double vlUnit = Unt - Desc;
                double total = (Unt * Qtde) - Desc;

                compras.Codigo = Convert.ToInt32(txtCod.Text);
                compras.descricao = lblNomeProdutoServico.Text;
                compras.Quantidade = Qtde;
                compras.valor = vlUnit;
                compras.total = total;

                ItemVenda.Add(compras);

            }
            catch (Exception)
            {

            }

            LimpaCampos();
            AtualizaView(dgvCompra);
        }

        public void LimpaCampos()
        {

            txtCod.Text = "";
            txtQuantidade.Text = "";
            txtValorUnt.Text = "";
            txtDesc.Text = "";
            txtQtde.Text = "00";
            txtValUnt.Text = "R$";
            txtdesconto.Text = "R$";
            txtTotal.Text = "R$";
            lblNomeProdutoServico.Text = "";

            cmbCli.Visible = false;
            lblCli.Visible = false;
            lblCPF.Visible = false;
            txtCpf.Visible = false;
            CkNotInform.Checked = true;
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

        public void AtualizaView(DataGridView dgv)
        {
            dgv.DataSource = "";
            dgv.DataSource = ItemVenda;

            dgv.Columns["id"].Visible = false;
            dgv.Columns["Vendas_id"].Visible = false;
            dgv.Columns["Vendas"].Visible = false;
            dgv.Columns["total"].Visible = false;

            dgv.Columns["Codigo"].DisplayIndex = 1;
            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns["Codigo"].Width = 90;

            dgv.Columns["descricao"].DisplayIndex = 2;
            dgv.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns["descricao"].Width = 390;

            dgv.Columns["Quantidade"].DisplayIndex = 3;
            dgv.Columns["Quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns["Quantidade"].Width = 90;

            dgv.Columns["valor"].DisplayIndex = 4;
            dgv.Columns["valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv.Columns["valor"].DefaultCellStyle.Format = "c";
            dgv.Columns["valor"].Width = 90;

            txtValorTotal.Text = dgv.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["total"].Value ?? 0)).ToString("C");
        }

        private void TxtCod_Leave(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                Contexto contexto = new Contexto();
                var cod = Convert.ToInt64(txtCod.Text);
                try
                {
                    var prod = contexto.Produto.FirstOrDefault(x => x.codigo == cod);
                    if (prod != null)
                    {
                        lblNomeProdutoServico.Text = prod.descricao;
                        txtValUnt.Text = prod.valor.ToString("C");
                        txtValorUnt.Text = prod.valor.ToString("C");
                    }
                }
                catch (Exception)
                {
                    Convert.ToInt64(txtCod.Text);
                    var serv = contexto.Servico.FirstOrDefault(x => x.id == cod);
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
                var abc = txtQuantidade.Text.Replace(".", ",");
                double valor = Convert.ToDouble(abc);
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
                double Quantidade = Convert.ToDouble(txtQuantidade.Text.Replace(".",","));
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

            if (ItemVenda.Count() > 0)
            {

                if (DialogResult == DialogResult.Yes)
                {
                    Contexto contexto = new Contexto();
                    ListaCompraBLL bll = new ListaCompraBLL();
                    Venda venda = new Venda();
                    venda.data = DateTime.Now;
                    venda.Funcionario_id = Convert.ToInt32(cmbFunc.SelectedValue);

                    int idCmb = (!CkNotInform.Checked && !CkCPF.Checked) ? Convert.ToInt32(cmbCli.SelectedValue) : 0;

                    Cliente cli = contexto.Cliente.FirstOrDefault(x => x.cpf == txtCpf.Text || x.id == idCmb);

                    if (cli == null)
                    {
                        cli = new Cliente();
                        cli.cpf = txtCpf.Text;
                    }


                    if (CkNotInform.Checked)
                    {
                        venda.Cliente_id = cli.id;
                        venda.Cliente = cli;
                    }
                    else if (CkCPF.Checked)
                    {
                        venda.Cliente_id = cli.id;
                        venda.Cliente = cli;
                    }
                    else
                    {
                        venda.Cliente_id = idCmb;
                    }


                    contexto.Venda.Add(venda);
                    contexto.SaveChanges();

                    int id = venda.id;
                    bll.Insert(ItemVenda, id);

                    ItemVenda.Clear();
                    AtualizaView(dgvCompra);
                }
            }
            else
            {
                DialogResult = DialogResult.Retry;
                List<ListaCompra> Aux = new List<ListaCompra>();
                ItemVenda = Aux;
                AtualizaView(dgvCompra);
            }
        }

        private void lbldesconto_Click(object sender, EventArgs e)
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

            checkBox1.Checked = false;
            CkNotInform.Checked = false;

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

            checkBox1.Checked = false;
            CkCPF.Checked = false;
        }

        private void dgvCompra_DoubleClick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long cod = Convert.ToInt64(dgvCompra.Rows[0].Cells["Codigo"].Value);
                string desc = dgvCompra.Rows[0].Cells["descricao"].Value.ToString();
                double qtde = Convert.ToDouble(dgvCompra.Rows[0].Cells["Quantidade"].Value);
                double valor = Convert.ToDouble(dgvCompra.Rows[0].Cells["valor"].Value);

                ItemVenda.RemoveAll(x => x.Codigo == cod && x.descricao == desc && x.Quantidade == qtde && x.valor == valor);
                AtualizaView(dgvCompra);
            }
            catch (Exception)
            {
            }
        }

        private void dgvCompra_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                long id = Convert.ToInt64(textBox1.Text.Trim());
                var item = ItemVenda.Where(x => x.Codigo == id).ToList();
                dgvCompra.DataSource = item;
            }
            catch (Exception)
            {
                var item = ItemVenda.Where(x => x.descricao.Contains(textBox1.Text.Trim().ToUpper())).ToList();
                dgvCompra.DataSource = item;
            }
        }

        private void checkBox1_Click_1(object sender, EventArgs e)
        {
            cmbCli.Visible = true;
            lblCli.Visible = true;
            lblCPF.Visible = false;
            txtCpf.Visible = false;

            CkCPF.Checked = (CkCPF.Checked == true) && false;
            CkNotInform.Checked = (CkNotInform.Checked == true) && false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConsulta frm = new frmConsulta();
            frm.ShowDialog();
        }
    }
}
