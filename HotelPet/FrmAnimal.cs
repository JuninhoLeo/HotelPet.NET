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
    public partial class frmAnimais : Form
    {
        public frmAnimais()
        {
            InitializeComponent();
        }

        private void Produtos_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDiretorio_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pbxImage.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("UM Erro Ocorreu", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja Salvar as alterações deste documento?", "Deseja Fechar?",
                           MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (confirm.ToString().ToUpper() == "YES")
            {
                // Salvar os dados
                this.Close();
            }
            if (confirm.ToString().ToUpper() == "NO")
            {
                // Sair sem salvar
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Conf = 0;
            DialogResult confirm = MessageBox.Show("Deseja Salvar as alterações deste documento antes do fechar? " +
                                                   "Clique em Sim para salvar e fechar", "Deseja Salvar?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (confirm.ToString().ToUpper() == "YES")
            {

                Camadas.MODEL.Animal animal = new Camadas.MODEL.Animal();

                if (Convert.ToString(cmbCli.SelectedItem) == "" && txtNome.Text == "")
                {
                    DialogResult dialog = MessageBox.Show("Selecione o 'Nome do Dono' e Informe o 'Nome do Animal' antes de Continuar o cadastro", "Nome do Animal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Conf = 1;
                }
                else
                {
                    if (Convert.ToString(cmbCli.SelectedItem) != "")
                    {
                        animal.idcli = Convert.ToInt32(cmbCli.SelectedItem);
                        Conf = 0;
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Selecione o Nome do Dono do Animal antes de Continuar o cadastro", "Nome do Animal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        Conf = 1;
                    }

                    if (txtNome.Text != "") 
                    {
                        animal.nome = txtNome.Text;
                        Conf = 0;
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Informe o Nome do Animal antes de Continuar o cadastro", "Nome do Animal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        Conf = 1;
                    }
                }


                animal.nascimento = dateNasc.Value;
                animal.nascpai = datePai.Value;
                animal.nascmae = dateMae.Value;
                animal.especie = txtEspecie.Text;
                animal.raca = txtRaca.Text;
                animal.pelagem = txtPelagem.Text;
                animal.cor = txtCor.Text;
                animal.apelido = txtApelido.Text;
                animal.pai = txtPai.Text;
                animal.mae = txtMae.Text;
                animal.observacoes = txtObs.Text;
                animal.cuidados = txtCuidados.Text;

                //-------------------------------------
                if (rbdMacho.Checked == true)
                {
                    animal.sexo = "Macho";
                }
                else
                {
                    animal.sexo = "Femea";
                }
                //------------------------------------
                if (rbdMini.Checked == true)
                {
                    animal.porte = "Mini";
                }
                else
                {
                    if (rbdPequeno.Checked == true)
                    {
                        animal.porte = "Pequeno";
                    }
                    else
                    {
                        if (rbdMedio.Checked == true)
                        {
                            animal.porte = "Medio";
                        }
                        else
                        {
                            if (rbdGrande.Checked == true)
                            {
                                animal.porte = "Grande";
                            }
                        }
                    }
                }
                               
                if (Conf == 0)
                {
                    Camadas.DAL.Animal dalAnimal = new Camadas.DAL.Animal();
                    dalAnimal.Insert(animal);
                    this.Close();
                }
            }            
        }

        private void txtObs_Click(object sender, EventArgs e)
        {
            txtObs.Text = "";
        }

        private void txtCuidados_Click(object sender, EventArgs e)
        {
            txtCuidados.Text = "";
        }
    }
}
