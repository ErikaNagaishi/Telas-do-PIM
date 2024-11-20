using Microsoft.EntityFrameworkCore;
using System.Data;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCarregamentoProdutos : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        public TelaCarregamentoProdutos(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(this.comboBoxProduto.SelectedIndex != -1 && upDownCaixas.Value > 0)
            {
                var id = int.Parse(comboBoxProduto.SelectedItem.ToString().Split('-')[0].Trim());

                var produto = genesisContext.Produtos.First(a => a.IdProduto.Equals(id));
                produto.QtdEmEstoque += (int)upDownCaixas.Value;

                genesisContext.Produtos.Update(produto);
                genesisContext.SaveChanges();

                this.comboBoxProduto.SelectedIndex = -1;
                this.upDownCaixas.Value = 0;
                MessageBox.Show("Carregamento adicionado com sucesso");
            }
            else
            {
                MessageBox.Show("Todos os campos são obrigatórios");
            }
        }

        private void TelaCarregamentoProdutos_Load(object sender, EventArgs e)
        {
            var produtos = genesisContext.Produtos.AsNoTracking();

            this.comboBoxProduto.Items.AddRange(produtos.Select(e => e.IdProduto + " - " + e.NomeProduto).ToArray());
        }
    }
}
