using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCadastroProduto : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private string? arquivoProduto = null;
        private byte[]? imagemProduto = null;

        private List<Produto> produtosCadastrados = new();
        public TelaCadastroProduto(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
        }

        public List<Produto> ProdutosCadastrados { get => produtosCadastrados; }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Abrir imagem";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.JPEG)|*.BMP;*.JPG;*.JPEG"; // custom filter

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        arquivoProduto = dlg.FileName;
                        pictureProduto.Image = new Bitmap(arquivoProduto);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível carregar a imagem");
                    }
                }
            }
            
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            if (arquivoProduto != null)
            {
                try
                {
                    FileStream fs = new FileStream(arquivoProduto, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imagemProduto = br.ReadBytes((int)fs.Length);

                    if (upDownValor.Value > 0 &&
                        !string.IsNullOrEmpty(comboxNome.Text) &&
                        upDownEstoque.Value > 0
                        && imagemProduto != null)
                    {
                        var produto = new Produto()
                        {
                            ValorVenda = upDownValor.Value,
                            NomeProduto = comboxNome.Text,
                            QtdEmEstoque = (int)upDownEstoque.Value,
                            ImagemProduto = imagemProduto
                        };

                        genesisContext.Produtos.Add(produto);
                        genesisContext.SaveChanges();
                        produtosCadastrados.Add(produto);
                        MessageBox.Show("Produto cadastrado com sucesso");

                        upDownValor.Value = 0;
                        comboxNome.Text = null;
                        upDownEstoque.Value = 0;
                        pictureProduto.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Todos os campos são obrigatórios");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível cadastrar o produto");
                }
            }

        }
    }
}
