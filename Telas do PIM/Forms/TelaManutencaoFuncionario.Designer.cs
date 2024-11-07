using DataGridViewAutoFilter;
using Telas_do_PIM.configuration;

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
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabelFilter, statusLabelShowAll });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelFilter
            // 
            statusLabelFilter.Name = "statusLabelFilter";
            statusLabelFilter.Size = new Size(0, 17);
            statusLabelFilter.Visible = false;
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
            // btnVoltar
            // 
            btnVoltar.Location = new Point(0, 2);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(75, 23);
            btnVoltar.TabIndex = 2;
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
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 399);
            dataGridView1.TabIndex = 4;
            // 
            // id
            // 
            id.DataPropertyName = "Id";
            id.FilteringEnabled = false;
            id.HeaderText = "Id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Resizable = DataGridViewTriState.True;
            // 
            // nome
            // 
            nome.DataPropertyName = "Nome";
            nome.FilteringEnabled = false;
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            nome.Resizable = DataGridViewTriState.True;
            // 
            // cpf
            // 
            cpf.DataPropertyName = "Cpf";
            cpf.FilteringEnabled = false;
            cpf.HeaderText = "Cpf";
            cpf.Name = "cpf";
            cpf.Resizable = DataGridViewTriState.True;
            // 
            // telefone
            // 
            telefone.DataPropertyName = "Telefone";
            telefone.FilteringEnabled = false;
            telefone.HeaderText = "Telefone";
            telefone.Name = "telefone";
            telefone.Resizable = DataGridViewTriState.True;
            // 
            // endereco
            // 
            endereco.DataPropertyName = "Endereço";
            endereco.FilteringEnabled = false;
            endereco.HeaderText = "Endereço";
            endereco.Name = "endereco";
            endereco.Resizable = DataGridViewTriState.True;
            // 
            // email
            // 
            email.DataPropertyName = "Email";
            email.FilteringEnabled = false;
            email.HeaderText = "Email";
            email.Name = "email";
            email.Resizable = DataGridViewTriState.True;
            // 
            // senha
            // 
            senha.DataPropertyName = "Senha";
            senha.FilteringEnabled = false;
            senha.HeaderText = "Senha";
            senha.Name = "senha";
            senha.ReadOnly = true;
            senha.Resizable = DataGridViewTriState.True;
            senha.Visible = false;
            // 
            // idPerfilDataGridViewTextBoxColumn
            // 
            idPerfilDataGridViewTextBoxColumn.DataPropertyName = "IdPerfil";
            idPerfilDataGridViewTextBoxColumn.HeaderText = "IdPerfil";
            idPerfilDataGridViewTextBoxColumn.Name = "idPerfilDataGridViewTextBoxColumn";
            idPerfilDataGridViewTextBoxColumn.Resizable = DataGridViewTriState.True;
            idPerfilDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            idPerfilDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPerfilNavigationDataGridViewTextBoxColumn
            // 
            idPerfilNavigationDataGridViewTextBoxColumn.DataPropertyName = "IdPerfilNavigation";
            idPerfilNavigationDataGridViewTextBoxColumn.HeaderText = "IdPerfilNavigation";
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
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnVoltar);
            splitContainer1.Panel2.Controls.Add(btnConfirmar);
            splitContainer1.Size = new Size(800, 428);
            splitContainer1.SplitterDistance = 399;
            splitContainer1.TabIndex = 5;
            // 
            // TelaManutencaoFuncionario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Name = "TelaManutencaoFuncionario";
            Text = "TelaManutencaoAdm";
            Load += TelaManutencaoAdm_Load;
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)funcionarioBindingSource1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
    }
}