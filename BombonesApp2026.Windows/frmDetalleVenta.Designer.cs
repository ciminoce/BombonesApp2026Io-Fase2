namespace BombonesApp2026.Windows
{
    partial class frmDetalleVenta
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
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            layoutPrincipal = new TableLayoutPanel();
            pnlContenido = new Panel();
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioTotal = new DataGridViewTextBoxColumn();
            btnCerrar = new Button();
            label6 = new Label();
            label3 = new Label();
            txtFormaDePago = new TextBox();
            txtPrecio = new TextBox();
            label4 = new Label();
            txtCliente = new TextBox();
            txtEstado = new TextBox();
            txtFechaVta = new TextBox();
            txtVentaId = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            layoutPrincipal.SuspendLayout();
            pnlContenido.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // layoutPrincipal
            // 
            layoutPrincipal.ColumnCount = 1;
            layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPrincipal.Controls.Add(pnlContenido, 0, 0);
            layoutPrincipal.Dock = DockStyle.Fill;
            layoutPrincipal.Location = new Point(0, 0);
            layoutPrincipal.Margin = new Padding(0);
            layoutPrincipal.Name = "layoutPrincipal";
            layoutPrincipal.RowCount = 2;
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            layoutPrincipal.Size = new Size(876, 561);
            layoutPrincipal.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.AutoScroll = true;
            pnlContenido.AutoScrollMinSize = new Size(572, 640);
            pnlContenido.Controls.Add(panel1);
            pnlContenido.Controls.Add(btnCerrar);
            pnlContenido.Controls.Add(label6);
            pnlContenido.Controls.Add(label3);
            pnlContenido.Controls.Add(txtFormaDePago);
            pnlContenido.Controls.Add(txtPrecio);
            pnlContenido.Controls.Add(label4);
            pnlContenido.Controls.Add(txtCliente);
            pnlContenido.Controls.Add(txtEstado);
            pnlContenido.Controls.Add(txtFechaVta);
            pnlContenido.Controls.Add(txtVentaId);
            pnlContenido.Controls.Add(label8);
            pnlContenido.Controls.Add(label7);
            pnlContenido.Controls.Add(label2);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Margin = new Padding(0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(876, 465);
            pnlContenido.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvDatos);
            panel1.Location = new Point(35, 117);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 225);
            panel1.TabIndex = 14;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colProducto, colPrecio, colCantidad, colPrecioTotal });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.Size = new Size(786, 225);
            dgvDatos.TabIndex = 1;
            // 
            // colId
            // 
            colId.DataPropertyName = "ProductoId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colProducto
            // 
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProducto.DataPropertyName = "Producto";
            colProducto.HeaderText = "Bombón";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "Precio";
            colPrecio.HeaderText = "Precio Unit.";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 80;
            // 
            // colPrecioTotal
            // 
            colPrecioTotal.DataPropertyName = "Subtotal";
            colPrecioTotal.HeaderText = "Precio Tot.";
            colPrecioTotal.Name = "colPrecioTotal";
            colPrecioTotal.ReadOnly = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(746, 391);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 60);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 351);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 6;
            label6.Text = "Forma de Pago:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 30);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Cliente:";
            // 
            // txtFormaDePago
            // 
            txtFormaDePago.Enabled = false;
            txtFormaDePago.Location = new Point(188, 349);
            txtFormaDePago.MaxLength = 100;
            txtFormaDePago.Name = "txtFormaDePago";
            txtFormaDePago.Size = new Size(134, 23);
            txtFormaDePago.TabIndex = 8;
            // 
            // txtPrecio
            // 
            txtPrecio.Enabled = false;
            txtPrecio.Location = new Point(720, 348);
            txtPrecio.MaxLength = 100;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(101, 23);
            txtPrecio.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(578, 353);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "Total Vta:";
            // 
            // txtCliente
            // 
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(88, 25);
            txtCliente.MaxLength = 100;
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(511, 23);
            txtCliente.TabIndex = 8;
            // 
            // txtEstado
            // 
            txtEstado.Enabled = false;
            txtEstado.Location = new Point(738, 75);
            txtEstado.MaxLength = 100;
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(83, 23);
            txtEstado.TabIndex = 8;
            // 
            // txtFechaVta
            // 
            txtFechaVta.Enabled = false;
            txtFechaVta.Location = new Point(738, 48);
            txtFechaVta.MaxLength = 100;
            txtFechaVta.Name = "txtFechaVta";
            txtFechaVta.Size = new Size(83, 23);
            txtFechaVta.TabIndex = 8;
            // 
            // txtVentaId
            // 
            txtVentaId.Enabled = false;
            txtVentaId.Location = new Point(738, 22);
            txtVentaId.MaxLength = 100;
            txtVentaId.Name = "txtVentaId";
            txtVentaId.Size = new Size(83, 23);
            txtVentaId.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(644, 78);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 6;
            label8.Text = "Estado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(644, 51);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "Fecha:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(644, 25);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Venta Nro:";
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 561);
            Controls.Add(layoutPrincipal);
            MinimumSize = new Size(588, 600);
            Name = "frmDetalleVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDetallesCaja";
            Load += frmDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            layoutPrincipal.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutPrincipal;
        private ErrorProvider errorProvider1;
        private Panel pnlContenido;
        private Panel panel1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioTotal;
        private Button btnCerrar;
        private Label label6;
        private Label label3;
        private TextBox txtFormaDePago;
        private TextBox txtPrecio;
        private Label label4;
        private TextBox txtCliente;
        private TextBox txtEstado;
        private TextBox txtFechaVta;
        private TextBox txtVentaId;
        private Label label8;
        private Label label7;
        private Label label2;
    }
}