namespace Telas_do_PIM.Forms
{
    partial class TelaCadastroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCadastroCliente));
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TxtNome = new TextBox();
            TxtEmail = new TextBox();
            TxtSenha = new TextBox();
            TxtConfSenha = new TextBox();
            BtnCadastrar = new Button();
            BtnVoltar = new Button();
            label10 = new Label();
            TxtNumeracao = new TextBox();
            pictureBoxShowPassword = new PictureBox();
            pictureBoxHidePassword = new PictureBox();
            pictureBoxShowConfPassword = new PictureBox();
            pictureBoxHideConfPassword = new PictureBox();
            TxtCEP = new MaskedTextBox();
            TxtEndereco = new TextBox();
            TxtCNPJ = new MaskedTextBox();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            tsUsuario = new ToolStripMenuItem();
            logoffToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(142, 38);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9.75F);
            label3.Location = new Point(104, 93);
            label3.Name = "label3";
            label3.Size = new Size(44, 16);
            label3.TabIndex = 2;
            label3.Text = "Nome";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9.75F);
            label4.Location = new Point(104, 136);
            label4.Name = "label4";
            label4.Size = new Size(40, 16);
            label4.TabIndex = 3;
            label4.Text = "CNPJ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Georgia", 9.75F);
            label5.Location = new Point(104, 180);
            label5.Name = "label5";
            label5.Size = new Size(31, 16);
            label5.TabIndex = 4;
            label5.Text = "CEP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Georgia", 9.75F);
            label6.Location = new Point(104, 224);
            label6.Name = "label6";
            label6.Size = new Size(66, 16);
            label6.TabIndex = 5;
            label6.Text = "Endereço";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Georgia", 9.75F);
            label7.Location = new Point(104, 268);
            label7.Name = "label7";
            label7.Size = new Size(47, 16);
            label7.TabIndex = 6;
            label7.Text = "E-mail";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Georgia", 9.75F);
            label8.Location = new Point(104, 312);
            label8.Name = "label8";
            label8.Size = new Size(44, 16);
            label8.TabIndex = 7;
            label8.Text = "Senha";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 9.75F);
            label9.Location = new Point(104, 356);
            label9.Name = "label9";
            label9.Size = new Size(143, 16);
            label9.TabIndex = 8;
            label9.Text = "Confirmação da senha";
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(104, 112);
            TxtNome.MaxLength = 255;
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(252, 22);
            TxtNome.TabIndex = 1;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(104, 287);
            TxtEmail.MaxLength = 100;
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(252, 22);
            TxtEmail.TabIndex = 6;
            // 
            // TxtSenha
            // 
            TxtSenha.Location = new Point(104, 331);
            TxtSenha.MaxLength = 255;
            TxtSenha.Name = "TxtSenha";
            TxtSenha.PasswordChar = '*';
            TxtSenha.Size = new Size(252, 22);
            TxtSenha.TabIndex = 7;
            // 
            // TxtConfSenha
            // 
            TxtConfSenha.Location = new Point(104, 375);
            TxtConfSenha.MaxLength = 255;
            TxtConfSenha.Name = "TxtConfSenha";
            TxtConfSenha.PasswordChar = '*';
            TxtConfSenha.Size = new Size(252, 22);
            TxtConfSenha.TabIndex = 8;
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.BackColor = Color.SeaGreen;
            BtnCadastrar.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCadastrar.ForeColor = Color.Snow;
            BtnCadastrar.Location = new Point(104, 403);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(252, 35);
            BtnCadastrar.TabIndex = 10;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = false;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // BtnVoltar
            // 
            BtnVoltar.BackColor = Color.SeaGreen;
            BtnVoltar.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnVoltar.ForeColor = Color.Snow;
            BtnVoltar.Location = new Point(12, 489);
            BtnVoltar.Name = "BtnVoltar";
            BtnVoltar.Size = new Size(80, 36);
            BtnVoltar.TabIndex = 11;
            BtnVoltar.Text = "Voltar";
            BtnVoltar.UseVisualStyleBackColor = false;
            BtnVoltar.Click += BtnVoltar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(362, 224);
            label10.Name = "label10";
            label10.Size = new Size(79, 16);
            label10.TabIndex = 18;
            label10.Text = "Numeração";
            // 
            // TxtNumeracao
            // 
            TxtNumeracao.Location = new Point(363, 243);
            TxtNumeracao.MaxLength = 20;
            TxtNumeracao.Name = "TxtNumeracao";
            TxtNumeracao.Size = new Size(78, 22);
            TxtNumeracao.TabIndex = 5;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(363, 331);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(25, 25);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 19;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(363, 331);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(25, 25);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 20;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // pictureBoxShowConfPassword
            // 
            pictureBoxShowConfPassword.Image = (Image)resources.GetObject("pictureBoxShowConfPassword.Image");
            pictureBoxShowConfPassword.Location = new Point(363, 372);
            pictureBoxShowConfPassword.Name = "pictureBoxShowConfPassword";
            pictureBoxShowConfPassword.Size = new Size(25, 25);
            pictureBoxShowConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowConfPassword.TabIndex = 21;
            pictureBoxShowConfPassword.TabStop = false;
            pictureBoxShowConfPassword.Click += pictureBoxShowConfPassword_Click;
            // 
            // pictureBoxHideConfPassword
            // 
            pictureBoxHideConfPassword.Image = (Image)resources.GetObject("pictureBoxHideConfPassword.Image");
            pictureBoxHideConfPassword.Location = new Point(363, 372);
            pictureBoxHideConfPassword.Name = "pictureBoxHideConfPassword";
            pictureBoxHideConfPassword.Size = new Size(25, 25);
            pictureBoxHideConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHideConfPassword.TabIndex = 22;
            pictureBoxHideConfPassword.TabStop = false;
            pictureBoxHideConfPassword.Click += pictureBoxHideConfPassword_Click;
            // 
            // TxtCEP
            // 
            TxtCEP.Location = new Point(104, 199);
            TxtCEP.Mask = "00000-999";
            TxtCEP.Name = "TxtCEP";
            TxtCEP.Size = new Size(252, 22);
            TxtCEP.TabIndex = 23;
            TxtCEP.TextMaskFormat = MaskFormat.IncludePrompt;
            // 
            // TxtEndereco
            // 
            TxtEndereco.Enabled = false;
            TxtEndereco.Location = new Point(104, 243);
            TxtEndereco.MaxLength = 100;
            TxtEndereco.Name = "TxtEndereco";
            TxtEndereco.Size = new Size(254, 22);
            TxtEndereco.TabIndex = 24;
            // 
            // TxtCNPJ
            // 
            TxtCNPJ.Location = new Point(104, 155);
            TxtCNPJ.Mask = "00,000,000/0000-00";
            TxtCNPJ.Name = "TxtCNPJ";
            TxtCNPJ.Size = new Size(252, 22);
            TxtCNPJ.TabIndex = 25;
            TxtCNPJ.TextMaskFormat = MaskFormat.IncludePrompt;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(504, -2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(410, 540);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 28;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsUsuario });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(914, 28);
            menuStrip1.TabIndex = 31;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsUsuario
            // 
            tsUsuario.BackgroundImageLayout = ImageLayout.Stretch;
            tsUsuario.DropDownItems.AddRange(new ToolStripItem[] { logoffToolStripMenuItem });
            tsUsuario.Image = (Image)resources.GetObject("tsUsuario.Image");
            tsUsuario.ImageAlign = ContentAlignment.MiddleRight;
            tsUsuario.Name = "tsUsuario";
            tsUsuario.RightToLeft = RightToLeft.Yes;
            tsUsuario.Size = new Size(79, 24);
            tsUsuario.Text = "Usuário";
            // 
            // logoffToolStripMenuItem
            // 
            logoffToolStripMenuItem.Image = (Image)resources.GetObject("logoffToolStripMenuItem.Image");
            logoffToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            logoffToolStripMenuItem.Size = new Size(116, 26);
            logoffToolStripMenuItem.Text = "Logout";
            logoffToolStripMenuItem.Click += logoffToolStripMenuItem_Click;
            // 
            // TelaCadastroCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 537);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(TxtCNPJ);
            Controls.Add(TxtEndereco);
            Controls.Add(TxtCEP);
            Controls.Add(pictureBoxHideConfPassword);
            Controls.Add(pictureBoxShowConfPassword);
            Controls.Add(pictureBoxHidePassword);
            Controls.Add(pictureBoxShowPassword);
            Controls.Add(TxtNumeracao);
            Controls.Add(label10);
            Controls.Add(BtnVoltar);
            Controls.Add(BtnCadastrar);
            Controls.Add(TxtConfSenha);
            Controls.Add(TxtSenha);
            Controls.Add(TxtEmail);
            Controls.Add(TxtNome);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Font = new Font("Georgia", 9.75F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TelaCadastroCliente";
            Text = "Cadastro de Cliente";
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TxtNome;
        private TextBox TxtEmail;
        private TextBox TxtSenha;
        private TextBox TxtConfSenha;
        private Button BtnCadastrar;
        private Button BtnVoltar;
        private Label label10;
        private TextBox TxtNumeracao;
        private PictureBox pictureBoxShowPassword;
        private PictureBox pictureBoxHidePassword;
        private PictureBox pictureBoxShowConfPassword;
        private PictureBox pictureBoxHideConfPassword;
        private MaskedTextBox TxtCEP;
        private TextBox TxtEndereco;
        private MaskedTextBox TxtCNPJ;
        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsUsuario;
        private ToolStripMenuItem logoffToolStripMenuItem;
    }
}