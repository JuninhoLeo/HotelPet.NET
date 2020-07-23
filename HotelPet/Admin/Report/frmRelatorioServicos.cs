using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.MODEL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin.Report
{
    public partial class frmRelatorioServicos : Form
    {
        public frmRelatorioServicos()
        {
            InitializeComponent();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = false;
            dataFim.Enabled = false;
        }

        private void rdbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = true;
            dataFim.Enabled = true;
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = true;
            dataFim.Enabled = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            string nomeArquivo = "RELATÓRIO_DE_SERVIÇOS_MAIS_PROCURADOS";

            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;

            List<Produtos> lstServicos = contexto.Produto.Where(x => x.isQuarto == false && x.isServico == true).ToList();
            List<ListaCompra> lstCompra = new List<ListaCompra>();
            List<Consumo> lstConsumo = new List<Consumo>();




            if (rdbTodos.Checked)
            {
                lstCompra = contexto.ListaCompras.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true).ToList();
                lstConsumo = contexto.Consumo.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true).ToList();
            }

            else if (rdbPeriodo.Checked)
            {
                lstCompra = contexto.ListaCompras.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true
                                                          && x.Vendas.data >= dataIni.Value
                                                          && x.Vendas.data <= dataFim.Value).ToList();

                lstConsumo = contexto.Consumo.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true
                                                           && x.data >= dataIni.Value
                                                           && x.data <= dataFim.Value).ToList();
            }

            else //Data
            {
                lstCompra = contexto.ListaCompras.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true
                                                          && x.Vendas.data == dataIni.Value).ToList();

                lstConsumo = contexto.Consumo.Where(x => x.Produtos.isQuarto == false && x.Produtos.isServico == true
                                                      && x.data == dataIni.Value).ToList();
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

            planilha.Cells[linha, coluna].Value = "COD. SERVIÇO";
            planilha.Cells[linha, ++coluna].Value = "DESCRIÇÃO";
            planilha.Cells[linha, ++coluna].Value = "VENDAS(%)";
            planilha.Cells[linha, ++coluna].Value = "HOTEL(%)";
            
            foreach (var serv in lstServicos.OrderBy(x => x.descricao))
            {
                coluna = 1;
                linha++;

                double compras = lstCompra.Where(x => x.Produtos.codigo == serv.codigo).Sum(x => x.Quantidade);
                int totalVenda = lstCompra.Count();
                int PercVenda = (int)((compras / totalVenda) * 100);

                double consumos = lstConsumo.Where(x => x.Produtos.codigo == serv.codigo).Sum(x => x.Quantidade);
                int totalHosp = lstConsumo.Count();
                int PercHosp = (int)((consumos / totalHosp) * 100);

                planilha.Cells[linha, coluna].Value = serv.codigo;
                planilha.Cells[linha, ++coluna].Value = serv.descricao;
                planilha.Cells[linha, ++coluna].Value = PercVenda;
                planilha.Cells[linha, ++coluna].Value = PercHosp;
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:D" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:D" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:D" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:D" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            //planilha.Cells["E:E"].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

            //Formatando Textos
            planilha.Cells["A1:D1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:D1"].Style.Font.Size = 11;
            planilha.Cells["A1:D1"].Style.Font.Bold = true;

            //Cor do Background da celula
            planilha.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(166, 166, 166));

            //Alinhando Todas as celulas
            planilha.Cells["A:A"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["C:D"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Alinhando cabeçalho
            planilha.Cells["A1:D1" + linha].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            planilha.Cells["A1:D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            planilha.View.ShowGridLines = false;
            planilha.Cells[planilha.Dimension.Address].AutoFitColumns();

            //planilha.Column(10).Width = 28;

            arquivoExcel.Save();
            arquivoExcel.Dispose();

            System.Diagnostics.Process.Start(arquivo);
        }

        private void frmRelatorioServicos_Load(object sender, EventArgs e)
        {
            dataIni.Value = DateTime.Now.AddMonths(-1);
            dataFim.Value = DateTime.Now;

            rdbTodos.Checked = true;
        }
    }
}
