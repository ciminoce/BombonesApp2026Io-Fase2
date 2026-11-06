namespace BombonesApp2026.Windows
{
    partial class frmVentas
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbFacturar = new ToolStripButton();
            tsbAnular = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbDetalles = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            panelNavegacion = new Panel();
            lblPaginas = new Label();
            label1 = new Label();
            btnUltimo = new Button();
            btnPrimero = new Button();
            lblCantidad = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            label2 = new Label();
            panelGrilla = new Panel();
            dgvDatos = new DataGridView();
            colVentaId = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            panelNavegacion.SuspendLayout();
            panelGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbFacturar, tsbAnular, toolStripSeparator1, tsbDetalles, toolStripSeparator5, tsbFiltrar, tsbActualizar, toolStripSeparator2, tsbCerrar, toolStripSeparator4 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 70);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = Properties.Resources.new_file_48px;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(52, 67);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbFacturar
            // 
            tsbFacturar.Image = Properties.Resources.invoice_48px;
            tsbFacturar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFacturar.ImageTransparentColor = Color.Magenta;
            tsbFacturar.Name = "tsbFacturar";
            tsbFacturar.Size = new Size(54, 67);
            tsbFacturar.Text = "Facturar";
            tsbFacturar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFacturar.Click += tsbFacturar_Click;
            // 
            // tsbAnular
            // 
            tsbAnular.Image = Properties.Resources.delete_file_48px;
            tsbAnular.ImageScaling = ToolStripItemImageScaling.None;
            tsbAnular.ImageTransparentColor = Color.Magenta;
            tsbAnular.Name = "tsbAnular";
            tsbAnular.Size = new Size(52, 67);
            tsbAnular.Text = "Anular";
            tsbAnular.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAnular.Click += tsbAnular_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
            // 
            // tsbDetalles
            // 
            tsbDetalles.Image = Properties.Resources.details_48px;
            tsbDetalles.ImageScaling = ToolStripItemImageScaling.None;
            tsbDetalles.ImageTransparentColor = Color.Magenta;
            tsbDetalles.Name = "tsbDetalles";
            tsbDetalles.Size = new Size(52, 67);
            tsbDetalles.Text = "Detalles";
            tsbDetalles.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDetalles.Click += tsbDetalles_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.Image = Properties.Resources.filter_48px;
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(52, 67);
            tsbFiltrar.Text = "Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = Properties.Resources.restart_48px;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(63, 67);
            tsbActualizar.Text = "Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 70);
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = Properties.Resources.close_pane_48px;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(52, 67);
            tsbCerrar.Text = "Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 70);
            // 
            // panelNavegacion
            // 
            panelNavegacion.Controls.Add(lblPaginas);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Controls.Add(btnUltimo);
            panelNavegacion.Controls.Add(btnPrimero);
            panelNavegacion.Controls.Add(lblCantidad);
            panelNavegacion.Controls.Add(btnAnterior);
            panelNavegacion.Controls.Add(btnSiguiente);
            panelNavegacion.Controls.Add(label2);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 350);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(800, 100);
            panelNavegacion.TabIndex = 7;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaginas.Location = new Point(153, 52);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(14, 15);
            lblPaginas.TabIndex = 28;
            lblPaginas.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 31);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 27;
            label1.Text = "Cantidad de Registros:";
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(736, 31);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(42, 38);
            btnUltimo.TabIndex = 22;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(592, 31);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(42, 38);
            btnPrimero.TabIndex = 26;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(153, 31);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(14, 15);
            lblCantidad.TabIndex = 29;
            lblCantidad.Text = "0";
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(640, 31);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(42, 38);
            btnAnterior.TabIndex = 25;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(688, 31);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(42, 38);
            btnSiguiente.TabIndex = 23;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 52);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 24;
            label2.Text = "Cantidad de Páginas:";
            // 
            // panelGrilla
            // 
            panelGrilla.Controls.Add(dgvDatos);
            panelGrilla.Dock = DockStyle.Fill;
            panelGrilla.Location = new Point(0, 70);
            panelGrilla.Name = "panelGrilla";
            panelGrilla.Size = new Size(800, 280);
            panelGrilla.TabIndex = 8;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colVentaId, colCliente, colFecha, colTotal });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 280);
            dgvDatos.TabIndex = 1;
            // 
            // colVentaId
            // 
            colVentaId.DataPropertyName = "VentaId";
            colVentaId.HeaderText = "Vta. Nro.";
            colVentaId.Name = "colVentaId";
            colVentaId.ReadOnly = true;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaVenta";
            colFecha.HeaderText = "Fecha Vta.";
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTotal.DefaultCellStyle = dataGridViewCellStyle4;
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelGrilla);
            Controls.Add(panelNavegacion);
            Controls.Add(toolStrip1);
            Name = "frmVentas";
            Text = "frmVentas";
            Load += frmVentas_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panelNavegacion.ResumeLayout(false);
            panelNavegacion.PerformLayout();
            panelGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbAnular;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbFiltrar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbCerrar;
        private ToolStripButton tsbDetalles;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator4;
        private Panel panelNavegacion;
        private Panel panelGrilla;
        private DataGridView dgvDatos;
        private Label lblPaginas;
        private Label label1;
        private Button btnUltimo;
        private Button btnPrimero;
        private Label lblCantidad;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Label label2;
        private ToolStripButton tsbFacturar;
        private DataGridViewTextBoxColumn colVentaId;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTotal;
    }
}