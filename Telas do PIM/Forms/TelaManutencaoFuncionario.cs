using DataGridViewAutoFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using Newtonsoft.Json;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaManutencaoFuncionario : Form
    {

        private readonly GenesisSolutionsContext genesisContext;

        private List<Funcionario> funcionariosAlterados = new();
        private bool telaAnteriorSelecao = true;

        public TelaManutencaoFuncionario(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;

            dataGridView1.Sorted += dataGridView1_Sorted;

            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellClick += dataGridView1_CellClick;

            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.KeyDown += dataGridView1_KeyDown;

            dataGridView1.RowsAdded += DataGridView1_RowsAdded;
        }

        private void DataGridView1_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            CarregaImagemLixeira();
            CarregaComboBoxPerfil();
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
                var funcionario = GeraFuncionarioDeRow(currentRow);
                if (funcionario.Id.Equals(Program.funcionarioLogado.Id))
                {
                    MessageBox.Show($"Você não pode remover o seu usuário");
                    return;
                }
                switch (MessageBox.Show(this, $"Tem certeza que deseja excluir o funcionário abaixo?" +
                    $"\nNome: {funcionario.Nome}\nEmail: {funcionario.Email}\nCPF: {funcionario.Cpf}", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    case DialogResult.Yes:
                        try
                        {
                            genesisContext.ChangeTracker.Clear();

                            genesisContext.Funcionarios.Remove(funcionario);
                            genesisContext.SaveChanges();

                            dataGridView1.Rows.Remove(currentRow);
                            MessageBox.Show("Funcionário removido com sucesso");

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

        private Funcionario GeraFuncionarioDeRow(DataGridViewRow row)
        {
            var perfilValor = row.Cells["Perfil"].Value?.ToString();
            int idPerfil = 0;
            if (perfilValor != null)
                idPerfil = int.Parse(perfilValor.ToString().Split('-')[0].ToString());

            return new Funcionario()
            {
                Id = (int)row.Cells["Id"].Value,
                Nome = row.Cells["Nome"].Value.ToString(),
                Cpf = row.Cells["Cpf"].Value.ToString(),
                Telefone = row.Cells["Telefone"].Value.ToString(),
                Endereço = row.Cells["Endereco"].Value.ToString(),
                Email = row.Cells["Email"].Value.ToString(),
                Senha = row.Cells["Senha"].Value.ToString(),
                IdPerfil = idPerfil
            };
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAlteracoes(e);
        }

        private void ValidaAlteracoes(DataGridViewCellEventArgs e)
        {
            var changedRow = dataGridView1.Rows[e.RowIndex];

            var funcionario = GeraFuncionarioDeRow(changedRow);

            var funcionarioBanco = genesisContext.Funcionarios.AsNoTracking().First(e => e.Id.Equals(funcionario.Id));

            if (!(JsonConvert.SerializeObject(funcionarioBanco) == JsonConvert.SerializeObject(funcionario)))
            {
                if (funcionariosAlterados.Any(e => e.Id.Equals(funcionario.Id)))
                {
                    funcionariosAlterados.RemoveAll(e => e.Id.Equals(funcionario.Id));
                }
                funcionariosAlterados.Add(funcionario);
                btnConfirmar.Enabled = true;
            }
            else
            {
                funcionariosAlterados.RemoveAll(e => e.Id.Equals(funcionario.Id));
                if (funcionariosAlterados.Count == 0) btnConfirmar.Enabled = false;
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

        private void TelaManutencaoAdm_Load(object sender, EventArgs e)
        {

            var funcionariosTable = genesisContext.Funcionarios.AsNoTracking().ToList().ToDataTable();

            var perfis = genesisContext.Perfils.Select(e => e.Id + " - " + e.Perfil1).ToArray();

            DataGridViewComboBoxColumn perfilColuna = new();

            perfilColuna.HeaderText = "Perfil";
            perfilColuna.Name = "Perfil";
            perfilColuna.Sorted = true;

            perfilColuna.Items.AddRange(perfis);
            dataGridView1.Columns.Add(perfilColuna);

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.HeaderText = "Excluir";
            iconColumn.Name = "Excluir";
            iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;

            funcionarioBindingSource.DataSource = funcionariosTable;

            dataGridView1.Columns.Add(iconColumn);
            dataGridView1.DataSource = funcionarioBindingSource;

            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            CarregaImagemLixeira();
            CarregaComboBoxPerfil();

            EnableGridFilter(true);
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            CarregaImagemLixeira();
            CarregaComboBoxPerfil();
        }
        private void CarregaImagemLixeira()
        {
            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
            {
                dataGridView1.Rows[row].Cells["Excluir"].Value = trashBinIcon;
            }
        }
        private void CarregaComboBoxPerfil()
        {
            var funcionarios = genesisContext.Funcionarios.AsNoTracking().ToList();
            var perfis = genesisContext.Perfils.ToList();

            for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
            {
                var funcionario = GeraFuncionarioDeRow(dataGridView1.Rows[row]);

                if (funcionariosAlterados.Any(e => e.Id.Equals(funcionario.Id)))
                {
                    var funcionarioAlterado = funcionariosAlterados.First(e => e.Id.Equals(funcionario.Id));
                    var idPerfil = funcionarioAlterado.IdPerfil;

                    dataGridView1.Rows[row].Cells["Perfil"].Value = idPerfil + " - " + perfis.First(e => e.Id.Equals(idPerfil)).Perfil1;
                }
                else
                {
                    var idPerfil = funcionarios.First(e => e.Id.Equals(funcionario.Id)).IdPerfil;

                    dataGridView1.Rows[row].Cells["Perfil"].Value = idPerfil + " - " + perfis.First(e => e.Id.Equals(idPerfil)).Perfil1;
                }
            }
        }
        private void EnableGridFilter(bool value)
        {
            id.FilteringEnabled = value;
            nome.FilteringEnabled = value;
            cpf.FilteringEnabled = value;
            telefone.FilteringEnabled = value;
            endereco.FilteringEnabled = value;
            email.FilteringEnabled = value;
        }

        private void statusLabelShowAll_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterTextBoxColumn.RemoveFilter(dataGridView1);
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
            if (telaAnteriorSelecao)
            {
                using (var fmTelaDeSelecao = Program.ServiceProvider.GetRequiredService<TelaDeSelecao>())
                {
                    this.Hide();
                    fmTelaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaDeSelecao.ShowDialog();
                }
            }
            else
            {
                using (var fmTelaDeManutencaoClientes = Program.ServiceProvider.GetRequiredService<TelaManutencaoClientes>())
                {
                    this.Hide();
                    fmTelaDeManutencaoClientes.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaDeManutencaoClientes.ShowDialog();
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, $"Tem certeza que deseja atualizar {funcionariosAlterados.Count} registros?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                case DialogResult.Yes:
                    try
                    {
                        genesisContext.Funcionarios.UpdateRange(funcionariosAlterados);
                        genesisContext.SaveChanges();
                        btnConfirmar.Enabled = false;
                        funcionariosAlterados.Clear();
                        MessageBox.Show("Alteração realizada com sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar funcionários\n{ex.Message}");
                    }
                    break;
            }
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

        private void btnAddFuncionario_Click(object sender, EventArgs e)
        {
            using (var fmTelaCadastroFuncionario = Program.ServiceProvider.GetRequiredService<TelaCadastroFuncionario>())
            {
                this.Hide();
                fmTelaCadastroFuncionario.StartPosition = FormStartPosition.CenterScreen;
                fmTelaCadastroFuncionario.telaAnteriorSelecao = false;
                fmTelaCadastroFuncionario.ShowDialog();
            }
        }
    }
}
