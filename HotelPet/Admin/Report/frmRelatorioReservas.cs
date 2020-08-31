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
    public partial class frmRelatorioReservas : Form
    {
        private object contexto;

        public frmRelatorioReservas()
        {
            InitializeComponent();
        }

        private  void Verifica()
        {
            if (rdbData.Checked)
            {
                dataIni.Enabled = true;
                dataFim.Enabled = false;
            }
            else if (rdbPeriodo.Checked)
            {
                dataIni.Enabled = true;
                dataFim.Enabled = true;
            }
            else if (rdbTodos.Checked)
            {
                dataIni.Enabled = false;
                dataFim.Enabled = false;
            }
        }

        private void frmReservas_Load(object sender, EventArgs e)
        {
            dataIni.Value = DateTime.Now.AddMonths(-1);
            dataFim.Value = DateTime.Now;
            rdbTodos.Checked = true;
            Verifica();
        }

        private void rdbData_CheckedChanged(object sender, EventArgs e)
        {
            Verifica();
        }

        private void rdbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            Verifica();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            Verifica();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            // isso é só para o cabeçalho ficar dinamico
            DateTime dataCab = dataIni.Value;
            string dataCabecalho = dataCab.Month.ToString();

            while (dataCab.Month < dataFim.Value.Month)
            {
                dataCab = dataCab.AddMonths(1);
                dataCabecalho += "/" + dataCab.Month.ToString();
            }

            string nomeArquivo = "RELATÓRIO_DE_RESERVAS_REALIZADAS";
            
            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;
            List<Reserva> lstReservas = new List<Reserva>();

            if (rdbTodos.Checked)
            {
                lstReservas = contexto.Reserva.Where(x=> x.saida != null).OrderBy(x=> x.entrada).ToList();
            }
            else if (rdbData.Checked)
            {
                lstReservas = contexto.Reserva.Where(x => x.entrada.Date.ToShortDateString() == dataIni.Value.ToShortDateString() && x.saida != null).ToList();
            }
            else if (rdbPeriodo.Checked)
            {
                lstReservas = contexto.Reserva.Where(x => x.entrada >= dataIni.Value && x.entrada <= dataFim.Value && x.saida != null).OrderBy(x => x.entrada).ToList();
            }

            string dataArquivo = DateTime.Now.ToShortDateString();
            string horaArquivo = DateTime.Now.ToLongTimeString();
            arquivo +=  "_" + dataArquivo.Replace("/", "-") + ".xlsx";

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
            planilha.Cells[linha, coluna].Value = "SEQ";
            planilha.Cells[linha, ++coluna].Value = "CLIENTE";
            planilha.Cells[linha, ++coluna].Value = "ANIMAL";
            planilha.Cells[linha, ++coluna].Value = "ENTRADA";
            planilha.Cells[linha, ++coluna].Value = "SAÍDA";
            planilha.Cells[linha, ++coluna].Value = "CUSTAS";
            planilha.Cells[linha, ++coluna].Value = "CANIL";
            planilha.Cells[linha, ++coluna].Value = "N° DO CANIL";
            planilha.Cells[linha, ++coluna].Value = "Vl. Diária";
            planilha.Cells[linha, ++coluna].Value = "Qtde Dias";
            planilha.Cells[linha, ++coluna].Value = "TOTAL";
            planilha.Cells[linha, ++coluna].Value = "FUNCIONÁRIO";

            int i = 0;
            foreach (var res in lstReservas.OrderBy(x=> x.entrada))
            {
                coluna = 1;
                linha++;

                double valor = contexto.Consumo.Where(x => x.Reserva_id == res.id).ToList().Sum(x=> x.valor);
                var consumo = contexto.Consumo.FirstOrDefault(x => x.Reserva_id == res.id);

                planilha.Cells[linha, coluna].Value = ++i;//"SEQ";
                planilha.Cells[linha, ++coluna].Value = res.Cliente.nome;//"CLIENTE";
                planilha.Cells[linha, ++coluna].Value = res.Animal.nome;//"ANIMAL";
                planilha.Cells[linha, ++coluna].Value = res.entrada; //"ENTRADA";
                planilha.Cells[linha, ++coluna].Value = res.saida; //"SAÍDA";


                planilha.Cells[linha, ++coluna].Style.WrapText = true;
                planilha.Cells[linha, coluna].Value = valor;//"CUSTAS";
                planilha.Cells[linha, ++coluna].Value = (consumo == null)? "" : consumo.Produtos.descricao;//"CANIL";
                planilha.Cells[linha, ++coluna].Value = res.Quarto.numero;//"N° DO CANIL";
                planilha.Cells[linha, ++coluna].Value = res.Quarto.valor;//"Diária";
                planilha.Cells[linha, ++coluna].Value = (consumo == null) ? 0 : consumo.Produtos.quantidade;//"Qtde";
                planilha.Cells[linha, ++coluna].Value = (consumo == null) ? 0 : consumo.Produtos.valor;//"Valor";
                planilha.Cells[linha, ++coluna].Value = res.Funcionario.nome;//"FUNCIONÁRIO";
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:L" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:L" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:L" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:L" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            planilha.Cells["D:E"].Style.Numberformat.Format = "dd/MM/yyyy";
            planilha.Cells["F:F"].Style.Numberformat.Format = "R$ #,##0.00";
            planilha.Cells["I:I"].Style.Numberformat.Format = "R$ #,##0.00";
            planilha.Cells["K:K"].Style.Numberformat.Format = "R$ #,##0.00";

            //Formatando Textos
            planilha.Cells["A1:L1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:L1"].Style.Font.Size = 8;
            planilha.Cells["A1:L1"].Style.Font.Bold = true;
            planilha.Cells["A1:L1"].Style.Font.Color.SetColor(Color.White);

            //Cor do Background da celula
            planilha.Cells["A1:L1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:L1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(24, 71, 97));

            //Alinhando Todas as celulas
            planilha.Cells["A:A"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["D:E"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["F:F"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            planilha.Cells["I:I"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            planilha.Cells["K:K"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            planilha.Cells["J:J"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            
            //Alinhando cabeçalho
            planilha.Cells["A1:L1"+ linha].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            planilha.Cells["A1:L1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            planilha.View.ShowGridLines = false;
            planilha.Cells[planilha.Dimension.Address].AutoFitColumns();

            //planilha.Column(10).Width = 28;

            arquivoExcel.Save();
            arquivoExcel.Dispose();

            System.Diagnostics.Process.Start(arquivo);

        }
    }
}
