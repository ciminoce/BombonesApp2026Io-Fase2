namespace BombonesApp2026.Windows
{
    partial class frmDetalleBombon
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
            groupBox1 = new GroupBox();
            txtDescripcion = new TextBox();
            btnCerrar = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Location = new Point(41, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(578, 139);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = " Descripción ";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(10, 20);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(557, 100);
            txtDescripcion.TabIndex = 0;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(544, 207);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 60);
            btnCerrar.TabIndex = 11;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleBombon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 285);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(groupBox1);
            MaximumSize = new Size(680, 324);
            MinimumSize = new Size(680, 324);
            Name = "frmDetalleBombon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDetalleBombon";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtDescripcion;
        private Button btnCerrar;
    }
}