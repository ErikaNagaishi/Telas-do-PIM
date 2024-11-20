using System.Threading;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroCategoria : Form
    {
        private readonly GenesisSolutionsContext genesisContext;

        private List<Categorizacao> categoriasCadastradas = new();
        public TelaCadastroCategoria(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
        }

        public List<Categorizacao> CategoriasCadastradas { get => categoriasCadastradas; }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                    !string.IsNullOrEmpty(comboxNome.Text))
                {
                    var categoria = new Categorizacao()
                    {
                        Nome = comboxNome.Text
                    };

                    genesisContext.Categorizacaos.Add(categoria);
                    genesisContext.SaveChanges();
                    categoriasCadastradas.Add(categoria);
                    MessageBox.Show("Categoria cadastrada com sucesso");

                    comboxNome.Text = null;
                }
                else
                {
                    MessageBox.Show("Todos os campos são obrigatórios");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar a categoria");
            }

        }
    }
}
