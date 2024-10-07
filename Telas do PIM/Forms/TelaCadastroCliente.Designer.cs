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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            TxtNome = new TextBox();
            TxtCNPJ = new TextBox();
            TxtCEP = new TextBox();
            TxtEndereco = new TextBox();
            TxtEmail = new TextBox();
            TxtSenha = new TextBox();
            TxtConfSenha = new TextBox();
            BtnCadastrar = new Button();
            BtnVoltar = new Button();
            label10 = new Label();
            TxtNumeracao = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 42);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 73);
            label2.Name = "label2";
            label2.Size = new Size(142, 15);
            label2.TabIndex = 1;
            label2.Text = "Cadastre um novo cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 85);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 132);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "CNPJ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 181);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 4;
            label5.Text = "CEP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(70, 227);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Endereço";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(68, 279);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 6;
            label7.Text = "E-mail";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(70, 333);
            label8.Name = "label8";
            label8.Size = new Size(39, 15);
            label8.TabIndex = 7;
            label8.Text = "Senha";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(70, 390);
            label9.Name = "label9";
            label9.Size = new Size(126, 15);
            label9.TabIndex = 8;
            label9.Text = "Confirmação da senha";
            label9.Click += label9_Click;
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(70, 103);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(100, 23);
            TxtNome.TabIndex = 9;
            // 
            // TxtCNPJ
            // 
            TxtCNPJ.Location = new Point(68, 155);
            TxtCNPJ.Name = "TxtCNPJ";
            TxtCNPJ.Size = new Size(100, 23);
            TxtCNPJ.TabIndex = 10;
            // 
            // TxtCEP
            // 
            TxtCEP.Location = new Point(70, 201);
            TxtCEP.Name = "TxtCEP";
            TxtCEP.Size = new Size(100, 23);
            TxtCEP.TabIndex = 11;
            // 
            // TxtEndereco
            // 
            TxtEndereco.Location = new Point(70, 245);
            TxtEndereco.Name = "TxtEndereco";
            TxtEndereco.Size = new Size(100, 23);
            TxtEndereco.TabIndex = 12;
            // 
            // TxtEmail
            // 
            TxtEmail.Location = new Point(70, 297);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(100, 23);
            TxtEmail.TabIndex = 13;
            // 
            // TxtSenha
            // 
            TxtSenha.Location = new Point(70, 351);
            TxtSenha.Name = "TxtSenha";
            TxtSenha.Size = new Size(100, 23);
            TxtSenha.TabIndex = 14;
            TxtSenha.TextChanged += TxtSenha_TextChanged;
            // 
            // TxtConfSenha
            // 
            TxtConfSenha.Location = new Point(70, 408);
            TxtConfSenha.Name = "TxtConfSenha";
            TxtConfSenha.Size = new Size(100, 23);
            TxtConfSenha.TabIndex = 15;
            // 
            // BtnCadastrar
            // 
            BtnCadastrar.Location = new Point(310, 451);
            BtnCadastrar.Name = "BtnCadastrar";
            BtnCadastrar.Size = new Size(75, 23);
            BtnCadastrar.TabIndex = 16;
            BtnCadastrar.Text = "Cadastrar";
            BtnCadastrar.UseVisualStyleBackColor = true;
            BtnCadastrar.Click += BtnCadastrar_Click;
            // 
            // BtnVoltar
            // 
            BtnVoltar.Location = new Point(23, 468);
            BtnVoltar.Name = "BtnVoltar";
            BtnVoltar.Size = new Size(75, 23);
            BtnVoltar.TabIndex = 17;
            BtnVoltar.Text = "Voltar";
            BtnVoltar.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(186, 227);
            label10.Name = "label10";
            label10.Size = new Size(69, 15);
            label10.TabIndex = 18;
            label10.Text = "Numeração";
            // 
            // TxtNumeracao
            // 
            TxtNumeracao.Location = new Point(186, 245);
            TxtNumeracao.Name = "TxtNumeracao";
            TxtNumeracao.Size = new Size(69, 23);
            TxtNumeracao.TabIndex = 19;
            // 
            // TelaCadastroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 503);
            Controls.Add(TxtNumeracao);
            Controls.Add(label10);
            Controls.Add(BtnVoltar);
            Controls.Add(BtnCadastrar);
            Controls.Add(TxtConfSenha);
            Controls.Add(TxtSenha);
            Controls.Add(TxtEmail);
            Controls.Add(TxtEndereco);
            Controls.Add(TxtCEP);
            Controls.Add(TxtCNPJ);
            Controls.Add(TxtNome);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaCadastroCliente";
            Text = "Cadastro de Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TxtNome;
        private TextBox TxtCNPJ;
        private TextBox TxtCEP;
        private TextBox TxtEndereco;
        private TextBox TxtEmail;
        private TextBox TxtSenha;
        private TextBox TxtConfSenha;
        private Button BtnCadastrar;
        private Button BtnVoltar;
        private Label label10;
        private TextBox TxtNumeracao;
    }
}