﻿using HotelPet.Camadas.BLL;
using HotelPet.Camadas.MODEL;
using HotelPet.Entity;
using HotelPet.Layers.BLL;
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
    public partial class frmCadServicos : Form
    {
        public frmCadServicos()
        {
            InitializeComponent();
        }

        Contexto contexto = new Contexto();
        private void frmCadServicos_Load(object sender, EventArgs e)
        {
            LimpaCampos();            
        }

        private void dgvServicos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtId.Enabled = false;
                txtId.Text = dgvServicos.SelectedRows[0].Cells["Código"].Value.ToString();
                txtDescricao.Text = dgvServicos.SelectedRows[0].Cells["Descrição"].Value.ToString();
                txtQtde.Text = dgvServicos.SelectedRows[0].Cells["Qtde"].Value.ToString();
                double valor = Convert.ToInt32(dgvServicos.SelectedRows[0].Cells["Valor"].Value);
                txtValor.Text = valor.ToString("C").Replace("R$ ", "");
            }
            catch (Exception)
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = Convert.ToInt32(txtId.Text);
                Produtos servicos = contexto.Produto.FirstOrDefault(x => x.id == id);

                servicos.descricao = txtDescricao.Text;
                servicos.quantidade = Convert.ToDouble(txtQtde.Text);
                servicos.valor = Convert.ToDouble(txtValor.Text);
                servicos.isQuarto = false;
                servicos.isServico = true;

                contexto.Entry(servicos).State = EntityState.Modified;
                contexto.SaveChanges();

                LimpaCampos();
            }
            else
            {
                MessageBox.Show("ERRO: Nenhum Serviço selecionado", "ERRO NA ATUALIZAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void LimpaCampos()
        {
            txtId.Text = "";
            txtDescricao.Text = "";
            txtQtde.Text = "";
            txtValor.Text = "";

            dgvServicos.DataSource = "";
            var lista = from Serv in contexto.Produto.Where(x=> x.isQuarto == false && x.isServico == true).ToList()
                        select new
                        {
                            Código = Serv.codigo,
                            Descrição = Serv.descricao,
                            Qtde = Serv.quantidade,
                            Valor = Serv.valor
                        };

            dgvServicos.DataSource = lista.ToList();
            dgvServicos.Columns["Código"].Width = 87;
            dgvServicos.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServicos.Columns["Descrição"].Width = 300;

            dgvServicos.Columns["Qtde"].Width = 90;
            dgvServicos.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvServicos.Columns["Valor"].Width = 90;
            dgvServicos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServicos.Columns["Valor"].DefaultCellStyle.Format = "C";
        }

        private void txtBusca_KeyUp(object sender, KeyEventArgs e)
        {

            var Texto = txtBusca.Text.Trim().ToLower();

            dgvServicos.DataSource = "";
            var lista = from Serv in contexto.Produto.Where(x=> x.descricao.Trim().ToLower().Contains(Texto) 
                                                             && x.isQuarto == false && x.isServico == true).ToList()
                        select new
                        {
                            Código = Serv.codigo,
                            Descrição = Serv.descricao,
                            Qtde = Serv.quantidade,
                            Valor = Serv.valor
                        };

            dgvServicos.DataSource = lista.ToList();
            dgvServicos.Columns["Código"].Width = 87;
            dgvServicos.Columns["Código"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServicos.Columns["Descrição"].Width = 300;

            dgvServicos.Columns["Qtde"].Width = 90;
            dgvServicos.Columns["Qtde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dgvServicos.Columns["Valor"].Width = 90;
            dgvServicos.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServicos.Columns["Valor"].DefaultCellStyle.Format = "C";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                int id = Convert.ToInt32(txtId.Text);
                ServicosBLL BLL = new ServicosBLL();
                Produtos servico = contexto.Produto.FirstOrDefault(x => x.id == id);

                DialogResult dialogResult = MessageBox.Show("Você tem certeza em remover este serviço?\n Irá remover tambem todos os dados que estão ligados a ele", "VOCÊ TEM CERTEZA?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (dialogResult == DialogResult.Yes)
                {
                    BLL.Delete(servico);
                }

                LimpaCampos();
            }
            else
            {
                MessageBox.Show("ERRO: Nenhum Serviço selecionado", "ERRO NA REMOÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool estaOk = true;

            if(txtDescricao.Text == "") 
            {
                estaOk = false;
                MessageBox.Show("Informe a Descrição/Nome do Serviço.", "Informações necessárias não informadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if(txtQtde.Text == "") 
            {
                estaOk = false;
                MessageBox.Show("Informe a Quantidade do Serviço ou defina como 1(Padrão).", "Informações necessárias não informadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if(txtValor.Text == "") 
            {
                estaOk = false;
                MessageBox.Show("Informe o Valor(R$) do Serviço.", "Informações necessárias não informadas", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            if (estaOk)
            {
                Produtos servico = new Produtos();


                servico.descricao = txtDescricao.Text;
                servico.quantidade = Convert.ToDouble(txtQtde.Text);
                servico.valor = Convert.ToDouble(txtValor.Text);
                servico.isQuarto = false;
                servico.isServico = true;

                contexto.Produto.Add(servico);
                contexto.SaveChanges();
                contexto.Entry(servico).Reload();

                var serv = contexto.Produto.FirstOrDefault(x => x.id == servico.id);
                serv.codigo = servico.id;
                contexto.Entry(serv).State = EntityState.Modified;
                contexto.SaveChanges();

                LimpaCampos();
                //var id = servico.id;
            }

        }
    }
}
