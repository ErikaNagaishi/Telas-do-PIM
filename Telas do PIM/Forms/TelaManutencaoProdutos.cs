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
            dataGridView1.Sorted += dataGridView1_Sorted;

            dataGridView1.RowsAdded += DataGridView1_RowsAdded;

            tsUsuario.Text = Program.funcionarioLogado.Nome;
        }

        private void dataGridView1_Sorted(object? sender, EventArgs e)
        {
            CarregaComboBoxCategoria();
        }

        private void DataGridView1_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            //CarregaComboBoxCategoria();
            CarregaImagemLixeira();
        }
        [STAThread]
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

                            produto.Excluido = true;
                            genesisContext.Produtos.Update(produto);
                            genesisContext.SaveChanges();

                            genesisContext.ChangeTracker.Clear();
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
            var categoriaValor = row.Cells["Categoria"].Value?.ToString();
            int idCategoria = 0;
            if (categoriaValor != null)
                idCategoria = int.Parse(categoriaValor.ToString().Split('-')[0].ToString());
            byte[] imagemEmByte;

            try
            {
                imagemEmByte = (byte[])row.Cells["ImagemProduto"].Value;
            }
            catch
            {
                imagemEmByte = null;
            }

            return new Produto()
            {
                IdProduto = (int)row.Cells["idProduto"].Value,
                NomeProduto = row.Cells["nomeProduto"].Value.ToString(),
                QtdEmEstoque = (int)row.Cells["qtdEmEstoque"].Value,
                ValorVenda = (decimal)row.Cells["valorVenda"].Value,
                ImagemProduto = (imagemEmByte is not null) ? imagemEmByte : null,
                IdCategorizacao = idCategoria
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

            if (!IsEqualTo(produtoBanco, produto))
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
        public bool IsEqualTo(Produto a, Produto b)
        {
            foreach (var prop in typeof(Produto).GetProperties())
            {
                var value1 = prop.GetValue(a);
                var value2 = prop.GetValue(b);

                if (value1.GetType().Name.Contains("Proxy"))
                    continue;

                if (!value1.Equals(value2))
                {
                    return false;
                }
            }
            return true;
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
            CarregaComboBoxCategoria();
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
                        genesisContext.ChangeTracker.Clear();
                        genesisContext.Produtos.UpdateRange(produtosAlterados);
                        genesisContext.SaveChanges();
                        genesisContext.ChangeTracker.Clear();
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
            }
        }
        private void TelaMnatuencaoProdutos_Load(object sender, EventArgs e)
        {
            var produtosTable = genesisContext.Produtos.AsNoTracking().ToList().Where(e => !e.Excluido).ToDataTable();

            var categorias = genesisContext.Categorizacaos.AsNoTracking().Select(e => e.IdCategorizacao + " - " + e.Nome).ToArray();

            DataGridViewComboBoxColumn categoriaColuna = new();

            categoriaColuna.HeaderText = "Categoria";
            categoriaColuna.Name = "Categoria";
            categoriaColuna.Sorted = true;

            categoriaColuna.Items.AddRange(categorias);
            dataGridView1.Columns.Add(categoriaColuna);

            DataGridViewImageColumn iconColumn = new DataGridViewImageColumn();
            iconColumn.HeaderText = "Excluir";
            iconColumn.Name = "Excluir";
            iconColumn.ImageLayout = DataGridViewImageCellLayout.Normal;

            produtoBindingSource.DataSource = produtosTable;

            dataGridView1.Columns.Add(iconColumn);
            dataGridView1.DataSource = produtoBindingSource;

            Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

            CarregaImagemLixeira();
            //CarregaComboBoxCategoria();

            EnableGridFilter(true);
        }

        private void CarregaComboBoxCategoria()
        {
            var produtos = genesisContext.Produtos.AsNoTracking().ToList().Where(e => !e.Excluido);
            var categorias = genesisContext.Categorizacaos.AsNoTracking().ToList();

            if (categorias.Count > 0)
            {
                for (int row = 0; row <= dataGridView1.Rows.Count - 1; row++)
                {
                    var produto = GeraProdutoDeRow(dataGridView1.Rows[row]);

                    if (produtosAlterados.Any(e => e.IdProduto.Equals(produto.IdProduto)))
                    {
                        var produtooAlterado = produtosAlterados.First(e => e.IdProduto.Equals(produto.IdProduto));
                        var idCategoria = produtooAlterado.IdCategorizacao;

                        dataGridView1.Rows[row].Cells["Categoria"].Value = idCategoria + " - " + categorias.First(e => e.IdCategorizacao.Equals(idCategoria)).Nome;
                    }
                    else
                    {
                        var idCategoria = produtos.FirstOrDefault(e => e.IdProduto.Equals(produto.IdProduto))?.IdCategorizacao;

                        if (idCategoria != null)
                            dataGridView1.Rows[row].Cells["Categoria"].Value = idCategoria + " - " + categorias.First(e => e.IdCategorizacao.Equals(idCategoria)).Nome;
                    }
                }
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

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            using (var formCadastroCategoria = Program.ServiceProvider.GetRequiredService<TelaCadastroCategoria>())
            {
                formCadastroCategoria.StartPosition = FormStartPosition.CenterScreen;
                formCadastroCategoria.ShowDialog();
                var qtdCategoriasInseridas = formCadastroCategoria.CategoriasCadastradas.Count;
                //Caso algum produto tenha sido adicionado, será adicionado as informações no datagrid do form
                if (qtdCategoriasInseridas > 0)
                {
                    using (var fmTelaManutencaoProduto = Program.ServiceProvider.GetRequiredService<TelaManutencaoProdutos>())
                    {
                        this.Hide();
                        fmTelaManutencaoProduto.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaManutencaoProduto.ShowDialog();
                    }
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var currentRow = dataGridView1.Rows[e.RowIndex];
            var currentColumn = dataGridView1.Columns[e.ColumnIndex];
            if (currentRow != null && currentColumn != null && currentColumn.HeaderText == "ImagemProduto")
            {
                var produto = GeraProdutoDeRow(currentRow);


                string? arquivoProduto = null;
                byte[]? imagemProduto = null;
                try
                {
                    using (var fmTelaAtualizaImagemProduto = Program.ServiceProvider.GetRequiredService<TelaAtualizaImagemProduto>())
                    {
                        //this.Hide();
                        fmTelaAtualizaImagemProduto.StartPosition = FormStartPosition.CenterScreen;
                        fmTelaAtualizaImagemProduto.produto = produto;
                        fmTelaAtualizaImagemProduto.ShowDialog();

                        if (fmTelaAtualizaImagemProduto.produtoAlterado)
                        {
                            using (var fmTelaManutencaoProduto = Program.ServiceProvider.GetRequiredService<TelaManutencaoProdutos>())
                            {
                                this.Hide();
                                fmTelaManutencaoProduto.StartPosition = FormStartPosition.CenterScreen;
                                fmTelaManutencaoProduto.ShowDialog();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possível carregar a imagem");
                }
            }
        }
    }
}
