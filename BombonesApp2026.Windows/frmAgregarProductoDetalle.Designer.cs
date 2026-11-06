namespace BombonesApp2026.Windows
{
    partial class frmAgregarProductoDetalle
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
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colDetalle = new DataGridViewButtonColumn();
            groupBox1 = new GroupBox();
            btnCancelar = new Button();
            btnOK = new Button();
            nudCantidad = new NumericUpDown();
            label3 = new Label();
            txtPrecioTotal = new TextBox();
            label4 = new Label();
            txtPrecioUnitario = new TextBox();
            label2 = new Label();
            txtProducto = new TextBox();
            label1 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label7 = new Label();
            comboBox1 = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 91);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(800, 674);
            splitContainer1.SplitterDistance = 367;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colTipo, colNombre, colStock, colPrecio, colDetalle });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(800, 367);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellClick += dgvDatos_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "ProductoId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTipo.DataPropertyName = "TipoProducto";
            colTipo.HeaderText = "Tipo de de Producto";
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 127;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colStock
            // 
            colStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colStock.DataPropertyName = "Stock";
            colStock.HeaderText = "Stock";
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colStock.Width = 61;
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colPrecio.DataPropertyName = "Precio";
            colPrecio.HeaderText = "Precio";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 65;
            // 
            // colDetalle
            // 
            colDetalle.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDetalle.HeaderText = "Ver Detalle";
            colDetalle.Name = "colDetalle";
            colDetalle.ReadOnly = true;
            colDetalle.Width = 61;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnOK);
            groupBox1.Controls.Add(nudCantidad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPrecioTotal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtPrecioUnitario);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtProducto);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(17, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 129);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = " Selección ";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(525, 26);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(424, 26);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 11;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(293, 55);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(95, 23);
            nudCantidad.TabIndex = 2;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 56);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 0;
            label3.Text = "Cantidad:";
            // 
            // txtPrecioTotal
            // 
            txtPrecioTotal.Location = new Point(90, 80);
            txtPrecioTotal.Name = "txtPrecioTotal";
            txtPrecioTotal.Size = new Size(84, 23);
            txtPrecioTotal.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 84);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 0;
            label4.Text = "Precio: Total:";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(90, 51);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(84, 23);
            txtPrecioUnitario.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 55);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 0;
            label2.Text = "Precio Unit.:";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(90, 22);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(298, 23);
            txtProducto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 26);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Producto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 13);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 1;
            label6.Text = "Producto:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(305, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(472, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 49);
            label7.Name = "label7";
            label7.Size = new Size(85, 15);
            label7.TabIndex = 1;
            label7.Text = "Tipo Producto:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(117, 47);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(305, 23);
            comboBox1.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAgregarProductoDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 604);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(splitContainer1);
            Name = "frmAgregarProductoDetalle";
            Text = "frmAgregarProductoDetalle";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private GroupBox groupBox1;
        private Label label1;
        private NumericUpDown nudCantidad;
        private Label label3;
        private TextBox txtPrecioTotal;
        private Label label4;
        private TextBox txtPrecioUnitario;
        private Label label2;
        private TextBox txtProducto;
        private Button btnCancelar;
        private Button btnOK;
        private Label label6;
        private TextBox textBox1;
        private Button button1;
        private Label label7;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewButtonColumn colDetalle;
        private ErrorProvider errorProvider1;
    }
}