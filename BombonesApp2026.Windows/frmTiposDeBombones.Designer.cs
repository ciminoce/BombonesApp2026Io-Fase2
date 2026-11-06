namespace BombonesApp2026.Windows
{
    partial class frmTiposDeBombones
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripDropDownButton();
            activosToolStripMenuItem = new ToolStripMenuItem();
            noActivosToolStripMenuItem = new ToolStripMenuItem();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas = new Label();
            lblCantidad = new Label();
            label2 = new Label();
            label1 = new Label();
            toolStripLabel1 = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, toolStripSeparator1, tsbFiltrar, toolStripLabel1, txtBuscar, tsbBuscar, tsbActualizar, toolStripSeparator2, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 70);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = Properties.Resources.new_file_48px;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(52, 67);
            tsbNuevo.Text = "&Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = Properties.Resources.delete_file_48px;
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(52, 67);
            tsbBorrar.Text = "&Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = Properties.Resources.edit_file_48px;
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(52, 67);
            tsbEditar.Text = "&Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { activosToolStripMenuItem, noActivosToolStripMenuItem });
            tsbFiltrar.Image = Properties.Resources.filled_filter_48px;
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(61, 67);
            tsbFiltrar.Text = "&Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // activosToolStripMenuItem
            // 
            activosToolStripMenuItem.Name = "activosToolStripMenuItem";
            activosToolStripMenuItem.Size = new Size(132, 22);
            activosToolStripMenuItem.Text = "Activos";
            activosToolStripMenuItem.Click += activosToolStripMenuItem_Click;
            // 
            // noActivosToolStripMenuItem
            // 
            noActivosToolStripMenuItem.Name = "noActivosToolStripMenuItem";
            noActivosToolStripMenuItem.Size = new Size(132, 22);
            noActivosToolStripMenuItem.Text = "No Activos";
            noActivosToolStripMenuItem.Click += noActivosToolStripMenuItem_Click;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = Properties.Resources.restart_48px;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(63, 67);
            tsbActualizar.Text = "&Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
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
            tsbCerrar.Text = "&Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 70);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Panel2.Controls.Add(lblPaginas);
            splitContainer1.Panel2.Controls.Add(lblCantidad);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(800, 380);
            splitContainer1.SplitterDistance = 321;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion, colActivo });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 321);
            dgvDatos.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "TipoBombonId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Tipo de Bombón";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo";
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(659, 10);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(41, 38);
            btnUltimo.TabIndex = 2;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(612, 10);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(41, 38);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(565, 10);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(41, 38);
            btnAnterior.TabIndex = 2;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(518, 10);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(41, 38);
            btnPrimero.TabIndex = 2;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaginas.Location = new Point(163, 31);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(14, 15);
            lblPaginas.TabIndex = 1;
            lblPaginas.Text = "0";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(163, 10);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(14, 15);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 31);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 0;
            label2.Text = "Cantidad de Páginas:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 10);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 0;
            label1.Text = "Cantidad de Registros:";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(45, 67);
            toolStripLabel1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(150, 70);
            // 
            // tsbBuscar
            // 
            tsbBuscar.Image = Properties.Resources.search_property_48px;
            tsbBuscar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBuscar.ImageTransparentColor = Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(52, 67);
            tsbBuscar.Text = "B&uscar";
            tsbBuscar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // frmTiposDeBombones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "frmTiposDeBombones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmTipoBombones";
            Load += frmTiposDeBombones_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Label lblCantidad;
        private Label label1;
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem activosToolStripMenuItem;
        private ToolStripMenuItem noActivosToolStripMenuItem;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas;
        private Label label2;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewCheckBoxColumn colActivo;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
    }
}