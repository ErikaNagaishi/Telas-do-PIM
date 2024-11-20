using System.Threading;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaAtualizaImagemProduto : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private string? arquivoProduto = null;
        private byte[]? imagemProduto = null;

        public Produto produto = null;
        public bool produtoAlterado = false;

        public TelaAtualizaImagemProduto(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();

        }


        private void btnImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Abrir imagem";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG"; // custom filterthread.SetApartmentState(ApartmentState.STA)
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

                    if (imagemProduto != null && produto != null)
                    {
                        produto.ImagemProduto = imagemProduto;
                        genesisContext.Produtos.Update(produto);
                        genesisContext.SaveChanges();
                        MessageBox.Show("Imagem atualizada com sucesso");

                        pictureProduto.Image = null;
                        produtoAlterado = true;
                    }
                    else
                    {
                        MessageBox.Show("Todos os campos são obrigatórios");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível atualizar a imagem");
                }
            }

        }
    }
}
