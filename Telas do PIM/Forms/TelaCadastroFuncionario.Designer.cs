namespace Telas_do_PIM.Forms
{
    partial class TelaCadastroFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroFuncionario));
            label1 = new Label();
            LblCadastro = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TxtNome = new TextBox();
            TxtConfSenha = new TextBox();
            TxtSenha = new TextBox();
            TxtEmail = new TextBox();
            TxtEndereco = new TextBox();
            BtnCadastrar = new Button();
            btnVoltar = new Button();
            pictureBoxHidePassword = new PictureBox();
            pictureBoxShowPassword = new PictureBox();
            pictureBoxShowConfPassword = new PictureBox();
            pictureBoxHideConfPassword = new PictureBox();
            TxtTelefone = new MaskedTextBox();
            TxtCPF = new MaskedTextBox();
            label2 = new Label();
            cmbBoxPerfil = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(354, 46);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // LblCadastro
            // 
            LblCadastro.AutoSize = true;
            LblCadastro.Location = new Point(321, 71);
            LblCadastro.Name = "LblCadastro";
            LblCadastro.Size = new Size(168, 15);
            LblCadastro.TabIndex = 1;
            LblCadastro.Text = "Cadastre um novo funcionário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 443);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 2;
            label3.Text = "Confirmação de senha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(98, 399);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Senha";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(98, 310);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 4;
            label5.Text = "E-mail";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(98, 266);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Endereço";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(98, 222);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 6;
            label7.Text = "Telefone";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(98, 178);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 7;
            label8.Text = "CPF";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(98, 134);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 8;
            label9.Text = "Nome";
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(98, 152);
            TxtNome.MaxLength = 100;
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(252, 23);
            TxtNome.TabIndex = 1;
            TxtNome.TextChanged += textBox1_TextChanged;
            // 
            // TxtConfSenha
            // 
            TxtConfSenha.Location = new Point(98, 461);
            TxtConfSenha.MaxLength = 100;
            TxtConfSenha.Name = "TxtConfSenha";
            TxtConfSenha.PasswordChar = '*';
            TxtConfSenha.Size = new Size(252, 23);
            TxtConfSenha.TabIndex = 7;
            // 
            // TxtSenha
            // 
            TxtSenha.Location = new Point(98, 417);
            TxtSenha.MaxLength = 100;
            TxtSenha.Name = "TxtSenha";
            TxtSenha.PasswordChar = '*';
            TxtSenha.Size = new Size(252, 23);
            TxtSenha.TabIndex = 6;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(98, 328);
            TxtEmail.MaxLength = 100;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(252, 23);
            TxtEmail.TabIndex = 5;
            // 
            // TxtEndereco
            // 
            TxtEndereco.Location = new Point(98, 284);
            TxtEndereco.MaxLength = 255;
            TxtEndereco.Name = "TxtEndereco";
            TxtEndereco.Size = new Size(252, 23);
            TxtEndereco.TabIndex = 4;
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(98, 490);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(252, 23);
            BtnCadastrar.TabIndex = 8;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(12, 554);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(75, 23);
            btnVoltar.TabIndex = 9;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(354, 417);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(22, 23);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 10;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(354, 417);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(22, 23);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 11;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxShowConfPassword
            // 
            pictureBoxShowConfPassword.Image = (Image)resources.GetObject("pictureBoxShowConfPassword.Image");
            pictureBoxShowConfPassword.Location = new Point(354, 461);
            pictureBoxShowConfPassword.Name = "pictureBoxShowConfPassword";
            pictureBoxShowConfPassword.Size = new Size(22, 23);
            pictureBoxShowConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowConfPassword.TabIndex = 12;
            pictureBoxShowConfPassword.TabStop = false;
            pictureBoxShowConfPassword.Click += pictureBoxShowConfPassword_Click;
            // 
            // pictureBoxHideConfPassword
            // 
            pictureBoxHideConfPassword.Image = (Image)resources.GetObject("pictureBoxHideConfPassword.Image");
            pictureBoxHideConfPassword.Location = new Point(354, 461);
            pictureBoxHideConfPassword.Name = "pictureBoxHideConfPassword";
            pictureBoxHideConfPassword.Size = new Size(22, 23);
            pictureBoxHideConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHideConfPassword.TabIndex = 21;
            pictureBoxHideConfPassword.TabStop = false;
            pictureBoxHideConfPassword.Click += pictureBoxHideConfPassword_Click;
            // 
            // TxtTelefone
            // 
            TxtTelefone.Location = new Point(98, 240);
            TxtTelefone.Mask = "(99) 00000-0000";
            TxtTelefone.Name = "TxtTelefone";
            TxtTelefone.Size = new Size(252, 23);
            TxtTelefone.TabIndex = 3;
            TxtTelefone.TextMaskFormat = MaskFormat.IncludePrompt;
            // 
            // TxtCPF
            // 
            TxtCPF.Location = new Point(98, 196);
            TxtCPF.Mask = "000,000,000-00";
            TxtCPF.Name = "TxtCPF";
            TxtCPF.Size = new Size(252, 23);
            TxtCPF.TabIndex = 2;
            TxtCPF.TextMaskFormat = MaskFormat.IncludePrompt;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 354);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 22;
            label2.Text = "Perfil";
            // 
            // cmbBoxPerfil
            // 
            cmbBoxPerfil.FormattingEnabled = true;
            cmbBoxPerfil.Location = new Point(98, 372);
            cmbBoxPerfil.Name = "cmbBoxPerfil";
            cmbBoxPerfil.Size = new Size(252, 23);
            cmbBoxPerfil.TabIndex = 23;
            // 
            // TelaCadastroFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 589);
            Controls.Add(cmbBoxPerfil);
            Controls.Add(label2);
            Controls.Add(TxtCPF);
            Controls.Add(TxtTelefone);
            Controls.Add(pictureBoxHideConfPassword);
            Controls.Add(pictureBoxShowConfPassword);
            Controls.Add(pictureBoxShowPassword);
            Controls.Add(pictureBoxHidePassword);
            Controls.Add(btnVoltar);
            Controls.Add(BtnCadastrar);
            Controls.Add(TxtEndereco);
            Controls.Add(TxtEmail);
            Controls.Add(TxtSenha);
            Controls.Add(TxtConfSenha);
            Controls.Add(TxtNome);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(LblCadastro);
            Controls.Add(label1);
            Name = "TelaCadastroFuncionario";
            Text = "Cadastro de funcionário";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label LblCadastro;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TxtNome;
        private TextBox TxtConfSenha;
        private TextBox TxtSenha;
        private TextBox TxtEmail;
        private TextBox TxtEndereco;
        private Button BtnCadastrar;
        private Button btnVoltar;
        private PictureBox pictureBoxHidePassword;
        private PictureBox pictureBoxShowPassword;
        private PictureBox pictureBoxShowConfPassword;
        private PictureBox pictureBoxHideConfPassword;
        private MaskedTextBox TxtTelefone;
        private MaskedTextBox TxtCPF;
        private Label label2;
        private ComboBox cmbBoxPerfil;
    }
}