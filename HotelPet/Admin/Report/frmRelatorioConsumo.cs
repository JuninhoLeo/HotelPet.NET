﻿using HotelPet.Entity;
using HotelPet.Layers.MODEL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet.Admin.Report
{
    public partial class frmRelatorioConsumo : Form
    {
        public frmRelatorioConsumo()
        {
            InitializeComponent();
        }

        private void frmRelatorioConsumo_Load(object sender, EventArgs e)
        {
            dataIni.Value = DateTime.Now.AddMonths(-1);
            dataFim.Value = DateTime.Now;
            rdbTodos.Checked = true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            string nomeArquivo = "RELATÓRIO_DE_PRODUTOS_MAIS_CONSUMIDOS";

            string folder = @"c:\Relatórios";
            string arquivo = @"C:\Relatórios\" + nomeArquivo;
            var lstConsumo = from prod in contexto.ListaCompras.ToList()
                             group prod by new { prod.Vendas.data.Date, prod.Codigo, prod.descricao } into p
                             select new
                             {
                                 p.Key.Codigo,
                                 data = p.Key.Date,
                                 p.Key.descricao,
                                 Qtde = p.Count(),
                                 Valor = p.FirstOrDefault(x => x.Codigo == p.Key.Codigo).valor
                             };

            if (rdbTodos.Checked)
            {
                lstConsumo = from prod in contexto.ListaCompras.ToList()
                             group prod by new { prod.Vendas.data.Date, prod.Codigo, prod.descricao } into p
                             select new
                             {
                                 p.Key.Codigo,
                                 data = p.Key.Date,
                                 p.Key.descricao,
                                 Qtde = p.Count(),
                                 Valor = p.FirstOrDefault(x => x.Codigo == p.Key.Codigo).valor
                             };
            }

            else if (rdbPeriodo.Checked)
            {
                lstConsumo = from prod in contexto.ListaCompras.Where(x => x.Vendas.data >= dataIni.Value && x.Vendas.data <= dataFim.Value).ToList()
                             group prod by new { prod.Vendas.data.Date, prod.Codigo, prod.descricao } into p
                             select new
                             {
                                 p.Key.Codigo,
                                 data = p.Key.Date,
                                 p.Key.descricao,
                                 Qtde = p.Count(),
                                 Valor = p.FirstOrDefault(x => x.Codigo == p.Key.Codigo).valor
                             };
            }

            else //Data
            {
                lstConsumo = from prod in contexto.ListaCompras.Where(x => x.Vendas.data == dataIni.Value).ToList()
                             group prod by new { prod.Vendas.data.Date, prod.Codigo, prod.descricao } into p
                             select new
                             {
                                 p.Key.Codigo,
                                 data = p.Key.Date,
                                 p.Key.descricao,
                                 Qtde = p.Count(),
                                 Valor = p.FirstOrDefault(x => x.Codigo == p.Key.Codigo).valor
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
            planilha.Cells[linha, coluna].Value = "CÓDIGO";
            planilha.Cells[linha, ++coluna].Value = "DATA";
            planilha.Cells[linha, ++coluna].Value = "DESCRIÇÃO";
            planilha.Cells[linha, ++coluna].Value = "QTDE VENDIDO";
            planilha.Cells[linha, ++coluna].Value = "VALOR";

            foreach (var prod in lstConsumo.OrderByDescending(x => x.Qtde))
            {
                coluna = 1;
                linha++;

                planilha.Cells[linha, coluna].Value = prod.Codigo; //"CÓDIGO";
                planilha.Cells[linha, ++coluna].Value = prod.data.ToShortDateString(); //"DATA";
                planilha.Cells[linha, ++coluna].Value = prod.descricao; //"DESCRIÇÃO";
                planilha.Cells[linha, ++coluna].Value = prod.Qtde; //"QTDE VENDIDO";
                planilha.Cells[linha, ++coluna].Value = prod.Valor; //"VALOR";
            }

            //CRIANDO LINHA DO CABEÇALHO DA TABELA
            planilha.Cells["A1:E" + linha].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells["A1:E" + linha].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            //formatando valores
            planilha.Cells["E:E"].Style.Numberformat.Format = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

            //Formatando Textos
            planilha.Cells["A1:E1"].Style.Font.Name = "Arial";
            planilha.Cells["A1:E1"].Style.Font.Size = 11;
            planilha.Cells["A1:E1"].Style.Font.Bold = true;

            //Cor do Background da celula
            planilha.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(166, 166, 166));

            //Alinhando Todas as celulas
            planilha.Cells["A:B"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            planilha.Cells["D:D"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

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
    }
}
