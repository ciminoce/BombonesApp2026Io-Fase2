namespace BombonesApp2026.Windows
{
    partial class frmPrincipal
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
            panelTop = new Panel();
            lblFecha = new Label();
            label2 = new Label();
            btnLogout = new Button();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblUsuario = new ToolStripStatusLabel();
            panelMenu = new Panel();
            btnVentas = new Button();
            btnClientes = new Button();
            btnFormasDePago = new Button();
            btnCajas = new Button();
            btnBombones = new Button();
            btnTiposBombones = new Button();
            panelContent = new Panel();
            label4 = new Label();
            label3 = new Label();
            panelTop.SuspendLayout();
            statusStrip1.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblFecha);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(949, 74);
            panelTop.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(575, 25);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(73, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "01/01/2026";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(528, 25);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(852, 24);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(180, 30);
            label1.TabIndex = 0;
            label1.Text = "Bombones 2026";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblUsuario });
            statusStrip1.Location = new Point(0, 517);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(949, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(50, 17);
            toolStripStatusLabel1.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(108, 17);
            lblUsuario.Text = "Usuario Conectado";
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(btnVentas);
            panelMenu.Controls.Add(btnClientes);
            panelMenu.Controls.Add(btnFormasDePago);
            panelMenu.Controls.Add(btnCajas);
            panelMenu.Controls.Add(btnBombones);
            panelMenu.Controls.Add(btnTiposBombones);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 74);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(238, 443);
            panelMenu.TabIndex = 2;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(37, 321);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(171, 37);
            btnVentas.TabIndex = 0;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(37, 186);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(171, 37);
            btnClientes.TabIndex = 0;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnFormasDePago
            // 
            btnFormasDePago.Location = new Point(37, 278);
            btnFormasDePago.Name = "btnFormasDePago";
            btnFormasDePago.Size = new Size(171, 37);
            btnFormasDePago.TabIndex = 0;
            btnFormasDePago.Text = "Formas de Pago";
            btnFormasDePago.UseVisualStyleBackColor = true;
            btnFormasDePago.Click += btnFormasDePago_Click;
            // 
            // btnCajas
            // 
            btnCajas.Location = new Point(37, 114);
            btnCajas.Name = "btnCajas";
            btnCajas.Size = new Size(171, 37);
            btnCajas.TabIndex = 0;
            btnCajas.Text = "Cajas";
            btnCajas.UseVisualStyleBackColor = true;
            btnCajas.Click += btnCajas_Click;
            // 
            // btnBombones
            // 
            btnBombones.Location = new Point(37, 71);
            btnBombones.Name = "btnBombones";
            btnBombones.Size = new Size(171, 37);
            btnBombones.TabIndex = 0;
            btnBombones.Text = "Bombones";
            btnBombones.UseVisualStyleBackColor = true;
            btnBombones.Click += btnBombones_Click;
            // 
            // btnTiposBombones
            // 
            btnTiposBombones.Location = new Point(37, 28);
            btnTiposBombones.Name = "btnTiposBombones";
            btnTiposBombones.Size = new Size(171, 37);
            btnTiposBombones.TabIndex = 0;
            btnTiposBombones.Text = "Tipos de Bombones";
            btnTiposBombones.UseVisualStyleBackColor = true;
            btnTiposBombones.Click += btnTiposBombones_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(label4);
            panelContent.Controls.Add(label3);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(238, 74);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(711, 443);
            panelContent.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(203, 131);
            label4.Name = "label4";
            label4.Size = new Size(263, 15);
            label4.TabIndex = 0;
            label4.Text = "Seleccione una opción del menú para comenzar.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 94);
            label3.Name = "label3";
            label3.Size = new Size(191, 15);
            label3.TabIndex = 0;
            label3.Text = "Sistema de Gestión de Bombonería";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 539);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(statusStrip1);
            Controls.Add(panelTop);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Label label1;
        private Label lblFecha;
        private Label label2;
        private Button btnLogout;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblUsuario;
        private Panel panelMenu;
        private Button btnVentas;
        private Button btnClientes;
        private Button btnCajas;
        private Button btnBombones;
        private Button btnTiposBombones;
        private Panel panelContent;
        private Label label4;
        private Label label3;
        private Button btnFormasDePago;
    }
}