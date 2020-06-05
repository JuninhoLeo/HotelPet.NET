using ExcelDataReader;
using HotelPet.Camadas.MODEL;
using HotelPet.Layers.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet.Admin
{
    public partial class frmImportar : Form
    {
        public frmImportar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmImportar_Load(object sender, EventArgs e)
        {
            ProgressBar.Visible = false;
            lblProgress.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Microsoft Excel(*.xlsx)|*.xlsx"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imageLocation = dialog.FileName.ToString(); ;
                txtPath.Text = imageLocation;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            btnDone.Visible = false;
            lblStatus.Text = "Analizando o Arquivo...";
            lblStatus.Refresh();

            if (txtPath.Text == "")
            {
                MessageBox.Show("Precisa informar o caminho do arquivo primeiro.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDone.Visible = true;
                lblStatus.Text = "";
            }
            else
            {
                FileStream stream = File.Open(txtPath.Text, FileMode.Open, FileAccess.Read);
                var reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                ProdutosBLL bll = new ProdutosBLL();
                Produtos produtos = new Produtos();

                reader.Read();
                lblStatus.Text = "Carregando...";
                lblStatus.Refresh();

                while (reader.Read())
                {
                    int progress = (int)Math.Ceiling((decimal)reader.Depth / (decimal)reader.RowCount * (decimal)100);
                    ProgressBar.Visible = true;
                    ProgressBar.Value = progress;
                    ProgressBar.Refresh();

                    lblProgress.Visible = true;
                    lblProgress.Text = progress.ToString() + "%";
                    lblProgress.Refresh();

                    produtos.codigo = (reader[0] != null) ? reader[0].ToString() : "";
                    produtos.descricao = (reader[1] != null) ? reader[1].ToString() : "";
                    produtos.quantidade = (reader[2] != null) ? Convert.ToDouble(reader[2].ToString()) : 0;
                    produtos.valor = (reader[3] != null) ? Convert.ToDouble(reader[3].ToString()) : 0;

                    bll.VerificaProduto(produtos);
                }
                MessageBox.Show("Importado com êxito!", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
