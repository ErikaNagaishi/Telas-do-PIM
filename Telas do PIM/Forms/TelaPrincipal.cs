using MercadoPago.Client.Payment;
using MercadoPago.Client;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telas_do_PIM.Models;
using Telas_do_PIM.UserControls;
using QRCoder;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;

namespace Telas_do_PIM.Forms
{
    public partial class TelaPrincipal : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private decimal valorTotal = 0;
        private List<UCProduto> carrinho = new();
        private List<UCProduto> ucProdutos = new();
        Bitmap bitmap;
        public TelaPrincipal(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;
            dgvCarrinho.CellClick += dgvCarrinho_CellClick;
            this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }

        private void btnInformacoes_Click(object sender, EventArgs e)
        {
            painelInformacoes.BringToFront();
        }

        private void dgvCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;


            var currentRow = dgvCarrinho.Rows[e.RowIndex];
            var currentColumn = dgvCarrinho.Columns[e.ColumnIndex];

            if (currentRow != null && currentColumn != null && currentColumn.HeaderText == "#")
            {
                var produto = GeraProdutoDeRow(currentRow);

                var produtoDoCarrinho = carrinho.Find(x => produto.Nome.Equals(x.Nome));
                var ucProduto = ucProdutos.Find(x => produto.Nome.Equals(x.Nome));

                produtoDoCarrinho.MaxQtdUpDown = produtoDoCarrinho.MaxQtd;
                produtoDoCarrinho.NumericUpDown = produtoDoCarrinho.MaxQtd;
                produtoDoCarrinho.ValorTotal = 0;
                produtoDoCarrinho.Qtd = 0;

                ucProduto.MaxQtdUpDown = ucProduto.MaxQtd;
                ucProduto.NumericUpDown = ucProduto.MaxQtd;
                ucProduto.ValorTotal = 0;
                ucProduto.Qtd = 0;

                this.CarregaProdutos();
                ucProdutos.Remove(ucProduto);
                carrinho.Remove(produtoDoCarrinho);

                if (carrinho.Count == 0)
                    btnComprar.Enabled = false;

                for (int i = 0; i < dgvCarrinho.Rows.Count; i++)
                {
                    var row = dgvCarrinho.Rows[i];
                    if (row.Cells["Item"].Value.ToString() == produto.Nome)
                    {
                        var valor = decimal.Parse(row.Cells["Valor"].Value.ToString());

                        this.valorTotal -= valor;
                        this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

                        dgvCarrinho.Rows.Remove(row);
                        break;
                    }
                }
            }
            return;

        }

        private UCProduto GeraProdutoDeRow(DataGridViewRow currentRow)
        {
            var nome = currentRow.Cells["Item"].Value;

            return carrinho.First(e => e.Nome == nome);
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            painelCatalogo.BringToFront();
            CarregaProdutos();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {

        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

            painelInformacoes.BringToFront();
        }

        private void CarregaProdutos()
        {
            string? filtro = "";
            if (textBoxPesquisa.Text.Length == 1) return;

            if (textBoxPesquisa.Text.Length == 0) filtro = null;

            else filtro = textBoxPesquisa.Text;

            List<Produto> produtos = new();
            if (filtro == null)
                produtos = genesisContext.Produtos.AsNoTracking().ToList();
            else
                produtos = genesisContext.Produtos.AsNoTracking()
                                    .Where(e => e.NomeProduto.ToLower().Contains(filtro.ToLower())).ToList();

            List<List<Produto>> rowProdutos = new();

            //Agrupar os produtos de 2 em dois para separa-los por duas colunas
            rowProdutos = produtos.Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / 2)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();

            ucProdutos.Clear();
            tableProdutos.Controls.Clear();
            tableProdutos.RowStyles.RemoveAt(0);
            rowProdutos.ForEach(x =>
            {
                tableProdutos.RowCount = tableProdutos.RowCount + 1;
                tableProdutos.RowStyles.Add(new RowStyle() { SizeType = SizeType.AutoSize });
                int coluna = 0;
                x.ForEach(a =>
                {
                    MemoryStream mStream = new MemoryStream();
                    mStream.Write(a.ImagemProduto, 0, Convert.ToInt32(a.ImagemProduto.Length));
                    Bitmap bm = new Bitmap(mStream, false);

                    var produtoEmCarrinho = carrinho.Find(e => e.Nome.Equals(a.NomeProduto));

                    if (produtoEmCarrinho is not null)
                    {
                        var maxQtd = produtoEmCarrinho.MaxQtdUpDown;
                        var qtd = produtoEmCarrinho.Qtd;

                        var ucProduto = new UCProduto(a.NomeProduto, a.ValorVenda, maxQtd, qtd, bm, this);
                        tableProdutos.Controls.Add(ucProduto, coluna, tableProdutos.RowCount - 1);

                        ucProdutos.Add(ucProduto);
                    }
                    else
                    {
                        tableProdutos.Controls.Add(new UCProduto(a.NomeProduto, a.ValorVenda, a.QtdEmEstoque, 0, bm, this), coluna, tableProdutos.RowCount - 1);

                        var ucProduto = new UCProduto(a.NomeProduto, a.ValorVenda, a.QtdEmEstoque, 0, bm, this);
                        ucProdutos.Add(ucProduto);
                    }

                    coluna++;
                });
            });

            //Desabilitar barra de rolagem horizontal
            tableProdutos.AutoScroll = false;
            tableProdutos.HorizontalScroll.Enabled = false;
            tableProdutos.HorizontalScroll.Visible = false;
            tableProdutos.AutoScroll = true;
        }

        public void AdicionaNoCarrinho(UCProduto produto)
        {
            var produtoDoCarrinho = carrinho.Find(e => e.Nome.Equals(produto.Nome));
            if (produtoDoCarrinho is null)
            {
                this.carrinho.Add(produto);

                Image trashBinIcon = new Bitmap(Properties.Resources.trashBinImg.ToBitmap(), 23, 23);

                this.dgvCarrinho.Rows.Add(this.dgvCarrinho.Rows.Count + 1, produto.Nome, produto.Qtd, produto.ValorTotal, trashBinIcon);
            }
            else
            {
                for (int i = 0; i < dgvCarrinho.Rows.Count; i++)
                {
                    var row = dgvCarrinho.Rows[i];
                    if (row.Cells["Item"].Value.ToString() == produto.Nome)
                    {
                        row.Cells["Valor"].Value = produto.ValorTotal;
                        row.Cells["Quantidade"].Value = produto.Qtd;
                        produtoDoCarrinho.MaxQtdUpDown = produto.MaxQtdUpDown;
                        produtoDoCarrinho.MaxQtd = produto.MaxQtd;
                        produtoDoCarrinho.Qtd = produto.Qtd;
                        produtoDoCarrinho.ValorTotal = produto.ValorTotal;
                        break;
                    }
                }
            }
            btnComprar.Enabled = true;
            this.valorTotal = carrinho.Select(e => e.ValorTotal).Sum();

            this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
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
                            //Environment.Exit(0);
                        }
                        catch
                        {
                            Application.Exit();
                        }
                        break;
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.dgvCarrinho.Rows.Clear();
            this.valorTotal = 0;

            carrinho.ForEach(a =>
            {
                a.ValorTotal = 0;
                a.Qtd = 0;
            });

            btnComprar.Enabled = false;
            this.carrinho.Clear();
            this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            carrinho.ForEach(e =>
            {
                var produto = genesisContext.Produtos.First(produto => produto.NomeProduto == e.Nome);

                produto.QtdEmEstoque -= e.Qtd;

                genesisContext.Produtos.Update(produto);
            });
            genesisContext.SaveChanges();


            foreach (DataGridViewRow selRow in dgvCarrinho.Rows.OfType<DataGridViewRow>().ToArray())
            {
                dgvCarrinho.Rows.Remove(selRow);
                dgvResumoPedido.Rows.Add(selRow);
            }

                textBoxValorResumo.Text = this.textBoxPreco.Text;

            painelPedido.BringToFront();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            this.CarregaProdutos();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.clienteLogado = null;

            using (var fmTelaDeLogin = Program.ServiceProvider.GetRequiredService<TelaDeLogin>())
            {
                this.Hide();
                fmTelaDeLogin.StartPosition = FormStartPosition.CenterScreen;
                fmTelaDeLogin.ShowDialog();
            }
        }

        private void rbtnPix_CheckedChanged(object sender, EventArgs e)
        {
            btnConfirmarPedido.Enabled = true;
        }

        private void rbtnCartao_CheckedChanged(object sender, EventArgs e)
        {
            painelCartao.Visible = true;
            painelCartao.BringToFront();
            btnConfirmarPedido.Enabled = true;
        }

        private async void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            rbtnCartao.Enabled = false;
            rbtnPix.Enabled = false;
            if (rbtnPix.Checked)
            {
                painelPix.Visible = true;
                painelPix.BringToFront();
                //MercadoPagoConfig.AccessToken = "TEST-5286284997561521-111720-2c4a1178c9f376e8dc7091f198e95be2-260945420";
                MercadoPagoConfig.AccessToken = "APP_USR-5286284997561521-111720-45e6a340d207fb36452a2fdb462bc55f-260945420";
                var requestOptions = new RequestOptions();
                requestOptions.CustomHeaders.Add("x-idempotency-key", UniqueId.CreateRandomId());

                var dataDeExpiracao = DateTime.Now.AddMinutes(5);

                var request = new PaymentCreateRequest
                {
                    TransactionAmount = valorTotal,
                    PaymentMethodId = "pix",
                    DateOfExpiration = DateTime.Now.AddMinutes(20),
                    Payer = new PaymentPayerRequest
                    {
                        Email = Program.clienteLogado.Email
                    },
                };

                var client = new PaymentClient();
                Payment payment = await client.CreateAsync(request, requestOptions);

                var qrCodeCodificado = payment.PointOfInteraction.TransactionData.QrCodeBase64;

                byte[] data = Convert.FromBase64String(qrCodeCodificado);

                var copiaECola = payment.PointOfInteraction.TransactionData.QrCode;

                textBoxCopiaECola.Text = copiaECola;

                var id = payment.Id;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    pictureBoxQrCode.Image = Image.FromStream(ms);
                    pictureBoxQrCode.BringToFront();
                    pictureBoxQrCode.Visible = true;
                }
                var pedidoPago = false;
                while (!pedidoPago)
                {
                    var resultado = client.Get(id.Value);

                    if (resultado.Status == "approved")
                    {
                        pedidoPago = true;
                        break;
                    }
                    if (resultado.Status == "cancelled" || resultado.Status == "rejected")
                    {
                        break;
                    }

                    if (dataDeExpiracao.Subtract(DateTime.Now).TotalMinutes < 0)
                        break;

                    Thread.Sleep(10000);
                }

                if (pedidoPago)
                {
                    MessageBox.Show("Pedido pago com sucesso");
                    painelAcompanhamento.BringToFront();
                    progressBarPedido.Value = 65;
                }
                else
                {
                    carrinho.ForEach(e =>
                    {
                        var produto = genesisContext.Produtos.First(produto => produto.NomeProduto == e.Nome);

                        produto.QtdEmEstoque += e.Qtd;

                        genesisContext.Produtos.Update(produto);
                    });
                    genesisContext.SaveChanges();

                    painelCatalogo.BringToFront();

                    carrinho.Clear();
                    dgvCarrinho.Rows.Clear();
                    valorTotal = 0;
                    this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                    MessageBox.Show("Pagamento não realizado, favor realizar a compra novamente");
                }

            }
            else
            {

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxCopiaECola.Text);
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            painelCatalogo.BringToFront();


            switch (MessageBox.Show(this, "Tem certeza que deseja cancelar o pedido?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                //Stay on this form
                case DialogResult.Yes:
                    carrinho.Clear();
                    dgvCarrinho.Rows.Clear();
                    valorTotal = 0;
                    this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                    carrinho.ForEach(e =>
                    {
                        var produto = genesisContext.Produtos.First(produto => produto.NomeProduto == e.Nome);

                        produto.QtdEmEstoque += e.Qtd;

                        genesisContext.Produtos.Update(produto);
                    });
                    break;
                default:
                    break;
            }

        }

        private void pictureBoxNotaFiscal_Click(object sender, EventArgs e)
        {
            int height = dgvResumoPedido.Height;
            dgvResumoPedido.Height = dgvResumoPedido.RowCount * dgvResumoPedido.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dgvResumoPedido.Width, this.dgvResumoPedido.Height);
            dgvResumoPedido.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dgvResumoPedido.Width, this.dgvResumoPedido.Height));

            //Resize DataGridView back to original height.
            dgvResumoPedido.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print the contents.
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int height = dgvResumoPedido.Height;
            dgvResumoPedido.Height = dgvResumoPedido.RowCount * dgvResumoPedido.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dgvResumoPedido.Width, this.dgvResumoPedido.Height);
            dgvResumoPedido.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dgvResumoPedido.Width, this.dgvResumoPedido.Height));

            //Resize DataGridView back to original height.
            dgvResumoPedido.Height = height;

            //Show the Print Preview Dialog.
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
