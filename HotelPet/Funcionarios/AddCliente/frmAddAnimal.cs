using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Funcionarios.AddCliente;
using HotelPet.Funcionarios.Hotel;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Contexto contexto = new Contexto();

            cmbCli.DataSource = contexto.Cliente.Where(x => x.nome != null).ToList();
            cmbCli.DisplayMember = "nome";
            cmbCli.ValueMember = "id";
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imageLocation = dialog.FileName.ToString(); ;
                pbxImage.ImageLocation = imageLocation;
                Imagem.Text = imageLocation;
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

        private static FileStream fstream = new FileStream("C:\\Users\\JrJos\\Desktop\\ProjetoTcc\\HotelPet.NET\\HotelPet\\Resources\\SEM-IMAGEM-13.jpg", FileMode.Open, FileAccess.Read);
        private static BinaryReader br = new BinaryReader(fstream);
        private static byte[] imagem = br.ReadBytes((int)fstream.Length);
        public int idAnimal { get; set; }
        private void button5_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            frmUpdAnimal frm = new frmUpdAnimal(this);
            frm.ShowDialog();

            Animal animal = contexto.Animal.FirstOrDefault(x => x.id == idAnimal);

            cmbCli.SelectedValue = animal.Cliente_id;

            txtEspecie.Text = animal.especie;
            txtRaca.Text = animal.raca;
            txtPelagem.Text = animal.pelagem;
            txtCor.Text = animal.cor;
            rbdFemea.Checked = (animal.sexo.Trim().ToLower() == "femea") ? true : false;
            rbdMacho.Checked = (animal.sexo.Trim().ToLower() == "macho") ? true : false;
            txtNome.Text = animal.nome;
            txtMae.Text = animal.mae;
            txtPai.Text = animal.pai;
            txtApelido.Text = animal.apelido;
            dateNasc.Value = (animal.nascimento == null) ? DateTime.Now : (DateTime)animal.nascimento;
            dateMae.Value = (animal.nascmae == null) ? DateTime.Now : (DateTime)animal.nascmae;
            datePai.Value = (animal.nascpai == null) ? DateTime.Now : (DateTime)animal.nascpai;
            txtObs.Text = animal.observacoes;
            txtCuidados.Text = animal.cuidados;
            pbxImage.Image = (animal.imagem == null) ? Image.FromStream(new MemoryStream(imagem)) : Image.FromStream(new MemoryStream(animal.imagem));

            if (animal.porte.Trim().ToLower() == "mini")
            {
                rbdMini.Checked = true;
            }
            else if (animal.porte.Trim().ToLower() == "pequeno")
            {
                rbdPequeno.Checked = true;
            }
            else if (animal.porte.Trim().ToLower() == "medio")
            {
                rbdMedio.Checked = true;
            }
            else if (animal.porte.Trim().ToLower() == "grande")
            {
                rbdGrande.Checked = true;
            }
            lblId.Text = animal.id.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            int Conf = 0;
            DialogResult confirm = MessageBox.Show("Deseja Salvar este Animal? " +
                                                   "Clique em Sim para salvar e fechar", "Deseja Salvar",
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
                        animal.Cliente_id = Convert.ToInt32(cmbCli.SelectedValue);
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

                if (Imagem.Text != "")
                {
                    FileStream fstream = new FileStream(Imagem.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    byte[] imagem = br.ReadBytes((int)fstream.Length);

                    animal.imagem = imagem;
                }
                else
                {
                    animal.imagem = null;
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

                if (lblId.Text.Trim() != "")
                {
                    Conf = 1;
                    MessageBox.Show("ERRO: Não é possivel gravar novo pois esse animal já está cadastrado, Tente atualizar.",
                                    "ERRO ao Gravar", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                if (Conf == 0)
                {
                    contexto.Animal.Add(animal);
                    contexto.SaveChanges();
                    LimpaCampos();
                    this.Close();
                }
            }
        }

        public void LimpaCampos()
        {
            lblId.Text = "";
            dateNasc.Value = DateTime.Now;
            datePai.Value = DateTime.Now;
            dateMae.Value = DateTime.Now;
            txtEspecie.Text = "";
            txtRaca.Text = "";
            txtPelagem.Text = "";
            txtCor.Text = "";
            rbdMini.Checked = true;
            rbdMacho.Checked = true;
            txtApelido.Text = "";
            txtNome.Text = "";
            txtPai.Text = "";
            txtMae.Text = "";
            txtObs.Text = "Ex: Alérgico a comida humana, etc.";
            txtCuidados.Text = "Ex: Cortar as unhas cada 15 dias, etc.";
            pbxImage.Image = Image.FromStream(new MemoryStream(imagem));
        }

        private void txtObs_Click(object sender, EventArgs e)
        {
            txtObs.Text = "";
        }

        private void txtCuidados_Click(object sender, EventArgs e)
        {
            txtCuidados.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void pbxImage_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();

            int Conf = 0;
            DialogResult confirm = MessageBox.Show("Deseja Salvar as alterações deste Animal? " +
                                                   "Clique em Sim para salvar", "Deseja Salvar",
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
                        animal.Cliente_id = Convert.ToInt32(cmbCli.SelectedValue);
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

                if (Imagem.Text != "")
                {
                    FileStream fstream = new FileStream(Imagem.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    byte[] imagem = br.ReadBytes((int)fstream.Length);

                    animal.imagem = imagem;
                }
                else
                {
                    animal.imagem = null;
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
                    animal.id = Convert.ToInt32(lblId.Text.Trim());
                    contexto.Entry(animal).State = EntityState.Modified;
                    contexto.SaveChanges();
                    contexto.Entry(animal).Reload();

                    LimpaCampos();
                }
            }
        }
    }
}
