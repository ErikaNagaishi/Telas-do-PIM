namespace Telas_do_PIM.Forms
{
    partial class TelaCadastroCategoria
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
            SuspendLayout();
            // 
            // btnCadastro
            // 
            btnCadastro.Font = new Font("Georgia", 9F);
            btnCadastro.Location = new Point(47, 140);
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
            comboxNome.Location = new Point(47, 84);
            comboxNome.MaxLength = 50;
            comboxNome.Name = "comboxNome";
            comboxNome.Size = new Size(175, 21);
            comboxNome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 9F);
            label1.Location = new Point(47, 21);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 3;
            label1.Text = "Cadastro de categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Georgia", 9F);
            label2.Location = new Point(47, 66);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 4;
            label2.Text = "Nome da categoria";
            // 
            // TelaCadastroCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 184);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboxNome);
            Controls.Add(btnCadastro);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaCadastroCategoria";
            Text = "Genesis Solutions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCadastro;
        private TextBox comboxNome;
        private Label label1;
        private Label label2;
        private TextBox comboBoxEstoque;
    }
}