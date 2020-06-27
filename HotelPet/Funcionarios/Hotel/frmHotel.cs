using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Funcionarios.Hotel;
using HotelPet.Layers.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmHotel : Form
    {

        public int idCliente { get; set; }
        public int idAnimal { get; set; }
        public List<Animal> listAnimal { get; set; }
        public List<Consumo> lstConsumo { get; set; }

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
            lblCliente.Text = "";
            lblAnimal.Text = "";
            lblAni.Text = "";
            lblEspecie.Text = "";
            lblEsp.Text = "";
            lblQuarto.Text = "";
            lblDescr.Text = "";
            lblNumQuarto.Text = "";
            lblNumero.Text = "";
            lblEntrada.Text = "";
            lblDataEntr.Text = "";
            lblSaida.Text = "Não Informado";
            lblDataSai.Text = "";
            lblValor.Text = "";

            int val = 0;
            txtValorTotal.Text = val.ToString("C");
            lblValorTotal.Text = val.ToString("C");
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

            cmbQuartos.DataSource = contexto.Quarto.Where(x => x.disponivel == true).OrderByDescending(x => x.descricao).ToList();
            cmbQuartos.DisplayMember = "descricao";
            cmbQuartos.ValueMember = "id";

            cmbFunc.DataSource = contexto.Funcionario.Where(x => x.Permicoes.frmHotel == true).OrderBy(x => x.nome).ToList();
            cmbFunc.DisplayMember = "nome";
            cmbFunc.ValueMember = "id";

            var lstCli = from Cli in contexto.Reserva.OrderBy(x => x.Cliente.nome).ToList()
                         group Cli by new { Cli.Cliente.nome, Cli.Cliente_id  } into cli
                         select new
                         {
                             nome = cli.Key.nome,
                             id = cli.Key.Cliente_id
                         };

            cmbCli.DataSource = lstCli.ToList();
            cmbCli.DisplayMember = "nome";
            cmbCli.ValueMember = "id";

            dgvCheckOut.DataSource = "";
            cmbAni.Enabled = false;
            //var lstAnimal = from Cli in contexto.Reserva.OrderBy(x => x.Animal.nome).ToList()
            //             select new
            //             {
            //                 Cli.Animal.nome,
            //                 Cli.Animal.id
            //             };

            //cmbAni.DataSource = lstAnimal.ToList();
            //cmbAni.DisplayMember = "nome";
            //cmbAni.ValueMember = "id";
        }

        private void data_Tick(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToShortDateString();
            lbldata2.Text = DateTime.Now.ToShortDateString();
        }

        private void Hora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblHora2.Text = DateTime.Now.ToLongTimeString();
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

            try
            {
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
            catch (Exception)
            {
            }
        }

        private void dtpSaida_Leave(object sender, EventArgs e)
        {
            if (dtpSaida.Value > dtpEntr.Value)
            {
                if (lblValor.Text != "")
                {
                    lblSaida.Text = dtpSaida.Text;

                    var qtde = dtpSaida.Value.Date - dtpEntr.Value.Date;
                    int dias = qtde.Days;

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
                MessageBox.Show("Erro: A DATA DE SAÍDA NÃO PODE SER MENOR QUE A DATA DE ENTRADA", "Erro de Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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

                    var qtde = dtpSaida.Value.Date - dtpEntr.Value.Date;
                    int dias = qtde.Days;

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
                DialogResult = MessageBox.Show("Confirmar Reserva?", "Obrigado pela preferência", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

                if(DialogResult == DialogResult.Yes)
                { 
                    Reserva reserva = new Reserva();

                    reserva.pago = false;

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

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmConsulta frmConsulta = new frmConsulta(this);
            frmConsulta.ShowDialog();
            cmbCli.SelectedValue = idCliente;

            cmbAni.DataSource = listAnimal;
            cmbAni.DisplayMember = "nome";
            cmbAni.ValueMember = "id";

            cmbAni.SelectedValue = idAnimal;
        }

        private void cmbCli_Leave(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbCli.SelectedValue);
            var lstAnimal = from Cli in contexto.Reserva.Where(x => x.Cliente.id == id && x.Animal.hospedado == true && x.pago == false).OrderBy(x => x.Animal.nome).ToList()
                            select new
                            {
                                Cli.Animal.nome,
                                Cli.Animal.id
                            };

            cmbAni.Enabled = true;
            cmbAni.DataSource = lstAnimal.ToList();
            cmbAni.DisplayMember = "nome";
            cmbAni.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstConsumo = new List<Consumo>();

            int IDCliente = contexto.Cliente.FirstOrDefault(x => x.nome.Trim().ToLower().Contains(cmbCli.Text.Trim().ToLower())).id;
            int IDAnimal = contexto.Animal.FirstOrDefault(x => x.nome.Trim().ToLower().Contains(cmbAni.Text.Trim().ToLower()) 
                                                            && x.Cliente_id == IDCliente && x.hospedado == true).id;

            var reserva = contexto.Reserva.FirstOrDefault(x => x.Cliente_id == IDCliente && x.Animal_id == IDAnimal && x.pago == false);

            lblCliente.Text = reserva.Cliente.nome;
            lblAni.Text = reserva.Animal.nome;
            lblEsp.Text = reserva.Animal.especie;
            lblDescr.Text = reserva.Quarto.descricao;
            lblNumero.Text = reserva.Quarto.numero.ToString();
            lblDataEntr.Text = reserva.entrada.ToShortDateString();
            lblDataSai.Text = DateTime.Now.ToShortDateString();

            DateTime dateTime = DateTime.Now;

            var qtde = dateTime - reserva.entrada.Date;
            int dias = qtde.Days;

            double total = reserva.Quarto.valor;
            double valor = total * dias;

            txtValorTotal.Text = valor.ToString("C");

            lstConsumo = contexto.Consumo.Where(x => x.Reserva_id == reserva.id).ToList();

            Servicos servico = new Servicos();
            servico = contexto.Servico.FirstOrDefault(x => x.descricao == reserva.Quarto.descricao && x.quantidade == dias);

            if (servico == null)
            {
                servico = new Servicos();
                servico.descricao = reserva.Quarto.descricao;
                servico.quantidade = dias;
                servico.valor = valor;
                contexto.Servico.Add(servico);
                contexto.SaveChanges();
            }

            Consumo consumo = new Consumo();
            consumo.valor = total;
            consumo.Quantidade = dias;
            consumo.total = valor;
            consumo.Reserva = reserva;
            consumo.Servicos = servico;

            lstConsumo.Add(consumo);

            var lista = from Cons in lstConsumo
                        select new
                        {
                            Codigo = Cons.Servicos.id,
                            descricao = Cons.Servicos.descricao,
                            Quantidade = Cons.Servicos.quantidade,
                            valor = Cons.valor,
                            total = Cons.total
                        };

            dgvCheckOut.DataSource = "";
            dgvCheckOut.DataSource = lista.ToList();

            dgvCheckOut.Columns["total"].Visible = false;

            dgvCheckOut.Columns["Codigo"].DisplayIndex = 1;
            dgvCheckOut.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCheckOut.Columns["Codigo"].Width = 85;

            dgvCheckOut.Columns["descricao"].DisplayIndex = 2;
            dgvCheckOut.Columns["descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCheckOut.Columns["descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCheckOut.Columns["descricao"].Width = 383;

            dgvCheckOut.Columns["Quantidade"].DisplayIndex = 3;
            dgvCheckOut.Columns["Quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCheckOut.Columns["Quantidade"].Width = 85;

            dgvCheckOut.Columns["valor"].DisplayIndex = 4;
            dgvCheckOut.Columns["valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCheckOut.Columns["valor"].DefaultCellStyle.Format = "c";
            dgvCheckOut.Columns["valor"].Width = 90;

            lblValorTotal.Text = dgvCheckOut.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["total"].Value ?? 0)).ToString("C");

        }

        private void dgvCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma Pagamento da Reserva?", "Finalizar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {

                Animal animal = contexto.Animal.FirstOrDefault(x => x.nome.Contains(lblAni.Text) && x.Cliente.nome.Contains(lblCliente.Text) && x.hospedado == true);
                animal.hospedado = false;

                contexto.Entry(animal).State = EntityState.Modified;
                contexto.SaveChanges();

                double valor = Convert.ToDouble(lblValorTotal.Text.Replace("R$", ""));

                ConsumoBLL bll = new ConsumoBLL();
                int id = bll.Insert(lstConsumo);

                Reserva reserva = contexto.Reserva.FirstOrDefault(x => x.id == id);
                reserva.pago = true;

                reserva.Quarto.disponivel = true;

                contexto.Entry(reserva).State = EntityState.Modified;
                contexto.SaveChanges();
                lstConsumo = new List<Consumo>();
                LimpaCampos();
            }
            else
            {
                LimpaCampos();
            }
 
        }
    }
}
