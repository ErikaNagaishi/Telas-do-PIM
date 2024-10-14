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
            Rbtndashboard = new RadioButton();
            Rbtnfunc = new RadioButton();
            Rbtnadm = new RadioButton();
            Rbtncliente = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(306, 73);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // Rbtndashboard
            // 
            Rbtndashboard.AutoSize = true;
            Rbtndashboard.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtndashboard.Location = new Point(94, 193);
            Rbtndashboard.Margin = new Padding(3, 4, 3, 4);
            Rbtndashboard.Name = "Rbtndashboard";
            Rbtndashboard.Size = new Size(157, 24);
            Rbtndashboard.TabIndex = 1;
            Rbtndashboard.TabStop = true;
            Rbtndashboard.Text = "Acessar Dashboard";
            Rbtndashboard.UseVisualStyleBackColor = true;
            Rbtndashboard.MouseEnter += Rbtndashboard_MouseHover;
            // 
            // Rbtnfunc
            // 
            Rbtnfunc.AutoSize = true;
            Rbtnfunc.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtnfunc.Location = new Point(94, 257);
            Rbtnfunc.Margin = new Padding(3, 4, 3, 4);
            Rbtnfunc.Name = "Rbtnfunc";
            Rbtnfunc.Size = new Size(174, 24);
            Rbtnfunc.TabIndex = 2;
            Rbtnfunc.TabStop = true;
            Rbtnfunc.Text = "Cadastrar Funcionário";
            Rbtnfunc.UseVisualStyleBackColor = true;
            Rbtnfunc.MouseClick += Rbtnfunc_Click;
            Rbtnfunc.MouseEnter += Rbtnfunc_MouseHover;
            // 
            // Rbtnadm
            // 
            Rbtnadm.AutoSize = true;
            Rbtnadm.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtnadm.Location = new Point(94, 325);
            Rbtnadm.Margin = new Padding(3, 4, 3, 4);
            Rbtnadm.Name = "Rbtnadm";
            Rbtnadm.Size = new Size(131, 24);
            Rbtnadm.TabIndex = 3;
            Rbtnadm.TabStop = true;
            Rbtnadm.Text = "Cadastrar ADM";
            Rbtnadm.UseVisualStyleBackColor = true;
            Rbtnadm.MouseClick += Rbtnadm_Click;
            Rbtnadm.MouseEnter += Rbtnadm_MouseHover;
            // 
            // Rbtncliente
            // 
            Rbtncliente.AutoSize = true;
            Rbtncliente.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtncliente.Location = new Point(94, 389);
            Rbtncliente.Margin = new Padding(3, 4, 3, 4);
            Rbtncliente.Name = "Rbtncliente";
            Rbtncliente.Size = new Size(143, 24);
            Rbtncliente.TabIndex = 4;
            Rbtncliente.TabStop = true;
            Rbtncliente.Text = "Cadastrar Cliente";
            Rbtncliente.UseVisualStyleBackColor = true;
            Rbtncliente.MouseClick += Rbtncliente_Click;
            Rbtncliente.MouseEnter += Rbtncliente_MouseHover;
            // 
            // TelaDeSelecao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(Rbtncliente);
            Controls.Add(Rbtnadm);
            Controls.Add(Rbtnfunc);
            Controls.Add(Rbtndashboard);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TelaDeSelecao";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RadioButton Rbtndashboard;
        private RadioButton Rbtnfunc;
        private RadioButton Rbtnadm;
        private RadioButton Rbtncliente;
    }
}