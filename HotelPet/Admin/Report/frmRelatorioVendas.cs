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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin.Report
{
    public partial class frmRelatorioVendas : Form
    {
        public frmRelatorioVendas()
        {
            InitializeComponent();
        }

        private void frmRelatorioVendas_Load(object sender, EventArgs e)
        {
            dataIni.Value = DateTime.Now.AddMonths(-1);
            dataFim.Value = DateTime.Now;
            rdbTodos.Checked = true;
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = true;
            dataFim.Enabled = false;
        }

        private void rdbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = true;
            dataFim.Enabled = true;
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            dataIni.Enabled = false;
            dataFim.Enabled = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            string nomeArquivo = "RELATÓRIO_DE_VENDAS";

            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;
            List<Venda> lstVendas = new List<Venda>();

            if (rdbTodos.Checked)
            {
                lstVendas = contexto.Venda.ToList();
            }

            else if (rdbPeriodo.Checked)
            {
                lstVendas = contexto.Venda.Where(x=> x.data >= dataIni.Value && x.data <= dataFim.Value).ToList();
            }

            else //Data
            {
                lstVendas = contexto.Venda.Where(x => x.data == dataIni.Value).ToList();
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
            planilha.Cells[linha, coluna].Value = "DATA";
            planilha.Cells[linha, ++coluna].Value = "HORA";
            planilha.Cells[linha, ++coluna].Value = "FUNCIONÁRIO";
            planilha.Cells[linha, ++coluna].Value = "CLIENTE";
            planilha.Cells[linha, ++coluna].Value = "ITENS";
            planilha.Cells[linha, ++coluna].Value = "Vl. TOTAL";

            foreach (var vend in lstVendas.OrderBy(x => x.Funcionario.nome))
            {
                coluna = 1;
                linha++;

                planilha.Cells[linha, coluna].Value = vend.data.ToShortDateString(); //"DATA";
                planilha.Cells[linha, ++coluna].Value = vend.data.ToShortTimeString(); //"HORA";
                planilha.Cells[linha, ++coluna].Value = vend.Funcionario.nome; //"FUNCIONÁRIO";
                planilha.Cells[linha, ++coluna].Value = (vend.Cliente.nome == null) ? "Não informado" : vend.Cliente.nome; //"CLIENTE";

                List<ListaCompra> lstCompras = contexto.ListaCompras.Where(x => x.Vendas_id == vend.id).ToList();
                string compras = "";
                double total = 0;
                foreach (var item in lstCompras)
                {
                    compras += (item.descricao + "" +
                                "\nQtde: " + item.Quantidade + " Valor: " + item.valor.ToString("C")) 
                                + "\n---------------------\n";
                    total += item.total;
                }

                planilha.Cells[linha, ++coluna].Style.WrapText = true;
                planilha.Cells[linha, coluna].Value = compras; //"ITENS";
                planilha.Cells[linha, ++coluna].Value = total; //"Vl. TOTAL";
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:F" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:F" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:F" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:F" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            planilha.Cells["F:F"].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

            //Formatando Textos
            planilha.Cells["A1:F1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:F1"].Style.Font.Size = 11;
            planilha.Cells["A1:F1"].Style.Font.Bold = true;

            //Cor do Background da celula
            planilha.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(166, 166, 166));

            //Alinhando Todas as celulas
            planilha.Cells["A:B"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Alinhando cabeçalho
            planilha.Cells["A1:F1" + linha].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            planilha.Cells["A1:F1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["E1:E" + linha].Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;

            planilha.View.ShowGridLines = false;
            planilha.Cells[planilha.Dimension.Address].AutoFitColumns();

            planilha.Column(5).Width = 80;

            arquivoExcel.Save();
            arquivoExcel.Dispose();

            System.Diagnostics.Process.Start(arquivo);
        }
    }
}
