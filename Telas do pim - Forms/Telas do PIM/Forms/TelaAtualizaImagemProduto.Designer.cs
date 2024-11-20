namespace Telas_do_PIM.Forms
{
    partial class TelaAtualizaImagemProduto
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
            label1 = new Label();
            btnImagem = new Button();
            pictureProduto = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureProduto).BeginInit();
            SuspendLayout();
            // 
            // btnCadastro
            // 
            btnCadastro.Font = new Font("Georgia", 9F);
            btnCadastro.Location = new Point(58, 207);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(175, 23);
            btnCadastro.TabIndex = 5;
            btnCadastro.Text = "Cadastrar";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9F);
            label1.Location = new Point(85, 23);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 3;
            label1.Text = "Atualizar imagem";
            // 
            // btnImagem
            // 
            btnImagem.Font = new Font("Georgia", 9F);
            btnImagem.Location = new Point(58, 56);
            btnImagem.Name = "btnImagem";
            btnImagem.Size = new Size(175, 23);
            btnImagem.TabIndex = 4;
            btnImagem.Text = "Escolher imagem";
            btnImagem.UseVisualStyleBackColor = true;
            btnImagem.Click += btnImagem_Click;
            // 
            // pictureProduto
            // 
            pictureProduto.Location = new Point(58, 95);
            pictureProduto.Name = "pictureProduto";
            pictureProduto.Size = new Size(175, 89);
            pictureProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureProduto.TabIndex = 10;
            pictureProduto.TabStop = false;
            // 
            // TelaAtualizaImagemProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 254);
            Controls.Add(pictureProduto);
            Controls.Add(btnImagem);
            Controls.Add(label1);
            Controls.Add(btnCadastro);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaAtualizaImagemProduto";
            Text = "Genesis Solutions";
            ((System.ComponentModel.ISupportInitialize)pictureProduto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastro;
        private Label label1;
        private TextBox comboBoxEstoque;
        private Button btnImagem;
        private PictureBox pictureProduto;
    }
}