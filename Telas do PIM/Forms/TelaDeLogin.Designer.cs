namespace Telas_do_PIM
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 36);
            label1.Name = "label1";
            label1.Size = new Size(539, 84);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            label1.UseCompatibleTextRendering = true;
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 189);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 269);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Senha";
            // 
            // TxtUsuario
            // 
            TxtUsuario.Location = new Point(85, 207);
            TxtUsuario.Name = "TxtUsuario";
            TxtUsuario.Size = new Size(100, 23);
            TxtUsuario.TabIndex = 3;
            TxtUsuario.Text = "Usuário...";
            TxtUsuario.TextChanged += TxtUser_TextChanged;
            // 
            // TxtSenha
            // 
            TxtSenha.Location = new Point(85, 296);
            TxtSenha.Name = "TxtSenha";
            TxtSenha.Size = new Size(100, 23);
            TxtSenha.TabIndex = 4;
            TxtSenha.Text = "Senha...";
            TxtSenha.TextChanged += TxtSenha_TextChanged;
            // 
            // BtnEntrar
            // 
            BtnEntrar.Location = new Point(246, 368);
            BtnEntrar.Name = "BtnEntrar";
            BtnEntrar.Size = new Size(75, 23);
            BtnEntrar.TabIndex = 5;
            BtnEntrar.Text = "Entrar";
            BtnEntrar.UseVisualStyleBackColor = true;
            BtnEntrar.Click += BtnEntrar_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(191, 296);
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
            pictureBoxHidePassword.Location = new Point(191, 296);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(22, 23);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 7;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // TelaDeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 625);
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
    }
}
