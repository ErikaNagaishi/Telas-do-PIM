using Microsoft.EntityFrameworkCore;
using System.Threading;
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
            var categorias = genesisContext.Categorizacaos.AsNoTracking().Select(e => e.IdCategorizacao + " - " + e.Nome).ToArray();
            InitializeComponent();

            comboBoxCategoria.Items.AddRange(categorias);

        }

        public List<Produto> ProdutosCadastrados { get => produtosCadastrados; }

        [STAThread]
        private void btnImagem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => {
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
            }); 
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join(); //Wait for the thread to end


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
                        && imagemProduto != null
                        && comboBoxCategoria.SelectedIndex > 0)
                    {
                        var idCategoria = int.Parse(comboBoxCategoria.SelectedItem.ToString().Split('-')[0].ToString());
                        var produto = new Produto()
                        {
                            ValorVenda = upDownValor.Value,
                            NomeProduto = comboxNome.Text,
                            QtdEmEstoque = (int)upDownEstoque.Value,
                            ImagemProduto = imagemProduto,
                            IdCategorizacao = idCategoria
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
