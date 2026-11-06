namespace BombonesApp2026.Windows
{
    partial class frmBombonAe
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
            cboTipoBombon = new ComboBox();
            btnCancelar = new Button();
            btnOK = new Button();
            txtNombreBombon = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtDescripcion = new TextBox();
            label4 = new Label();
            txtPrecio = new TextBox();
            label5 = new Label();
            nudStock = new NumericUpDown();
            chkTieneAzucar = new CheckBox();
            chkActivo = new CheckBox();
            label6 = new Label();
            nudPesoEnGramos = new NumericUpDown();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoEnGramos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboTipoBombon
            // 
            cboTipoBombon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoBombon.FormattingEnabled = true;
            cboTipoBombon.Location = new Point(140, 161);
            cboTipoBombon.Name = "cboTipoBombon";
            cboTipoBombon.Size = new Size(334, 23);
            cboTipoBombon.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(399, 325);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(31, 325);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtNombreBombon
            // 
            txtNombreBombon.Location = new Point(140, 28);
            txtNombreBombon.MaxLength = 100;
            txtNombreBombon.Name = "txtNombreBombon";
            txtNombreBombon.Size = new Size(334, 23);
            txtNombreBombon.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 31);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 6;
            label2.Text = "Nombre Bombón:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 164);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 7;
            label1.Text = "Tipo de Bombón:";
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
            txtDescripcion.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 195);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(140, 190);
            txtPrecio.MaxLength = 100;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(134, 23);
            txtPrecio.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 225);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 6;
            label5.Text = "Stock:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(140, 221);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(134, 23);
            nudStock.TabIndex = 4;
            // 
            // chkTieneAzucar
            // 
            chkTieneAzucar.AutoSize = true;
            chkTieneAzucar.CheckAlign = ContentAlignment.MiddleRight;
            chkTieneAzucar.Location = new Point(140, 287);
            chkTieneAzucar.Name = "chkTieneAzucar";
            chkTieneAzucar.Size = new Size(101, 19);
            chkTieneAzucar.TabIndex = 6;
            chkTieneAzucar.Text = "¿Tiene azucar?";
            chkTieneAzucar.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(373, 287);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 254);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 6;
            label6.Text = "Peso (en grs.):";
            // 
            // nudPesoEnGramos
            // 
            nudPesoEnGramos.Location = new Point(140, 250);
            nudPesoEnGramos.Name = "nudPesoEnGramos";
            nudPesoEnGramos.Size = new Size(134, 23);
            nudPesoEnGramos.TabIndex = 5;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmBombonAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 407);
            Controls.Add(chkActivo);
            Controls.Add(chkTieneAzucar);
            Controls.Add(nudPesoEnGramos);
            Controls.Add(nudStock);
            Controls.Add(cboTipoBombon);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtDescripcion);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(txtPrecio);
            Controls.Add(label4);
            Controls.Add(txtNombreBombon);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmBombonAe";
            Text = "frmBombonAe";
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPesoEnGramos).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTipoBombon;
        private Button btnCancelar;
        private Button btnOK;
        private TextBox txtNombreBombon;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtDescripcion;
        private Label label4;
        private TextBox txtPrecio;
        private Label label5;
        private NumericUpDown nudStock;
        private CheckBox chkTieneAzucar;
        private CheckBox chkActivo;
        private Label label6;
        private NumericUpDown nudPesoEnGramos;
        private ErrorProvider errorProvider1;
    }
}