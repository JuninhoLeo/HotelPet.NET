using HotelPet.Camadas.BLL;
using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmAddCliente : Form
    {
        private Permicoes Permicao { get; set; }
        public frmAddCliente(int userID)
        {
            InitializeComponent();
            Contexto contexto = new Contexto();
            var func = contexto.Funcionario.FirstOrDefault(x => x.Usuario_id == userID);
            this.Permicao = contexto.Permicao.FirstOrDefault(x => x.id == func.Permicoes_id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool estaOK = true;

            if(txtNome.Text == "") 
            { MessageBox.Show("Informe o nome do cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false;}
            else
            {
                if (txtCPF.MaskedTextProvider.AssignedEditPositionCount < 11) { MessageBox.Show("Informe o CPF do cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false; }
                else
                {
                    if (txtRG.MaskedTextProvider.AssignedEditPositionCount < 9) { MessageBox.Show("Informe o RG do cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false; }
                    else
                    {
                        if (txtCidade.Text == "") { MessageBox.Show("Informe a CIDADE do cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false; }
                        else
                        {
                            if (txtUF.Text == "") { MessageBox.Show("Informe a sigla do ESTADO do Cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false; }
                            else
                            {
                                if (txtTelefone.MaskedTextProvider.AssignedEditPositionCount < 10) { MessageBox.Show("Informe o TELEFONE do cliente", "Por favor", MessageBoxButtons.OK, MessageBoxIcon.Information); estaOK = false; }
                            }
                        }
                    }
                }
            }

            Contexto contexto = new Contexto();
            var consulta = contexto.Cliente.FirstOrDefault(x => x.nome.Trim().ToLower().Contains(txtNome.Text.ToLower()));
            if(consulta != null)
            {
                estaOK = false;
                DialogResult confirm = MessageBox.Show("Cliente já cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            if (estaOK)
            {
                DialogResult confirm = MessageBox.Show("Salvar as alterações Clique em Sim para salvar", "Deseja Salvar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (confirm.ToString().ToUpper() == "YES")
                {
                    Cliente cliente = new Cliente
                    {
                        nome = txtNome.Text,
                        cpf = txtCPF.Text,
                        rg = txtRG.Text,
                        cidade = txtCidade.Text,
                        uf = txtUF.Text,
                        telefone = txtTelefone.Text,
                        email = txtEmail.Text
                    };
                    contexto.Cliente.Add(cliente);
                    contexto.SaveChanges();
                }

                AtualizaView();
                LimpaCampos();
            }
        }

        public void LimpaCampos()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtBusca.ForeColor = Color.DarkGray;
            txtBusca.Text = "Digite aqui o Nome do Cliente:";
            btnDeletar.Enabled = false;
            btnAtualizar.Enabled = false;
            btnConfirm.Enabled = true;
            AtualizaView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (txtBusca.Text == "Digite aqui o Nome do Cliente:")
            {
                txtBusca.ForeColor = Color.Black;
                txtBusca.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtBusca.Text == "")
            {
                txtBusca.ForeColor = Color.DarkGray;
                txtBusca.Text = "Digite aqui o Nome do Cliente:";
            }
        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();
            dgvCliente.DataSource = "";
            dgvCliente.DataSource = contexto.Cliente.Where(x => x.nome.Contains(txtBusca.Text)).ToList();
        }

        private void HabilitaCampos(bool status)
        {
            txtBusca.Enabled = !status;

            btnConfirm.Enabled = status;
            btnAtualizar.Enabled = status;
            btnDeletar.Enabled = status;

            txtNome.Enabled = status;
            txtCPF.Enabled = status;
            txtRG.Enabled = status;
            txtCidade.Enabled = status;
            txtUF.Enabled = status;
            txtTelefone.Enabled = status;
            txtEmail.Enabled = status;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            txtId.Visible = false;

            HabilitaCampos(false);

            Contexto contexto = new Contexto();
            
            dgvCliente.DataSource = "";
            dgvCliente.DataSource = contexto.Cliente.Where(x=> !x.nome.Trim().Contains("")).ToList();

            txtBusca.ForeColor = Color.DarkGray;
            txtBusca.Text = "Digite aqui o Nome do Cliente:";
            AtualizaView();
        }

        private void dgvCliente_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtId.Text = dgvCliente.SelectedRows[0].Cells["id"].Value.ToString();
                txtNome.Text = dgvCliente.SelectedRows[0].Cells["nome"].Value.ToString();
                txtCPF.Text = dgvCliente.SelectedRows[0].Cells["cpf"].Value.ToString();
                txtRG.Text = dgvCliente.SelectedRows[0].Cells["rg"].Value.ToString();
                txtCidade.Text = dgvCliente.SelectedRows[0].Cells["cidade"].Value.ToString();
                txtUF.Text = dgvCliente.SelectedRows[0].Cells["uf"].Value.ToString();
                txtTelefone.Text = dgvCliente.SelectedRows[0].Cells["telefone"].Value.ToString();
                txtEmail.Text = dgvCliente.SelectedRows[0].Cells["email"].Value.ToString();
                btnDeletar.Enabled = true;
                btnAtualizar.Enabled = true;

                HabilitaCampos(true);
                btnConfirm.Enabled = false;
                button2.Enabled = false;
            }
            catch (Exception)
            {

            }
        }

        private void AtualizaView()
        {
            Contexto contexto = new Contexto();

            dgvCliente.DataSource = "";
            dgvCliente.DataSource = contexto.Cliente.Where(x => x.nome.Contains("")).ToList();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtId.Text !="")
            {

            DialogResult confirm = MessageBox.Show("Deseja realmente apagar esse cliente.\n " +
                                                   "Ao continuar será apagado também todos os animais cadastrados para esse cliente\n " +
                                                   "Você quer Apagar?", "Apagar dados do cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                
                if (confirm.ToString().ToUpper() == "YES")
                {
                    Cliente cliente = new Cliente
                    {
                        id = Convert.ToInt32(txtId.Text),
                        nome = txtNome.Text,
                        cpf = txtCPF.Text,
                        rg = txtRG.Text,
                        cidade = txtCidade.Text,
                        uf = txtUF.Text,
                        telefone = txtTelefone.Text,
                        email = txtEmail.Text
                    };
                    ClienteBLL bll = new ClienteBLL();
                    bll.Delete(cliente);
                }
            }
            else { MessageBox.Show("Para apagar, precisa selecionar um cliente!","Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            AtualizaView();
            LimpaCampos();
            btnConfirm.Enabled = false;
            button2.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HabilitaCampos(false);
            button2.Enabled = true;
            btnConfirm.Enabled = false;
            btnAtualizar.Enabled = false;
            btnDeletar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Permicao.frmAddCliente == true)
            {
                LimpaCampos();
                HabilitaCampos(true);
                btnDeletar.Enabled = false;
                btnAtualizar.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Você não permição para adicionar Clientes\n" +
                                "Por favor contate seu administrador.",
                                "Não foi possível adicionar cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            if (txtId.Text != "")
            {

                DialogResult confirm = MessageBox.Show("Deseja atualizar os dados desse cliente.\n ",                                                       
                                                      "Atualizar dados do cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (confirm.ToString().ToUpper() == "YES")
                {
                    Cliente cliente = new Cliente
                    {
                        id = Convert.ToInt32(txtId.Text),
                        nome = txtNome.Text,
                        cpf = txtCPF.Text,
                        rg = txtRG.Text,
                        cidade = txtCidade.Text,
                        uf = txtUF.Text,
                        telefone = txtTelefone.Text,
                        email = txtEmail.Text
                    };
                    contexto.Entry(cliente).State = EntityState.Modified;
                    contexto.SaveChanges();
                }
            }
            else { MessageBox.Show("Para apagar, precisa selecionar um cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            LimpaCampos();
            AtualizaView();
            btnConfirm.Enabled = false;
            button2.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
