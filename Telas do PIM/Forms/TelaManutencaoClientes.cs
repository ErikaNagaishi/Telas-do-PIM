using DataGridViewAutoFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaManutencaoClientes : Form
    {
        private readonly TelaDeSelecao _telaDeSelecao;

        private readonly GenesisSolutionsContext genesisContext;
        private List<Cliente> clienteAlterados = new();
        public TelaManutencaoClientes(GenesisSolutionsContext genesisSolutionsContext, TelaDeSelecao telaDeSelecao)
        {
            _telaDeSelecao = telaDeSelecao;
            genesisContext = genesisSolutionsContext;
            InitializeComponent();

            FormClosing += FormClosingAction;

            dataGridView1.Sorted += dataGridView1_Sorted;

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.RowsAdded += DataGridView1_RowsAdded;

            tsUsuario.Text = Program.funcionarioLogado.Nome;
        }

        private void DataGridView1_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            CarregaImagemLixeira();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewCheckBoxCell cell = this.dataGridView1.CurrentCell as DataGridViewCheckBoxCell;

            if (cell != null && !cell.ReadOnly)
            {
                cell.Value = cell.Value == null || !((bool)cell.Value);
                ValidaAlteracoes(e);
            }
            var currentRow = dataGridView1.Rows[e.RowIndex];
            var currentColumn = dataGridView1.Columns[e.ColumnIndex];

            if (currentRow != null && currentColumn != null && currentColumn.HeaderText == "Excluir")
            {
                var clinte = GeraClienteDeRow(currentRow);
                switch (MessageBox.Show(this, $"Tem certeza que deseja excluir o cliente abaixo?" +
                    $"\nNome: {clinte.RazaoSocial}\nEmail: {clinte.Email}\nCNPJ: {clinte.CnpjCliente}", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    case DialogResult.Yes:
                        try
                        {
                            genesisContext.ChangeTracker.Clear();

                            genesisContext.Clientes.Remove(clinte);
                            genesisContext.SaveChanges();

                            dataGridView1.Rows.Remove(currentRow);
                            MessageBox.Show("Cliente removido com sucesso");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao remover funcionário\n{ex.Message}");
                        }
                        break;
                }
            }
            return;

        }

        private Cliente GeraClienteDeRow(DataGridViewRow row)
        {
            return new Cliente()
            {
                IdCliente = (int)row.Cells["id"].Value,
                RazaoSocial = row.Cells["razaoSocial"].Value.ToString(),
                CnpjCliente = row.Cells["cnpj"].Value.ToString(),
                EnderecoCliente = row.Cells["endereco"].Value.ToString(),
                Email = row.Cells["email"].Value.ToString(),
                SenhaCliente = row.Cells["senha"].Value.ToString(),
                Cep = row.Cells["Cep"].Value.ToString(),
                Numero = row.Cells["numero"].Value.ToString()
            };
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAlteracoes(e);
        }

        private void ValidaAlteracoes(DataGridViewCellEventArgs e)
        {
            var changedRow = dataGridView1.Rows[e.RowIndex];

            var cliente = GeraClienteDeRow(changedRow);

            var clienteBanco = genesisContext.Clientes.AsNoTracking().First(e => e.IdCliente.Equals(cliente.IdCliente));

            if (!(JsonConvert.SerializeObject(clienteBanco) == JsonConvert.SerializeObject(cliente)))
            {
                if (clienteAlterados.Any(e => e.IdCliente.Equals(cliente.IdCliente)))
                {
                    clienteAlterados.RemoveAll(e => e.IdCliente.Equals(cliente.IdCliente));
                }
                clienteAlterados.Add(cliente);
                btnConfirmar.Enabled = true;
            }
            else
            {
                clienteAlterados.RemoveAll(e => e.IdCliente.Equals(cliente.IdCliente));
                if (clienteAlterados.Count == 0) btnConfirmar.Enabled = false;
            }
        }

        private void FormClosingAction(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                switch (MessageBox.Show(this, "Tem certeza que deseja encerrar?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //Stay on this form
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    default:
                        try
                        {
                            Application.Exit();
                        }
                        catch
                        {
                            Application.Exit();
                        }
                        break;
                }
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            CarregaImagemLixeira();
        }
        private void CarregaImagemLixeira()
        {
            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            bool existeExcluir = false;
            for (int column = 0; column <= dataGridView1.Columns.Count - 1; column++)
            {
                if (dataGridView1.Columns[column].Name == "Excluir")
                {
                    existeExcluir = true;
                    break;
                }
            }

            if (!existeExcluir)
            {
                return;
            }

            for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
            {
                dataGridView1.Rows[row].Cells["Excluir"].Value = trashBinIcon;
            }
        }
        private void EnableGridFilter(bool value)
        {
            id.FilteringEnabled = value;
            razaoSocial.FilteringEnabled = value;
            cnpj.FilteringEnabled = value;
            endereco.FilteringEnabled = value;
            Cep.FilteringEnabled = value;
            email.FilteringEnabled = value;
        }


        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(dataGridView1);
            if (string.IsNullOrEmpty(filterStatus))
            {
                statusLabelShowAll.Visible = false;
                statusLabelFilter.Visible = false;
            }
            else
            {
                statusLabelShowAll.Visible = true;
                statusLabelFilter.Visible = true;
                statusLabelFilter.Text = filterStatus;
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt
            && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            && dataGridView1.CurrentCell != null
            && dataGridView1.CurrentCell.OwningColumn.HeaderCell is DataGridViewAutoFilterColumnHeaderCell filterCell)
            {
                filterCell.ShowDropDownList();
                e.Handled = true;
            }
        }
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            _telaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
            _telaDeSelecao.ShowDialog();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, $"Tem certeza que deseja atualizar {clienteAlterados.Count} registros?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                case DialogResult.Yes:
                    try
                    {
                        genesisContext.Clientes.UpdateRange(clienteAlterados);
                        genesisContext.SaveChanges();
                        btnConfirmar.Enabled = false;
                        clienteAlterados.Clear();
                        MessageBox.Show("Alteração realizada com sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar clientes\n{ex.Message}");
                    }
                    break;
            }
        }
        private void statusLabelShowAll_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(dataGridView1);
        }

        private void TelaManutencaoClientes_Load(object sender, EventArgs e)
        {
            var ClientesTable = genesisContext.Clientes.AsNoTracking().ToList().ToDataTable();

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.HeaderText = "Excluir";
            iconColumn.Name = "Excluir";
            iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;

            clienteBindingSource.DataSource = ClientesTable;

            dataGridView1.Columns.Add(iconColumn);
            dataGridView1.DataSource = clienteBindingSource;

            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            CarregaImagemLixeira();

            EnableGridFilter(true);
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.funcionarioLogado = null;

            using (var fmTelaDeLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaDeLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaDeLogin.ShowDialog();
            }
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroCliente = Program.ServiceProvider.GetRequiredService<TelaCadastroCliente>())
            {
                this.Hide();
                fmTelaCadastroCliente.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroCliente.telaAnteriorSelecao = false;
                fmTelaCadastroCliente.ShowDialog();
            }
        }
    }
}
