using DataGridViewAutoFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoreLinq;
using Newtonsoft.Json;
using System.Data;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaManutencaoProdutos : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private List<Produto> produtosAlterados = new();
        private bool telaAnteriorSelecao = true;

        public TelaManutencaoProdutos(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

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
                var produto = GeraProdutoDeRow(currentRow);
                switch (MessageBox.Show(this, $"Tem certeza que deseja excluir o produto abaixo?" +
                    $"\nNome: {produto.NomeProduto}\nQtd em estoque: {produto.QtdEmEstoque}", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {

                    case DialogResult.Yes:
                        try
                        {
                            genesisContext.ChangeTracker.Clear();

                            genesisContext.Produtos.Remove(produto);
                            genesisContext.SaveChanges();

                            dataGridView1.Rows.Remove(currentRow);
                            MessageBox.Show("Produto removido com sucesso");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Erro ao remover produto\n{ex.Message}");
                        }
                        break;
                }
            }
            return;

        }
        private Produto GeraProdutoDeRow(DataGridViewRow row)
        {
            return new Produto()
            {
                IdProduto = (int)row.Cells["idProduto"].Value,
                NomeProduto = row.Cells["nomeProduto"].Value.ToString(),
                QtdEmEstoque = (int)row.Cells["qtdEmEstoque"].Value,
                ValorVenda = (decimal)row.Cells["valorVenda"].Value
            };
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ValidaAlteracoes(e);
        }
        private void ValidaAlteracoes(DataGridViewCellEventArgs e)
        {
            var changedRow = dataGridView1.Rows[e.RowIndex];

            var produto = GeraProdutoDeRow(changedRow);

            var produtoBanco = genesisContext.Produtos.AsNoTracking().First(e => e.IdProduto.Equals(produto.IdProduto));

            if (!(JsonConvert.SerializeObject(produtoBanco) == JsonConvert.SerializeObject(produto)))
            {
                if (produtosAlterados.Any(e => e.IdProduto.Equals(produto.IdProduto)))
                {
                    produtosAlterados.RemoveAll(e => e.IdProduto.Equals(produto.IdProduto));
                }
                produtosAlterados.Add(produto);
                btnConfirmar.Enabled = true;
            }
            else
            {
                produtosAlterados.RemoveAll(e => e.IdProduto.Equals(produto.IdProduto));
                if (produtosAlterados.Count == 0) btnConfirmar.Enabled = false;
            }
        }
        private void btnAddProduto_Click(object sender, EventArgs e)
        {
            using (var formCadastroProduto = Program.ServiceProvider.GetRequiredService<TelaCadastroProduto>())
            {
                //this.Hide();
                formCadastroProduto.StartPosition = FormStartPosition.CenterScreen;
                formCadastroProduto.ShowDialog();
                var qtdProdutosInseridos = formCadastroProduto.ProdutosCadastrados.Count;
                //Caso algum produto tenha sido adicionado, será adicionado as informações no datagrid do form
                if (qtdProdutosInseridos > 0)
                {
                    //    var produtosBanco = genesisContext.Produtos.AsNoTracking();
                    //    var produtos = produtosBanco.OrderByDescending(e=> e.IdProduto).Skip(Math.Max(0, produtosBanco.Count() - qtdProdutosInseridos));
                    //    foreach (var produto in formCadastroProduto.ProdutosCadastrados)
                    //    {
                    //        var ultimoId = produtos.First(e => e.NomeProduto.Equals(produto.NomeProduto)).IdProduto;
                    //        Byte[] data = new Byte[0];
                    //        data = (Byte[])(produto.ImagemProduto);
                    //        MemoryStream mem = new MemoryStream(data);

                    //        dataGridView1.Rows.Add(ultimoId, produto.NomeProduto, produto.ValorVenda, produto.QtdEmEstoque, Image.FromStream(mem));
                    //    }
                    using (var fmTelaManutencaoProduto = Program.ServiceProvider.GetRequiredService<TelaManutencaoProdutos>())
                    {
                        this.Hide();
                        fmTelaManutencaoProduto.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaManutencaoProduto.ShowDialog();
                    }
                }
            }
        }

        private void addBtnCarregamento_Click(object sender, EventArgs e)
        {
            using (var fmTelaAdicionarCarregamento = Program.ServiceProvider.GetRequiredService<TelaCarregamentoProdutos>())
            {
                fmTelaAdicionarCarregamento.StartPosition = FormStartPosition.CenterScreen;
                fmTelaAdicionarCarregamento.ShowDialog();

                using (var fmTelaManutencaoProduto = Program.ServiceProvider.GetRequiredService<TelaManutencaoProdutos>())
                {
                    this.Hide();
                    fmTelaManutencaoProduto.StartPosition = FormStartPosition.CenterScreen;
                    fmTelaManutencaoProduto.ShowDialog();
                }
            }
        }
        private void EnableGridFilter(bool value)
        {
            idProduto.FilteringEnabled = value;
            nomeProduto.FilteringEnabled = value;
            valorVenda.FilteringEnabled = value;
            qtdEmEstoque.FilteringEnabled = value;
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
            using (var fmTelaDeSelecao = Program.ServiceProvider.GetRequiredService<TelaDeSelecao>())
            {
                this.Hide();
                fmTelaDeSelecao.StartPosition = FormStartPosition.CenterScreen;
                fmTelaDeSelecao.ShowDialog();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, $"Tem certeza que deseja atualizar {produtosAlterados.Count} registros?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                case DialogResult.Yes:
                    try
                    {
                        genesisContext.Produtos.UpdateRange(produtosAlterados);
                        genesisContext.SaveChanges();
                        btnConfirmar.Enabled = false;
                        produtosAlterados.Clear();
                        MessageBox.Show("Alteração realizada com sucesso");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar funcionários\n{ex.Message}");
                    }
                    break;
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
        private void CarregaImagemProdutos()
        {
            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
            {
                dataGridView1.Rows[row].Cells["Excluir"].Value = trashBinIcon;

                //System.Drawing.Bitmap bitmap = null;
                //ImageConverter converter = new ImageConverter();
                //System.Drawing.Image img =
                //(System.Drawing.Image)converter.ConvertFrom(arr);
                //bitmap = (System.Drawing.Bitmap)img;
            }
        }
        private void TelaMnatuencaoProdutos_Load(object sender, EventArgs e)
        {
            var produtosTable = genesisContext.Produtos.AsNoTracking().ToList().ToDataTable();

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.HeaderText = "Excluir";
            iconColumn.Name = "Excluir";
            iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;

            produtoBindingSource.DataSource = produtosTable;

            dataGridView1.Columns.Add(iconColumn);
            dataGridView1.DataSource = produtoBindingSource;

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
    }
}
