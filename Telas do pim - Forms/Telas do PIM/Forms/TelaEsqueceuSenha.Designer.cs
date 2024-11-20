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
            btnVoltarEmail = new Button();
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
            label1.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 73);
            label1.Name = "label1";
            label1.Size = new Size(116, 15);
            label1.TabIndex = 0;
            label1.Text = "Informe seu E-Mail";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(188, 70);
            textBoxEmail.Margin = new Padding(3, 2, 3, 2);
            textBoxEmail.MaxLength = 100;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(211, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirmar.Location = new Point(278, 147);
            btnConfirmar.Margin = new Padding(3, 2, 3, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(82, 22);
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
            painelConfirmacao.Margin = new Padding(3, 2, 3, 2);
            painelConfirmacao.Name = "painelConfirmacao";
            painelConfirmacao.Size = new Size(432, 212);
            painelConfirmacao.TabIndex = 3;
            // 
            // btnVoltarEmail
            // 
            btnVoltarEmail.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVoltarEmail.Location = new Point(55, 147);
            btnVoltarEmail.Margin = new Padding(3, 2, 3, 2);
            btnVoltarEmail.Name = "btnVoltarEmail";
            btnVoltarEmail.Size = new Size(82, 22);
            btnVoltarEmail.TabIndex = 3;
            btnVoltarEmail.Text = "Voltar";
            btnVoltarEmail.UseVisualStyleBackColor = true;
            btnVoltarEmail.Click += btnVoltarEmail_Click;
            // 
            // painelInformarCodigo
            // 
            painelInformarCodigo.Controls.Add(btnVoltar);
            painelInformarCodigo.Controls.Add(btnConfirmarCodigo);
            painelInformarCodigo.Controls.Add(label2);
            painelInformarCodigo.Controls.Add(textBoxInformeCodigo);
            painelInformarCodigo.Dock = DockStyle.Fill;
            painelInformarCodigo.Location = new Point(0, 0);
            painelInformarCodigo.Margin = new Padding(3, 2, 3, 2);
            painelInformarCodigo.Name = "painelInformarCodigo";
            painelInformarCodigo.Size = new Size(432, 212);
            painelInformarCodigo.TabIndex = 3;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(55, 163);
            btnVoltar.Margin = new Padding(3, 2, 3, 2);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(109, 22);
            btnVoltar.TabIndex = 3;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnConfirmarCodigo
            // 
            btnConfirmarCodigo.Location = new Point(235, 163);
            btnConfirmarCodigo.Margin = new Padding(3, 2, 3, 2);
            btnConfirmarCodigo.Name = "btnConfirmarCodigo";
            btnConfirmarCodigo.Size = new Size(109, 22);
            btnConfirmarCodigo.TabIndex = 2;
            btnConfirmarCodigo.Text = "Confirmar";
            btnConfirmarCodigo.UseVisualStyleBackColor = true;
            btnConfirmarCodigo.Click += btnConfirmarCodigo_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 83);
            label2.Name = "label2";
            label2.Size = new Size(214, 15);
            label2.TabIndex = 1;
            label2.Text = "Informe o código enviado no seu email";
            // 
            // textBoxInformeCodigo
            // 
            textBoxInformeCodigo.Location = new Point(131, 108);
            textBoxInformeCodigo.Margin = new Padding(3, 2, 3, 2);
            textBoxInformeCodigo.MaxLength = 6;
            textBoxInformeCodigo.Name = "textBoxInformeCodigo";
            textBoxInformeCodigo.Size = new Size(110, 23);
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
            painelConfirmarSenha.Margin = new Padding(3, 2, 3, 2);
            painelConfirmarSenha.Name = "painelConfirmarSenha";
            painelConfirmarSenha.Size = new Size(432, 212);
            painelConfirmarSenha.TabIndex = 2;
            // 
            // btnVoltarInforme
            // 
            btnVoltarInforme.Location = new Point(66, 173);
            btnVoltarInforme.Margin = new Padding(3, 2, 3, 2);
            btnVoltarInforme.Name = "btnVoltarInforme";
            btnVoltarInforme.Size = new Size(81, 22);
            btnVoltarInforme.TabIndex = 27;
            btnVoltarInforme.Text = "Voltar";
            btnVoltarInforme.UseVisualStyleBackColor = true;
            btnVoltarInforme.Click += btnVoltarInforme_Click;
            // 
            // pictureBoxShowConfPassword
            // 
            pictureBoxShowConfPassword.Image = (Image)resources.GetObject("pictureBoxShowConfPassword.Image");
            pictureBoxShowConfPassword.Location = new Point(278, 119);
            pictureBoxShowConfPassword.Margin = new Padding(3, 2, 3, 2);
            pictureBoxShowConfPassword.Name = "pictureBoxShowConfPassword";
            pictureBoxShowConfPassword.Size = new Size(22, 20);
            pictureBoxShowConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowConfPassword.TabIndex = 26;
            pictureBoxShowConfPassword.TabStop = false;
            pictureBoxShowConfPassword.Click += pictureBoxShowConfPassword_Click;
            // 
            // pictureBoxShowPassword
            // 
            pictureBoxShowPassword.Image = (Image)resources.GetObject("pictureBoxShowPassword.Image");
            pictureBoxShowPassword.Location = new Point(278, 64);
            pictureBoxShowPassword.Margin = new Padding(3, 2, 3, 2);
            pictureBoxShowPassword.Name = "pictureBoxShowPassword";
            pictureBoxShowPassword.Size = new Size(22, 20);
            pictureBoxShowPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxShowPassword.TabIndex = 25;
            pictureBoxShowPassword.TabStop = false;
            pictureBoxShowPassword.Click += pictureBoxShowPassword_Click;
            // 
            // pictureBoxHideConfPassword
            // 
            pictureBoxHideConfPassword.Image = (Image)resources.GetObject("pictureBoxHideConfPassword.Image");
            pictureBoxHideConfPassword.Location = new Point(278, 119);
            pictureBoxHideConfPassword.Margin = new Padding(3, 2, 3, 2);
            pictureBoxHideConfPassword.Name = "pictureBoxHideConfPassword";
            pictureBoxHideConfPassword.Size = new Size(22, 20);
            pictureBoxHideConfPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHideConfPassword.TabIndex = 24;
            pictureBoxHideConfPassword.TabStop = false;
            pictureBoxHideConfPassword.Click += pictureBoxHideConfPassword_Click;
            // 
            // pictureBoxHidePassword
            // 
            pictureBoxHidePassword.Image = (Image)resources.GetObject("pictureBoxHidePassword.Image");
            pictureBoxHidePassword.Location = new Point(278, 64);
            pictureBoxHidePassword.Margin = new Padding(3, 2, 3, 2);
            pictureBoxHidePassword.Name = "pictureBoxHidePassword";
            pictureBoxHidePassword.Size = new Size(22, 20);
            pictureBoxHidePassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxHidePassword.TabIndex = 23;
            pictureBoxHidePassword.TabStop = false;
            pictureBoxHidePassword.Click += pictureBoxHidePassword_Click;
            // 
            // btnConfirmarSenha
            // 
            btnConfirmarSenha.Location = new Point(246, 173);
            btnConfirmarSenha.Margin = new Padding(3, 2, 3, 2);
            btnConfirmarSenha.Name = "btnConfirmarSenha";
            btnConfirmarSenha.Size = new Size(81, 22);
            btnConfirmarSenha.TabIndex = 4;
            btnConfirmarSenha.Text = "Confirmar";
            btnConfirmarSenha.UseVisualStyleBackColor = true;
            btnConfirmarSenha.Click += btnConfirmarSenha_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 102);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 3;
            label4.Text = "Confirme a senha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 44);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 2;
            label3.Text = "Informe a senha";
            // 
            // textBoxConfirmeSenha
            // 
            textBoxConfirmeSenha.Location = new Point(125, 119);
            textBoxConfirmeSenha.Margin = new Padding(3, 2, 3, 2);
            textBoxConfirmeSenha.MaxLength = 20;
            textBoxConfirmeSenha.Name = "textBoxConfirmeSenha";
            textBoxConfirmeSenha.PasswordChar = '*';
            textBoxConfirmeSenha.Size = new Size(148, 23);
            textBoxConfirmeSenha.TabIndex = 1;
            // 
            // textBoxSenha
            // 
            textBoxSenha.Location = new Point(125, 64);
            textBoxSenha.Margin = new Padding(3, 2, 3, 2);
            textBoxSenha.MaxLength = 20;
            textBoxSenha.Name = "textBoxSenha";
            textBoxSenha.PasswordChar = '*';
            textBoxSenha.Size = new Size(148, 23);
            textBoxSenha.TabIndex = 0;
            // 
            // TelaEsqueceuSenha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 212);
            Controls.Add(painelConfirmacao);
            Controls.Add(painelInformarCodigo);
            Controls.Add(painelConfirmarSenha);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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