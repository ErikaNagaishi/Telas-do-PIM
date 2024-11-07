namespace Telas_do_PIM.Forms
{
    partial class TelaManutencaoClientes
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
            id = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            razaoSocial = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            cnpj = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            email = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            Cep = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            endereco = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            numero = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            senha = new DataGridViewTextBoxColumn();
            clienteBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            statusLabelShowAll = new ToolStripStatusLabel();
            statusLabelFilter = new ToolStripStatusLabel();
            btnVoltar = new Button();
            btnConfirmar = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(statusStrip1);
            splitContainer1.Panel2.Controls.Add(btnVoltar);
            splitContainer1.Panel2.Controls.Add(btnConfirmar);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 399;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, razaoSocial, cnpj, email, Cep, endereco, numero, senha });
            dataGridView1.DataSource = clienteBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 399);
            dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.DataPropertyName = "IdCliente";
            id.FilteringEnabled = false;
            id.HeaderText = "Id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.True;
            // 
            // razaoSocial
            // 
            razaoSocial.DataPropertyName = "RazaoSocial";
            razaoSocial.FilteringEnabled = false;
            razaoSocial.HeaderText = "Razão Social";
            razaoSocial.Name = "razaoSocial";
            razaoSocial.Resizable = DataGridViewTriState.True;
            // 
            // cnpj
            // 
            cnpj.DataPropertyName = "CnpjCliente";
            cnpj.FilteringEnabled = false;
            cnpj.HeaderText = "CNPJ";
            cnpj.Name = "cnpj";
            cnpj.Resizable = DataGridViewTriState.True;
            // 
            // email
            // 
            email.DataPropertyName = "Email";
            email.FilteringEnabled = false;
            email.HeaderText = "Email";
            email.Name = "email";
            email.Resizable = DataGridViewTriState.True;
            // 
            // Cep
            // 
            Cep.DataPropertyName = "Cep";
            Cep.FilteringEnabled = false;
            Cep.HeaderText = "Cep";
            Cep.Name = "Cep";
            // 
            // endereco
            // 
            endereco.DataPropertyName = "EnderecoCliente";
            endereco.FilteringEnabled = false;
            endereco.HeaderText = "Endereço";
            endereco.Name = "endereco";
            endereco.Resizable = DataGridViewTriState.True;
            // 
            // numero
            // 
            numero.DataPropertyName = "Numero";
            numero.FilteringEnabled = false;
            numero.HeaderText = "Número";
            numero.Name = "numero";
            numero.Resizable = DataGridViewTriState.True;
            // 
            // senha
            // 
            senha.DataPropertyName = "SenhaCliente";
            senha.HeaderText = "SenhaCliente";
            senha.Name = "senha";
            senha.Visible = false;
            // 
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(Models.Cliente);
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
            btnConfirmar.Location = new Point(663, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(137, 23);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar alterações";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // TelaManutencaoClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "TelaManutencaoClientes";
            Text = "TelaManutencaoClientes";
            Load += TelaManutencaoClientes_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private BindingSource clienteBindingSource;
        private Button btnVoltar;
        private Button btnConfirmar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelFilter;
        private ToolStripStatusLabel statusLabelShowAll;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn id;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn razaoSocial;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn cnpj;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn email;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn Cep;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn endereco;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn numero;
        private DataGridViewTextBoxColumn senha;
    }
}