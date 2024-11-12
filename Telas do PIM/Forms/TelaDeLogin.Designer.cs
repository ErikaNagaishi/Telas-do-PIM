namespace Telas_do_PIM.Forms
{
    partial class TelaDeLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaDeLogin));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            TxtUsuario = new TextBox();
            TxtSenha = new TextBox();
            BtnEntrar = new Button();
            pictureBoxShowPassword = new PictureBox();
            pictureBoxHidePassword = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(81, 56);
            label1.Name = "label1";
            label1.Size = new Size(312, 50);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F);
            label2.Location = new Point(104, 180);
            label2.Name = "label2";
            label2.Size = new Size(63, 18);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F);
            label3.Location = new Point(104, 243);
            label3.Name = "label3";
            label3.Size = new Size(51, 18);
            label3.TabIndex = 2;
            label3.Text = "Senha";
            // 
            // TxtUsuario
            // 
            TxtUsuario.Font = new Font("Georgia", 12F);
            TxtUsuario.Location = new Point(104, 201);
            TxtUsuario.Name = "TxtUsuario";
            TxtUsuario.PlaceholderText = "Usuário...";
            TxtUsuario.Size = new Size(252, 26);
            TxtUsuario.TabIndex = 3;
            // 
            // TxtSenha
            // 
            TxtSenha.Font = new Font("Georgia", 12F);
            TxtSenha.Location = new Point(104, 264);
            TxtSenha.Name = "TxtSenha";
            TxtSenha.PasswordChar = '*';
            TxtSenha.PlaceholderText = "Senha...";
            TxtSenha.Size = new Size(252, 26);
            TxtSenha.TabIndex = 4;
            // 
            // BtnEntrar
            // 
            BtnEntrar.BackColor = Color.SeaGreen;
            BtnEntrar.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEntrar.ForeColor = Color.Snow;
            BtnEntrar.Location = new Point(104, 311);
            BtnEntrar.Name = "BtnEntrar";
            BtnEntrar.Size = new Size(252, 35);
            BtnEntrar.TabIndex = 5;
            BtnEntrar.Text = "Entrar";
            BtnEntrar.UseVisualStyleBackColor = false;
            BtnEntrar.Click += BtnEntrar_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(367, 264);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(22, 23);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 6;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(367, 264);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(22, 23);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 7;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(504, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 540);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // TelaDeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 537);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxHidePassword);
            Controls.Add(pictureBoxShowPassword);
            Controls.Add(BtnEntrar);
            Controls.Add(TxtSenha);
            Controls.Add(TxtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaDeLogin";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TxtUsuario;
        private TextBox TxtSenha;
        private Button BtnEntrar;
        private PictureBox pictureBoxShowPassword;
        private PictureBox pictureBoxHidePassword;
        private PictureBox pictureBox1;
    }
}
