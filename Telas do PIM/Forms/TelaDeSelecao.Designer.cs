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
            label1 = new Label();
            rbtnDashboard = new RadioButton();
            rbtnCadastroFuncionario = new RadioButton();
            rbtnMantutencaoFuncionario = new RadioButton();
            rbtnCadastroCliente = new RadioButton();
            rbtnManutencaoClientes = new RadioButton();
            rbtnManutencaoProdutos = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 55);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // rbtnDashboard
            // 
            rbtnDashboard.AutoSize = true;
            rbtnDashboard.Enabled = false;
            rbtnDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnDashboard.Location = new Point(82, 145);
            rbtnDashboard.Name = "rbtnDashboard";
            rbtnDashboard.Size = new Size(125, 19);
            rbtnDashboard.TabIndex = 1;
            rbtnDashboard.TabStop = true;
            rbtnDashboard.Text = "Acessar Dashboard";
            rbtnDashboard.UseVisualStyleBackColor = true;
            rbtnDashboard.MouseEnter += Rbtndashboard_MouseHover;
            // 
            // rbtnCadastroFuncionario
            // 
            rbtnCadastroFuncionario.AutoSize = true;
            rbtnCadastroFuncionario.Enabled = false;
            rbtnCadastroFuncionario.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnCadastroFuncionario.Location = new Point(82, 183);
            rbtnCadastroFuncionario.Name = "rbtnCadastroFuncionario";
            rbtnCadastroFuncionario.Size = new Size(141, 19);
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
            rbtnMantutencaoFuncionario.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnMantutencaoFuncionario.Location = new Point(353, 183);
            rbtnMantutencaoFuncionario.Name = "rbtnMantutencaoFuncionario";
            rbtnMantutencaoFuncionario.Size = new Size(179, 19);
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
            rbtnCadastroCliente.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnCadastroCliente.Location = new Point(82, 218);
            rbtnCadastroCliente.Name = "rbtnCadastroCliente";
            rbtnCadastroCliente.Size = new Size(115, 19);
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
            rbtnManutencaoClientes.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnManutencaoClientes.Location = new Point(353, 218);
            rbtnManutencaoClientes.Name = "rbtnManutencaoClientes";
            rbtnManutencaoClientes.Size = new Size(153, 19);
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
            rbtnManutencaoProdutos.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            rbtnManutencaoProdutos.Location = new Point(353, 145);
            rbtnManutencaoProdutos.Name = "rbtnManutencaoProdutos";
            rbtnManutencaoProdutos.Size = new Size(159, 19);
            rbtnManutencaoProdutos.TabIndex = 7;
            rbtnManutencaoProdutos.TabStop = true;
            rbtnManutencaoProdutos.Text = "Manutenção de Produtos";
            rbtnManutencaoProdutos.UseVisualStyleBackColor = true;
            rbtnManutencaoProdutos.MouseClick += rbtnManutencaoProdutos_Click;
            rbtnManutencaoProdutos.MouseEnter += rbtnManutencaoProdutos_MouseHover;
            // 
            // TelaDeSelecao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rbtnManutencaoProdutos);
            Controls.Add(rbtnManutencaoClientes);
            Controls.Add(rbtnCadastroCliente);
            Controls.Add(rbtnMantutencaoFuncionario);
            Controls.Add(rbtnCadastroFuncionario);
            Controls.Add(rbtnDashboard);
            Controls.Add(label1);
            Name = "TelaDeSelecao";
            Text = "Genesis Solution";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton rbtnDashboard;
        private RadioButton rbtnCadastroFuncionario;
        private RadioButton rbtnMantutencaoFuncionario;
        private RadioButton rbtnCadastroCliente;
        private RadioButton rbtnManutencaoClientes;
        private RadioButton rbtnManutencaoProdutos;
    }
}