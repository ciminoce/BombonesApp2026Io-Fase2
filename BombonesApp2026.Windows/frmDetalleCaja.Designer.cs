namespace BombonesApp2026.Windows
{
    partial class frmDetalleCaja
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
            btnCerrar = new Button();
            txtNombreCaja = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            txtPrecio = new TextBox();
            label5 = new Label();
            chkActivo = new CheckBox();
            label6 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1 = new Panel();
            dgvDatos = new DataGridView();
            txtStock = new TextBox();
            txtCantidadBombones = new TextBox();
            label1 = new Label();
            txtSurtida = new TextBox();
            colId = new DataGridViewTextBoxColumn();
            colBombon = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(447, 503);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 60);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtNombreCaja
            // 
            txtNombreCaja.Enabled = false;
            txtNombreCaja.Location = new Point(140, 28);
            txtNombreCaja.MaxLength = 100;
            txtNombreCaja.Name = "txtNombreCaja";
            txtNombreCaja.Size = new Size(334, 23);
            txtNombreCaja.TabIndex = 8;
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
            txtDescripcion.Enabled = false;
            txtDescripcion.Location = new Point(140, 57);
            txtDescripcion.MaxLength = 300;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(334, 54);
            txtDescripcion.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 461);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Enabled = false;
            txtPrecio.Location = new Point(129, 456);
            txtPrecio.MaxLength = 100;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(134, 23);
            txtPrecio.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 124);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 6;
            label5.Text = "Stock:";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Enabled = false;
            chkActivo.Location = new Point(414, 124);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 13;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 431);
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
            panel1.Controls.Add(dgvDatos);
            panel1.Location = new Point(9, 166);
            panel1.Name = "panel1";
            panel1.Size = new Size(527, 225);
            panel1.TabIndex = 14;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colBombon, colCantidad });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.Size = new Size(527, 225);
            dgvDatos.TabIndex = 1;
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(140, 120);
            txtStock.MaxLength = 100;
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(79, 23);
            txtStock.TabIndex = 8;
            // 
            // txtCantidadBombones
            // 
            txtCantidadBombones.Enabled = false;
            txtCantidadBombones.Location = new Point(129, 428);
            txtCantidadBombones.MaxLength = 100;
            txtCantidadBombones.Name = "txtCantidadBombones";
            txtCantidadBombones.Size = new Size(134, 23);
            txtCantidadBombones.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 490);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 6;
            label1.Text = "Surtida:";
            // 
            // txtSurtida
            // 
            txtSurtida.Enabled = false;
            txtSurtida.Location = new Point(129, 485);
            txtSurtida.MaxLength = 100;
            txtSurtida.Name = "txtSurtida";
            txtSurtida.Size = new Size(134, 23);
            txtSurtida.TabIndex = 8;
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
            // frmDetalleCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(572, 573);
            Controls.Add(panel1);
            Controls.Add(chkActivo);
            Controls.Add(btnCerrar);
            Controls.Add(txtDescripcion);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(txtCantidadBombones);
            Controls.Add(txtSurtida);
            Controls.Add(label1);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(txtStock);
            Controls.Add(txtNombreCaja);
            Controls.Add(label2);
            Name = "frmDetalleCaja";
            Text = "frmDetallesCaja";
            Load += frmDetalleCaja_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private TextBox txtNombreCaja;
        private Label label2;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private TextBox txtPrecio;
        private Label label5;
        private CheckBox chkActivo;
        private Label label6;
        private ErrorProvider errorProvider1;
        private Panel panel1;
        private DataGridView dgvDatos;
        private TextBox txtCantidadBombones;
        private TextBox txtStock;
        private TextBox txtSurtida;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colBombon;
        private DataGridViewTextBoxColumn colCantidad;
    }
}