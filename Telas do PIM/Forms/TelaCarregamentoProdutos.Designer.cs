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
            upDownCaixas.Location = new Point(38, 165);
            upDownCaixas.Margin = new Padding(3, 4, 3, 4);
            upDownCaixas.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            upDownCaixas.Name = "upDownCaixas";
            upDownCaixas.Size = new Size(137, 27);
            upDownCaixas.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(54, 216);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(86, 31);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 33);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 2;
            label1.Text = "Carregamento de lote";
            // 
            // comboBoxProduto
            // 
            comboBoxProduto.FormattingEnabled = true;
            comboBoxProduto.Location = new Point(38, 101);
            comboBoxProduto.Margin = new Padding(3, 4, 3, 4);
            comboBoxProduto.Name = "comboBoxProduto";
            comboBoxProduto.Size = new Size(137, 28);
            comboBoxProduto.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 77);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 4;
            label2.Text = "Produto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 141);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 5;
            label3.Text = "Quantidade";
            // 
            // TelaCarregamentoProdutos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(217, 263);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxProduto);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(upDownCaixas);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
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