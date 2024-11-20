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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaManutencaoClientes));
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
            menuStrip1 = new MenuStrip();
            tsUsuario = new ToolStripMenuItem();
            logoffToolStripMenuItem = new ToolStripMenuItem();
            btnAddCliente = new Button();
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
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Controls.Add(menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnAddCliente);
            splitContainer1.Panel2.Controls.Add(statusStrip1);
            splitContainer1.Panel2.Controls.Add(btnVoltar);
            splitContainer1.Panel2.Controls.Add(btnConfirmar);
            splitContainer1.Size = new Size(914, 600);
            splitContainer1.SplitterDistance = 532;
            splitContainer1.SplitterWidth = 5;
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
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(914, 504);
            dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.DataPropertyName = "IdCliente";
            id.FilteringEnabled = false;
            id.HeaderText = "Id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.True;
            // 
            // razaoSocial
            // 
            razaoSocial.DataPropertyName = "RazaoSocial";
            razaoSocial.FilteringEnabled = false;
            razaoSocial.HeaderText = "Razão Social";
            razaoSocial.MinimumWidth = 6;
            razaoSocial.Name = "razaoSocial";
            razaoSocial.Resizable = DataGridViewTriState.True;
            // 
            // cnpj
            // 
            cnpj.DataPropertyName = "CnpjCliente";
            cnpj.FilteringEnabled = false;
            cnpj.HeaderText = "CNPJ";
            cnpj.MinimumWidth = 6;
            cnpj.Name = "cnpj";
            cnpj.Resizable = DataGridViewTriState.True;
            // 
            // email
            // 
            email.DataPropertyName = "Email";
            email.FilteringEnabled = false;
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Resizable = DataGridViewTriState.True;
            // 
            // Cep
            // 
            Cep.DataPropertyName = "Cep";
            Cep.FilteringEnabled = false;
            Cep.HeaderText = "Cep";
            Cep.MinimumWidth = 6;
            Cep.Name = "Cep";
            // 
            // endereco
            // 
            endereco.DataPropertyName = "EnderecoCliente";
            endereco.FilteringEnabled = false;
            endereco.HeaderText = "Endereço";
            endereco.MinimumWidth = 6;
            endereco.Name = "endereco";
            endereco.Resizable = DataGridViewTriState.True;
            // 
            // numero
            // 
            numero.DataPropertyName = "Numero";
            numero.FilteringEnabled = false;
            numero.HeaderText = "Número";
            numero.MinimumWidth = 6;
            numero.Name = "numero";
            numero.Resizable = DataGridViewTriState.True;
            // 
            // senha
            // 
            senha.DataPropertyName = "SenhaCliente";
            senha.HeaderText = "SenhaCliente";
            senha.MinimumWidth = 6;
            senha.Name = "senha";
            senha.Visible = false;
            // 
            // clienteBindingSource
            // 
            clienteBindingSource.DataSource = typeof(Models.Cliente);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsUsuario });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(914, 28);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsUsuario
            // 
            tsUsuario.BackgroundImageLayout = ImageLayout.Stretch;
            tsUsuario.DropDownItems.AddRange(new ToolStripItem[] { logoffToolStripMenuItem });
            tsUsuario.Image = (Image)resources.GetObject("tsUsuario.Image");
            tsUsuario.ImageAlign = ContentAlignment.MiddleRight;
            tsUsuario.Name = "tsUsuario";
            tsUsuario.RightToLeft = RightToLeft.Yes;
            tsUsuario.Size = new Size(93, 24);
            tsUsuario.Text = "Usuário";
            // 
            // logoffToolStripMenuItem
            // 
            logoffToolStripMenuItem.Image = (Image)resources.GetObject("logoffToolStripMenuItem.Image");
            logoffToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            logoffToolStripMenuItem.Size = new Size(139, 26);
            logoffToolStripMenuItem.Text = "Logout";
            logoffToolStripMenuItem.Click += logoffToolStripMenuItem_Click;
            // 
            // btnAddCliente
            // 
            btnAddCliente.Location = new Point(337, 3);
            btnAddCliente.Margin = new Padding(3, 4, 3, 4);
            btnAddCliente.Name = "btnAddCliente";
            btnAddCliente.Size = new Size(155, 31);
            btnAddCliente.TabIndex = 9;
            btnAddCliente.Text = "Adicionar Cliente";
            btnAddCliente.UseVisualStyleBackColor = true;
            btnAddCliente.Click += btnAddCliente_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelShowAll, statusLabelFilter });
            statusStrip1.Location = new Point(0, 37);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 26);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelShowAll
            // 
            statusLabelShowAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            statusLabelShowAll.IsLink = true;
            statusLabelShowAll.LinkBehavior = LinkBehavior.HoverUnderline;
            statusLabelShowAll.Name = "statusLabelShowAll";
            statusLabelShowAll.Size = new Size(102, 20);
            statusLabelShowAll.Text = "Mostrar tudo";
            statusLabelShowAll.Click += statusLabelShowAll_Click;
            // 
            // statusLabelFilter
            // 
            statusLabelFilter.Name = "statusLabelFilter";
            statusLabelFilter.Size = new Size(0, 20);
            statusLabelFilter.Visible = false;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(0, 3);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(86, 31);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Enabled = false;
            btnConfirmar.Location = new Point(758, 4);
            btnConfirmar.Margin = new Padding(3, 4, 3, 4);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(157, 31);
            btnConfirmar.TabIndex = 5;
            btnConfirmar.Text = "Confirmar alterações";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // TelaManutencaoClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "TelaManutencaoClientes";
            Text = "Genesis Solutions";
            Load += TelaManutencaoClientes_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clienteBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsUsuario;
        private ToolStripMenuItem logoffToolStripMenuItem;
        private Button btnAddCliente;
    }
}