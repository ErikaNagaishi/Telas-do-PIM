namespace Telas_do_PIM.Forms
{
    partial class TelaEsqueceuSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaEsqueceuSenha));
            label1 = new Label();
            textBoxEmail = new TextBox();
            btnConfirmar = new Button();
            painelConfirmacao = new Panel();
            painelInformarCodigo = new Panel();
            btnVoltar = new Button();
            btnConfirmarCodigo = new Button();
            label2 = new Label();
            textBoxInformeCodigo = new TextBox();
            painelConfirmarSenha = new Panel();
            btnVoltarInforme = new Button();
            pictureBoxShowConfPassword = new PictureBox();
            pictureBoxShowPassword = new PictureBox();
            pictureBoxHideConfPassword = new PictureBox();
            pictureBoxHidePassword = new PictureBox();
            btnConfirmarSenha = new Button();
            label4 = new Label();
            label3 = new Label();
            textBoxConfirmeSenha = new TextBox();
            textBoxSenha = new TextBox();
            btnVoltarEmail = new Button();
            painelConfirmacao.SuspendLayout();
            painelInformarCodigo.SuspendLayout();
            painelConfirmarSenha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 97);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 0;
            label1.Text = "Informe seu E-Mail";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(215, 94);
            textBoxEmail.MaxLength = 100;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(241, 27);
            textBoxEmail.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(318, 196);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // painelConfirmacao
            // 
            painelConfirmacao.Controls.Add(btnVoltarEmail);
            painelConfirmacao.Controls.Add(btnConfirmar);
            painelConfirmacao.Controls.Add(label1);
            painelConfirmacao.Controls.Add(textBoxEmail);
            painelConfirmacao.Dock = DockStyle.Fill;
            painelConfirmacao.Location = new Point(0, 0);
            painelConfirmacao.Name = "painelConfirmacao";
            painelConfirmacao.Size = new Size(494, 282);
            painelConfirmacao.TabIndex = 3;
            // 
            // painelInformarCodigo
            // 
            painelInformarCodigo.Controls.Add(btnVoltar);
            painelInformarCodigo.Controls.Add(btnConfirmarCodigo);
            painelInformarCodigo.Controls.Add(label2);
            painelInformarCodigo.Controls.Add(textBoxInformeCodigo);
            painelInformarCodigo.Dock = DockStyle.Fill;
            painelInformarCodigo.Location = new Point(0, 0);
            painelInformarCodigo.Name = "painelInformarCodigo";
            painelInformarCodigo.Size = new Size(494, 282);
            painelInformarCodigo.TabIndex = 3;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(63, 217);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(125, 29);
            btnVoltar.TabIndex = 3;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnConfirmarCodigo
            // 
            btnConfirmarCodigo.Location = new Point(269, 217);
            btnConfirmarCodigo.Name = "btnConfirmarCodigo";
            btnConfirmarCodigo.Size = new Size(125, 29);
            btnConfirmarCodigo.TabIndex = 2;
            btnConfirmarCodigo.Text = "Confirmar";
            btnConfirmarCodigo.UseVisualStyleBackColor = true;
            btnConfirmarCodigo.Click += btnConfirmarCodigo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 111);
            label2.Name = "label2";
            label2.Size = new Size(270, 20);
            label2.TabIndex = 1;
            label2.Text = "Informe o código enviado no seu email";
            // 
            // textBoxInformeCodigo
            // 
            textBoxInformeCodigo.Location = new Point(150, 144);
            textBoxInformeCodigo.MaxLength = 6;
            textBoxInformeCodigo.Name = "textBoxInformeCodigo";
            textBoxInformeCodigo.Size = new Size(125, 27);
            textBoxInformeCodigo.TabIndex = 0;
            // 
            // painelConfirmarSenha
            // 
            painelConfirmarSenha.Controls.Add(btnVoltarInforme);
            painelConfirmarSenha.Controls.Add(pictureBoxShowConfPassword);
            painelConfirmarSenha.Controls.Add(pictureBoxShowPassword);
            painelConfirmarSenha.Controls.Add(pictureBoxHideConfPassword);
            painelConfirmarSenha.Controls.Add(pictureBoxHidePassword);
            painelConfirmarSenha.Controls.Add(btnConfirmarSenha);
            painelConfirmarSenha.Controls.Add(label4);
            painelConfirmarSenha.Controls.Add(label3);
            painelConfirmarSenha.Controls.Add(textBoxConfirmeSenha);
            painelConfirmarSenha.Controls.Add(textBoxSenha);
            painelConfirmarSenha.Dock = DockStyle.Fill;
            painelConfirmarSenha.Location = new Point(0, 0);
            painelConfirmarSenha.Name = "painelConfirmarSenha";
            painelConfirmarSenha.Size = new Size(494, 282);
            painelConfirmarSenha.TabIndex = 2;
            // 
            // btnVoltarInforme
            // 
            btnVoltarInforme.Location = new Point(76, 231);
            btnVoltarInforme.Name = "btnVoltarInforme";
            btnVoltarInforme.Size = new Size(93, 29);
            btnVoltarInforme.TabIndex = 27;
            btnVoltarInforme.Text = "Voltar";
            btnVoltarInforme.UseVisualStyleBackColor = true;
            btnVoltarInforme.Click += btnVoltarInforme_Click;
            // 
            // pictureBoxShowConfPassword
            // 
            pictureBoxShowConfPassword.Image = (Image)resources.GetObject("pictureBoxShowConfPassword.Image");
            pictureBoxShowConfPassword.Location = new Point(318, 159);
            pictureBoxShowConfPassword.Name = "pictureBoxShowConfPassword";
            pictureBoxShowConfPassword.Size = new Size(25, 27);
            pictureBoxShowConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowConfPassword.TabIndex = 26;
            pictureBoxShowConfPassword.TabStop = false;
            pictureBoxShowConfPassword.Click += pictureBoxShowConfPassword_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(318, 86);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(25, 27);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 25;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxHideConfPassword
            // 
            pictureBoxHideConfPassword.Image = (Image)resources.GetObject("pictureBoxHideConfPassword.Image");
            pictureBoxHideConfPassword.Location = new Point(318, 159);
            pictureBoxHideConfPassword.Name = "pictureBoxHideConfPassword";
            pictureBoxHideConfPassword.Size = new Size(25, 27);
            pictureBoxHideConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHideConfPassword.TabIndex = 24;
            pictureBoxHideConfPassword.TabStop = false;
            pictureBoxHideConfPassword.Click += pictureBoxHideConfPassword_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(318, 86);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(25, 27);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 23;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // btnConfirmarSenha
            // 
            btnConfirmarSenha.Location = new Point(281, 231);
            btnConfirmarSenha.Name = "btnConfirmarSenha";
            btnConfirmarSenha.Size = new Size(93, 29);
            btnConfirmarSenha.TabIndex = 4;
            btnConfirmarSenha.Text = "Confirmar";
            btnConfirmarSenha.UseVisualStyleBackColor = true;
            btnConfirmarSenha.Click += btnConfirmarSenha_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 136);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 3;
            label4.Text = "Confirme a senha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(143, 59);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 2;
            label3.Text = "Informe a senha";
            // 
            // textBoxConfirmeSenha
            // 
            textBoxConfirmeSenha.Location = new Point(143, 159);
            textBoxConfirmeSenha.MaxLength = 20;
            textBoxConfirmeSenha.Name = "textBoxConfirmeSenha";
            textBoxConfirmeSenha.PasswordChar = '*';
            textBoxConfirmeSenha.Size = new Size(169, 27);
            textBoxConfirmeSenha.TabIndex = 1;
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(143, 86);
            textBoxSenha.MaxLength = 20;
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new Size(169, 27);
            textBoxSenha.TabIndex = 0;
            // 
            // btnVoltarEmail
            // 
            btnVoltarEmail.Location = new Point(63, 196);
            btnVoltarEmail.Name = "btnVoltarEmail";
            btnVoltarEmail.Size = new Size(94, 29);
            btnVoltarEmail.TabIndex = 3;
            btnVoltarEmail.Text = "Voltar";
            btnVoltarEmail.UseVisualStyleBackColor = true;
            btnVoltarEmail.Click += btnVoltarEmail_Click;
            // 
            // TelaEsqueceuSenha
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(494, 282);
            Controls.Add(painelConfirmacao);
            Controls.Add(painelInformarCodigo);
            Controls.Add(painelConfirmarSenha);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TelaEsqueceuSenha";
            Text = "Genesis Solutions";
            Load += TelaEsqueceuSenha_Load;
            painelConfirmacao.ResumeLayout(false);
            painelConfirmacao.PerformLayout();
            painelInformarCodigo.ResumeLayout(false);
            painelInformarCodigo.PerformLayout();
            painelConfirmarSenha.ResumeLayout(false);
            painelConfirmarSenha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowConfPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxShowPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHideConfPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHidePassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox textBoxEmail;
        private Button btnConfirmar;
        private Panel painelConfirmacao;
        private Panel painelInformarCodigo;
        private Panel painelConfirmarSenha;
        private Label label2;
        private TextBox textBoxInformeCodigo;
        private Label label4;
        private Label label3;
        private TextBox textBoxConfirmeSenha;
        private TextBox textBoxSenha;
        private Button btnConfirmarSenha;
        private Button btnConfirmarCodigo;
        private PictureBox pictureBoxHideConfPassword;
        private PictureBox pictureBoxHidePassword;
        private PictureBox pictureBoxShowConfPassword;
        private PictureBox pictureBoxShowPassword;
        private Button btnVoltarInforme;
        private Button btnVoltar;
        private Button btnVoltarEmail;
    }
}