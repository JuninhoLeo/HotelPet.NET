namespace HotelPet.Funcionarios.Clinica
{
    partial class frmTelaImpressao
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
            this.rvClinica = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvClinica
            // 
            this.rvClinica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvClinica.LocalReport.ReportEmbeddedResource = "HotelPet.Funcionarios.Clinica.ReceitaAtestado.rdlc";
            this.rvClinica.Location = new System.Drawing.Point(0, 0);
            this.rvClinica.Name = "rvClinica";
            this.rvClinica.ServerReport.BearerToken = null;
            this.rvClinica.Size = new System.Drawing.Size(659, 526);
            this.rvClinica.TabIndex = 0;
            // 
            // frmTelaImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 526);
            this.Controls.Add(this.rvClinica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTelaImpressao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTelaImpressao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvClinica;
    }
}