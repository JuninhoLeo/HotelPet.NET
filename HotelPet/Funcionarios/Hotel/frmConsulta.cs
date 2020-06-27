using HotelPet.Camadas.MODEL;
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

namespace HotelPet.Funcionarios.Hotel
{
    public partial class frmConsulta : Form
    {

        frmHotel frmHotel = new frmHotel();
        Contexto contexto = new Contexto();

        public frmConsulta()
        {
            InitializeComponent();
        }

        public frmConsulta(frmHotel frmHotel)
        {
            InitializeComponent();
            this.frmHotel = frmHotel;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            var lstReserva = from Res in contexto.Reserva.Where(x=> x.Animal.hospedado == true && x.pago == false).ToList()
                             orderby Res.Cliente.nome
                             select new
                             {
                                 Codigo = Res.id,
                                 idCli = Res.Cliente.id,
                                 Cliente = Res.Cliente.nome,
                                 idAnimal = Res.Animal.id, 
                                 Animal = Res.Animal.nome,
                                 Entrada = Res.entrada,
                                 Saída = Res.saida,
                                 Quarto = Res.Quarto.numero,
                                 Funcionário = Res.Funcionario.nome,
                             };


            dgvhotel.DataSource = "";
            dgvhotel.DataSource = lstReserva.ToList();

            dgvhotel.Columns["idCli"].Visible = false;
            dgvhotel.Columns["idAnimal"].Visible = false;
        }

        private void dgvProdutos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int idCli = Convert.ToInt32(dgvhotel.SelectedRows[0].Cells["idCli"].Value);
                int idAnimal = Convert.ToInt32(dgvhotel.SelectedRows[0].Cells["idAnimal"].Value);

                frmHotel.idCliente = idCli;

                List<Animal> lstAnimal = contexto.Animal.Where(x => x.Cliente.id == idCli && x.hospedado == true).OrderBy(x => x.nome).ToList();

                frmHotel.listAnimal = lstAnimal;
                frmHotel.idAnimal = idAnimal;

                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string nome = txtbusca.Text.Trim().ToLower();

            var lstReserva = from Res in contexto.Reserva.Where(x => x.Cliente.nome.Trim().ToLower().Contains(nome) 
                                                                  && x.Animal.hospedado == true
                                                                  && x.pago == false).ToList()
            orderby Res.Cliente.nome
                             select new
                             {
                                 Codigo = Res.id,
                                 idCli = Res.Cliente.id,
                                 Cliente = Res.Cliente.nome,
                                 idAnimal = Res.Animal.id,
                                 Animal = Res.Animal.nome,
                                 Entrada = Res.entrada,
                                 Saída = Res.saida,
                                 Quarto = Res.Quarto.numero,
                                 Funcionário = Res.Funcionario.nome,
                             };


            dgvhotel.DataSource = "";
            dgvhotel.DataSource = lstReserva.ToList();

            dgvhotel.Columns["idCli"].Visible = false;
            dgvhotel.Columns["idAnimal"].Visible = false;
        }
    }
}
