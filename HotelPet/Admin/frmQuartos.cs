using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin
{
    public partial class frmQuartos : Form
    {
        public frmQuartos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();

            string Busca = txtBusca.Text.Trim();
            var Lista = from quarto in contexto.Quarto.Where(x => x.descricao.Trim().ToLower().Contains(Busca) || x.numero.ToString().Trim().Contains(Busca)).ToList()
                        orderby quarto.descricao
                        select new
                        {
                            quarto.id,
                            Número = quarto.numero,
                            Descrição = quarto.descricao,
                            Disponível = (quarto.disponivel == true)? "Sim" : "Não",
                            Valor = quarto.valor
                        };
            dgvQuartos.DataSource = "";
            dgvQuartos.DataSource = Lista.ToList();

            dgvQuartos.Columns["Número"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Disponível"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Valor"].DefaultCellStyle.Format = "C";
            dgvQuartos.Columns["id"].Visible = false;
        }

        private void dgvQuartos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;
                txtId.Text = dgvQuartos.SelectedRows[0].Cells["id"].Value.ToString();
                txtNumero.Text = dgvQuartos.SelectedRows[0].Cells["Número"].Value.ToString();
                txtDescricao.Text = dgvQuartos.SelectedRows[0].Cells["Descrição"].Value.ToString();
                double valor = Convert.ToInt32(dgvQuartos.SelectedRows[0].Cells["Valor"].Value);
                txtValor.Text = valor.ToString("C").Replace("R$ ", "");

                string cond = dgvQuartos.SelectedRows[0].Cells["Disponível"].Value.ToString();

                rdbSim.Checked = cond == "Sim";
                rdbNao.Checked = cond == "Não";
            }
            catch (Exception)
            {

            }
        }

        private void LimpaCampos()
        {
            txtId.Text = "";
            txtDescricao.Text = "";
            txtNumero.Text = "";
            txtValor.Text = "";
            rdbSim.Checked = true;

            Contexto contexto = new Contexto();
            var Lista = from quarto in contexto.Quarto.ToList()
                        orderby quarto.descricao
                        select new
                        {
                            quarto.id,
                            Número = quarto.numero,
                            Descrição = quarto.descricao,
                            Disponível = (quarto.disponivel == true) ? "Sim" : "Não",
                            Valor = quarto.valor
                        };
            dgvQuartos.DataSource = "";
            dgvQuartos.DataSource = Lista.ToList();

            dgvQuartos.Columns["Número"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Disponível"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQuartos.Columns["Valor"].DefaultCellStyle.Format = "C";
            dgvQuartos.Columns["id"].Visible = false;
        }

        private void frmQuartos_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            LimpaCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            Quarto quarto = new Quarto();
            bool estaOK = true;

            try
            {
                int num = Convert.ToInt32(txtNumero.Text);
            }
            catch
            {
                estaOK = false;
                MessageBox.Show("Informe o Numero do Quarto.");
            }
            
            if (txtDescricao.Text.Trim() == "" || estaOK == false)
            {
                estaOK = false;
                MessageBox.Show("Informe a Descrição do Quarto.");
            }
            else if (!rdbNao.Checked && !rdbSim.Checked)
            {
                estaOK = false;
                MessageBox.Show("Informe a Disponibilidade deste Quarto.");
            }
            else if (txtValor.Text.Trim() == "")
            {
                estaOK = false;
                MessageBox.Show("Informe a Valor do Quarto.");
            }

            if (estaOK)
            {
                quarto.numero = Convert.ToInt32(txtNumero.Text);
                quarto.descricao = txtDescricao.Text;
                quarto.disponivel = rdbSim.Checked;
                quarto.valor = Convert.ToDouble(txtValor.Text);

                contexto.Quarto.Add(quarto);
                contexto.SaveChanges();
                contexto.Entry(quarto).Reload();

                LimpaCampos();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            Quarto quarto = new Quarto();
            bool estaOK = true;

            if (txtNumero.Text.Trim() == "")
            {
                estaOK = false;
                MessageBox.Show("Informe o Numero do Quarto.");
            }
            else if (txtDescricao.Text.Trim() == "")
            {
                estaOK = false;
                MessageBox.Show("Informe a Descrição do Quarto.");
            }
            else if (!rdbNao.Checked && !rdbSim.Checked)
            {
                estaOK = false;
                MessageBox.Show("Informe a Disponibilidade deste Quarto.");
            }
            else if (txtValor.Text.Trim() == "")
            {
                estaOK = false;
                MessageBox.Show("Informe a Valor do Quarto.");
            }

            if (estaOK)
            {
                quarto.id = Convert.ToInt32(txtId.Text);
                quarto.numero = Convert.ToInt32(txtNumero.Text);
                quarto.descricao = txtDescricao.Text;
                quarto.disponivel = rdbSim.Checked;
                quarto.valor = Convert.ToDouble(txtValor.Text);

                contexto.Entry(quarto).State = EntityState.Modified;
                contexto.SaveChanges();
                contexto.Entry(quarto).Reload();

                LimpaCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Você quer realmente Apagar Esse Quarto?", "Apagar Quarto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            
            if (dialogResult == DialogResult.Yes)
            {
                int id = Convert.ToInt32(txtId.Text);
                Contexto contexto = new Contexto();
                Quarto quarto = contexto.Quarto.FirstOrDefault(x=> x.id == id);

                contexto.Quarto.Remove(quarto);
                contexto.SaveChanges();
            }

            LimpaCampos();
        }
    }
}
