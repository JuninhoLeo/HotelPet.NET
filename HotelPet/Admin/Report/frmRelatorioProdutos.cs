using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin.Report
{
    public partial class frmRelatorioProdutos : Form
    {
        public frmRelatorioProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {            
            rdbTodos.Checked = true;
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            txtQtde.Enabled = false;
            txtQtde.Text = "";
        }

        private void rdbQtde_CheckedChanged(object sender, EventArgs e)
        {
            txtQtde.Enabled = true;
            txtQtde.Text = "";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            string nomeArquivo = "RELATÓRIO_DE_PRODUTOS";

            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;
            List<Produtos> lstProdutos = new List<Produtos>();

            if (rdbTodos.Checked)
            {
                lstProdutos = contexto.Produto.ToList();
            }

            else if (rdbQtde.Checked)
            {
                double qtde = Convert.ToDouble(txtQtde.Text);
                lstProdutos = contexto.Produto.Where(x => x.quantidade <= qtde
                                                       && x.isQuarto == false
                                                       && x.isServico == false).ToList();
            }

            string dataArquivo = DateTime.Now.ToShortDateString();
            string horaArquivo = DateTime.Now.ToLongTimeString();
            arquivo += "_" + dataArquivo.Replace("/", "-") + ".xlsx";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }

            FileInfo caminhoNomeArquivo = new FileInfo(arquivo);
            ExcelPackage arquivoExcel = new ExcelPackage(caminhoNomeArquivo);

            ExcelWorksheet planilha = arquivoExcel.Workbook.Worksheets.Add("Plan1");

            int linha = 1;
            int coluna = 1;
            planilha.Cells[linha, coluna].Value = "CÓDIGO";
            planilha.Cells[linha, ++coluna].Value = "DESCRIÇÃO";
            planilha.Cells[linha, ++coluna].Value = "QTDE";
            planilha.Cells[linha, ++coluna].Value = "VALOR";
            planilha.Cells[linha, ++coluna].Value = "REMOVER";

            int i = 0;
            foreach (var prod in lstProdutos.OrderBy(x => x.descricao))
            {
                coluna = 1;
                linha++;

                planilha.Cells[linha, coluna].Value = prod.codigo;
                planilha.Cells[linha, ++coluna].Value = prod.descricao;
                planilha.Cells[linha, ++coluna].Value = prod.quantidade;
                planilha.Cells[linha, ++coluna].Value = prod.valor;
                planilha.Cells[linha, ++coluna].Value = "N";                             
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:E" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            planilha.Cells["D:D"].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

            //Formatando Textos
            planilha.Cells["A1:E1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:E1"].Style.Font.Size = 11;
            planilha.Cells["A1:E1"].Style.Font.Bold = true;

            //Cor do Background da celula
            planilha.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(166, 166, 166));

            //Alinhando Todas as celulas
            planilha.Cells["A:A"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["C:C"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["E:E"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Alinhando cabeçalho
            planilha.Cells["A1:E1" + linha].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            planilha.Cells["A1:E1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            planilha.View.ShowGridLines = false;
            planilha.Cells[planilha.Dimension.Address].AutoFitColumns();

            //planilha.Column(10).Width = 28;

            arquivoExcel.Save();
            arquivoExcel.Dispose();

            System.Diagnostics.Process.Start(arquivo);
        }

        private void txtQtde_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtQtde.Text.Trim() != "")
                {
                    double qtde = Convert.ToDouble(txtQtde.Text);
                }
            }
            catch
            {
                MessageBox.Show("Somente Números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtQtde.Text = "";
            }
        }
    }
}
