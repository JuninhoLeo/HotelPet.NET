namespace HotelPet.Funcionarios.Hotel
{
    partial class frmConsulta
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
            this.txtbusca = new System.Windows.Forms.TextBox();
            this.dgvhotel = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhotel)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbusca
            // 
            this.txtbusca.Location = new System.Drawing.Point(12, 87);
            this.txtbusca.Name = "txtbusca";
            this.txtbusca.Size = new System.Drawing.Size(340, 20);
            this.txtbusca.TabIndex = 8;
            this.txtbusca.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // dgvhotel
            // 
            this.dgvhotel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvhotel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvhotel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvhotel.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvhotel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvhotel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhotel.Location = new System.Drawing.Point(14, 113);
            this.dgvhotel.Name = "dgvhotel";
            this.dgvhotel.Size = new System.Drawing.Size(689, 206);
            this.dgvhotel.TabIndex = 7;
            this.dgvhotel.DoubleClick += new System.EventHandler(this.dgvProdutos_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Digite o Nome do Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(187, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Buscar Animais hospedados";
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(715, 331);
            this.Controls.Add(this.txtbusca);
            this.Controls.Add(this.dgvhotel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhotel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbusca;
        private System.Windows.Forms.DataGridView dgvhotel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}