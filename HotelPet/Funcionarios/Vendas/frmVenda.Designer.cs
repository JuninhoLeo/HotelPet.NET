namespace HotelPet
{
    partial class frmVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHora = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.lblData = new System.Windows.Forms.Label();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.Timer(this.components);
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lbldesconto = new System.Windows.Forms.Label();
            this.lblvalorunt = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.txtQtde = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtdesconto = new System.Windows.Forms.Label();
            this.txtValUnt = new System.Windows.Forms.Label();
            this.lblVtotal = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblQtdE_x_Valor = new System.Windows.Forms.Label();
            this.lblToalProd = new System.Windows.Forms.Label();
            this.lblLista = new System.Windows.Forms.Label();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblFinalizar = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtValorUnt = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblFunc = new System.Windows.Forms.Label();
            this.cmbFunc = new System.Windows.Forms.ComboBox();
            this.lblNomeProdutoServico = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.cmbCli = new System.Windows.Forms.ComboBox();
            this.lblCli = new System.Windows.Forms.Label();
            this.CkNotInform = new System.Windows.Forms.CheckBox();
            this.CkCPF = new System.Windows.Forms.CheckBox();
            this.dgvCompra = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLancar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.img6 = new System.Windows.Forms.PictureBox();
            this.img4 = new System.Windows.Forms.PictureBox();
            this.img5 = new System.Windows.Forms.PictureBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.imglogo = new System.Windows.Forms.PictureBox();
            this.img1 = new System.Windows.Forms.PictureBox();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.img3 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHora
            // 
            this.lblHora.BackColor = System.Drawing.Color.White;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.DimGray;
            this.lblHora.Location = new System.Drawing.Point(326, 211);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(175, 40);
            this.lblHora.TabIndex = 5;
            this.lblHora.Click += new System.EventHandler(this.LblHora_Click);
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Interval = 1000;
            this.hora.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.DimGray;
            this.lblData.Location = new System.Drawing.Point(212, 211);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(99, 40);
            this.lblData.TabIndex = 6;
            this.lblData.Click += new System.EventHandler(this.LblData_Click);
            // 
            // lblSeparador
            // 
            this.lblSeparador.BackColor = System.Drawing.Color.White;
            this.lblSeparador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeparador.ForeColor = System.Drawing.Color.DimGray;
            this.lblSeparador.Location = new System.Drawing.Point(302, 211);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(29, 40);
            this.lblSeparador.TabIndex = 7;
            this.lblSeparador.Click += new System.EventHandler(this.Label3_Click);
            // 
            // data
            // 
            this.data.Enabled = true;
            this.data.Interval = 1000;
            this.data.Tick += new System.EventHandler(this.Data_Tick);
            // 
            // txtCod
            // 
            this.txtCod.BackColor = System.Drawing.Color.LightGray;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(21, 306);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(394, 22);
            this.txtCod.TabIndex = 4;
            this.txtCod.Leave += new System.EventHandler(this.TxtCod_Leave);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.BackColor = System.Drawing.Color.White;
            this.lblCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCod.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCod.Location = new System.Drawing.Point(21, 283);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(225, 20);
            this.lblCod.TabIndex = 1;
            this.lblCod.Text = "Codigo do Produto ou Serviço*";
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.BackColor = System.Drawing.Color.White;
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblQtde.Location = new System.Drawing.Point(21, 507);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(98, 20);
            this.lblQtde.TabIndex = 14;
            this.lblQtde.Text = "Quantidade*";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.BackColor = System.Drawing.Color.White;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblValor.Location = new System.Drawing.Point(187, 509);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(80, 20);
            this.lblValor.TabIndex = 15;
            this.lblValor.Text = "Valor Unt.";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.White;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDesc.Location = new System.Drawing.Point(331, 509);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(109, 20);
            this.lblDesc.TabIndex = 17;
            this.lblDesc.Text = "Desconto(R$)";
            // 
            // lbldesconto
            // 
            this.lbldesconto.AutoSize = true;
            this.lbldesconto.BackColor = System.Drawing.Color.White;
            this.lbldesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldesconto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbldesconto.Location = new System.Drawing.Point(275, 584);
            this.lbldesconto.Name = "lbldesconto";
            this.lbldesconto.Size = new System.Drawing.Size(58, 13);
            this.lbldesconto.TabIndex = 20;
            this.lbldesconto.Text = "Valor Total";
            this.lbldesconto.Click += new System.EventHandler(this.lbldesconto_Click);
            // 
            // lblvalorunt
            // 
            this.lblvalorunt.AutoSize = true;
            this.lblvalorunt.BackColor = System.Drawing.Color.White;
            this.lblvalorunt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvalorunt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblvalorunt.Location = new System.Drawing.Point(111, 584);
            this.lblvalorunt.Name = "lblvalorunt";
            this.lblvalorunt.Size = new System.Drawing.Size(125, 13);
            this.lblvalorunt.TabIndex = 19;
            this.lblvalorunt.Text = "Valor Unitário do Produto";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.BackColor = System.Drawing.Color.White;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblQuantidade.Location = new System.Drawing.Point(18, 584);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(62, 13);
            this.lblQuantidade.TabIndex = 18;
            this.lblQuantidade.Text = "Quantidade";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.BackColor = System.Drawing.Color.White;
            this.lbltotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbltotal.Location = new System.Drawing.Point(389, 584);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(66, 13);
            this.lbltotal.TabIndex = 21;
            this.lbltotal.Text = "Valor à Vista";
            // 
            // txtQtde
            // 
            this.txtQtde.AutoSize = true;
            this.txtQtde.BackColor = System.Drawing.Color.White;
            this.txtQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtde.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtQtde.Location = new System.Drawing.Point(25, 612);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(0, 15);
            this.txtQtde.TabIndex = 22;
            this.txtQtde.Click += new System.EventHandler(this.TxtQtde_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtTotal.Location = new System.Drawing.Point(392, 610);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(0, 15);
            this.txtTotal.TabIndex = 23;
            this.txtTotal.Click += new System.EventHandler(this.TxtTotal_Click);
            // 
            // txtdesconto
            // 
            this.txtdesconto.AutoSize = true;
            this.txtdesconto.BackColor = System.Drawing.Color.White;
            this.txtdesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesconto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtdesconto.Location = new System.Drawing.Point(277, 610);
            this.txtdesconto.Name = "txtdesconto";
            this.txtdesconto.Size = new System.Drawing.Size(0, 15);
            this.txtdesconto.TabIndex = 24;
            this.txtdesconto.Click += new System.EventHandler(this.Txtdesconto_Click);
            // 
            // txtValUnt
            // 
            this.txtValUnt.AutoSize = true;
            this.txtValUnt.BackColor = System.Drawing.Color.White;
            this.txtValUnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValUnt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtValUnt.Location = new System.Drawing.Point(114, 610);
            this.txtValUnt.Name = "txtValUnt";
            this.txtValUnt.Size = new System.Drawing.Size(0, 15);
            this.txtValUnt.TabIndex = 25;
            this.txtValUnt.Click += new System.EventHandler(this.TxtValUnt_Click);
            // 
            // lblVtotal
            // 
            this.lblVtotal.AutoSize = true;
            this.lblVtotal.BackColor = System.Drawing.Color.DimGray;
            this.lblVtotal.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVtotal.ForeColor = System.Drawing.Color.Silver;
            this.lblVtotal.Location = new System.Drawing.Point(646, 501);
            this.lblVtotal.Name = "lblVtotal";
            this.lblVtotal.Size = new System.Drawing.Size(219, 32);
            this.lblVtotal.TabIndex = 28;
            this.lblVtotal.Text = "Valor Total(R$):";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.Color.DimGray;
            this.txtValorTotal.Font = new System.Drawing.Font("Arial", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.ForeColor = System.Drawing.Color.White;
            this.txtValorTotal.Location = new System.Drawing.Point(734, 535);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(614, 76);
            this.txtValorTotal.TabIndex = 29;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.txtValorTotal.Click += new System.EventHandler(this.Label14_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.White;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCodigo.Location = new System.Drawing.Point(649, 79);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(92, 29);
            this.lblCodigo.TabIndex = 30;
            this.lblCodigo.Text = "Codigo";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.BackColor = System.Drawing.Color.White;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDescricao.Location = new System.Drawing.Point(823, 79);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(121, 29);
            this.lblDescricao.TabIndex = 31;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblQtdE_x_Valor
            // 
            this.lblQtdE_x_Valor.AutoSize = true;
            this.lblQtdE_x_Valor.BackColor = System.Drawing.Color.White;
            this.lblQtdE_x_Valor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdE_x_Valor.ForeColor = System.Drawing.Color.DarkGray;
            this.lblQtdE_x_Valor.Location = new System.Drawing.Point(1135, 79);
            this.lblQtdE_x_Valor.Name = "lblQtdE_x_Valor";
            this.lblQtdE_x_Valor.Size = new System.Drawing.Size(66, 29);
            this.lblQtdE_x_Valor.TabIndex = 32;
            this.lblQtdE_x_Valor.Text = "Qtde";
            // 
            // lblToalProd
            // 
            this.lblToalProd.AutoSize = true;
            this.lblToalProd.BackColor = System.Drawing.Color.White;
            this.lblToalProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToalProd.ForeColor = System.Drawing.Color.DarkGray;
            this.lblToalProd.Location = new System.Drawing.Point(1231, 79);
            this.lblToalProd.Name = "lblToalProd";
            this.lblToalProd.Size = new System.Drawing.Size(67, 29);
            this.lblToalProd.TabIndex = 34;
            this.lblToalProd.Text = "Unit. ";
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.BackColor = System.Drawing.Color.White;
            this.lblLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLista.ForeColor = System.Drawing.Color.DarkGray;
            this.lblLista.Location = new System.Drawing.Point(646, 28);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(242, 31);
            this.lblLista.TabIndex = 36;
            this.lblLista.Text = "Lista de Produtos";
            // 
            // lblProd
            // 
            this.lblProd.AutoSize = true;
            this.lblProd.BackColor = System.Drawing.Color.White;
            this.lblProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProd.Location = new System.Drawing.Point(21, 336);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(125, 20);
            this.lblProd.TabIndex = 41;
            this.lblProd.Text = "Produto/ Serviço";
            // 
            // lblFinalizar
            // 
            this.lblFinalizar.AutoSize = true;
            this.lblFinalizar.BackColor = System.Drawing.Color.White;
            this.lblFinalizar.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalizar.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblFinalizar.Location = new System.Drawing.Point(916, 438);
            this.lblFinalizar.Name = "lblFinalizar";
            this.lblFinalizar.Size = new System.Drawing.Size(221, 32);
            this.lblFinalizar.TabIndex = 42;
            this.lblFinalizar.Text = "Finalizar Compra";
            this.lblFinalizar.Click += new System.EventHandler(this.Label22_Click);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.LightGray;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(21, 536);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(122, 22);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.Leave += new System.EventHandler(this.TxtQuantidade_Leave);
            // 
            // txtValorUnt
            // 
            this.txtValorUnt.BackColor = System.Drawing.Color.LightGray;
            this.txtValorUnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorUnt.Location = new System.Drawing.Point(186, 536);
            this.txtValorUnt.Name = "txtValorUnt";
            this.txtValorUnt.Size = new System.Drawing.Size(109, 22);
            this.txtValorUnt.TabIndex = 6;
            this.txtValorUnt.Leave += new System.EventHandler(this.TxtValorUnt_Leave);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.LightGray;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(328, 536);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(97, 22);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.Leave += new System.EventHandler(this.TxtDesc_Leave);
            // 
            // lblFunc
            // 
            this.lblFunc.AutoSize = true;
            this.lblFunc.BackColor = System.Drawing.Color.White;
            this.lblFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFunc.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFunc.Location = new System.Drawing.Point(21, 389);
            this.lblFunc.Name = "lblFunc";
            this.lblFunc.Size = new System.Drawing.Size(92, 20);
            this.lblFunc.TabIndex = 49;
            this.lblFunc.Text = "Funcionario";
            // 
            // cmbFunc
            // 
            this.cmbFunc.BackColor = System.Drawing.Color.LightGray;
            this.cmbFunc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFunc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFunc.FormattingEnabled = true;
            this.cmbFunc.Location = new System.Drawing.Point(21, 411);
            this.cmbFunc.Name = "cmbFunc";
            this.cmbFunc.Size = new System.Drawing.Size(394, 24);
            this.cmbFunc.TabIndex = 48;
            // 
            // lblNomeProdutoServico
            // 
            this.lblNomeProdutoServico.BackColor = System.Drawing.Color.LightGray;
            this.lblNomeProdutoServico.Enabled = false;
            this.lblNomeProdutoServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeProdutoServico.Location = new System.Drawing.Point(21, 359);
            this.lblNomeProdutoServico.Name = "lblNomeProdutoServico";
            this.lblNomeProdutoServico.Size = new System.Drawing.Size(394, 22);
            this.lblNomeProdutoServico.TabIndex = 51;
            // 
            // txtCpf
            // 
            this.txtCpf.BackColor = System.Drawing.Color.LightGray;
            this.txtCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpf.Location = new System.Drawing.Point(21, 467);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(394, 22);
            this.txtCpf.TabIndex = 4;
            this.txtCpf.TabStop = false;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.BackColor = System.Drawing.Color.White;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCPF.Location = new System.Drawing.Point(21, 443);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(40, 20);
            this.lblCPF.TabIndex = 3;
            this.lblCPF.Text = "CPF";
            // 
            // cmbCli
            // 
            this.cmbCli.BackColor = System.Drawing.Color.LightGray;
            this.cmbCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCli.FormattingEnabled = true;
            this.cmbCli.Location = new System.Drawing.Point(21, 466);
            this.cmbCli.Name = "cmbCli";
            this.cmbCli.Size = new System.Drawing.Size(394, 24);
            this.cmbCli.TabIndex = 6;
            // 
            // lblCli
            // 
            this.lblCli.AutoSize = true;
            this.lblCli.BackColor = System.Drawing.Color.White;
            this.lblCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCli.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCli.Location = new System.Drawing.Point(21, 444);
            this.lblCli.Name = "lblCli";
            this.lblCli.Size = new System.Drawing.Size(58, 20);
            this.lblCli.TabIndex = 5;
            this.lblCli.Text = "Cliente";
            // 
            // CkNotInform
            // 
            this.CkNotInform.AutoSize = true;
            this.CkNotInform.BackColor = System.Drawing.Color.White;
            this.CkNotInform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkNotInform.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CkNotInform.Location = new System.Drawing.Point(510, 473);
            this.CkNotInform.Name = "CkNotInform";
            this.CkNotInform.Size = new System.Drawing.Size(119, 24);
            this.CkNotInform.TabIndex = 2;
            this.CkNotInform.TabStop = false;
            this.CkNotInform.Text = "Não informar";
            this.CkNotInform.UseVisualStyleBackColor = false;
            this.CkNotInform.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // CkCPF
            // 
            this.CkCPF.AutoSize = true;
            this.CkCPF.BackColor = System.Drawing.Color.White;
            this.CkCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CkCPF.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CkCPF.Location = new System.Drawing.Point(510, 443);
            this.CkCPF.Name = "CkCPF";
            this.CkCPF.Size = new System.Drawing.Size(59, 24);
            this.CkCPF.TabIndex = 52;
            this.CkCPF.TabStop = false;
            this.CkCPF.Text = "CPF";
            this.CkCPF.UseVisualStyleBackColor = false;
            this.CkCPF.Click += new System.EventHandler(this.CkCPF_Click);
            // 
            // dgvCompra
            // 
            this.dgvCompra.AllowUserToOrderColumns = true;
            this.dgvCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCompra.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompra.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompra.Enabled = false;
            this.dgvCompra.GridColor = System.Drawing.Color.LightGray;
            this.dgvCompra.Location = new System.Drawing.Point(645, 111);
            this.dgvCompra.Name = "dgvCompra";
            this.dgvCompra.RowHeadersVisible = false;
            this.dgvCompra.RowHeadersWidth = 50;
            this.dgvCompra.Size = new System.Drawing.Size(700, 291);
            this.dgvCompra.TabIndex = 47;
            this.dgvCompra.DoubleClick += new System.EventHandler(this.dgvCompra_DoubleClick);
            this.dgvCompra.Leave += new System.EventHandler(this.dgvCompra_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Image = global::HotelPet.Properties.Resources.trash;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(654, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 36);
            this.button1.TabIndex = 53;
            this.button1.TabStop = false;
            this.button1.Text = "Remover Itens";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLancar
            // 
            this.btnLancar.BackColor = System.Drawing.Color.DarkGray;
            this.btnLancar.Image = global::HotelPet.Properties.Resources.lançar;
            this.btnLancar.Location = new System.Drawing.Point(506, 565);
            this.btnLancar.Name = "btnLancar";
            this.btnLancar.Size = new System.Drawing.Size(123, 51);
            this.btnLancar.TabIndex = 9;
            this.btnLancar.UseVisualStyleBackColor = false;
            this.btnLancar.Click += new System.EventHandler(this.Button5_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnFinalizar.Image = global::HotelPet.Properties.Resources.ok;
            this.btnFinalizar.Location = new System.Drawing.Point(1143, 413);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(193, 61);
            this.btnFinalizar.TabIndex = 11;
            this.btnFinalizar.TabStop = false;
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // img6
            // 
            this.img6.BackColor = System.Drawing.Color.LightGray;
            this.img6.Location = new System.Drawing.Point(649, 73);
            this.img6.Name = "img6";
            this.img6.Size = new System.Drawing.Size(693, 3);
            this.img6.TabIndex = 35;
            this.img6.TabStop = false;
            // 
            // img4
            // 
            this.img4.BackColor = System.Drawing.Color.DimGray;
            this.img4.Location = new System.Drawing.Point(645, 487);
            this.img4.Name = "img4";
            this.img4.Size = new System.Drawing.Size(703, 151);
            this.img4.TabIndex = 27;
            this.img4.TabStop = false;
            // 
            // img5
            // 
            this.img5.BackColor = System.Drawing.Color.Silver;
            this.img5.Location = new System.Drawing.Point(16, 599);
            this.img5.Name = "img5";
            this.img5.Size = new System.Drawing.Size(447, 3);
            this.img5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img5.TabIndex = 26;
            this.img5.TabStop = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackgroundImage = global::HotelPet.Properties.Resources.ext1;
            this.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpar.Location = new System.Drawing.Point(421, 305);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(29, 25);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.UseVisualStyleBackColor = false;
            // 
            // imglogo
            // 
            this.imglogo.BackColor = System.Drawing.Color.White;
            this.imglogo.BackgroundImage = global::HotelPet.Properties.Resources.logo;
            this.imglogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imglogo.Location = new System.Drawing.Point(152, 4);
            this.imglogo.Name = "imglogo";
            this.imglogo.Size = new System.Drawing.Size(340, 187);
            this.imglogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imglogo.TabIndex = 4;
            this.imglogo.TabStop = false;
            // 
            // img1
            // 
            this.img1.BackColor = System.Drawing.Color.White;
            this.img1.Location = new System.Drawing.Point(5, 4);
            this.img1.Name = "img1";
            this.img1.Size = new System.Drawing.Size(634, 262);
            this.img1.TabIndex = 3;
            this.img1.TabStop = false;
            this.img1.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // img2
            // 
            this.img2.BackColor = System.Drawing.Color.White;
            this.img2.Location = new System.Drawing.Point(5, 272);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(634, 366);
            this.img2.TabIndex = 2;
            this.img2.TabStop = false;
            // 
            // img3
            // 
            this.img3.BackColor = System.Drawing.Color.White;
            this.img3.Location = new System.Drawing.Point(645, 4);
            this.img3.Name = "img3";
            this.img3.Size = new System.Drawing.Size(703, 478);
            this.img3.TabIndex = 0;
            this.img3.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(794, 413);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 54;
            this.textBox1.TabStop = false;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(650, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "Codigo/Descrição:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Image = global::HotelPet.Properties.Resources.loupe_78347;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(510, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 36);
            this.button2.TabIndex = 56;
            this.button2.TabStop = false;
            this.button2.Text = "Pesquisar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkBox1.Location = new System.Drawing.Point(510, 413);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 24);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "Clientes";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click_1);
            // 
            // frmVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1360, 648);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CkCPF);
            this.Controls.Add(this.lblNomeProdutoServico);
            this.Controls.Add(this.lblFunc);
            this.Controls.Add(this.CkNotInform);
            this.Controls.Add(this.cmbFunc);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtValorUnt);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnLancar);
            this.Controls.Add(this.lblFinalizar);
            this.Controls.Add(this.lblProd);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblLista);
            this.Controls.Add(this.img6);
            this.Controls.Add(this.lblToalProd);
            this.Controls.Add(this.lblQtdE_x_Valor);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.lblVtotal);
            this.Controls.Add(this.img4);
            this.Controls.Add(this.img5);
            this.Controls.Add(this.txtValUnt);
            this.Controls.Add(this.txtdesconto);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.lbldesconto);
            this.Controls.Add(this.lblvalorunt);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.txtCod);
            this.Controls.Add(this.lblSeparador);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.imglogo);
            this.Controls.Add(this.img1);
            this.Controls.Add(this.cmbCli);
            this.Controls.Add(this.lblCli);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.img2);
            this.Controls.Add(this.dgvCompra);
            this.Controls.Add(this.img3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 5);
            this.Name = "frmVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imglogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox img2;
        private System.Windows.Forms.PictureBox img1;
        private System.Windows.Forms.PictureBox imglogo;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Timer data;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lbldesconto;
        private System.Windows.Forms.Label lblvalorunt;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label txtQtde;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label txtdesconto;
        private System.Windows.Forms.Label txtValUnt;
        private System.Windows.Forms.PictureBox img5;
        private System.Windows.Forms.PictureBox img4;
        private System.Windows.Forms.Label lblVtotal;
        private System.Windows.Forms.Label txtValorTotal;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblQtdE_x_Valor;
        private System.Windows.Forms.Label lblToalProd;
        private System.Windows.Forms.PictureBox img6;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.Label lblFinalizar;
        private System.Windows.Forms.Button btnLancar;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtValorUnt;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblFunc;
        private System.Windows.Forms.ComboBox cmbFunc;
        private System.Windows.Forms.TextBox lblNomeProdutoServico;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.ComboBox cmbCli;
        private System.Windows.Forms.Label lblCli;
        private System.Windows.Forms.CheckBox CkNotInform;
        private System.Windows.Forms.CheckBox CkCPF;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCompra;
        private System.Windows.Forms.PictureBox img3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}