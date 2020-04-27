using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPet
{
    public partial class frmPermissoes : Form
    {
        public delegate void InvokeDelegate();

        public frmPermissoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPermissoes_Load(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            login.ShowDialog();
            ;
            if (login.DialogResult == DialogResult.Cancel)
            {
                BeginInvoke(new InvokeDelegate(confirm));
            }
            
        }

        private void confirm()
        {
            MdiParent.MainMenuStrip.Enabled = true;
            this.Visible = false;
            this.Close();
        }

    }
}
