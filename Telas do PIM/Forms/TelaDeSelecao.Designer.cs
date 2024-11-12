namespace Telas_do_PIM.Forms
{
    partial class TelaDeSelecao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaDeSelecao));
            label1 = new Label();
            rbtnCadastroFuncionario = new RadioButton();
            rbtnMantutencaoFuncionario = new RadioButton();
            rbtnCadastroCliente = new RadioButton();
            rbtnManutencaoClientes = new RadioButton();
            rbtnManutencaoProdutos = new RadioButton();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(137, 113);
            label1.Name = "label1";
            label1.Size = new Size(229, 31);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // rbtnCadastroFuncionario
            // 
            rbtnCadastroFuncionario.AutoSize = true;
            rbtnCadastroFuncionario.Enabled = false;
            rbtnCadastroFuncionario.Font = new Font("Georgia", 12F, FontStyle.Underline);
            rbtnCadastroFuncionario.Location = new Point(60, 208);
            rbtnCadastroFuncionario.Name = "rbtnCadastroFuncionario";
            rbtnCadastroFuncionario.Size = new Size(183, 22);
            rbtnCadastroFuncionario.TabIndex = 2;
            rbtnCadastroFuncionario.TabStop = true;
            rbtnCadastroFuncionario.Text = "Cadastrar Funcionário";
            rbtnCadastroFuncionario.UseVisualStyleBackColor = true;
            rbtnCadastroFuncionario.MouseClick += rbtnCadastroFuncionario_Click;
            rbtnCadastroFuncionario.MouseEnter += rbtnCadastroFuncionario_MouseHover;
            // 
            // rbtnMantutencaoFuncionario
            // 
            rbtnMantutencaoFuncionario.AutoSize = true;
            rbtnMantutencaoFuncionario.Enabled = false;
            rbtnMantutencaoFuncionario.Font = new Font("Georgia", 12F, FontStyle.Underline);
            rbtnMantutencaoFuncionario.Location = new Point(60, 322);
            rbtnMantutencaoFuncionario.Name = "rbtnMantutencaoFuncionario";
            rbtnMantutencaoFuncionario.Size = new Size(228, 22);
            rbtnMantutencaoFuncionario.TabIndex = 3;
            rbtnMantutencaoFuncionario.TabStop = true;
            rbtnMantutencaoFuncionario.Text = "Manutenção de Funcionários";
            rbtnMantutencaoFuncionario.UseVisualStyleBackColor = true;
            rbtnMantutencaoFuncionario.MouseClick += rbtnMantutencaoFuncionario_Click;
            rbtnMantutencaoFuncionario.MouseEnter += rbtnMantutencaoFuncionario_MouseHover;
            // 
            // rbtnCadastroCliente
            // 
            rbtnCadastroCliente.AutoSize = true;
            rbtnCadastroCliente.Enabled = false;
            rbtnCadastroCliente.Font = new Font("Georgia", 12F, FontStyle.Underline);
            rbtnCadastroCliente.Location = new Point(60, 246);
            rbtnCadastroCliente.Name = "rbtnCadastroCliente";
            rbtnCadastroCliente.Size = new Size(149, 22);
            rbtnCadastroCliente.TabIndex = 4;
            rbtnCadastroCliente.TabStop = true;
            rbtnCadastroCliente.Text = "Cadastrar Cliente";
            rbtnCadastroCliente.UseVisualStyleBackColor = true;
            rbtnCadastroCliente.MouseClick += rbtnCadastroClientes_Click;
            rbtnCadastroCliente.MouseEnter += rbtnCadastroClientes_MouseHover;
            // 
            // rbtnManutencaoClientes
            // 
            rbtnManutencaoClientes.AutoSize = true;
            rbtnManutencaoClientes.Enabled = false;
            rbtnManutencaoClientes.Font = new Font("Georgia", 12F, FontStyle.Underline);
            rbtnManutencaoClientes.Location = new Point(60, 360);
            rbtnManutencaoClientes.Name = "rbtnManutencaoClientes";
            rbtnManutencaoClientes.Size = new Size(194, 22);
            rbtnManutencaoClientes.TabIndex = 6;
            rbtnManutencaoClientes.TabStop = true;
            rbtnManutencaoClientes.Text = "Manutenção de Clientes";
            rbtnManutencaoClientes.UseVisualStyleBackColor = true;
            rbtnManutencaoClientes.MouseClick += rbtnManutencaoClientes_Click;
            rbtnManutencaoClientes.MouseEnter += rbtnManutencaoClientes_MouseHover;
            // 
            // rbtnManutencaoProdutos
            // 
            rbtnManutencaoProdutos.AutoSize = true;
            rbtnManutencaoProdutos.Enabled = false;
            rbtnManutencaoProdutos.Font = new Font("Georgia", 12F, FontStyle.Underline);
            rbtnManutencaoProdutos.Location = new Point(60, 284);
            rbtnManutencaoProdutos.Name = "rbtnManutencaoProdutos";
            rbtnManutencaoProdutos.Size = new Size(202, 22);
            rbtnManutencaoProdutos.TabIndex = 7;
            rbtnManutencaoProdutos.TabStop = true;
            rbtnManutencaoProdutos.Text = "Manutenção de Produtos";
            rbtnManutencaoProdutos.UseVisualStyleBackColor = true;
            rbtnManutencaoProdutos.MouseClick += rbtnManutencaoProdutos_Click;
            rbtnManutencaoProdutos.MouseEnter += rbtnManutencaoProdutos_MouseHover;
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
            // TelaDeSelecao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 537);
            Controls.Add(pictureBox1);
            Controls.Add(rbtnManutencaoProdutos);
            Controls.Add(rbtnManutencaoClientes);
            Controls.Add(rbtnCadastroCliente);
            Controls.Add(rbtnMantutencaoFuncionario);
            Controls.Add(rbtnCadastroFuncionario);
            Controls.Add(label1);
            Name = "TelaDeSelecao";
            Text = "Genesis Solution";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbtnCadastroFuncionario;
        private RadioButton rbtnMantutencaoFuncionario;
        private RadioButton rbtnCadastroCliente;
        private RadioButton rbtnManutencaoClientes;
        private RadioButton rbtnManutencaoProdutos;
        private PictureBox pictureBox1;
    }
}