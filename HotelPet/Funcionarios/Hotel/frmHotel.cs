using Google.Protobuf.WellKnownTypes;
using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Funcionarios.Hotel;
using HotelPet.Functions;
using HotelPet.Layers.BLL;
using HotelPet.Layers.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmHotel : Form
    {
        private Funcionario Funcionario { get; set; }
        private int UserID { get; set; }
        public int idCliente { get; set; }
        public int idAnimal { get; set; }
        public List<Animal> listAnimal { get; set; }
        public List<Consumo> lstConsumo { get; set; }

        private static FileStream fstream = new FileStream("C:\\Users\\JrJos\\Desktop\\ProjetoTcc\\HotelPet.NET\\HotelPet\\Resources\\SEM-IMAGEM-13.jpg", FileMode.Open, FileAccess.Read);
        private static BinaryReader br = new BinaryReader(fstream);
        private static byte[] imagem = br.ReadBytes((int)fstream.Length);

        public frmHotel()
        {
            InitializeComponent();           
        }

        public frmHotel(int usuarioId)
        {
            InitializeComponent();
            this.UserID = usuarioId;
            Contexto contexto = new Contexto();
            this.Funcionario = contexto.Funcionario.FirstOrDefault(x => x.Usuario_id == usuarioId);
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

            lblCodigoReserva.Text = "0";
            txtObservacoes.Text = "";
            txtCuidados.Text = "";
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

            txtConsBuscAnimal.Text = "";
            txtConsBuscServicos.Text = "";

            int val = 0;
            txtValorTotal.Text = val.ToString("C");
            lblValorTotal.Text = val.ToString("C");
            txtBuscQuarto.Text = "";
            txtBuscaCli.Text = "";

            Contexto contexto = new Contexto();

            var lstClientes = from cli in contexto.Animal.Where(x => x.Cliente != null && x.hospedado == false).OrderBy(x => x.Cliente.nome).ToList()
                              orderby cli.Cliente.nome
                              select new
                              {
                                  id = cli.Cliente_id,
                                  nome = cli.Cliente.nome
                              };

            cmbClientes.DataSource = lstClientes.ToList();
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
            cmbFunc.SelectedValue = Funcionario.id;

            var lstCli = from Cli in contexto.Reserva.Where(x => x.pago == false).OrderBy(x => x.Cliente.nome).ToList()
                         group Cli by new { Cli.Cliente.nome, Cli.Cliente_id } into cli
                         select new
                         {
                             nome = cli.Key.nome,
                             id = cli.Key.Cliente_id
                         };

            cmbCli.Text = "";
            cmbCli.DataSource = lstCli.ToList();
            cmbCli.DisplayMember = "nome";
            cmbCli.ValueMember = "id";

            dgvCheckOut.DataSource = "";
            cmbAni.Text = "";
            cmbAni.Enabled = false;

            var lstAnimal = from Cli in contexto.Reserva.Where(x => x.Animal.hospedado == true && x.pago == false).OrderBy(x => x.Animal.nome).ToList()
                            select new
                            {
                                Cli.id,
                                cliente = Cli.Cliente.nome,
                                animal = Cli.Animal.nome,
                                quarto = Cli.Quarto.descricao,
                                Cli.Quarto.numero,
                                Cli.Animal.especie,
                                Cli.Animal.raca,
                                Cli.Animal.pelagem,
                                Cli.Animal.cor,
                                Cli.Animal.porte,
                                Cli.Animal.sexo,
                                Cli.Animal.observacoes,
                                Cli.Animal.cuidados,
                                foto = (Cli.Animal.imagem == null) ? Image.FromStream(new MemoryStream(imagem)) : Image.FromStream(new MemoryStream(Cli.Animal.imagem))
                            };

            InterfaceTools.dgvTransformation(dgvConsAnimal);
            dgvConsAnimal.DataSource = lstAnimal.ToList();

            dgvConsServicos.DataSource = "";
            var lista = from Serv in contexto.Produto.Where(x => x.isQuarto == false && x.isServico == true).ToList()
                        select new
                        {
                            Código = Serv.codigo,
                            Descrição = Serv.descricao,
                            Qtde = Serv.quantidade,
                            Valor = Serv.valor
                        };

            dgvConsServicos.DataSource = lista.ToList();
            dgvConsServicos.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Qtde"].DefaultCellStyle.Format = "N3";
            dgvConsServicos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Valor"].DefaultCellStyle.Format = "C";

            dgvConsumos.DataSource = "";

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
            Contexto contexto = new Contexto();
            var permicao = contexto.Permicao.FirstOrDefault(x => x.id == Funcionario.Permicoes_id);

            if (permicao.frmCliente == true)
            {
                frmAddCliente frm = new frmAddCliente(UserID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Você não permição para consultar Clientes\n" +
                                "Por favor contate seu administrador.",
                                "Não foi possível consultar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void btnCadastroAnimal_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            var permicao = contexto.Permicao.FirstOrDefault(x => x.id == Funcionario.Permicoes_id);

            if (permicao.frmCliente == true)
            {
                frmAnimais frm = new frmAnimais();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Você não permição para consultar Animais\n" +
                                "Por favor contate seu administrador.",
                                "Não foi possível consultar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbClientes_Leave(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            lblcli.Text = cmbClientes.Text;
            cmbAnimal.Text = "";
            cmbAnimal.DataSource = contexto.Animal.Where(x => x.hospedado == false && x.Cliente.nome.Trim().ToLower().Equals(cmbClientes.SelectedText.ToLower())).ToList();
            cmbAnimal.DisplayMember = "nome";
            cmbAnimal.ValueMember = "id";
        }

        private void cmbAnimal_Leave(object sender, EventArgs e)
        {
            string Anim = cmbAnimal.Text;
            lblAnimal.Text = Anim;

            Contexto contexto = new Contexto();

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
            Contexto contexto = new Contexto();

            lblcli.Text = cmbClientes.Text;
            cmbAnimal.Text = "";
            cmbAnimal.DataSource = contexto.Animal.Where(x => x.hospedado == false && x.Cliente.nome.Trim().ToLower().Equals(cmbClientes.SelectedText.ToLower())).ToList();
            cmbAnimal.DisplayMember = "nome";
            cmbAnimal.ValueMember = "id";
        }

        private void cmbAnimal_Click(object sender, EventArgs e)
        {
        }

        private void txtBuscaCli_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();

            dgvCli.DataSource = "";
            dgvCli.DataSource = contexto.Cliente.Where(x => x.nome.Contains(txtBuscaCli.Text)).ToList();
        }

        private void dgvCli_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Contexto contexto = new Contexto();

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
            Contexto contexto = new Contexto();

            dgvQuarto.DataSource = "";
            dgvQuarto.DataSource = contexto.Quarto.Where(x => x.descricao.Contains(txtBuscQuarto.Text) && x.disponivel == true).ToList();
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
                Contexto contexto = new Contexto();

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

                if (DialogResult == DialogResult.Yes)
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

                    Contexto contexto = new Contexto();

                    Quarto quarto = contexto.Quarto.First(x => x.id == reserva.Quarto_id);
                    quarto.disponivel = false;
                    contexto.Entry(quarto).State = EntityState.Modified;
                    contexto.SaveChanges();

                    Animal animal = contexto.Animal.First(x => x.id == reserva.Animal_id);
                    animal.hospedado = true;
                    contexto.Entry(animal).State = EntityState.Modified;
                    contexto.SaveChanges();

                    contexto.Reserva.Add(reserva);
                    contexto.SaveChanges();
                    LimpaCampos();
                }

                DialogResult = new DialogResult();
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
            Contexto contexto = new Contexto();

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
            Contexto contexto = new Contexto();

            lstConsumo = new List<Consumo>();
            var Cliente = contexto.Cliente.FirstOrDefault(x => x.nome == cmbCli.Text);
            int IDCliente = (Cliente == null) ? 0 : Cliente.id;

            var animal = contexto.Animal.FirstOrDefault(x => x.nome.Trim().ToLower().Contains(cmbAni.Text.Trim().ToLower())
                                                            && x.Cliente_id == IDCliente && x.hospedado == true);
            int IDAnimal = (animal == null) ? 0 : animal.id;

            var reserva = contexto.Reserva.FirstOrDefault(x => x.Cliente_id == IDCliente && x.Animal_id == IDAnimal && x.pago == false);

            if (IDCliente != 0 && IDAnimal != 0)
            {

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

                Produtos servico = new Produtos();
                servico = contexto.Produto.FirstOrDefault(x => x.descricao == reserva.Quarto.descricao 
                                                            && x.quantidade == dias && x.isServico == true);

                if (servico == null)
                {
                    servico = new Produtos();
                    servico.descricao = "Quarto " + reserva.Quarto.descricao;
                    servico.quantidade = dias;
                    servico.valor = valor;
                    servico.isQuarto = true;
                    servico.isServico = false;
                    contexto.Produto.Add(servico);
                    contexto.SaveChanges();
                }

                Consumo consumo = new Consumo();
                consumo.valor = total;
                consumo.Quantidade = dias;
                consumo.total = valor;
                consumo.Reserva = reserva;
                consumo.Produtos = servico;
                consumo.data = DateTime.Now;

                lstConsumo.Add(consumo);

                var lista = from Cons in lstConsumo
                            select new
                            {
                                Codigo = Cons.Produtos.codigo,
                                Descricao = Cons.Produtos.descricao,
                                Quantidade = Cons.Produtos.quantidade,
                                Valor = Cons.valor,
                                Cons.total
                            };

                dgvCheckOut.DataSource = "";
                dgvCheckOut.DataSource = lista.ToList();

                dgvCheckOut.Columns["total"].Visible = false;

                dgvCheckOut.Columns["Codigo"].DisplayIndex = 1;
                dgvCheckOut.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCheckOut.Columns["Codigo"].Width = 85;

                dgvCheckOut.Columns["Descricao"].DisplayIndex = 2;
                dgvCheckOut.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCheckOut.Columns["Descricao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvCheckOut.Columns["Descricao"].Width = 383;

                dgvCheckOut.Columns["Quantidade"].DisplayIndex = 3;
                dgvCheckOut.Columns["Quantidade"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCheckOut.Columns["Quantidade"].Width = 85;

                dgvCheckOut.Columns["Valor"].DisplayIndex = 4;
                dgvCheckOut.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvCheckOut.Columns["Valor"].DefaultCellStyle.Format = "c";
                dgvCheckOut.Columns["Valor"].Width = 90;

                lblValorTotal.Text = dgvCheckOut.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells["total"].Value ?? 0)).ToString("C");

            }
            else
            {
                MessageBox.Show("ERRO: Nenhum Cliente foi selecionado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgvCheckOut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma Pagamento da Reserva?", "Finalizar Reserva", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                Contexto contexto = new Contexto();

                Animal animal = contexto.Animal.FirstOrDefault(x => x.nome.Contains(lblAni.Text) && x.Cliente.nome.Contains(lblCliente.Text) && x.hospedado == true);
                animal.hospedado = false;

                contexto.Entry(animal).State = EntityState.Modified;
                contexto.SaveChanges();

                double valor = Convert.ToDouble(lblValorTotal.Text.Replace("R$", ""));

                ConsumoBLL bll = new ConsumoBLL();
                int id = bll.Insert(lstConsumo.Where(x=> x.Reserva_id == 0).ToList());

                Reserva reserva = contexto.Reserva.FirstOrDefault(x => x.id == id);
                reserva.pago = true;
                reserva.saida = DateTime.Now;
                reserva.Quarto.disponivel = true;

                contexto.Entry(reserva).State = EntityState.Modified;
                contexto.SaveChanges();
                lstConsumo = new List<Consumo>();

                Historico historico = new Historico();
                historico.data = DateTime.Now;
                historico.descricao = reserva.Funcionario.nome;
                historico.valor = Convert.ToDouble(lblValorTotal.Text.Replace("R$", ""));

                contexto.Historico.Add(historico);
                contexto.SaveChanges();
                
                LimpaCampos();
            }
            else
            {
                LimpaCampos();
            }

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            LimpaCampos();
        }

        private void txtConsBuscAnimal_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();
            string busca = txtConsBuscAnimal.Text.Trim().ToLower();

            var lstAnimal = from Cli in contexto.Reserva.Where(x => (x.Animal.nome.Trim().ToLower().Contains(busca) || x.Animal.Cliente.nome.Trim().ToLower().Contains(busca)) && x.Animal.hospedado == true && x.pago == false).OrderBy(x => x.Animal.nome).ToList()
                            select new
                            {
                                Cli.id,
                                cliente = Cli.Cliente.nome,
                                animal = Cli.Animal.nome,
                                quarto = Cli.Quarto.descricao,
                                Cli.Quarto.numero,
                                Cli.Animal.especie,
                                Cli.Animal.raca,
                                Cli.Animal.pelagem,
                                Cli.Animal.cor,
                                Cli.Animal.porte,
                                Cli.Animal.sexo,
                                Cli.Animal.observacoes,
                                Cli.Animal.cuidados,
                                foto = (Cli.Animal.imagem == null) ? Image.FromStream(new MemoryStream(imagem)) : Image.FromStream(new MemoryStream(Cli.Animal.imagem))
                            };

            InterfaceTools.dgvTransformation(dgvConsAnimal);
            dgvConsAnimal.DataSource = lstAnimal.ToList();
        }

        private void dgvConsAnimal_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvConsAnimal.SelectedRows[0].Cells["id"].Value);
           
            Contexto contexto = new Contexto();
            var reserva = contexto.Reserva.FirstOrDefault(x => x.id == id);

            lblCodigoReserva.Text = reserva.id.ToString();
            txtObservacoes.Text = reserva.Animal.observacoes;
            txtCuidados.Text = reserva.Animal.cuidados;

            var Consumos = from Cons in contexto.Consumo.Where(x => x.Reserva_id == id).ToList()
                           select new
                           {
                               Cons.id,
                               Código = Cons.Produtos.codigo,
                               Consumos = Cons.Produtos.descricao,
                               Data = Cons.data,
                               Qtde = Cons.Quantidade,
                               Valor = Cons.valor
                           };

            dgvConsumos.DataSource = "";
            dgvConsumos.DataSource = Consumos.ToList();
            dgvConsumos.Columns["id"].Visible = false;
            dgvConsumos.Columns["Qtde"].DefaultCellStyle.Format = "N3";
            dgvConsumos.Columns["Valor"].DefaultCellStyle.Format = "C";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            try
            {
                int Reserva_id = Convert.ToInt32(lblCodigoReserva.Text);
                int cod = Convert.ToInt32(dgvConsServicos.SelectedRows[0].Cells["Código"].Value);
                
                Contexto contexto = new Contexto();
                Produtos servico = contexto.Produto.FirstOrDefault(x => x.codigo == cod);
                Consumo consumo = new Consumo();

                consumo.Quantidade = servico.quantidade;
                consumo.valor = servico.valor;
                consumo.total = servico.valor;
                consumo.Reserva_id = Reserva_id;
                consumo.Produtos_id = servico.id;
                consumo.data = DateTime.Now;

                contexto.Consumo.Add(consumo);
                contexto.SaveChanges();
                contexto.Entry(consumo).Reload();

                var Consumos = from Cons in contexto.Consumo.Where(x => x.Reserva_id == Reserva_id).ToList()
                               select new
                               {
                                   Cons.id,
                                   Código = Cons.Produtos.codigo,
                                   Consumos = Cons.Produtos.descricao,
                                   Data = Cons.data,
                                   Qtde = Cons.Quantidade,
                                   Valor = Cons.valor
                               };

                dgvConsumos.DataSource = "";
                dgvConsumos.DataSource = Consumos.ToList();
                dgvConsumos.Columns["id"].Visible = false;
                dgvConsumos.Columns["Qtde"].DefaultCellStyle.Format = "N3";
                dgvConsumos.Columns["Valor"].DefaultCellStyle.Format = "C";

            }
            catch (Exception)
            {
                MessageBox.Show("ERRO: Nenhum Serviço foi Selecionado.", "Erro ao lançar o serviço", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void txtConsBuscServicos_KeyUp(object sender, KeyEventArgs e)
        {

            Contexto contexto = new Contexto();
            dgvConsServicos.DataSource = "";

            try
            {
                var busca = Convert.ToInt64(txtConsBuscServicos.Text);
                var lista = from Serv in contexto.Produto.Where(x => x.id == busca && x.isQuarto == false
                                                                  && x.isServico == true).ToList()
                            select new
                            {
                                Código = Serv.codigo,
                                Descrição = Serv.descricao,
                                Qtde = Serv.quantidade,
                                Valor = Serv.valor
                            };
                dgvConsServicos.DataSource = lista.ToList();
            }
            catch (Exception)
            {
                var busca = txtConsBuscServicos.Text;
                var lista = from Serv in contexto.Produto.Where(x => x.descricao.Trim().ToLower().Contains(busca) && x.isQuarto == false
                                                                  && x.isServico == true).ToList()
                            select new
                            {
                                Código = Serv.codigo,
                                Descrição = Serv.descricao,
                                Qtde = Serv.quantidade,
                                Valor = Serv.valor
                            };
                dgvConsServicos.DataSource = lista.ToList();
            }

            dgvConsServicos.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Qtde"].DefaultCellStyle.Format = "N3";
            dgvConsServicos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvConsServicos.Columns["Valor"].DefaultCellStyle.Format = "C";
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            //try
            {
                Contexto contexto = new Contexto();

                int Reserva_id = Convert.ToInt32(lblCodigoReserva.Text);
                int cod = Convert.ToInt32(dgvConsumos.SelectedRows[0].Cells["Código"].Value);
                DateTime data = Convert.ToDateTime(dgvConsumos.SelectedRows[0].Cells["Data"].Value);

                Consumo consumo = contexto.Consumo.FirstOrDefault(x => x.Produtos.codigo == cod && x.data == data && x.Reserva_id == Reserva_id);

                contexto.Consumo.Remove(consumo);
                contexto.SaveChanges();
                

                var Consumos = from Cons in contexto.Consumo.Where(x => x.Reserva_id == Reserva_id).ToList()
                               select new
                               {
                                   Cons.id,
                                   Código = Cons.Produtos.codigo,
                                   Consumos = Cons.Produtos.descricao,
                                   Data = Cons.data,
                                   Qtde = Cons.Quantidade,
                                   Valor = Cons.valor
                               };

                dgvConsumos.DataSource = "";
                dgvConsumos.DataSource = Consumos.ToList();
                dgvConsumos.Columns["id"].Visible = false;
                dgvConsumos.Columns["Qtde"].DefaultCellStyle.Format = "N3";
                dgvConsumos.Columns["Valor"].DefaultCellStyle.Format = "C";
            }
          //  catch (Exception)
            {
            //    MessageBox.Show("ERRO: Nenhum item foi selecionado.", "Erro ao apagar", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
