namespace Telas_do_PIM.Forms
{
    partial class TelaCarregamentoProdutos
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
            upDownCaixas = new NumericUpDown();
            btnConfirmar = new Button();
            label1 = new Label();
            comboBoxProduto = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)upDownCaixas).BeginInit();
            SuspendLayout();
            // 
            // upDownCaixas
            // 
            upDownCaixas.Location = new Point(33, 133);
            upDownCaixas.Margin = new Padding(3, 2, 3, 2);
            upDownCaixas.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            upDownCaixas.Name = "upDownCaixas";
            upDownCaixas.Size = new Size(92, 23);
            upDownCaixas.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(50, 161);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(75, 23);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9F);
            label1.Location = new Point(33, 18);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 2;
            label1.Text = "Carregamento de lote";
            // 
            // comboBoxProduto
            // 
            comboBoxProduto.FormattingEnabled = true;
            comboBoxProduto.Location = new Point(33, 62);
            comboBoxProduto.Name = "comboBoxProduto";
            comboBoxProduto.Size = new Size(120, 23);
            comboBoxProduto.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9F);
            label2.Location = new Point(33, 44);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Produto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Georgia", 9F);
            label3.Location = new Point(33, 116);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 5;
            label3.Text = "Quantidade";
            // 
            // TelaCarregamentoProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(182, 194);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxProduto);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(upDownCaixas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "TelaCarregamentoProdutos";
            Text = "Genesis Solutions";
            Load += TelaCarregamentoProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)upDownCaixas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown upDownCaixas;
        private Button btnConfirmar;
        private Label label1;
        private ComboBox comboBoxProduto;
        private Label label2;
        private Label label3;
    }
}