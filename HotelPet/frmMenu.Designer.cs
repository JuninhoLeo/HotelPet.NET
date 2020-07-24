namespace HotelPet
{
    partial class frmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.btnDash = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quartosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConsultar = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisCadastradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesCadstradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHotel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSair = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDash,
            this.btnAdmin,
            this.btnConsultar,
            this.btnCadastros,
            this.btnHotel,
            this.btnVendas,
            this.btnConfig,
            this.btnSair});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1029, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // btnDash
            // 
            this.btnDash.Image = global::HotelPet.Properties.Resources.Control_Panel_23581;
            this.btnDash.Name = "btnDash";
            this.btnDash.Size = new System.Drawing.Size(161, 24);
            this.btnDash.Text = "Painel de Controle";
            this.btnDash.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProdutos,
            this.serviçosToolStripMenuItem,
            this.quartosToolStripMenuItem});
            this.btnAdmin.Image = global::HotelPet.Properties.Resources.businessapplication_distributor_report_document_negocio_2319;
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(139, 24);
            this.btnAdmin.Text = "&Administrativo";
            // 
            // btnProdutos
            // 
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(180, 24);
            this.btnProdutos.Text = "&Produtos";
            this.btnProdutos.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.serviçosToolStripMenuItem.Text = "&Serviços";
            this.serviçosToolStripMenuItem.Click += new System.EventHandler(this.serviçosToolStripMenuItem_Click);
            // 
            // quartosToolStripMenuItem
            // 
            this.quartosToolStripMenuItem.Name = "quartosToolStripMenuItem";
            this.quartosToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.quartosToolStripMenuItem.Text = "&Quartos";
            this.quartosToolStripMenuItem.Click += new System.EventHandler(this.quartosToolStripMenuItem_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisCadastradosToolStripMenuItem,
            this.clientesCadstradosToolStripMenuItem});
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(87, 24);
            this.btnConsultar.Text = "Consultas";
            this.btnConsultar.Visible = false;
            // 
            // animaisCadastradosToolStripMenuItem
            // 
            this.animaisCadastradosToolStripMenuItem.Name = "animaisCadastradosToolStripMenuItem";
            this.animaisCadastradosToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.animaisCadastradosToolStripMenuItem.Text = "Animais Cadastrados";
            this.animaisCadastradosToolStripMenuItem.Click += new System.EventHandler(this.animaisCadastradosToolStripMenuItem_Click);
            // 
            // clientesCadstradosToolStripMenuItem
            // 
            this.clientesCadstradosToolStripMenuItem.Name = "clientesCadstradosToolStripMenuItem";
            this.clientesCadstradosToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.clientesCadstradosToolStripMenuItem.Text = "Clientes Cadstrados";
            this.clientesCadstradosToolStripMenuItem.Click += new System.EventHandler(this.clientesCadstradosToolStripMenuItem_Click);
            // 
            // btnCadastros
            // 
            this.btnCadastros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.animaisToolStripMenuItem});
            this.btnCadastros.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastros.Image")));
            this.btnCadastros.Name = "btnCadastros";
            this.btnCadastros.Size = new System.Drawing.Size(107, 24);
            this.btnCadastros.Text = "&Cadastros";
            this.btnCadastros.Click += new System.EventHandler(this.btnCadastros_Click);
            // 
            // animaisToolStripMenuItem
            // 
            this.animaisToolStripMenuItem.Name = "animaisToolStripMenuItem";
            this.animaisToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.animaisToolStripMenuItem.Text = "&Animais";
            this.animaisToolStripMenuItem.Click += new System.EventHandler(this.animaisToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.clientesToolStripMenuItem.Text = "&Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // btnHotel
            // 
            this.btnHotel.Image = global::HotelPet.Properties.Resources.pet_store_shop_building_animal_icon_124625;
            this.btnHotel.Name = "btnHotel";
            this.btnHotel.Size = new System.Drawing.Size(76, 24);
            this.btnHotel.Text = "&Hotel";
            this.btnHotel.Click += new System.EventHandler(this.hotelToolStripMenuItem_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.Image = global::HotelPet.Properties.Resources.shop_icon_34368;
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(87, 24);
            this.btnVendas.Text = "&Vendas";
            this.btnVendas.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Image = global::HotelPet.Properties.Resources._1486395874_settings_80622;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(136, 24);
            this.btnConfig.Text = "&Configurações";
            this.btnConfig.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // btnSair
            // 
            this.btnSair.Image = global::HotelPet.Properties.Resources.close_delete_delete_theaction_theoutput_10252;
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(66, 24);
            this.btnSair.Text = "&Sair";
            this.btnSair.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 424);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1029, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1029, 446);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMenu";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem btnAdmin;
        private System.Windows.Forms.ToolStripMenuItem btnProdutos;
        private System.Windows.Forms.ToolStripMenuItem btnSair;
        private System.Windows.Forms.ToolStripMenuItem btnHotel;
        private System.Windows.Forms.ToolStripMenuItem btnVendas;
        private System.Windows.Forms.ToolStripMenuItem btnCadastros;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnConfig;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnDash;
        private System.Windows.Forms.ToolStripMenuItem btnConsultar;
        private System.Windows.Forms.ToolStripMenuItem animaisCadastradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesCadstradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quartosToolStripMenuItem;
    }
}



