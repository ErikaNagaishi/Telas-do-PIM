using DataGridViewAutoFilter;

namespace Telas_do_PIM.Forms
{
    partial class TelaManutencaoFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaManutencaoFuncionario));
            funcionarioBindingSource = new BindingSource(components);
            statusStrip1 = new StatusStrip();
            statusLabelFilter = new ToolStripStatusLabel();
            statusLabelShowAll = new ToolStripStatusLabel();
            btnVoltar = new Button();
            btnConfirmar = new Button();
            dataGridView1 = new DataGridView();
            id = new DataGridViewAutoFilterTextBoxColumn();
            nome = new DataGridViewAutoFilterTextBoxColumn();
            cpf = new DataGridViewAutoFilterTextBoxColumn();
            telefone = new DataGridViewAutoFilterTextBoxColumn();
            endereco = new DataGridViewAutoFilterTextBoxColumn();
            email = new DataGridViewAutoFilterTextBoxColumn();
            senha = new DataGridViewAutoFilterTextBoxColumn();
            idPerfilDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idPerfilNavigationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            funcionarioBindingSource1 = new BindingSource(components);
            splitContainer1 = new SplitContainer();
            menuStrip1 = new MenuStrip();
            tsUsuario = new ToolStripMenuItem();
            logoffToolStripMenuItem = new ToolStripMenuItem();
            btnAddFuncionario = new Button();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelFilter, statusLabelShowAll });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelFilter
            // 
            statusLabelFilter.Name = "statusLabelFilter";
            statusLabelFilter.Size = new Size(0, 20);
            statusLabelFilter.Visible = false;
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
            // btnVoltar
            // 
            btnVoltar.Location = new Point(0, 3);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(86, 31);
            btnVoltar.TabIndex = 2;
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
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar alterações";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, nome, cpf, telefone, endereco, email, senha, idPerfilDataGridViewTextBoxColumn, idPerfilNavigationDataGridViewTextBoxColumn });
            dataGridView1.DataSource = funcionarioBindingSource1;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(914, 507);
            dataGridView1.TabIndex = 4;
            // 
            // id
            // 
            id.DataPropertyName = "Id";
            id.FilteringEnabled = false;
            id.HeaderText = "Id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.True;
            // 
            // nome
            // 
            nome.DataPropertyName = "Nome";
            nome.FilteringEnabled = false;
            nome.HeaderText = "Nome";
            nome.MinimumWidth = 6;
            nome.Name = "nome";
            nome.Resizable = DataGridViewTriState.True;
            // 
            // cpf
            // 
            cpf.DataPropertyName = "Cpf";
            cpf.FilteringEnabled = false;
            cpf.HeaderText = "Cpf";
            cpf.MinimumWidth = 6;
            cpf.Name = "cpf";
            cpf.Resizable = DataGridViewTriState.True;
            // 
            // telefone
            // 
            telefone.DataPropertyName = "Telefone";
            telefone.FilteringEnabled = false;
            telefone.HeaderText = "Telefone";
            telefone.MinimumWidth = 6;
            telefone.Name = "telefone";
            telefone.Resizable = DataGridViewTriState.True;
            // 
            // endereco
            // 
            endereco.DataPropertyName = "Endereço";
            endereco.FilteringEnabled = false;
            endereco.HeaderText = "Endereço";
            endereco.MinimumWidth = 6;
            endereco.Name = "endereco";
            endereco.Resizable = DataGridViewTriState.True;
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
            // senha
            // 
            senha.DataPropertyName = "Senha";
            senha.FilteringEnabled = false;
            senha.HeaderText = "Senha";
            senha.MinimumWidth = 6;
            senha.Name = "senha";
            senha.ReadOnly = true;
            senha.Resizable = DataGridViewTriState.True;
            senha.Visible = false;
            // 
            // idPerfilDataGridViewTextBoxColumn
            // 
            idPerfilDataGridViewTextBoxColumn.DataPropertyName = "IdPerfil";
            idPerfilDataGridViewTextBoxColumn.HeaderText = "IdPerfil";
            idPerfilDataGridViewTextBoxColumn.MinimumWidth = 6;
            idPerfilDataGridViewTextBoxColumn.Name = "idPerfilDataGridViewTextBoxColumn";
            idPerfilDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            idPerfilDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            idPerfilDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPerfilNavigationDataGridViewTextBoxColumn
            // 
            idPerfilNavigationDataGridViewTextBoxColumn.DataPropertyName = "IdPerfilNavigation";
            idPerfilNavigationDataGridViewTextBoxColumn.HeaderText = "IdPerfilNavigation";
            idPerfilNavigationDataGridViewTextBoxColumn.MinimumWidth = 6;
            idPerfilNavigationDataGridViewTextBoxColumn.Name = "idPerfilNavigationDataGridViewTextBoxColumn";
            idPerfilNavigationDataGridViewTextBoxColumn.Visible = false;
            // 
            // funcionarioBindingSource1
            // 
            funcionarioBindingSource1.DataSource = typeof(Models.Funcionario);
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
            splitContainer1.Panel2.Controls.Add(btnAddFuncionario);
            splitContainer1.Panel2.Controls.Add(btnVoltar);
            splitContainer1.Panel2.Controls.Add(btnConfirmar);
            splitContainer1.Size = new Size(914, 574);
            splitContainer1.SplitterDistance = 535;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsUsuario });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(914, 28);
            menuStrip1.TabIndex = 32;
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
            // btnAddFuncionario
            // 
            btnAddFuncionario.Location = new Point(358, 2);
            btnAddFuncionario.Margin = new Padding(3, 4, 3, 4);
            btnAddFuncionario.Name = "btnAddFuncionario";
            btnAddFuncionario.Size = new Size(177, 31);
            btnAddFuncionario.TabIndex = 10;
            btnAddFuncionario.Text = "Adicionar Funcionário";
            btnAddFuncionario.UseVisualStyleBackColor = true;
            btnAddFuncionario.Click += btnAddFuncionario_Click;
            // 
            // TelaManutencaoFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "TelaManutencaoFuncionario";
            Text = "Genesis Solutions";
            Load += TelaManutencaoAdm_Load;
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabelFilter;
        private ToolStripStatusLabel statusLabelShowAll;
        private BindingSource funcionarioBindingSource;
        private DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn id;
        private Button btnVoltar;
        private Button btnConfirmar;
        private DataGridView dataGridView1;
        private BindingSource funcionarioBindingSource1;
        private DataGridViewAutoFilterTextBoxColumn nome;
        private DataGridViewAutoFilterTextBoxColumn cpf;
        private DataGridViewAutoFilterTextBoxColumn telefone;
        private DataGridViewAutoFilterTextBoxColumn endereco;
        private DataGridViewAutoFilterTextBoxColumn email;
        private DataGridViewAutoFilterTextBoxColumn senha;
        private DataGridViewTextBoxColumn idPerfilDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idPerfilNavigationDataGridViewTextBoxColumn;
        private SplitContainer splitContainer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsUsuario;
        private ToolStripMenuItem logoffToolStripMenuItem;
        private Button btnAddFuncionario;
    }
}