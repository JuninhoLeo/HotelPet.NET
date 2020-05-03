﻿namespace HotelPet
{
    partial class frmPermissoes
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
            this.dgvPermicoes = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.gpbVendas = new System.Windows.Forms.GroupBox();
            this.rdbVendNao = new System.Windows.Forms.RadioButton();
            this.rdbVendSim = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbClientes = new System.Windows.Forms.GroupBox();
            this.rdbCliSim = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbCliNao = new System.Windows.Forms.RadioButton();
            this.gpbProdutos = new System.Windows.Forms.GroupBox();
            this.rdbProdSim = new System.Windows.Forms.RadioButton();
            this.rdbProdNao = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.gpbFuncionarios = new System.Windows.Forms.GroupBox();
            this.rdbFuncSim = new System.Windows.Forms.RadioButton();
            this.rdbFuncNao = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.gpbServicos = new System.Windows.Forms.GroupBox();
            this.rdbServSim = new System.Windows.Forms.RadioButton();
            this.rdbServNao = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.gpbHotel = new System.Windows.Forms.GroupBox();
            this.rdbHotelSim = new System.Windows.Forms.RadioButton();
            this.rdbHotelNao = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbClinica = new System.Windows.Forms.GroupBox();
            this.rdbClinSim = new System.Windows.Forms.RadioButton();
            this.rdbClinNao = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.checkPwd = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBusca = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.gpbConfig = new System.Windows.Forms.GroupBox();
            this.rdbConfigSim = new System.Windows.Forms.RadioButton();
            this.rdbConfigNao = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermicoes)).BeginInit();
            this.gpbVendas.SuspendLayout();
            this.gpbClientes.SuspendLayout();
            this.gpbProdutos.SuspendLayout();
            this.gpbFuncionarios.SuspendLayout();
            this.gpbServicos.SuspendLayout();
            this.gpbHotel.SuspendLayout();
            this.gpbClinica.SuspendLayout();
            this.gpbConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPermicoes
            // 
            this.dgvPermicoes.AllowUserToAddRows = false;
            this.dgvPermicoes.AllowUserToDeleteRows = false;
            this.dgvPermicoes.AllowUserToResizeColumns = false;
            this.dgvPermicoes.AllowUserToResizeRows = false;
            this.dgvPermicoes.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPermicoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPermicoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermicoes.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPermicoes.Location = new System.Drawing.Point(12, 12);
            this.dgvPermicoes.Name = "dgvPermicoes";
            this.dgvPermicoes.Size = new System.Drawing.Size(672, 234);
            this.dgvPermicoes.TabIndex = 0;
            this.dgvPermicoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvPermicoes.DoubleClick += new System.EventHandler(this.dgvPermicoes_DoubleClick);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(27, 325);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 16);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(87, 322);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(143, 22);
            this.txtUser.TabIndex = 3;
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(87, 359);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(143, 22);
            this.txtSenha.TabIndex = 4;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(35, 362);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(50, 16);
            this.lblSenha.TabIndex = 6;
            this.lblSenha.Text = "Senha:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(310, 325);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(306, 22);
            this.txtNome.TabIndex = 6;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(260, 328);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(48, 16);
            this.lblNome.TabIndex = 8;
            this.lblNome.Text = "Nome:";
            // 
            // txtRG
            // 
            this.txtRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRG.Location = new System.Drawing.Point(310, 359);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(219, 22);
            this.txtRG.TabIndex = 7;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRG.Location = new System.Drawing.Point(277, 362);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(31, 16);
            this.lblRG.TabIndex = 10;
            this.lblRG.Text = "RG:";
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(310, 393);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(219, 22);
            this.txtCPF.TabIndex = 8;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.Location = new System.Drawing.Point(271, 396);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(37, 16);
            this.lblCPF.TabIndex = 12;
            this.lblCPF.Text = "CPF:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(310, 427);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(306, 22);
            this.txtEndereco.TabIndex = 9;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndereco.Location = new System.Drawing.Point(238, 430);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(70, 16);
            this.lblEndereco.TabIndex = 14;
            this.lblEndereco.Text = "Endereço:";
            // 
            // txtUF
            // 
            this.txtUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUF.Location = new System.Drawing.Point(310, 461);
            this.txtUF.MaxLength = 7;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(66, 22);
            this.txtUF.TabIndex = 10;
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUF.Location = new System.Drawing.Point(279, 464);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(29, 16);
            this.lblUF.TabIndex = 16;
            this.lblUF.Text = "UF:";
            // 
            // gpbVendas
            // 
            this.gpbVendas.BackColor = System.Drawing.Color.White;
            this.gpbVendas.Controls.Add(this.rdbVendNao);
            this.gpbVendas.Controls.Add(this.rdbVendSim);
            this.gpbVendas.Controls.Add(this.label1);
            this.gpbVendas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gpbVendas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbVendas.Location = new System.Drawing.Point(679, 291);
            this.gpbVendas.Name = "gpbVendas";
            this.gpbVendas.Size = new System.Drawing.Size(268, 33);
            this.gpbVendas.TabIndex = 42;
            this.gpbVendas.TabStop = false;
            // 
            // rdbVendNao
            // 
            this.rdbVendNao.AutoSize = true;
            this.rdbVendNao.Checked = true;
            this.rdbVendNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbVendNao.Location = new System.Drawing.Point(225, 12);
            this.rdbVendNao.Name = "rdbVendNao";
            this.rdbVendNao.Size = new System.Drawing.Size(14, 13);
            this.rdbVendNao.TabIndex = 12;
            this.rdbVendNao.TabStop = true;
            this.rdbVendNao.UseVisualStyleBackColor = true;
            // 
            // rdbVendSim
            // 
            this.rdbVendSim.AutoSize = true;
            this.rdbVendSim.Location = new System.Drawing.Point(168, 12);
            this.rdbVendSim.Name = "rdbVendSim";
            this.rdbVendSim.Size = new System.Drawing.Size(14, 13);
            this.rdbVendSim.TabIndex = 11;
            this.rdbVendSim.TabStop = true;
            this.rdbVendSim.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Vendas";
            // 
            // gpbClientes
            // 
            this.gpbClientes.BackColor = System.Drawing.Color.White;
            this.gpbClientes.Controls.Add(this.rdbCliSim);
            this.gpbClientes.Controls.Add(this.label2);
            this.gpbClientes.Controls.Add(this.rdbCliNao);
            this.gpbClientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbClientes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbClientes.Location = new System.Drawing.Point(679, 324);
            this.gpbClientes.Name = "gpbClientes";
            this.gpbClientes.Size = new System.Drawing.Size(268, 33);
            this.gpbClientes.TabIndex = 43;
            this.gpbClientes.TabStop = false;
            // 
            // rdbCliSim
            // 
            this.rdbCliSim.AutoSize = true;
            this.rdbCliSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbCliSim.Location = new System.Drawing.Point(168, 12);
            this.rdbCliSim.Name = "rdbCliSim";
            this.rdbCliSim.Size = new System.Drawing.Size(14, 13);
            this.rdbCliSim.TabIndex = 13;
            this.rdbCliSim.TabStop = true;
            this.rdbCliSim.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Clientes";
            // 
            // rdbCliNao
            // 
            this.rdbCliNao.AutoSize = true;
            this.rdbCliNao.Checked = true;
            this.rdbCliNao.Location = new System.Drawing.Point(225, 12);
            this.rdbCliNao.Name = "rdbCliNao";
            this.rdbCliNao.Size = new System.Drawing.Size(14, 13);
            this.rdbCliNao.TabIndex = 14;
            this.rdbCliNao.TabStop = true;
            this.rdbCliNao.UseVisualStyleBackColor = true;
            // 
            // gpbProdutos
            // 
            this.gpbProdutos.BackColor = System.Drawing.Color.White;
            this.gpbProdutos.Controls.Add(this.rdbProdSim);
            this.gpbProdutos.Controls.Add(this.rdbProdNao);
            this.gpbProdutos.Controls.Add(this.label5);
            this.gpbProdutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbProdutos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbProdutos.Location = new System.Drawing.Point(679, 357);
            this.gpbProdutos.Name = "gpbProdutos";
            this.gpbProdutos.Size = new System.Drawing.Size(268, 33);
            this.gpbProdutos.TabIndex = 44;
            this.gpbProdutos.TabStop = false;
            // 
            // rdbProdSim
            // 
            this.rdbProdSim.AutoSize = true;
            this.rdbProdSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbProdSim.Location = new System.Drawing.Point(168, 12);
            this.rdbProdSim.Name = "rdbProdSim";
            this.rdbProdSim.Size = new System.Drawing.Size(14, 13);
            this.rdbProdSim.TabIndex = 15;
            this.rdbProdSim.TabStop = true;
            this.rdbProdSim.UseVisualStyleBackColor = true;
            // 
            // rdbProdNao
            // 
            this.rdbProdNao.AutoSize = true;
            this.rdbProdNao.Checked = true;
            this.rdbProdNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbProdNao.Location = new System.Drawing.Point(225, 12);
            this.rdbProdNao.Name = "rdbProdNao";
            this.rdbProdNao.Size = new System.Drawing.Size(14, 13);
            this.rdbProdNao.TabIndex = 16;
            this.rdbProdNao.TabStop = true;
            this.rdbProdNao.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Produtos";
            // 
            // gpbFuncionarios
            // 
            this.gpbFuncionarios.BackColor = System.Drawing.Color.White;
            this.gpbFuncionarios.Controls.Add(this.rdbFuncSim);
            this.gpbFuncionarios.Controls.Add(this.rdbFuncNao);
            this.gpbFuncionarios.Controls.Add(this.label7);
            this.gpbFuncionarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbFuncionarios.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbFuncionarios.Location = new System.Drawing.Point(679, 423);
            this.gpbFuncionarios.Name = "gpbFuncionarios";
            this.gpbFuncionarios.Size = new System.Drawing.Size(268, 33);
            this.gpbFuncionarios.TabIndex = 46;
            this.gpbFuncionarios.TabStop = false;
            // 
            // rdbFuncSim
            // 
            this.rdbFuncSim.AutoSize = true;
            this.rdbFuncSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbFuncSim.Location = new System.Drawing.Point(168, 13);
            this.rdbFuncSim.Name = "rdbFuncSim";
            this.rdbFuncSim.Size = new System.Drawing.Size(14, 13);
            this.rdbFuncSim.TabIndex = 19;
            this.rdbFuncSim.TabStop = true;
            this.rdbFuncSim.UseVisualStyleBackColor = true;
            // 
            // rdbFuncNao
            // 
            this.rdbFuncNao.AutoSize = true;
            this.rdbFuncNao.Checked = true;
            this.rdbFuncNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbFuncNao.Location = new System.Drawing.Point(225, 13);
            this.rdbFuncNao.Name = "rdbFuncNao";
            this.rdbFuncNao.Size = new System.Drawing.Size(14, 13);
            this.rdbFuncNao.TabIndex = 20;
            this.rdbFuncNao.TabStop = true;
            this.rdbFuncNao.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Funcionários";
            // 
            // gpbServicos
            // 
            this.gpbServicos.BackColor = System.Drawing.Color.White;
            this.gpbServicos.Controls.Add(this.rdbServSim);
            this.gpbServicos.Controls.Add(this.rdbServNao);
            this.gpbServicos.Controls.Add(this.label6);
            this.gpbServicos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbServicos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbServicos.Location = new System.Drawing.Point(679, 390);
            this.gpbServicos.Name = "gpbServicos";
            this.gpbServicos.Size = new System.Drawing.Size(268, 33);
            this.gpbServicos.TabIndex = 45;
            this.gpbServicos.TabStop = false;
            // 
            // rdbServSim
            // 
            this.rdbServSim.AutoSize = true;
            this.rdbServSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbServSim.Location = new System.Drawing.Point(168, 12);
            this.rdbServSim.Name = "rdbServSim";
            this.rdbServSim.Size = new System.Drawing.Size(14, 13);
            this.rdbServSim.TabIndex = 17;
            this.rdbServSim.TabStop = true;
            this.rdbServSim.UseVisualStyleBackColor = true;
            // 
            // rdbServNao
            // 
            this.rdbServNao.AutoSize = true;
            this.rdbServNao.Checked = true;
            this.rdbServNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbServNao.Location = new System.Drawing.Point(225, 12);
            this.rdbServNao.Name = "rdbServNao";
            this.rdbServNao.Size = new System.Drawing.Size(14, 13);
            this.rdbServNao.TabIndex = 18;
            this.rdbServNao.TabStop = true;
            this.rdbServNao.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Serviços";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label8.Location = new System.Drawing.Point(19, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Dados do Funcionário:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label9.Location = new System.Drawing.Point(667, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Permissões";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(717, 46);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(273, 20);
            this.txtBusca.TabIndex = 1;
            // 
            // gpbHotel
            // 
            this.gpbHotel.BackColor = System.Drawing.Color.White;
            this.gpbHotel.Controls.Add(this.rdbHotelSim);
            this.gpbHotel.Controls.Add(this.rdbHotelNao);
            this.gpbHotel.Controls.Add(this.label4);
            this.gpbHotel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbHotel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbHotel.Location = new System.Drawing.Point(679, 456);
            this.gpbHotel.Name = "gpbHotel";
            this.gpbHotel.Size = new System.Drawing.Size(268, 33);
            this.gpbHotel.TabIndex = 56;
            this.gpbHotel.TabStop = false;
            // 
            // rdbHotelSim
            // 
            this.rdbHotelSim.AutoSize = true;
            this.rdbHotelSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbHotelSim.Location = new System.Drawing.Point(168, 13);
            this.rdbHotelSim.Name = "rdbHotelSim";
            this.rdbHotelSim.Size = new System.Drawing.Size(14, 13);
            this.rdbHotelSim.TabIndex = 21;
            this.rdbHotelSim.TabStop = true;
            this.rdbHotelSim.UseVisualStyleBackColor = true;
            // 
            // rdbHotelNao
            // 
            this.rdbHotelNao.AutoSize = true;
            this.rdbHotelNao.Checked = true;
            this.rdbHotelNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbHotelNao.Location = new System.Drawing.Point(225, 13);
            this.rdbHotelNao.Name = "rdbHotelNao";
            this.rdbHotelNao.Size = new System.Drawing.Size(14, 13);
            this.rdbHotelNao.TabIndex = 22;
            this.rdbHotelNao.TabStop = true;
            this.rdbHotelNao.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Hotel";
            // 
            // gpbClinica
            // 
            this.gpbClinica.BackColor = System.Drawing.Color.White;
            this.gpbClinica.Controls.Add(this.rdbClinSim);
            this.gpbClinica.Controls.Add(this.rdbClinNao);
            this.gpbClinica.Controls.Add(this.label11);
            this.gpbClinica.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbClinica.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbClinica.Location = new System.Drawing.Point(679, 489);
            this.gpbClinica.Name = "gpbClinica";
            this.gpbClinica.Size = new System.Drawing.Size(268, 33);
            this.gpbClinica.TabIndex = 57;
            this.gpbClinica.TabStop = false;
            // 
            // rdbClinSim
            // 
            this.rdbClinSim.AutoSize = true;
            this.rdbClinSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbClinSim.Location = new System.Drawing.Point(168, 13);
            this.rdbClinSim.Name = "rdbClinSim";
            this.rdbClinSim.Size = new System.Drawing.Size(14, 13);
            this.rdbClinSim.TabIndex = 23;
            this.rdbClinSim.TabStop = true;
            this.rdbClinSim.UseVisualStyleBackColor = true;
            // 
            // rdbClinNao
            // 
            this.rdbClinNao.AutoSize = true;
            this.rdbClinNao.Checked = true;
            this.rdbClinNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbClinNao.Location = new System.Drawing.Point(225, 13);
            this.rdbClinNao.Name = "rdbClinNao";
            this.rdbClinNao.Size = new System.Drawing.Size(14, 13);
            this.rdbClinNao.TabIndex = 24;
            this.rdbClinNao.TabStop = true;
            this.rdbClinNao.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Clínica";
            // 
            // checkPwd
            // 
            this.checkPwd.AutoSize = true;
            this.checkPwd.Location = new System.Drawing.Point(87, 387);
            this.checkPwd.Name = "checkPwd";
            this.checkPwd.Size = new System.Drawing.Size(93, 17);
            this.checkPwd.TabIndex = 5;
            this.checkPwd.TabStop = false;
            this.checkPwd.Text = "Mostrar senha";
            this.checkPwd.UseVisualStyleBackColor = true;
            this.checkPwd.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGray;
            this.btnConfirm.Image = global::HotelPet.Properties.Resources.next_user_16730;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirm.Location = new System.Drawing.Point(1033, 400);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(104, 74);
            this.btnConfirm.TabIndex = 58;
            this.btnConfirm.Text = "&Enviar";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.Image = global::HotelPet.Properties.Resources.delete_delete_exit_1577;
            this.label10.Location = new System.Drawing.Point(894, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 36);
            this.label10.TabIndex = 52;
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.LightGray;
            this.btnBusca.Image = global::HotelPet.Properties.Resources.search_102938;
            this.btnBusca.Location = new System.Drawing.Point(932, 72);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(58, 54);
            this.btnBusca.TabIndex = 2;
            this.btnBusca.UseVisualStyleBackColor = false;
            // 
            // btnSair
            // 
            this.btnSair.Image = global::HotelPet.Properties.Resources.X;
            this.btnSair.Location = new System.Drawing.Point(1079, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(58, 54);
            this.btnSair.TabIndex = 28;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label3
            // 
            this.label3.Image = global::HotelPet.Properties.Resources.check_ok_accept_apply_1582;
            this.label3.Location = new System.Drawing.Point(838, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 36);
            this.label3.TabIndex = 24;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.LightGray;
            this.btnExcluir.Image = global::HotelPet.Properties.Resources.delete_remove_user_16732;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.Location = new System.Drawing.Point(1033, 479);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(104, 74);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.LightGray;
            this.btnEditar.Image = global::HotelPet.Properties.Resources.search_find_user_16727;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditar.Location = new System.Drawing.Point(1033, 239);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(104, 74);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.LightGray;
            this.btnNovo.Image = global::HotelPet.Properties.Resources.new_add_user_167341;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNovo.Location = new System.Drawing.Point(1033, 319);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(104, 74);
            this.btnNovo.TabIndex = 25;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.button1_Click);
            // 
            // gpbConfig
            // 
            this.gpbConfig.BackColor = System.Drawing.Color.White;
            this.gpbConfig.Controls.Add(this.rdbConfigSim);
            this.gpbConfig.Controls.Add(this.rdbConfigNao);
            this.gpbConfig.Controls.Add(this.label12);
            this.gpbConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpbConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gpbConfig.Location = new System.Drawing.Point(679, 522);
            this.gpbConfig.Name = "gpbConfig";
            this.gpbConfig.Size = new System.Drawing.Size(268, 33);
            this.gpbConfig.TabIndex = 58;
            this.gpbConfig.TabStop = false;
            // 
            // rdbConfigSim
            // 
            this.rdbConfigSim.AutoSize = true;
            this.rdbConfigSim.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbConfigSim.Location = new System.Drawing.Point(168, 13);
            this.rdbConfigSim.Name = "rdbConfigSim";
            this.rdbConfigSim.Size = new System.Drawing.Size(14, 13);
            this.rdbConfigSim.TabIndex = 23;
            this.rdbConfigSim.TabStop = true;
            this.rdbConfigSim.UseVisualStyleBackColor = true;
            // 
            // rdbConfigNao
            // 
            this.rdbConfigNao.AutoSize = true;
            this.rdbConfigNao.Checked = true;
            this.rdbConfigNao.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rdbConfigNao.Location = new System.Drawing.Point(225, 13);
            this.rdbConfigNao.Name = "rdbConfigNao";
            this.rdbConfigNao.Size = new System.Drawing.Size(14, 13);
            this.rdbConfigNao.TabIndex = 24;
            this.rdbConfigNao.TabStop = true;
            this.rdbConfigNao.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "Configurações";
            // 
            // frmPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1149, 565);
            this.ControlBox = false;
            this.Controls.Add(this.gpbConfig);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.checkPwd);
            this.Controls.Add(this.gpbClinica);
            this.Controls.Add(this.gpbHotel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gpbFuncionarios);
            this.Controls.Add(this.gpbServicos);
            this.Controls.Add(this.gpbProdutos);
            this.Controls.Add(this.gpbClientes);
            this.Controls.Add(this.gpbVendas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUF);
            this.Controls.Add(this.lblUF);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.lblEndereco);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtRG);
            this.Controls.Add(this.lblRG);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.dgvPermicoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPermissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPermissoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermicoes)).EndInit();
            this.gpbVendas.ResumeLayout(false);
            this.gpbVendas.PerformLayout();
            this.gpbClientes.ResumeLayout(false);
            this.gpbClientes.PerformLayout();
            this.gpbProdutos.ResumeLayout(false);
            this.gpbProdutos.PerformLayout();
            this.gpbFuncionarios.ResumeLayout(false);
            this.gpbFuncionarios.PerformLayout();
            this.gpbServicos.ResumeLayout(false);
            this.gpbServicos.PerformLayout();
            this.gpbHotel.ResumeLayout(false);
            this.gpbHotel.PerformLayout();
            this.gpbClinica.ResumeLayout(false);
            this.gpbClinica.PerformLayout();
            this.gpbConfig.ResumeLayout(false);
            this.gpbConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPermicoes;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gpbVendas;
        private System.Windows.Forms.GroupBox gpbClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gpbProdutos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpbFuncionarios;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gpbServicos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.RadioButton rdbVendNao;
        private System.Windows.Forms.RadioButton rdbVendSim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbCliSim;
        private System.Windows.Forms.RadioButton rdbCliNao;
        private System.Windows.Forms.RadioButton rdbProdSim;
        private System.Windows.Forms.RadioButton rdbProdNao;
        private System.Windows.Forms.RadioButton rdbFuncSim;
        private System.Windows.Forms.RadioButton rdbFuncNao;
        private System.Windows.Forms.RadioButton rdbServSim;
        private System.Windows.Forms.RadioButton rdbServNao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gpbHotel;
        private System.Windows.Forms.RadioButton rdbHotelSim;
        private System.Windows.Forms.RadioButton rdbHotelNao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gpbClinica;
        private System.Windows.Forms.RadioButton rdbClinSim;
        private System.Windows.Forms.RadioButton rdbClinNao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkPwd;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox gpbConfig;
        private System.Windows.Forms.RadioButton rdbConfigSim;
        private System.Windows.Forms.RadioButton rdbConfigNao;
        private System.Windows.Forms.Label label12;
    }
}