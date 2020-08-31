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

namespace HotelPet.Funcionarios.Clinica
{
    public partial class Consulta : Form
    {
        Contexto contexto = new Contexto();
        frmClinica frmClinica = new frmClinica();

        public Consulta()
        {
            InitializeComponent();
        }

        public Consulta(frmClinica frmClinica)
        {
            InitializeComponent();
            this.frmClinica = frmClinica;
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            var lstCli = from cli in contexto.Cliente.Where(x => x.nome != null).ToList()
                             orderby cli.nome
                             select new
                             {
                                 Codigo = cli.id,
                                 Cliente = cli.nome,
                                 CPF = cli.cpf,
                                 RG = cli.rg,
                                 Cidade = cli.cidade,
                                 UF = cli.uf,
                                 Telefone = cli.telefone,
                                 Email = cli.email
                             };


            dgvCli.DataSource = "";
            dgvCli.DataSource = lstCli.ToList();
        }

        private void dgvCli_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int idCli = Convert.ToInt32(dgvCli.SelectedRows[0].Cells["Codigo"].Value);
                frmClinica.idCliente = idCli;

                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void txtbusca_KeyUp(object sender, KeyEventArgs e)
        {
            string nome = txtbusca.Text.Trim().ToLower();

            var lstCli = from cli in contexto.Cliente.Where(x => x.nome.Trim().ToLower().Contains(nome)).ToList()
                         orderby cli.nome
                         select new
                         {
                             Codigo = cli.id,
                             Cliente = cli.nome,
                             CPF = cli.cpf,
                             RG = cli.rg,
                             Cidade = cli.cidade,
                             UF = cli.uf,
                             Telefone = cli.telefone,
                             Email = cli.email
                         };


            dgvCli.DataSource = "";
            dgvCli.DataSource = lstCli.ToList();
        }
    }
}
