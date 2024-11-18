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
            btnCadastrar = new Button();
            linkEsqueceuSenha = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(93, 75);
            label1.Name = "label1";
            label1.Size = new Size(390, 62);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 12F);
            label2.Location = new Point(119, 240);
            label2.Name = "label2";
            label2.Size = new Size(81, 24);
            label2.TabIndex = 1;
            label2.Text = "Usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 12F);
            label3.Location = new Point(119, 324);
            label3.Name = "label3";
            label3.Size = new Size(65, 24);
            label3.TabIndex = 2;
            label3.Text = "Senha";
            // 
            // TxtUsuario
            // 
            TxtUsuario.Font = new Font("Georgia", 12F);
            TxtUsuario.Location = new Point(119, 268);
            TxtUsuario.Margin = new Padding(3, 4, 3, 4);
            TxtUsuario.MaxLength = 100;
            TxtUsuario.Name = "TxtUsuario";
            TxtUsuario.PlaceholderText = "Usuário...";
            TxtUsuario.Size = new Size(287, 30);
            TxtUsuario.TabIndex = 3;
            // 
            // TxtSenha
            // 
            TxtSenha.Font = new Font("Georgia", 12F);
            TxtSenha.Location = new Point(119, 352);
            TxtSenha.Margin = new Padding(3, 4, 3, 4);
            TxtSenha.MaxLength = 20;
            TxtSenha.Name = "TxtSenha";
            TxtSenha.PasswordChar = '*';
            TxtSenha.PlaceholderText = "Senha...";
            TxtSenha.Size = new Size(287, 30);
            TxtSenha.TabIndex = 4;
            // 
            // BtnEntrar
            // 
            BtnEntrar.BackColor = Color.SeaGreen;
            BtnEntrar.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnEntrar.ForeColor = Color.Snow;
            BtnEntrar.Location = new Point(119, 438);
            BtnEntrar.Margin = new Padding(3, 4, 3, 4);
            BtnEntrar.Name = "BtnEntrar";
            BtnEntrar.Size = new Size(288, 47);
            BtnEntrar.TabIndex = 5;
            BtnEntrar.Text = "Entrar";
            BtnEntrar.UseVisualStyleBackColor = false;
            BtnEntrar.Click += BtnEntrar_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(419, 352);
            pictureBoxShowPassword.Margin = new Padding(3, 4, 3, 4);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(25, 31);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 6;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(419, 352);
            pictureBoxHidePassword.Margin = new Padding(3, 4, 3, 4);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(25, 31);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 7;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(576, -3);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(469, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.SeaGreen;
            btnCadastrar.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCadastrar.ForeColor = Color.Snow;
            btnCadastrar.Location = new Point(119, 505);
            btnCadastrar.Margin = new Padding(3, 4, 3, 4);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(288, 47);
            btnCadastrar.TabIndex = 30;
            btnCadastrar.Text = "Cadastre-se";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // linkEsqueceuSenha
            // 
            linkEsqueceuSenha.AutoSize = true;
            linkEsqueceuSenha.Location = new Point(119, 386);
            linkEsqueceuSenha.Name = "linkEsqueceuSenha";
            linkEsqueceuSenha.Size = new Size(132, 20);
            linkEsqueceuSenha.TabIndex = 31;
            linkEsqueceuSenha.TabStop = true;
            linkEsqueceuSenha.Text = "Esqueceu a senha?";
            linkEsqueceuSenha.LinkClicked += linkEsqueceuSenha_LinkClicked;
            // 
            // TelaDeLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1045, 716);
            Controls.Add(linkEsqueceuSenha);
            Controls.Add(btnCadastrar);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBoxHidePassword);
            Controls.Add(pictureBoxShowPassword);
            Controls.Add(BtnEntrar);
            Controls.Add(TxtSenha);
            Controls.Add(TxtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "TelaDeLogin";
            Text = "Genesis Solutions";
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
        private Button btnCadastrar;
        private LinkLabel linkEsqueceuSenha;
    }
}
