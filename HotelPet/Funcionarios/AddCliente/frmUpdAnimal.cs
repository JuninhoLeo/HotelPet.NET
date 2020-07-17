using HotelPet.Entity;
using HotelPet.Functions;
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

namespace HotelPet.Funcionarios.AddCliente
{
    public partial class frmUpdAnimal : Form
    {

        frmAnimais frmAnimais = new frmAnimais();

        public frmUpdAnimal(frmAnimais frmAnimais)
        {
            this.frmAnimais = frmAnimais;
            InitializeComponent();
        }

        private static FileStream fstream = new FileStream("C:\\Users\\JrJos\\Desktop\\ProjetoTcc\\HotelPet.NET\\HotelPet\\Resources\\SEM-IMAGEM-13.jpg", FileMode.Open, FileAccess.Read);
        private static BinaryReader br = new BinaryReader(fstream);
        private static byte[] imagem = br.ReadBytes((int)fstream.Length);

        private void frmUpdAnimal_Load(object sender, EventArgs e)
        {
            Contexto contexto = new Contexto();
            var Lista = from ani in contexto.Animal.ToList()
                        orderby ani.nome
                        select new
                        {
                            ani.id,
                            ani.Cliente_id,
                            cliente = ani.Cliente.nome,
                            animal = ani.nome,
                            especie = ani.especie,
                            raca = ani.raca,
                            pelagem = ani.pelagem,
                            cor = ani.cor,
                            porte = ani.porte,
                            sexo = ani.sexo,
                            foto = (ani.imagem == null) ? Image.FromStream(new MemoryStream(imagem)) : Image.FromStream(new MemoryStream(ani.imagem))
                        };

            InterfaceTools.dgvTransformation(dgvUpdAnimal);
            dgvUpdAnimal.DataSource = Lista.ToList();
        }

        private void dgvUpdAnimal_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Contexto contexto = new Contexto();

                int idAnimal = Convert.ToInt32(dgvUpdAnimal.SelectedRows[0].Cells["id"].Value);

                frmAnimais.idAnimal = idAnimal;

                this.Close();
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Contexto contexto = new Contexto();
            string busca = textBox1.Text.Trim().ToLower();
            var Lista = from ani in contexto.Animal.Where(x=> x.Cliente.nome.Trim().ToLower().Contains(busca) || 
                                                              x.nome.Trim().ToLower().Contains(busca)).ToList()
                        orderby ani.nome
                        select new
                        {
                            ani.id,
                            ani.Cliente_id,
                            cliente = ani.Cliente.nome,
                            animal = ani.nome,
                            especie = ani.especie,
                            raca = ani.raca,
                            pelagem = ani.pelagem,
                            cor = ani.cor,
                            porte = ani.porte,
                            sexo = ani.sexo,
                            foto = (ani.imagem == null) ? Image.FromStream(new MemoryStream(imagem)) : Image.FromStream(new MemoryStream(ani.imagem))
                        };

            InterfaceTools.dgvTransformation(dgvUpdAnimal);
            dgvUpdAnimal.DataSource = Lista.ToList();
        }

        private void dgvUpdAnimal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
