namespace HotelPet.Funcionarios.AddCliente
{
    partial class frmUpdAnimal
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvUpdAnimal = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.animal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1pelagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdAnimal)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(644, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // dgvUpdAnimal
            // 
            this.dgvUpdAnimal.AllowUserToAddRows = false;
            this.dgvUpdAnimal.AllowUserToDeleteRows = false;
            this.dgvUpdAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpdAnimal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUpdAnimal.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUpdAnimal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpdAnimal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdAnimal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Cliente_id,
            this.foto,
            this.animal,
            this.NomeCli,
            this.especie,
            this.raca,
            this.Column1pelagem,
            this.cor,
            this.porte,
            this.sexo});
            this.dgvUpdAnimal.Location = new System.Drawing.Point(12, 159);
            this.dgvUpdAnimal.Name = "dgvUpdAnimal";
            this.dgvUpdAnimal.ReadOnly = true;
            this.dgvUpdAnimal.Size = new System.Drawing.Size(972, 345);
            this.dgvUpdAnimal.TabIndex = 7;
            this.dgvUpdAnimal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdAnimal_CellContentClick);
            this.dgvUpdAnimal.DoubleClick += new System.EventHandler(this.dgvUpdAnimal_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Digite o Nome do Animal ou do Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(283, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selecione o Animal a ser Atualizado";
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Código";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 65;
            // 
            // Cliente_id
            // 
            this.Cliente_id.DataPropertyName = "Cliente_id";
            this.Cliente_id.HeaderText = "Cliente_id";
            this.Cliente_id.Name = "Cliente_id";
            this.Cliente_id.ReadOnly = true;
            this.Cliente_id.Visible = false;
            this.Cliente_id.Width = 78;
            // 
            // foto
            // 
            this.foto.DataPropertyName = "foto";
            this.foto.HeaderText = "Foto";
            this.foto.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.foto.Name = "foto";
            this.foto.ReadOnly = true;
            this.foto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.foto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.foto.Width = 53;
            // 
            // animal
            // 
            this.animal.DataPropertyName = "animal";
            this.animal.HeaderText = "Animal";
            this.animal.Name = "animal";
            this.animal.ReadOnly = true;
            this.animal.Width = 63;
            // 
            // NomeCli
            // 
            this.NomeCli.DataPropertyName = "cliente";
            this.NomeCli.HeaderText = "Cliente";
            this.NomeCli.Name = "NomeCli";
            this.NomeCli.ReadOnly = true;
            this.NomeCli.Width = 64;
            // 
            // especie
            // 
            this.especie.DataPropertyName = "especie";
            this.especie.HeaderText = "Espécie";
            this.especie.Name = "especie";
            this.especie.ReadOnly = true;
            this.especie.Width = 70;
            // 
            // raca
            // 
            this.raca.DataPropertyName = "raca";
            this.raca.HeaderText = "Raça";
            this.raca.Name = "raca";
            this.raca.ReadOnly = true;
            this.raca.Width = 58;
            // 
            // Column1pelagem
            // 
            this.Column1pelagem.DataPropertyName = "pelagem";
            this.Column1pelagem.HeaderText = "Pelagem";
            this.Column1pelagem.Name = "Column1pelagem";
            this.Column1pelagem.ReadOnly = true;
            this.Column1pelagem.Width = 73;
            // 
            // cor
            // 
            this.cor.DataPropertyName = "cor";
            this.cor.HeaderText = "Cor";
            this.cor.Name = "cor";
            this.cor.ReadOnly = true;
            this.cor.Width = 48;
            // 
            // porte
            // 
            this.porte.DataPropertyName = "porte";
            this.porte.HeaderText = "Porte";
            this.porte.Name = "porte";
            this.porte.ReadOnly = true;
            this.porte.Width = 57;
            // 
            // sexo
            // 
            this.sexo.DataPropertyName = "sexo";
            this.sexo.HeaderText = "Sexo";
            this.sexo.Name = "sexo";
            this.sexo.ReadOnly = true;
            this.sexo.Width = 56;
            // 
            // frmUpdAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(996, 516);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvUpdAnimal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1012, 555);
            this.MinimumSize = new System.Drawing.Size(1012, 555);
            this.Name = "frmUpdAnimal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpdAnimal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdAnimal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvUpdAnimal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente_id;
        private System.Windows.Forms.DataGridViewImageColumn foto;
        private System.Windows.Forms.DataGridViewTextBoxColumn animal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn especie;
        private System.Windows.Forms.DataGridViewTextBoxColumn raca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1pelagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cor;
        private System.Windows.Forms.DataGridViewTextBoxColumn porte;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexo;
    }
}