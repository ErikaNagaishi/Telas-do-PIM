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
            label1.Location = new Point(268, 55);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Genesis Solutions";
            // 
            // Rbtndashboard
            // 
            Rbtndashboard.AutoSize = true;
            Rbtndashboard.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtndashboard.Location = new Point(82, 145);
            Rbtndashboard.Name = "Rbtndashboard";
            Rbtndashboard.Size = new Size(125, 19);
            Rbtndashboard.TabIndex = 1;
            Rbtndashboard.TabStop = true;
            Rbtndashboard.Text = "Acessar Dashboard";
            Rbtndashboard.UseVisualStyleBackColor = true;
            // 
            // Rbtnfunc
            // 
            Rbtnfunc.AutoSize = true;
            Rbtnfunc.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtnfunc.Location = new Point(82, 193);
            Rbtnfunc.Name = "Rbtnfunc";
            Rbtnfunc.Size = new Size(141, 19);
            Rbtnfunc.TabIndex = 2;
            Rbtnfunc.TabStop = true;
            Rbtnfunc.Text = "Cadastrar Funcionário";
            Rbtnfunc.UseVisualStyleBackColor = true;
            Rbtnfunc.CheckedChanged += Rbtnfunc_CheckedChanged;
            Rbtnfunc.MouseClick += Rbtnfunc_Click;
            // 
            // Rbtnadm
            // 
            Rbtnadm.AutoSize = true;
            Rbtnadm.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtnadm.Location = new Point(82, 244);
            Rbtnadm.Name = "Rbtnadm";
            Rbtnadm.Size = new Size(105, 19);
            Rbtnadm.TabIndex = 3;
            Rbtnadm.TabStop = true;
            Rbtnadm.Text = "Cadastrar ADM";
            Rbtnadm.UseVisualStyleBackColor = true;
            // 
            // Rbtncliente
            // 
            Rbtncliente.AutoSize = true;
            Rbtncliente.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            Rbtncliente.Location = new Point(82, 292);
            Rbtncliente.Name = "Rbtncliente";
            Rbtncliente.Size = new Size(115, 19);
            Rbtncliente.TabIndex = 4;
            Rbtncliente.TabStop = true;
            Rbtncliente.Text = "Cadastrar Cliente";
            Rbtncliente.UseVisualStyleBackColor = true;
            // 
            // TelaDeSelecao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Rbtncliente);
            Controls.Add(Rbtnadm);
            Controls.Add(Rbtnfunc);
            Controls.Add(Rbtndashboard);
            Controls.Add(label1);
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