using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmHotel : Form
    {
        Contexto contexto = new Contexto();

        public frmHotel()
        {
            InitializeComponent();
        }

        private void frmHotel_Load(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            dtpSaida.Enabled = false;
            ckNotInform.Checked = true;
            cmbNumero.Enabled = false;
            cmbNumero.Text = "";

            dtpEntr.Value = DateTime.Now;
            dtpSaida.Value = DateTime.Now;

            lblcli.Text = "";
            lblAnimal.Text = "";
            lblEspecie.Text = "";
            lblQuarto.Text = "";
            lblNumQuarto.Text = "";
            lblEntrada.Text = "";
            lblSaida.Text = "Não Informado";
            lblValor.Text = "";

            int val = 0;
            txtValorTotal.Text = val.ToString("C");
            txtBuscQuarto.Text = "";
            txtBuscaCli.Text = "";

            cmbClientes.DataSource = contexto.Cliente.Where(x => x.nome != null).OrderBy(x => x.nome).ToList();
            cmbClientes.DisplayMember = "nome";
            cmbClientes.ValueMember = "id";

            dgvCli.DataSource = "";
            dgvCli.DataSource = contexto.Cliente.Where(x => x.nome.Contains("")).OrderBy(x => x.nome).ToList();
            dgvCli.Columns["id"].Visible = false;

            dgvQuarto.DataSource = "";
            dgvQuarto.DataSource = contexto.Quarto.Where(x => x.disponivel == true).OrderByDescending(x => x.descricao).ToList();
            dgvQuarto.Columns["id"].Visible = false;
            dgvQuarto.Columns["disponivel"].Visible = false;
            dgvQuarto.Columns["valor"].DefaultCellStyle.Format = "c";

            cmbAnimal.Text = "";
            cmbAnimal.DataSource = contexto.Animal.Where(x => x.hospedado == false && x.Cliente.nome.Trim().ToLower().Contains(cmbClientes.Text.ToLower())).OrderBy(x => x.nome).ToList();
            cmbAnimal.DisplayMember = "nome";
            cmbAnimal.ValueMember = "id";

            cmbQuartos.DataSource = contexto.Quarto.Where(x => x.disponivel == true).OrderByDescending(x => x.descricao).OrderBy(x => x.descricao).ToList();
            cmbQuartos.DisplayMember = "descricao";
            cmbQuartos.ValueMember = "id";

            cmbFunc.DataSource = contexto.Funcionario.Where(x => x.Permicoes.frmHotel == true).OrderBy(x => x.nome).ToList();
            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "id";
        }

        private void data_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
        }

        private void Hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastroCli_Click(object sender, EventArgs e)
        {
            frmAddCliente frm = new frmAddCliente();
            frm.ShowDialog();
        }

        private void btnCadastroAnimal_Click(object sender, EventArgs e)
        {
            frmAnimais frm = new frmAnimais();
            frm.ShowDialog();
        }

        private void cmbClientes_Leave(object sender, EventArgs e)
        {
            lblcli.Text = cmbClientes.Text;
            cmbAnimal.Text = "";
            cmbAnimal.DataSource = contexto.Animal.Where(x => x.hospedado == false && x.Cliente.nome.Trim().ToLower().Contains(cmbClientes.SelectedText.ToLower())).ToList();
            cmbAnimal.DisplayMember = "nome";
            cmbAnimal.ValueMember = "id";
        }

        private void cmbAnimal_Leave(object sender, EventArgs e)
        {
            string Anim = cmbAnimal.Text;
            lblAnimal.Text = Anim;

            Animal animal = contexto.Animal.FirstOrDefault(x => x.nome == Anim);
            lblEspecie.Text = (animal == null) ? "" : animal.especie;
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbClientes_Click(object sender, EventArgs e)
        {

        }

        private void cmbAnimal_Click(object sender, EventArgs e)
        {
        }

        private void txtBuscaCli_KeyUp(object sender, KeyEventArgs e)
        {
            dgvCli.DataSource = "";
            dgvCli.DataSource = contexto.Cliente.Where(x => x.nome.Contains(txtBuscaCli.Text)).ToList();
        }

        private void dgvCli_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string cli = dgvCli.SelectedRows[0].Cells["nome"].Value.ToString();
                lblcli.Text = cli;
                cmbAnimal.Text = "";
                cmbAnimal.DataSource = contexto.Animal.Where(x => x.hospedado == false && x.Cliente.nome.Trim().ToLower().Contains(cli.ToLower())).ToList();
                cmbAnimal.DisplayMember = "nome";
                cmbAnimal.ValueMember = "id";
            }
            catch (Exception)
            {

            }
        }

        private void txtBuscQuarto_KeyUp(object sender, KeyEventArgs e)
        {
            dgvQuarto.DataSource = "";
            dgvQuarto.DataSource = contexto.Quarto.Where(x => x.descricao.Contains(txtBuscQuarto.Text)
                                                           && x.disponivel == true).ToList();
            dgvQuarto.Columns["id"].Visible = false;
            dgvQuarto.Columns["disponivel"].Visible = false;
            dgvQuarto.Columns["valor"].DefaultCellStyle.Format = "c";
        }

        private void dgvQuarto_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lblNumQuarto.Text = dgvQuarto.SelectedRows[0].Cells["numero"].Value.ToString();
                string quarto = dgvQuarto.SelectedRows[0].Cells["descricao"].Value.ToString();
                lblQuarto.Text = quarto;

                double valor = Convert.ToDouble(dgvQuarto.SelectedRows[0].Cells["valor"].Value);

                lblValor.Text = valor.ToString();

                var qtde = dtpSaida.Value - dtpEntr.Value;
                int dias = qtde.Days + 1;

                double total = Convert.ToDouble(lblValor.Text);
                double valorFinal = total * dias;

                txtValorTotal.Text = valorFinal.ToString("C");
                lblEntrada.Text = dtpEntr.Text;
            }
            catch (Exception)
            {

            }
        }

        private void dtpEntr_Leave(object sender, EventArgs e)
        {
            lblEntrada.Text = dtpEntr.Text;
        }

        private void cmbNumero_Leave(object sender, EventArgs e)
        {
            lblNumQuarto.Text = cmbNumero.Text;
        }

        private void cmbQuartos_Leave(object sender, EventArgs e)
        {
            cmbNumero.Enabled = true;
            lblQuarto.Text = cmbQuartos.Text;
            Quarto quarto = contexto.Quarto.First(x => x.descricao == cmbQuartos.Text);

            lblValor.Text = quarto.valor.ToString();

            var qtde = dtpSaida.Value - dtpEntr.Value;
            int dias = qtde.Days + 1;

            double total = Convert.ToDouble(lblValor.Text);
            double valor = total * dias;

            txtValorTotal.Text = valor.ToString("C");

            cmbNumero.DataSource = contexto.Quarto.Where(x => x.disponivel == true && x.descricao == cmbQuartos.Text).ToList();
            cmbNumero.DisplayMember = "numero";
            cmbNumero.ValueMember = "id";

            lblValor.Text = quarto.valor.ToString();
            lblEntrada.Text = dtpEntr.Text;
        }

        private void dtpSaida_Leave(object sender, EventArgs e)
        {
            if (dtpSaida.Value > dtpEntr.Value)
            {
                if (lblValor.Text != "")
                {
                    lblSaida.Text = dtpSaida.Text;

                    var qtde = dtpSaida.Value - dtpEntr.Value;
                    int dias = qtde.Days + 1;

                    double total = Convert.ToDouble(lblValor.Text);
                    double valor = total * dias;

                    txtValorTotal.Text = valor.ToString("C");
                }
                else
                {
                    MessageBox.Show("Selecione o Quarto Primeiro!");
                }
            }
            else
            {
                MessageBox.Show("Erro: A DATA DE SAÍDA NÃO pode ser MAIOR que a DATA DE ENTRADA", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                dtpSaida.Value = dtpEntr.Value;
            }
        }

        private void ckNotInform_Click(object sender, EventArgs e)
        {
            if (ckNotInform.Checked && lblValor.Text != "")
            {
                dtpSaida.Enabled = false;
                lblSaida.Text = "Não Informado";
                double valor = Convert.ToDouble(lblValor.Text);
                txtValorTotal.Text = valor.ToString("C");

            }
            else
            {
                dtpSaida.Enabled = true;

                if (lblQuarto.Text != "")
                {
                    lblSaida.Text = dtpSaida.Text;

                    var qtde = dtpSaida.Value - dtpEntr.Value;
                    int dias = qtde.Days + 1;

                    double total = Convert.ToDouble(lblValor.Text);
                    double valor = total * dias;

                    txtValorTotal.Text = valor.ToString("C");
                }
                else
                {
                    MessageBox.Show("Selecione o Quarto Primeiro!");
                    dtpSaida.Enabled = false;
                    ckNotInform.Checked = true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            bool EstaOK = true;

            if (lblcli.Text == "")
            {
                MessageBox.Show("Informe o CLIENTE", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); EstaOK = false;
            }
            else if (lblAnimal.Text == "")
            {
                MessageBox.Show("Informe o ANIMAL", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); EstaOK = false;
            }
            else if (lblQuarto.Text == "")
            {
                MessageBox.Show("Informe o NOME do QUARTO que o Animal ficará", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); EstaOK = false;
            }
            else if (lblNumQuarto.Text == "")
            {
                MessageBox.Show("Informe o QUARTO que o Animal ficará", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); EstaOK = false;
            }
            else if (lblEntrada.Text == "")
            {
                MessageBox.Show("Informe a DATA DE ENTRADA", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); EstaOK = false;
            }

            if (EstaOK)
            {
                DialogResult = MessageBox.Show("Confirma Pagamento da Reserva?", "Obrigado pela preferência", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button3);

                if(DialogResult != DialogResult.Cancel)
                { 
                    Reserva reserva = new Reserva();
                    if (DialogResult == DialogResult.Yes)
                    {
                        reserva.pago = Convert.ToDouble(txtValorTotal.Text.Replace("R$",""));
                    }
                    else if (DialogResult == DialogResult.No)
                    {
                        reserva.pago = 0;
                    }

                    if (lblSaida.Text != "Não Informado")
                    {
                        reserva.saida = Convert.ToDateTime(lblSaida.Text);
                    }

                    reserva.entrada = Convert.ToDateTime(lblEntrada.Text);
                    reserva.Funcionario_id = Convert.ToInt32(cmbFunc.SelectedValue);
                    reserva.Cliente_id = Convert.ToInt32(cmbClientes.SelectedValue);
                    reserva.Animal_id = Convert.ToInt32(cmbAnimal.SelectedValue);
                    reserva.Quarto_id = Convert.ToInt32(cmbQuartos.SelectedValue);

                    Quarto quarto = contexto.Quarto.First(x => x.id == reserva.Quarto_id);
                    quarto.disponivel = false;
                    contexto.Entry(quarto).State = EntityState.Modified;
                    contexto.SaveChanges();

                    Animal animal  = contexto.Animal.First(x => x.id == reserva.Animal_id);
                    animal.hospedado = true;
                    contexto.Entry(animal).State = EntityState.Modified;
                    contexto.SaveChanges();

                    contexto.Reserva.Add(reserva);
                    contexto.SaveChanges();
                    LimpaCampos();
                }

            }



        }
    }
}
