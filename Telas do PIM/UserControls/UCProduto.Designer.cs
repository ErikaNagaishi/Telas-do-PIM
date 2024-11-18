namespace Telas_do_PIM.UserControls
{
    partial class UCProduto
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCProduto));
            pictureBoxProduto = new PictureBox();
            splitContainer1 = new SplitContainer();
            btnAdd = new Button();
            upDownQtd = new NumericUpDown();
            labelValorProduto = new Label();
            labelNomeProduto = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)upDownQtd).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProduto
            // 
            pictureBoxProduto.Dock = DockStyle.Fill;
            pictureBoxProduto.Location = new Point(0, 0);
            pictureBoxProduto.Margin = new Padding(3, 4, 3, 4);
            pictureBoxProduto.Name = "pictureBoxProduto";
            pictureBoxProduto.Size = new Size(253, 138);
            pictureBoxProduto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProduto.TabIndex = 0;
            pictureBoxProduto.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBoxProduto);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnAdd);
            splitContainer1.Panel2.Controls.Add(upDownQtd);
            splitContainer1.Panel2.Controls.Add(labelValorProduto);
            splitContainer1.Panel2.Controls.Add(labelNomeProduto);
            splitContainer1.Size = new Size(253, 282);
            splitContainer1.SplitterDistance = 138;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.BackgroundImage = (Image)resources.GetObject("btnAdd.BackgroundImage");
            btnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            btnAdd.Enabled = false;
            btnAdd.Location = new Point(144, 97);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(31, 31);
            btnAdd.TabIndex = 3;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // upDownQtd
            // 
            upDownQtd.Location = new Point(51, 97);
            upDownQtd.Margin = new Padding(3, 4, 3, 4);
            upDownQtd.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            upDownQtd.Name = "upDownQtd";
            upDownQtd.Size = new Size(64, 27);
            upDownQtd.TabIndex = 2;
            upDownQtd.ValueChanged += upDownQtd_ValueChanged;
            // 
            // labelValorProduto
            // 
            labelValorProduto.AutoSize = true;
            labelValorProduto.Location = new Point(93, 58);
            labelValorProduto.Name = "labelValorProduto";
            labelValorProduto.Size = new Size(26, 20);
            labelValorProduto.TabIndex = 1;
            labelValorProduto.Text = "R$";
            // 
            // labelNomeProduto
            // 
            labelNomeProduto.AutoSize = true;
            labelNomeProduto.Location = new Point(89, 21);
            labelNomeProduto.Name = "labelNomeProduto";
            labelNomeProduto.Size = new Size(50, 20);
            labelNomeProduto.TabIndex = 0;
            labelNomeProduto.Text = "Nome";
            // 
            // UCProduto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UCProduto";
            Size = new Size(253, 282);
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduto).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)upDownQtd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxProduto;
        private SplitContainer splitContainer1;
        private Label labelValorProduto;
        private Label labelNomeProduto;
        private Button btnAdd;
        private NumericUpDown upDownQtd;
    }
}
