using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.MODEL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin.Report
{
    public partial class frmRelatorioFuncionarios : Form
    {
        public frmRelatorioFuncionarios()
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

        private void frmRelatorioFuncionarios_Load(object sender, EventArgs e)
        {
            dataIni.Value = DateTime.Now.AddMonths(-1);
            dataFim.Value = DateTime.Now;
            rdbTodos.Checked = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            string nomeArquivo = "RELATÓRIO_DE_FUNCIONARIOS";

            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;
            List<Funcionario> lstFuncionarios = contexto.Funcionario.ToList();

            var lstVendas = from ven in contexto.ListaCompras.ToList()
                            group ven by ven.Vendas.Funcionario_id into v
                            select new
                            {
                                Funcionario_id = v.Key,
                                qtde = v.Count(),
                                total = v.Sum(x => x.total)
                            };

            if (rdbTodos.Checked)
            {
                lstVendas = from ven in contexto.ListaCompras.ToList()
                            group ven by ven.Vendas.Funcionario_id into v
                            select new
                            {
                                Funcionario_id = v.Key,
                                qtde = v.Count(),
                                total = v.Sum(x => x.total)
                            };
            }

            else if (rdbPeriodo.Checked)
            {
                lstVendas = from ven in contexto.ListaCompras.Where(x => x.Vendas.data >= dataIni.Value && x.Vendas.data <= dataFim.Value).ToList()
                            group ven by ven.Vendas.Funcionario_id into v
                            select new
                            {
                                Funcionario_id = v.Key,
                                qtde = v.Count(),
                                total = v.Sum(x => x.total)
                            };
            }

            else //Data
            {
                lstVendas = from ven in contexto.ListaCompras.Where(x => x.Vendas.data == dataIni.Value).ToList()
                            group ven by ven.Vendas.Funcionario_id into v
                            select new
                            {
                                Funcionario_id = v.Key,
                                qtde = v.Count(),
                                total = v.Sum(x => x.total)
                            };
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

            planilha.Cells[linha, coluna].Value = "FUNCIONÁRIO";
            planilha.Cells[linha, ++coluna].Value = "QTDE VENDAS";
            planilha.Cells[linha, ++coluna].Value = "TOTAL";

            foreach (var func in lstFuncionarios.OrderBy(x=> x.nome))
            {
                coluna = 1;
                linha++;

                planilha.Cells[linha, coluna].Value = func.nome; //"FUNCIONÁRIO";

                var lista = lstVendas.FirstOrDefault(x => x.Funcionario_id == func.id);
                int qtde = (lista == null) ? 0 : lista.qtde;
                double total = (lista == null) ? 0 : lista.total;

                planilha.Cells[linha, ++coluna].Value = qtde; //"QTDE VENDAS";
                planilha.Cells[linha, ++coluna].Value = total; //"TOTAL";
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:C" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:C" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:C" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:C" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            planilha.Cells["C:C"].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

            //Formatando Textos
            planilha.Cells["A1:C1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:C1"].Style.Font.Size = 11;
            planilha.Cells["A1:C1"].Style.Font.Bold = true;

            //Cor do Background da celula
            planilha.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(166, 166, 166));

            //Alinhando Todas as celulas
            planilha.Cells["B:B"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            //Alinhando cabeçalho
            planilha.Cells["A1:C1" + linha].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            planilha.Cells["A1:C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            planilha.View.ShowGridLines = false;
            planilha.Cells[planilha.Dimension.Address].AutoFitColumns();

            //planilha.Column(10).Width = 28;

            arquivoExcel.Save();
            arquivoExcel.Dispose();

            Process.Start(arquivo);
        }
    }
}
