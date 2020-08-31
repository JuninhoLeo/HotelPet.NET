using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Funcionarios.Clinica
{
    public partial class frmTelaImpressao : Form
    {
        public frmTelaImpressao(string medico, string conteudo, int cliente, int animal, string tipo)
        {
            InitializeComponent();
            rvClinica.LocalReport.DataSources.Clear();
            rvClinica.LocalReport.ReportEmbeddedResource = "HotelPet.Funcionarios.Clinica.ReceitaAtestado.rdlc";

            Contexto contexto = new Contexto();
            Cliente cli = contexto.Cliente.FirstOrDefault(x => x.id == cliente);
            Animal ani = contexto.Animal.FirstOrDefault(x => x.id == animal);

            ReportParameter[] p = new ReportParameter[6];
            p[0] = new ReportParameter("medico", medico);
            p[1] = new ReportParameter("conteudo", conteudo);

            if(cli != null)
                p[2] = new ReportParameter("cliente", cli.nome);

            if(ani != null)
            p[3] = new ReportParameter("animal", ani.nome);

            if (ani != null)
                p[4] = new ReportParameter("especie", ani.especie);

            p[5] = new ReportParameter("tipo", tipo);

            rvClinica.LocalReport.SetParameters(p);
            rvClinica.LocalReport.Refresh();
            rvClinica.RefreshReport();
        }

        private void frmTelaImpressao_Load(object sender, EventArgs e)
        {
            this.rvClinica.RefreshReport();
            
        }
    }
}
