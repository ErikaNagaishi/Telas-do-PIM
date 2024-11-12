namespace Telas_do_PIM.Forms
{
    partial class TelaManutencaoProdutos
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            produtoBindingSource = new BindingSource(components);
            btnAddProduto = new Button();
            addBtnCarregamento = new Button();
            statusStrip1 = new StatusStrip();
            statusLabelShowAll = new ToolStripStatusLabel();
            statusLabelFilter = new ToolStripStatusLabel();
            btnVoltar = new Button();
            btnConfirmar = new Button();
            idProduto = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            nomeProduto = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            valorVenda = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            qtdEmEstoque = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            lotesProdutosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ImagemProduto = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnAddProduto);
            splitContainer1.Panel2.Controls.Add(addBtnCarregamento);
            splitContainer1.Panel2.Controls.Add(statusStrip1);
            splitContainer1.Panel2.Controls.Add(btnVoltar);
            splitContainer1.Panel2.Controls.Add(btnConfirmar);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 399;
            splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idProduto, nomeProduto, valorVenda, qtdEmEstoque, lotesProdutosDataGridViewTextBoxColumn, ImagemProduto });
            dataGridView1.DataSource = produtoBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 399);
            dataGridView1.TabIndex = 0;
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Models.Produto);
            // 
            // btnAddProduto
            // 
            btnAddProduto.Location = new Point(222, 3);
            btnAddProduto.Name = "btnAddProduto";
            btnAddProduto.Size = new Size(114, 23);
            btnAddProduto.TabIndex = 8;
            btnAddProduto.Text = "Adicionar Produto";
            btnAddProduto.UseVisualStyleBackColor = true;
            btnAddProduto.Click += btnAddProduto_Click;
            // 
            // addBtnCarregamento
            // 
            addBtnCarregamento.Location = new Point(395, 2);
            addBtnCarregamento.Name = "addBtnCarregamento";
            addBtnCarregamento.Size = new Size(146, 23);
            addBtnCarregamento.TabIndex = 7;
            addBtnCarregamento.Text = "Adicionar carregamento";
            addBtnCarregamento.UseVisualStyleBackColor = true;
            addBtnCarregamento.Click += addBtnCarregamento_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelShowAll, statusLabelFilter });
            statusStrip1.Location = new Point(0, 25);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelShowAll
            // 
            statusLabelShowAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLabelShowAll.IsLink = true;
            statusLabelShowAll.LinkBehavior = LinkBehavior.HoverUnderline;
            statusLabelShowAll.Name = "statusLabelShowAll";
            statusLabelShowAll.Size = new Size(80, 17);
            statusLabelShowAll.Text = "Mostrar tudo";
            statusLabelShowAll.Click += statusLabelShowAll_Click;
            // 
            // statusLabelFilter
            // 
            statusLabelFilter.Name = "statusLabelFilter";
            statusLabelFilter.Size = new Size(0, 17);
            statusLabelFilter.Visible = false;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(0, 2);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(75, 23);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(660, 2);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(137, 23);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar alterações";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // idProduto
            // 
            idProduto.DataPropertyName = "IdProduto";
            idProduto.FilteringEnabled = false;
            idProduto.HeaderText = "Id";
            idProduto.Name = "idProduto";
            idProduto.ReadOnly = true;
            idProduto.Resizable = DataGridViewTriState.True;
            // 
            // nomeProduto
            // 
            nomeProduto.DataPropertyName = "NomeProduto";
            nomeProduto.FilteringEnabled = false;
            nomeProduto.HeaderText = "Nome";
            nomeProduto.Name = "nomeProduto";
            nomeProduto.Resizable = DataGridViewTriState.True;
            // 
            // valorVenda
            // 
            valorVenda.DataPropertyName = "ValorVenda";
            valorVenda.FilteringEnabled = false;
            valorVenda.HeaderText = "Valor";
            valorVenda.Name = "valorVenda";
            valorVenda.Resizable = DataGridViewTriState.True;
            // 
            // qtdEmEstoque
            // 
            qtdEmEstoque.DataPropertyName = "QtdEmEstoque";
            qtdEmEstoque.FilteringEnabled = false;
            qtdEmEstoque.HeaderText = "Estoque";
            qtdEmEstoque.Name = "qtdEmEstoque";
            qtdEmEstoque.Resizable = DataGridViewTriState.True;
            // 
            // lotesProdutosDataGridViewTextBoxColumn
            // 
            lotesProdutosDataGridViewTextBoxColumn.DataPropertyName = "LotesProdutos";
            lotesProdutosDataGridViewTextBoxColumn.HeaderText = "LotesProdutos";
            lotesProdutosDataGridViewTextBoxColumn.Name = "lotesProdutosDataGridViewTextBoxColumn";
            lotesProdutosDataGridViewTextBoxColumn.Visible = false;
            // 
            // ImagemProduto
            // 
            ImagemProduto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ImagemProduto.DataPropertyName = "ImagemProduto";
            ImagemProduto.HeaderText = "ImagemProduto";
            ImagemProduto.ImageLayout = DataGridViewImageCellLayout.Stretch;
            ImagemProduto.Name = "ImagemProduto";
            ImagemProduto.ReadOnly = true;
            // 
            // TelaManutencaoProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "TelaManutencaoProdutos";
            Text = "TelaMnatuencaoProdutos";
            Load += TelaMnatuencaoProdutos_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelShowAll;
        private ToolStripStatusLabel statusLabelFilter;
        private Button btnVoltar;
        private Button btnConfirmar;
        private BindingSource produtoBindingSource;
        private Button btnAddProduto;
        private Button addBtnCarregamento;
        private DataGridViewImageColumn Imagem;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn idProduto;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn nomeProduto;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn valorVenda;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn qtdEmEstoque;
        private DataGridViewTextBoxColumn lotesProdutosDataGridViewTextBoxColumn;
        private DataGridViewImageColumn ImagemProduto;
    }
}