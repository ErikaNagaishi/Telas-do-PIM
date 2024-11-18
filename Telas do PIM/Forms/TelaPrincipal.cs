using MercadoPago.Client.Payment;
using MercadoPago.Client;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Telas_do_PIM.Models;
using Telas_do_PIM.UserControls;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Printing;
using System.Data;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Telas_do_PIM.Forms
{
    public partial class TelaPrincipal : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private decimal valorTotal = 0;
        private List<UCProduto> carrinho = new();
        private List<UCProduto> ucProdutos = new();
        Bitmap bitmap;
        System.Windows.Forms.Timer timerStatusPedido;

        private PedidosCliente? ultimoPedido;
        public TelaPrincipal(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
            FormClosing += FormClosingAction;
            dgvCarrinho.CellClick += dgvCarrinho_CellClick;
            this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

            tsUsuario.Text = Program.clienteLogado.RazaoSocial;

            ultimoPedido = genesisContext.PedidosClientes.AsNoTracking().Where(x => x.IdCliente == Program.clienteLogado.IdCliente).OrderByDescending(e => e.IdPedido).ToList().FirstOrDefault();
            if (ultimoPedido is not null)
            {
                genesisContext.Entry<PedidosCliente>(ultimoPedido).State = EntityState.Detached;
            }
            CarregaDataGridResumo();
        }

        public void CarregaDataGridResumo()
        {
            if (ultimoPedido is not null)
            {
                if (dgvResumoPedido.Rows.Count == 0)
                {
                    try
                    {
                        dgvResumoPedido.Columns.Remove("TrashIcon");
                    }
                    catch { }
                    ultimoPedido.PedidosClienteDetalhes.ToList().ForEach(x =>
                    {
                        dgvResumoPedido.Rows.Add(dgvResumoPedido.Rows.Count, x.IdProdutoNavigation.NomeProduto, x.Quantidade, x.ValorUnitario * x.Quantidade);
                    });
                    btnCancelarPedido.Enabled = false;
                    textBoxValorResumo.Text = ultimoPedido.ValorTotal.Value.ToString("C", CultureInfo.GetCultureInfo("pt-BR")); ;
                }
                if (ultimoPedido.StatusPagamento == "pending")
                {
                    timerStatusPedido = new System.Windows.Forms.Timer
                    {
                        Interval = 1000
                    };
                    timerStatusPedido.Tick += (sender, e) => AguardaStatusPagamento(sender, e, ultimoPedido);
                    timerStatusPedido.Start();
                    btnCancelarPedido.Enabled = true;

                    if (ultimoPedido.FormaPagamento == "pix")
                    {
                        textBoxCopiaECola.Text = ultimoPedido.QrCode;

                        using (MemoryStream ms = new MemoryStream(ultimoPedido.QrCodeImage))
                        {
                            pictureBoxQrCode.Image = Image.FromStream(ms);
                            pictureBoxQrCode.BringToFront();
                            pictureBoxQrCode.Visible = true;
                        }
                        painelPix.BringToFront();
                        painelPix.Visible = true;
                    }
                }
            }
            if(ultimoPedido is not null && ultimoPedido.StatusPagamento == "pending")
            {
                progressBarPedido.Value = 10;
                btnCancelarPedido.Enabled = false;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "cancelled")
            {
                progressBarPedido.Value = 45;
                btnCancelarPedido.Enabled = false;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "approved")
            {
                progressBarPedido.Value = 65;
                btnCancelarPedido.Enabled = false;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "available")
            {
                progressBarPedido.Value = 100;
                btnCancelarPedido.Enabled = false;
            }
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
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "pending")
                btnComprar.Enabled = false;
            CarregaProdutos();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            if(dgvResumoPedido.Rows.Count == 0)
            {
                pictureBoxBag.Enabled = false;
                pictureBoxNotaFiscal.Enabled = false;
                linkLabel2.Enabled = false;
                linkLabel1.Enabled = false;
            }
            else
            {
                pictureBoxBag.Enabled = true;
                pictureBoxNotaFiscal.Enabled = true;
                linkLabel2.Enabled = true;
                linkLabel1.Enabled = true;
            }
            painelAcompanhamento.BringToFront();
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

            produtos.ForEach(a => genesisContext.Entry<Produto>(a).State = EntityState.Detached);
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
            btnCancelarPedido.Enabled = true ;
            progressBarPedido.BackColor = Color.Green;
            progressBarPedido.Value = 10;
            var pedido_detalhe = new List<PedidosClienteDetalhe>();

            if(dgvResumoPedido.Rows.Count > 0)
            {
                if (ultimoPedido is not null && (ultimoPedido.StatusPagamento == "pending" || ultimoPedido.StatusPagamento == "created"))
                {
                    MessageBox.Show("Conclua o pedido anterior para prosseguir com um novo pedido");
                    return;
                }
            }
            dgvResumoPedido.Rows.Clear();

            carrinho.ForEach(e =>
            {
                var produto = genesisContext.Produtos.AsNoTracking().First(produto => produto.NomeProduto == e.Nome);

                produto.QtdEmEstoque -= e.Qtd;

                genesisContext.Produtos.Update(produto);

                pedido_detalhe.Add(new PedidosClienteDetalhe()
                {
                    IdProduto = produto.IdProduto,
                    Quantidade = e.Qtd,
                    ValorUnitario = e.Valor,
                });
                genesisContext.SaveChanges();
                genesisContext.Entry<Produto>(produto).State = EntityState.Detached;

            });

            var pedido = new PedidosCliente()
            {
                IdCliente = Program.clienteLogado.IdCliente,
                ValorTotal = this.valorTotal,
                StatusPagamento = "created",
                FormaPagamento = "pix",
                PedidosClienteDetalhes = pedido_detalhe,
                DataLimitePagamento = DateTime.Now.AddMinutes(20)
            };

            genesisContext.PedidosClientes.Add(pedido);

            genesisContext.SaveChanges();
            genesisContext.Entry<PedidosCliente>(pedido).State = EntityState.Detached;

            ultimoPedido = pedido;

            foreach (DataGridViewRow selRow in dgvCarrinho.Rows.OfType<DataGridViewRow>().ToArray())
            {
                dgvCarrinho.Rows.Remove(selRow);
                selRow.Cells.RemoveAt(selRow.Cells.Count - 1);

                dgvResumoPedido.Rows.Add(selRow);
            }

            try
            {
                dgvResumoPedido.Columns.Remove("TrashIcon");
            }
            catch { }

            textBoxValorResumo.Text = this.textBoxPreco.Text;

            //rbtnCartao.Enabled = true;
            rbtnPix.Enabled = true;

            dgvCarrinho.Rows.Clear();
            //valorTotal = 0;
            //this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

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
            btnConfirmarPedido.Enabled = false;
            btnCancelarPedido.Enabled = false;
            rbtnCartao.Enabled = false;
            rbtnPix.Enabled = false;
            if (rbtnPix.Checked)
            {
                var pedido = genesisContext.PedidosClientes.AsNoTracking().Where(x => x.IdCliente == Program.clienteLogado.IdCliente).OrderByDescending(e => e.IdPedido).ToList().FirstOrDefault();
                ultimoPedido = pedido;
                painelPix.Visible = true;
                painelPix.BringToFront();
                //MercadoPagoConfig.AccessToken = "TEST-5286284997561521-111720-2c4a1178c9f376e8dc7091f198e95be2-260945420";
                MercadoPagoConfig.AccessToken = "APP_USR-5286284997561521-111720-45e6a340d207fb36452a2fdb462bc55f-260945420";
                var requestOptions = new RequestOptions();
                requestOptions.CustomHeaders.Add("x-idempotency-key", UniqueId.CreateRandomId());

                var dataDeExpiracao = DateTime.Now.AddMinutes(20);

                var request = new PaymentCreateRequest
                {
                    TransactionAmount = valorTotal,
                    PaymentMethodId = "pix",
                    DateOfExpiration = dataDeExpiracao,
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

                pedido.StatusPagamento = payment.Status;
                pedido.IdPagamentoMp = payment.Id;
                pedido.QrCode = copiaECola;
                pedido.QrCodeImage = data;

                genesisContext.PedidosClientes.Update(pedido);

                genesisContext.SaveChanges();
                genesisContext.Entry<PedidosCliente>(pedido).State = EntityState.Detached;

                var id = payment.Id;

                using (MemoryStream ms = new MemoryStream(data))
                {
                    pictureBoxQrCode.Image = Image.FromStream(ms);
                    pictureBoxQrCode.BringToFront();
                    pictureBoxQrCode.Visible = true;
                }

                timerStatusPedido = new System.Windows.Forms.Timer
                {
                    Interval = 1000
                };
                timerStatusPedido.Tick += (sender, e) => AguardaStatusPagamento(sender, e, pedido);
                timerStatusPedido.Start();
            }
            else
            {

            }
        }
        public void AguardaStatusPagamento(object? sender, EventArgs e, PedidosCliente pedido)
        {
            var statusPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido).StatusPagamento;

            if (statusPedido == "approved")
            {
                timerStatusPedido.Stop();
                MessageBox.Show("Pedido pago com sucesso");
                painelAcompanhamento.BringToFront();
                progressBarPedido.Value = 65;
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                this.valorTotal = 0;
                //dgvResumoPedido.Rows.Clear();
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                ultimoPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido);
                carrinho.Clear();

            }
            else if (statusPedido == "cancelled" || statusPedido == "rejected")
            {
                progressBarPedido.Value = 65;
                carrinho.ForEach(e =>
                {
                    var produto = genesisContext.Produtos.AsNoTracking().First(produto => produto.NomeProduto == e.Nome);

                    produto.QtdEmEstoque += e.Qtd;

                    //var produtoDoCarrinho = ucProdutos.First(produto => produto.Nome == e.Nome);

                    //produtoDoCarrinho.Qtd += e.Qtd;
                    //produtoDoCarrinho.MaxQtdUpDown = produtoDoCarrinho.MaxQtd;

                    CarregaProdutos();

                    genesisContext.Produtos.Update(produto);
                    genesisContext.SaveChanges();
                    genesisContext.Entry<Produto>(produto).State = EntityState.Detached;
                });
                carrinho.Clear();

                painelCatalogo.BringToFront();
                this.valorTotal = 0;
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                dgvResumoPedido.Rows.Clear();
                timerStatusPedido.Stop();
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                MessageBox.Show("Pagamento não realizado, favor realizar a compra novamente");
            }
            if (statusPedido == "available")
            {
                timerStatusPedido.Stop();
                MessageBox.Show("Pedido disponível para retirada");
                painelAcompanhamento.BringToFront();
                progressBarPedido.Value = 100;
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                this.valorTotal = 0;
                //dgvResumoPedido.Rows.Clear();
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                ultimoPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido);
                carrinho.Clear();

            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxCopiaECola.Text);
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            if(timerStatusPedido is not null)
                timerStatusPedido.Stop();
            switch (MessageBox.Show(this, "Tem certeza que deseja cancelar o pedido?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    painelCatalogo.BringToFront();
                    progressBarPedido.BackColor = Color.Red;
                    btnConfirmarPedido.Enabled = true;
                    carrinho.ForEach(e =>
                    {
                        var produto = genesisContext.Produtos.AsNoTracking().First(produto => produto.NomeProduto == e.Nome);

                        produto.QtdEmEstoque += e.Qtd;

                        //var produtoDoCarrinho = ucProdutos.First(produto => produto.Nome == e.Nome);

                        ////produtoDoCarrinho.Qtd += e.Qtd;
                        //produtoDoCarrinho.MaxQtdUpDown = produtoDoCarrinho.MaxQtd;


                        genesisContext.Produtos.Update(produto);
                        genesisContext.SaveChanges();
                        genesisContext.Entry<Produto>(produto).State = EntityState.Detached;
                        e.ValorTotal = 0;
                        e.Qtd = 0;
                    });

                    btnComprar.Enabled = false;
                    this.carrinho.Clear();
                    carrinho.Clear();
                    dgvCarrinho.Rows.Clear();
                    dgvResumoPedido.Rows.Clear();
                    valorTotal = 0;
                    this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

                    CarregaProdutos();

                    if (ultimoPedido is not null)
                    {
                        ultimoPedido.StatusPagamento = "cancelled";
                        genesisContext.PedidosClientes.Update(ultimoPedido);
                        genesisContext.SaveChanges();
                        genesisContext.Entry<PedidosCliente>(ultimoPedido).State = EntityState.Detached;
                    }
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

        private void pictureBoxBag_Click(object sender, EventArgs e)
        {
            rbtnCartao.Enabled = false;
            rbtnPix.Enabled = false;

            CarregaDataGridResumo();

            painelPedido.BringToFront();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            rbtnCartao.Enabled = false;
            rbtnPix.Enabled = false;

            CarregaDataGridResumo();

            painelPedido.BringToFront();
        }
    }
}
