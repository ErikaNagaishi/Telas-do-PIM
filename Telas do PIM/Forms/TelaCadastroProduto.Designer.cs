namespace Telas_do_PIM.Forms
{
    partial class TelaCadastroProduto
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
            btnCadastro = new Button();
            comboxNome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnImagem = new Button();
            pictureProduto = new PictureBox();
            upDownEstoque = new NumericUpDown();
            upDownValor = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownEstoque).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upDownValor).BeginInit();
            SuspendLayout();
            // 
            // btnCadastro
            // 
            btnCadastro.Font = new Font("Georgia", 9F);
            btnCadastro.Location = new Point(58, 313);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(175, 23);
            btnCadastro.TabIndex = 5;
            btnCadastro.Text = "Cadastrar";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // comboxNome
            // 
            comboxNome.Font = new Font("Georgia", 9F);
            comboxNome.Location = new Point(58, 64);
            comboxNome.MaxLength = 50;
            comboxNome.Name = "comboxNome";
            comboxNome.Size = new Size(175, 21);
            comboxNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9F);
            label1.Location = new Point(85, 23);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 3;
            label1.Text = "Cadastro de produto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9F);
            label2.Location = new Point(58, 46);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome do produto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9F);
            label3.Location = new Point(58, 90);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Valor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Georgia", 9F);
            label4.Location = new Point(58, 135);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 7;
            label4.Text = "Caixas em estoque";
            // 
            // btnImagem
            // 
            btnImagem.Font = new Font("Georgia", 9F);
            btnImagem.Location = new Point(58, 182);
            btnImagem.Name = "btnImagem";
            btnImagem.Size = new Size(175, 23);
            btnImagem.TabIndex = 4;
            btnImagem.Text = "Escolher imagem";
            btnImagem.UseVisualStyleBackColor = true;
            btnImagem.Click += btnImagem_Click;
            // 
            // pictureProduto
            // 
            pictureProduto.Location = new Point(58, 211);
            pictureProduto.Name = "pictureProduto";
            pictureProduto.Size = new Size(175, 89);
            pictureProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureProduto.TabIndex = 10;
            pictureProduto.TabStop = false;
            // 
            // upDownEstoque
            // 
            upDownEstoque.Font = new Font("Georgia", 9F);
            upDownEstoque.Location = new Point(58, 153);
            upDownEstoque.Name = "upDownEstoque";
            upDownEstoque.Size = new Size(175, 21);
            upDownEstoque.TabIndex = 3;
            // 
            // upDownValor
            // 
            upDownValor.DecimalPlaces = 2;
            upDownValor.Font = new Font("Georgia", 9F);
            upDownValor.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            upDownValor.Location = new Point(58, 108);
            upDownValor.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            upDownValor.Name = "upDownValor";
            upDownValor.Size = new Size(175, 21);
            upDownValor.TabIndex = 2;
            // 
            // TelaCadastroProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 348);
            Controls.Add(upDownValor);
            Controls.Add(upDownEstoque);
            Controls.Add(pictureProduto);
            Controls.Add(btnImagem);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboxNome);
            Controls.Add(btnCadastro);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaCadastroProduto";
            Text = "TelaCadastroProduto";
            ((System.ComponentModel.ISupportInitialize)pictureProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownEstoque).EndInit();
            ((System.ComponentModel.ISupportInitialize)upDownValor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastro;
        private TextBox comboxNome;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox comboBoxEstoque;
        private Button btnImagem;
        private PictureBox pictureProduto;
        private NumericUpDown upDownEstoque;
        private NumericUpDown upDownValor;
    }
}