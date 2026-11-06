namespace BombonesApp2026.Windows
{
    partial class frmVentaAe
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
            pnlContenido = new Panel();
            groupBox1 = new GroupBox();
            txtProvincia = new TextBox();
            txtCiudad = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cboFormasDePago = new ComboBox();
            btnCancelar = new Button();
            btnOK = new Button();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioTotal = new DataGridViewTextBoxColumn();
            btnEditarProducto = new Button();
            btnBorrarProducto = new Button();
            btnAgregarProducto = new Button();
            cboClientes = new ComboBox();
            label6 = new Label();
            label3 = new Label();
            txtTotal = new TextBox();
            label4 = new Label();
            txtEstado = new TextBox();
            txtFechaVta = new TextBox();
            label8 = new Label();
            label7 = new Label();
            errorProvider1 = new ErrorProvider(components);
            pnlContenido.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlContenido
            // 
            pnlContenido.AutoScrollMinSize = new Size(572, 640);
            pnlContenido.Controls.Add(groupBox1);
            pnlContenido.Controls.Add(cboFormasDePago);
            pnlContenido.Controls.Add(btnCancelar);
            pnlContenido.Controls.Add(btnOK);
            pnlContenido.Controls.Add(splitContainer1);
            pnlContenido.Controls.Add(cboClientes);
            pnlContenido.Controls.Add(label6);
            pnlContenido.Controls.Add(label3);
            pnlContenido.Controls.Add(txtTotal);
            pnlContenido.Controls.Add(label4);
            pnlContenido.Controls.Add(txtEstado);
            pnlContenido.Controls.Add(txtFechaVta);
            pnlContenido.Controls.Add(label8);
            pnlContenido.Controls.Add(label7);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Margin = new Padding(0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(889, 595);
            pnlContenido.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtProvincia);
            groupBox1.Controls.Add(txtCiudad);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(32, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(486, 85);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = " Domicilio ";
            // 
            // txtProvincia
            // 
            txtProvincia.Enabled = false;
            txtProvincia.Location = new Point(332, 46);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.Size = new Size(136, 23);
            txtProvincia.TabIndex = 1;
            // 
            // txtCiudad
            // 
            txtCiudad.Enabled = false;
            txtCiudad.Location = new Point(81, 46);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(136, 23);
            txtCiudad.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(266, 49);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 0;
            label5.Text = "Provincia:";
            // 
            // txtDireccion
            // 
            txtDireccion.Enabled = false;
            txtDireccion.Location = new Point(81, 17);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(387, 23);
            txtDireccion.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 49);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 0;
            label2.Text = "Ciudad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Dirección:";
            // 
            // cboFormasDePago
            // 
            cboFormasDePago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormasDePago.FormattingEnabled = true;
            cboFormasDePago.Location = new Point(109, 446);
            cboFormasDePago.Name = "cboFormasDePago";
            cboFormasDePago.Size = new Size(168, 23);
            cboFormasDePago.TabIndex = 15;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(759, 486);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(28, 486);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 13;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 133);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnEditarProducto);
            splitContainer1.Panel2.Controls.Add(btnBorrarProducto);
            splitContainer1.Panel2.Controls.Add(btnAgregarProducto);
            splitContainer1.Size = new Size(889, 304);
            splitContainer1.SplitterDistance = 686;
            splitContainer1.TabIndex = 12;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colProducto, colPrecio, colCantidad, colPrecioTotal });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(686, 304);
            dgvDatos.TabIndex = 2;
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
            // btnEditarProducto
            // 
            btnEditarProducto.Image = Properties.Resources.edit_property_24px;
            btnEditarProducto.Location = new Point(32, 176);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(134, 60);
            btnEditarProducto.TabIndex = 10;
            btnEditarProducto.Text = "Editar Cantidad";
            btnEditarProducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarProducto.UseVisualStyleBackColor = true;
            btnEditarProducto.Click += btnEditarProducto_Click;
            // 
            // btnBorrarProducto
            // 
            btnBorrarProducto.Image = Properties.Resources.cancel_24px;
            btnBorrarProducto.Location = new Point(32, 101);
            btnBorrarProducto.Name = "btnBorrarProducto";
            btnBorrarProducto.Size = new Size(134, 60);
            btnBorrarProducto.TabIndex = 11;
            btnBorrarProducto.Text = "Quitar Producto";
            btnBorrarProducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBorrarProducto.UseVisualStyleBackColor = true;
            btnBorrarProducto.Click += btnBorrarProducto_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Image = Properties.Resources.ok_24px;
            btnAgregarProducto.Location = new Point(32, 26);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(134, 60);
            btnAgregarProducto.TabIndex = 12;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(85, 12);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(432, 23);
            cboClientes.TabIndex = 11;
            cboClientes.SelectedIndexChanged += cboClientes_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 449);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 6;
            label6.Text = "Forma de Pago:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 15);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 6;
            label3.Text = "Cliente:";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Location = new Point(585, 443);
            txtTotal.MaxLength = 100;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(101, 23);
            txtTotal.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(511, 446);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "Total Vta:";
            // 
            // txtEstado
            // 
            txtEstado.Enabled = false;
            txtEstado.Location = new Point(731, 56);
            txtEstado.MaxLength = 100;
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(112, 23);
            txtEstado.TabIndex = 8;
            // 
            // txtFechaVta
            // 
            txtFechaVta.Enabled = false;
            txtFechaVta.Location = new Point(731, 29);
            txtFechaVta.MaxLength = 100;
            txtFechaVta.Name = "txtFechaVta";
            txtFechaVta.Size = new Size(112, 23);
            txtFechaVta.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(666, 59);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 6;
            label8.Text = "Estado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(666, 32);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "Fecha:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmVentaAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(889, 595);
            Controls.Add(pnlContenido);
            Name = "frmVentaAe";
            Text = "frmVentaAe";
            Load += frmVentaAe_Load;
            pnlContenido.ResumeLayout(false);
            pnlContenido.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContenido;
        private Label label6;
        private Label label3;
        private TextBox txtTotal;
        private Label label4;
        private TextBox txtEstado;
        private TextBox txtFechaVta;
        private Label label8;
        private Label label7;
        private ComboBox cboClientes;
        private SplitContainer splitContainer1;
        private Button btnEditarProducto;
        private Button btnBorrarProducto;
        private Button btnAgregarProducto;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioTotal;
        private ComboBox cboFormasDePago;
        private Button btnCancelar;
        private Button btnOK;
        private GroupBox groupBox1;
        private TextBox txtProvincia;
        private TextBox txtCiudad;
        private Label label5;
        private TextBox txtDireccion;
        private Label label2;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}