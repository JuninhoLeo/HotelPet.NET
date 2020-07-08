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
            double receita = contexto.Historico.Where(x=> x.data > data).Sum(x => x.valor);
            lblReceita.Text = receita.ToString("C");


            //Calculo de Capacidade de reservas
            int desocupados = contexto.Quarto.Count(x => x.disponivel == true);
            int total = contexto.Quarto.Count();
            lblTotCapacidade.Text = desocupados.ToString() + "/" + total.ToString();
            int pocentagem = desocupados * (total / 100);
            if (pocentagem > 50)
            {
                pictureBox9.Visible = true;
                label10.Visible = true;
            }
            else
            {
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
                           orderby metrica.data ascending
                           group metrica by new { metrica.data.Year, metrica.data.Month } into m
                           select new
                           {
                               Mes = m.Key.Month + "/" + m.Key.Year,
                               Valor = m.Sum(x=> x.valor).ToString("C"),
                               qtde = m.Count()
                           };
            dgvMetricaAnual.DataSource = "";
            dgvMetricaAnual.DataSource = Metricas.ToList();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
