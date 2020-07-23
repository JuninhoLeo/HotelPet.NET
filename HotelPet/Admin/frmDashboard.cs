using HotelPet.Admin.Report;
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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            lblTotFunc.Text = contexto.Funcionario.Count().ToString();
            lblTotCli.Text = contexto.Cliente.Count().ToString();

            DateTime data = DateTime.Now.AddDays(-1);
            double receita = 0;

            try
            {
                receita = contexto.Historico.Where(x => x.data > data).Sum(x => x.valor);
            }
            catch (Exception)
            {

            }

            lblReceita.Text = receita.ToString("C");

            //Calculo de Capacidade de reservas
            int desocupados = contexto.Quarto.Count(x => x.disponivel == true);
            int total = contexto.Quarto.Count();
            lblTotCapacidade.Text = desocupados.ToString() + "/" + total.ToString();
            int pocentagem = 100;
            try
            {
                pocentagem = Convert.ToInt32((decimal)desocupados / (decimal)total * (decimal)100);
            }
            catch (Exception){ }

            if (pocentagem < 50)
            {
                label7.Visible = false;
                pictureBox9.Visible = true;
                label10.Visible = true;
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Sua capacidade\n disponível é de " + pocentagem + "%";
                pictureBox9.Visible = false;
                label10.Visible = false;
            }

            //dgvVendasDiarias
            var historico = from hist in contexto.Historico.Where(x => x.data > data).ToList()
                            select new
                            {
                                Código = hist.id,
                                Descrição = hist.descricao,
                                Data = hist.data,
                                Valor = hist.valor
                            };
            dgvVendasDiarias.DataSource = "";
            dgvVendasDiarias.DataSource = historico.ToList();
            dgvVendasDiarias.Columns["Valor"].DefaultCellStyle.Format = "C";

            //dgvMetricaAnual
            var Metricas = from metrica in contexto.Historico.ToList()
                           orderby metrica.data descending
                           group metrica by new { metrica.data.Year, metrica.data.Month } into m
                           select new
                           {
                               Mes = m.Key.Month + "/" + m.Key.Year,
                               Valor = m.Sum(x => x.valor).ToString("C"),
                               qtde = m.Count()
                           };
            dgvMetricaAnual.DataSource = "";
            dgvMetricaAnual.DataSource = Metricas.ToList();

            //dgvProdAbaixoEstoque
            var ProdAbaixoEstoque = from prod in contexto.Produto.Where(x => x.quantidade <= 0 
                                                                          && x.isQuarto == false
                                                                          && x.isServico == false).ToList()
                                    orderby prod.quantidade ascending
                                    select new
                                    {
                                        Qtde = prod.quantidade,
                                        Código = prod.codigo,
                                        Descrição = prod.descricao
                                    };
            dgvProdAbaixoEstoque.DataSource = "";
            dgvProdAbaixoEstoque.DataSource = ProdAbaixoEstoque.ToList();
            txtProdAbaixoEstoque.Text = "Total de Produtos = " + ProdAbaixoEstoque.Count();
            txtQtde.Text = "0";
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            frmRelatorioVendas frm = new frmRelatorioVendas();
            frm.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            frmRelatorioReservas frm = new frmRelatorioReservas();
            frm.ShowDialog();
        }

        private void txtQtde_Leave(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            if (txtQtde.Text.Trim() != "")
            {
                int qtde = Convert.ToInt32(txtQtde.Text.Trim());
                var ProdAbaixoEstoque = from prod in contexto.Produto.Where(x => x.quantidade <= qtde
                                                                              && x.isQuarto == false
                                                                              && x.isServico == false).ToList()
                                        orderby prod.quantidade ascending
                                        select new
                                        {
                                            Qtde = prod.quantidade,
                                            Código = prod.codigo,
                                            Descrição = prod.descricao
                                        };
                dgvProdAbaixoEstoque.DataSource = "";
                dgvProdAbaixoEstoque.DataSource = ProdAbaixoEstoque.ToList();
                txtProdAbaixoEstoque.Text = "Total de Produtos = " + ProdAbaixoEstoque.Count();
            }
            else
            {
                txtQtde.Text = "0";
                var ProdAbaixoEstoque = from prod in contexto.Produto.Where(x => x.quantidade <= 0).ToList()
                                        orderby prod.quantidade ascending
                                        select new
                                        {
                                            Qtde = prod.quantidade,
                                            Código = prod.codigo,
                                            Descrição = prod.descricao
                                        };
                dgvProdAbaixoEstoque.DataSource = "";
                dgvProdAbaixoEstoque.DataSource = ProdAbaixoEstoque.ToList();
                txtProdAbaixoEstoque.Text = "Total de Produtos = " + ProdAbaixoEstoque.Count();
            }
        }

        private void txtQtde_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();

            int qtde = (txtQtde.Text.Trim() == "") ? 0 : Convert.ToInt32(txtQtde.Text.Trim());
            var ProdAbaixoEstoque = from prod in contexto.Produto.Where(x => x.quantidade <= qtde
                                                                          && x.isQuarto == false
                                                                          && x.isServico == false).ToList()
                                    orderby prod.quantidade ascending
                                    select new
                                    {
                                        Qtde = prod.quantidade,
                                        Código = prod.codigo,
                                        Descrição = prod.descricao
                                    };
            dgvProdAbaixoEstoque.DataSource = "";
            dgvProdAbaixoEstoque.DataSource = ProdAbaixoEstoque.ToList();
            txtProdAbaixoEstoque.Text = "Total de Produtos = " + ProdAbaixoEstoque.Count();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            lblTotFunc.Text = contexto.Funcionario.Count().ToString();
            lblTotCli.Text = contexto.Cliente.Count().ToString();

            DateTime data = DateTime.Now.AddDays(-1);
            double receita = 0;

            try
            {
                receita = contexto.Historico.Where(x => x.data > data).Sum(x => x.valor);
            }
            catch (Exception)
            {

            }

            lblReceita.Text = receita.ToString("C");

            //Calculo de Capacidade de reservas
            int desocupados = contexto.Quarto.Count(x => x.disponivel == true);
            int total = contexto.Quarto.Count();
            lblTotCapacidade.Text = desocupados.ToString() + "/" + total.ToString();
            int pocentagem = 100;
            try
            {
                pocentagem = Convert.ToInt32((decimal)desocupados / (decimal)total * (decimal)100);
            }
            catch (Exception) { }

            if (pocentagem < 50)
            {
                label7.Visible = false;
                pictureBox9.Visible = true;
                label10.Visible = true;
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Sua capacidade\n disponível é de " + pocentagem + "%";
                pictureBox9.Visible = false;
                label10.Visible = false;
            }

            //dgvVendasDiarias
            var historico = from hist in contexto.Historico.Where(x => x.data > data).ToList()
                            select new
                            {
                                Código = hist.id,
                                Descrição = hist.descricao,
                                Data = hist.data,
                                Valor = hist.valor
                            };
            dgvVendasDiarias.DataSource = "";
            dgvVendasDiarias.DataSource = historico.ToList();
            dgvVendasDiarias.Columns["Valor"].DefaultCellStyle.Format = "C";

            //dgvMetricaAnual
            var Metricas = from metrica in contexto.Historico.ToList()
                           orderby metrica.data descending
                           group metrica by new { metrica.data.Year, metrica.data.Month } into m
                           select new
                           {
                               Mes = m.Key.Month + "/" + m.Key.Year,
                               Valor = m.Sum(x => x.valor).ToString("C"),
                               qtde = m.Count()
                           };
            dgvMetricaAnual.DataSource = Metricas.ToList();

            //dgvProdAbaixoEstoque
            int qtde = Convert.ToInt32(txtQtde.Text.Trim());
            var ProdAbaixoEstoque = from prod in contexto.Produto.Where(x => x.quantidade <= qtde
                                                                          && x.isQuarto == false
                                                                          && x.isServico == false).ToList()
                                    orderby prod.quantidade ascending
                                    select new
                                    {
                                        Qtde = prod.quantidade,
                                        Código = prod.codigo,
                                        Descrição = prod.descricao
                                    };
            dgvProdAbaixoEstoque.DataSource = "";
            dgvProdAbaixoEstoque.DataSource = ProdAbaixoEstoque.ToList();
            txtProdAbaixoEstoque.Text = "Total de Produtos = " + ProdAbaixoEstoque.Count();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            frmRelatorioProdutos frm = new frmRelatorioProdutos();
            frm.ShowDialog();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            frmRelatorioConsumo frm = new frmRelatorioConsumo();
            frm.ShowDialog();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            frmRelatorioFuncionarios frm = new frmRelatorioFuncionarios();
            frm.ShowDialog();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            frmRelatorioServicos frm = new frmRelatorioServicos();
            frm.ShowDialog();
        }
    }
}
