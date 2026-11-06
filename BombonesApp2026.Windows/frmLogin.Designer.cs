namespace BombonesApp2026.Windows
{
    partial class frmLogin
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            txtClave = new TextBox();
            btnSalir = new Button();
            btnLogin = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.key_2_200px;
            pictureBox1.Location = new Point(40, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 37);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(262, 34);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(204, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "admin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 78);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 1;
            label2.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(262, 75);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(204, 23);
            txtClave.TabIndex = 1;
            txtClave.Text = "123456";
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.cancel_24px;
            btnSalir.Location = new Point(359, 122);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 60);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Cerrar";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnLogin
            // 
            btnLogin.Image = Properties.Resources.ok_24px;
            btnLogin.Location = new Point(190, 122);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(107, 60);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 228);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Controls.Add(txtClave);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            MaximumSize = new Size(552, 267);
            MinimumSize = new Size(552, 267);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtUsuario;
        private Label label2;
        private TextBox txtClave;
        private Button btnSalir;
        private Button btnLogin;
        private ErrorProvider errorProvider1;
    }
}