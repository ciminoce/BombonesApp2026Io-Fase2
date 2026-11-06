namespace BombonesApp2026.Windows
{
    partial class frmCajaAe
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
            btnCancelar = new Button();
            btnOK = new Button();
            txtNombreCaja = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            txtPrecio = new TextBox();
            label5 = new Label();
            nudStock = new NumericUpDown();
            chkActivo = new CheckBox();
            label6 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colBombon = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            btnEditarBombon = new Button();
            btnEliminarBombon = new Button();
            btnAgregarBombon = new Button();
            txtCantidadBombones = new TextBox();
            txtSurtida = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(618, 521);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(24, 521);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtNombreCaja
            // 
            txtNombreCaja.Location = new Point(140, 28);
            txtNombreCaja.MaxLength = 100;
            txtNombreCaja.Name = "txtNombreCaja";
            txtNombreCaja.Size = new Size(334, 23);
            txtNombreCaja.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 31);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre Caja:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 60);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(140, 57);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(334, 98);
            txtDescripcion.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 423);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Enabled = false;
            txtPrecio.Location = new Point(133, 418);
            txtPrecio.MaxLength = 100;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(134, 23);
            txtPrecio.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(482, 32);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 6;
            label5.Text = "Stock:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(542, 28);
            nudStock.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(134, 23);
            nudStock.TabIndex = 1;
            nudStock.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(484, 80);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 13;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 451);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 6;
            label6.Text = "Cant. Bombones:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(splitContainer1);
            panel1.Location = new Point(9, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 240);
            panel1.TabIndex = 14;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnEditarBombon);
            splitContainer1.Panel2.Controls.Add(btnEliminarBombon);
            splitContainer1.Panel2.Controls.Add(btnAgregarBombon);
            splitContainer1.Size = new Size(682, 238);
            splitContainer1.SplitterDistance = 533;
            splitContainer1.TabIndex = 0;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colBombon, colCantidad });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(533, 238);
            dgvDatos.TabIndex = 0;
            // 
            // colId
            // 
            colId.DataPropertyName = "BombonId";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colBombon
            // 
            colBombon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBombon.DataPropertyName = "NombreBombon";
            colBombon.HeaderText = "Bombón";
            colBombon.Name = "colBombon";
            colBombon.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colCantidad.DataPropertyName = "CantidadBombon";
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 80;
            // 
            // btnEditarBombon
            // 
            btnEditarBombon.Image = Properties.Resources.edit_property_24px;
            btnEditarBombon.Location = new Point(16, 147);
            btnEditarBombon.Name = "btnEditarBombon";
            btnEditarBombon.Size = new Size(112, 60);
            btnEditarBombon.TabIndex = 2;
            btnEditarBombon.Text = "Editar Bombón";
            btnEditarBombon.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarBombon.UseVisualStyleBackColor = true;
            btnEditarBombon.Click += btnEditarBombon_Click;
            // 
            // btnEliminarBombon
            // 
            btnEliminarBombon.Image = Properties.Resources.cancel_24px;
            btnEliminarBombon.Location = new Point(16, 81);
            btnEliminarBombon.Name = "btnEliminarBombon";
            btnEliminarBombon.Size = new Size(112, 60);
            btnEliminarBombon.TabIndex = 1;
            btnEliminarBombon.Text = "Eliminar Bombón";
            btnEliminarBombon.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEliminarBombon.UseVisualStyleBackColor = true;
            btnEliminarBombon.Click += btnEliminarBombon_Click;
            // 
            // btnAgregarBombon
            // 
            btnAgregarBombon.Image = Properties.Resources.ok_24px;
            btnAgregarBombon.Location = new Point(16, 15);
            btnAgregarBombon.Name = "btnAgregarBombon";
            btnAgregarBombon.Size = new Size(112, 60);
            btnAgregarBombon.TabIndex = 0;
            btnAgregarBombon.Text = "Agregar Bombón";
            btnAgregarBombon.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarBombon.UseVisualStyleBackColor = true;
            btnAgregarBombon.Click += btnAgregarBombon_Click;
            // 
            // txtCantidadBombones
            // 
            txtCantidadBombones.Enabled = false;
            txtCantidadBombones.Location = new Point(133, 447);
            txtCantidadBombones.MaxLength = 100;
            txtCantidadBombones.Name = "txtCantidadBombones";
            txtCantidadBombones.Size = new Size(134, 23);
            txtCantidadBombones.TabIndex = 8;
            // 
            // txtSurtida
            // 
            txtSurtida.Enabled = false;
            txtSurtida.Location = new Point(133, 476);
            txtSurtida.MaxLength = 100;
            txtSurtida.Name = "txtSurtida";
            txtSurtida.Size = new Size(134, 23);
            txtSurtida.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 480);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 6;
            label1.Text = "¿Es surtida?";
            // 
            // frmCajaAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(712, 612);
            Controls.Add(panel1);
            Controls.Add(chkActivo);
            Controls.Add(nudStock);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtDescripcion);
            Controls.Add(label1);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(txtSurtida);
            Controls.Add(txtCantidadBombones);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(txtNombreCaja);
            Controls.Add(label2);
            Name = "frmCajaAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCajaAe";
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnOK;
        private TextBox txtNombreCaja;
        private Label label2;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private TextBox txtPrecio;
        private Label label5;
        private NumericUpDown nudStock;
        private CheckBox chkActivo;
        private Label label6;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private Button btnAgregarBombon;
        private Button btnEliminarBombon;
        private Button btnEditarBombon;
        private Label label1;
        private TextBox txtSurtida;
        private TextBox txtCantidadBombones;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colBombon;
        private DataGridViewTextBoxColumn colCantidad;
    }
}