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
using MercadoPago.Client.Common;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System.Windows.Forms;

namespace Telas_do_PIM.Forms
{
    public partial class TelaPrincipal : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        private decimal valorTotal = 0;
        private List<UCProduto> carrinho = new();
        private List<UCProduto> ucProdutos = new();
        Bitmap bitmap;
        System.Windows.Forms.Timer timerStatusPedido = new System.Windows.Forms.Timer
        {
            Interval = 1000
        };

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
                genesisContext.ChangeTracker.Clear();
            }
            timerStatusPedido.Tick += (sender, e) => AguardaStatusPagamento(sender, e, ultimoPedido);
            CarregaDataGridResumo();
        }

        public void CarregaDataGridResumo()
        {
            progressBarPedido.SetState(1);
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
                        dgvResumoPedido.Rows.Add(dgvResumoPedido.Rows.Count + 1, x.Descricao, x.Quantidade, x.ValorUnitario * x.Quantidade);
                    });
                    btnCancelarPedido.Enabled = false;
                    textBoxValorResumo.Text = ultimoPedido.ValorTotal.Value.ToString("C", CultureInfo.GetCultureInfo("pt-BR")); ;
                }
                if (ultimoPedido.StatusPagamento == "pending")
                {
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
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "created")
            {
                progressBarPedido.Value = 10;
                rbtnPix.Enabled = true;
                rbtnCartao.Enabled = true;
                pictureBoxNotaFiscal.Enabled = false;
                linkLabel1.Enabled = false;
                btnCancelarPedido.Enabled = true;
                rbtnCartao.Enabled = true;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "pending")
            {
                progressBarPedido.Value = 10;
                btnCancelarPedido.Enabled = true;
                rbtnCartao.Enabled = false;
                rbtnPix.Enabled = false;
                pictureBoxNotaFiscal.Enabled = false;
                linkLabel1.Enabled = false;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "cancelled")
            {
                progressBarPedido.SetState(2);
                progressBarPedido.Value = 10;
                btnCancelarPedido.Enabled = false;
                pictureBoxNotaFiscal.Enabled = false;
                linkLabel1.Enabled = false;
                timerStatusPedido.Stop();
                rbtnCartao.Enabled = false;
                rbtnPix.Enabled = false;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "approved")
            {
                progressBarPedido.Value = 65;
                btnCancelarPedido.Enabled = false;
                pictureBoxNotaFiscal.Enabled = true;
                linkLabel1.Enabled = true;
            }
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "available")
            {
                progressBarPedido.Value = 100;
                btnCancelarPedido.Enabled = false;
                pictureBoxNotaFiscal.Enabled = true;
                linkLabel1.Enabled = true;
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
            var categorias = genesisContext.Categorizacaos.AsNoTracking().Select(e=> e.IdCategorizacao + " - " + e.Nome).ToArray();

            comboBoxCategoria.Items.Clear();
            comboBoxCategoria.Items.Add("");

            comboBoxCategoria.Items.AddRange(categorias);
            painelCatalogo.BringToFront();
            if (ultimoPedido is not null && ultimoPedido.StatusPagamento == "pending")
                btnComprar.Enabled = false;
            CarregaProdutos();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            //if (dgvResumoPedido.Rows.Count == 0)
            //{
            //    pictureBoxBag.Enabled = false;
            //    pictureBoxNotaFiscal.Enabled = false;
            //    linkLabel2.Enabled = false;
            //    linkLabel1.Enabled = false;
            //}
            //else
            //{
            //    pictureBoxBag.Enabled = true;
            //    pictureBoxNotaFiscal.Enabled = true;
            //    linkLabel2.Enabled = true;
            //    linkLabel1.Enabled = true;
            //}
            CarregaDataGridResumo();
            painelAcompanhamento.BringToFront();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

            painelInformacoes.BringToFront();
        }

        private void CarregaProdutos()
        {
            string? filtro = "";
            int idCategoria = 0;

            if (comboBoxCategoria.SelectedIndex > 0)
            {
                idCategoria = int.Parse(comboBoxCategoria.SelectedItem.ToString().Split('-')[0].ToString());
            }

            if (textBoxPesquisa.Text.Length == 1) return;

            if (textBoxPesquisa.Text.Length == 0) filtro = null;

            else filtro = textBoxPesquisa.Text;

            List<Produto> produtos = genesisContext.Produtos.AsNoTracking().Where(e => e.QtdEmEstoque > 0 && !e.Excluido).ToList();
            if (filtro != null)
                produtos = produtos.FindAll(e => e.NomeProduto.ToLower().Contains(filtro.ToLower())).ToList();

            if(idCategoria > 0)
            {
                produtos = produtos.FindAll(e => e.IdCategorizacao == idCategoria);
            }

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
                    Bitmap? bm = null;
                    MemoryStream mStream = new MemoryStream();
                    if (a.ImagemProduto is not null)
                    {
                        mStream.Write(a.ImagemProduto, 0, Convert.ToInt32(a.ImagemProduto.Length));
                        bm = new Bitmap(mStream, false);
                    }

                    var produtoEmCarrinho = carrinho.Find(e => e.Nome.Equals(a.NomeProduto));

                    if (produtoEmCarrinho is not null)
                    {
                        var maxQtd = produtoEmCarrinho.MaxQtdUpDown;
                        var qtd = produtoEmCarrinho.Qtd;

                        var ucProduto = new UCProduto(a.NomeProduto, a.ValorVenda, maxQtd, qtd, (bm == null) ? null : bm, this);
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
            btnCancelarPedido.Enabled = true;
            progressBarPedido.BackColor = Color.Green;
            progressBarPedido.Value = 10;
            var pedido_detalhe = new List<PedidosClienteDetalhe>();

            if (dgvResumoPedido.Rows.Count > 0)
            {
                if (ultimoPedido is not null && (ultimoPedido.StatusPagamento == "pending" || ultimoPedido.StatusPagamento == "created") || ultimoPedido.StatusPagamento == "approved")
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

                genesisContext.ChangeTracker.Clear();
                genesisContext.Produtos.Update(produto);

                genesisContext.ChangeTracker.Clear();
                pedido_detalhe.Add(new PedidosClienteDetalhe()
                {
                    IdProduto = produto.IdProduto,
                    Descricao = produto.NomeProduto,
                    Quantidade = e.Qtd,
                    ValorUnitario = e.Valor,
                });
                genesisContext.SaveChanges();
                genesisContext.Entry<Produto>(produto).State = EntityState.Detached;
                genesisContext.ChangeTracker.Clear();

            });

            var pedido = new PedidosCliente()
            {
                IdCliente = Program.clienteLogado.IdCliente,
                ValorTotal = this.valorTotal,
                StatusPagamento = "created",
                FormaPagamento = (rbtnPix.Checked) ? "pix" : "credit card",
                PedidosClienteDetalhes = pedido_detalhe,
                DataLimitePagamento = DateTime.Now.AddMinutes(20)
            };

            genesisContext.ChangeTracker.Clear();
            genesisContext.PedidosClientes.Add(pedido);

            genesisContext.SaveChanges();
            genesisContext.Entry<PedidosCliente>(pedido).State = EntityState.Detached;
            genesisContext.ChangeTracker.Clear();

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

            rbtnCartao.Enabled = true;
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
            //btnCancelarPedido.Enabled = false;
            rbtnCartao.Enabled = false;
            rbtnPix.Enabled = false;
            var dataDeExpiracao = DateTime.Now.AddMinutes(20);
            var pedido = ultimoPedido;
            //MercadoPagoConfig.AccessToken = "TEST-5286284997561521-111720-2c4a1178c9f376e8dc7091f198e95be2-260945420";
            MercadoPagoConfig.AccessToken = "APP_USR-5286284997561521-111720-45e6a340d207fb36452a2fdb462bc55f-260945420";
            if (rbtnPix.Checked)
            {
                painelPix.Visible = true;
                painelPix.BringToFront();
                var requestOptions = new RequestOptions();
                requestOptions.CustomHeaders.Add("x-idempotency-key", UniqueId.CreateRandomId());


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

                genesisContext.ChangeTracker.Clear();
                genesisContext.PedidosClientes.Update(pedido);

                genesisContext.SaveChanges();
                genesisContext.Entry<PedidosCliente>(pedido).State = EntityState.Detached;
                genesisContext.ChangeTracker.Clear();

                using (MemoryStream ms = new MemoryStream(data))
                {
                    pictureBoxQrCode.Image = Image.FromStream(ms);
                    pictureBoxQrCode.BringToFront();
                    pictureBoxQrCode.Visible = true;
                }
                timerStatusPedido.Start();
            }
            else
            {
                MercadoPagoConfig.AccessToken = "TEST-5286284997561521-111720-2c4a1178c9f376e8dc7091f198e95be2-260945420";
                var items = new List<PreferenceItemRequest>();

                pedido.PedidosClienteDetalhes.ToList().ForEach(e =>
                {
                    items.Add(new PreferenceItemRequest()
                    {
                        Id = e.IdDetalhe.ToString(),
                        Title = e.Descricao,
                        CurrencyId = "BRL",
                        CategoryId = "food",
                        Quantity = e.Quantidade,
                        UnitPrice = e.ValorUnitario
                    });
                });

                var request = new PreferenceRequest
                {
                    Items = items,
                    Payer = new PreferencePayerRequest
                    {
                        Name = Program.clienteLogado.RazaoSocial,
                        Email = Program.clienteLogado.Email,
                        Identification = new IdentificationRequest
                        {
                            Type = "CNPJ",
                            Number = Program.clienteLogado.CnpjCliente
                        },
                        Address = new AddressRequest
                        {
                            StreetName = Program.clienteLogado.EnderecoCliente,
                            StreetNumber = Program.clienteLogado.Numero,
                            ZipCode = Program.clienteLogado.Cep
                        }
                    },
                    BackUrls = new PreferenceBackUrlsRequest()
                    {
                        Success = "https://www.google.com/",
                        Failure = "https://www.google.com/",
                        Pending = "https://www.google.com/"
                    },
                    PaymentMethods = new PreferencePaymentMethodsRequest()
                    {
                        ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>
                        {
                            new PreferencePaymentMethodRequest
                            {
                                Id = "pix",
                            },
                            new PreferencePaymentMethodRequest
                            {
                                Id = "bolbradesco",
                            },
                            new PreferencePaymentMethodRequest
                            {
                                Id = "pec",
                            },
                        },
                        ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>()
                        {
                            new PreferencePaymentTypeRequest()
                            {
                                Id = "debit_card"
                            }
                        },
                    },
                    Purpose = "",
                    NotificationUrl = "https://www.google.com/",
                    StatementDescriptor = "Genesis Solutions",
                    ExternalReference = pedido.IdPedido.ToString(),
                    Expires = true,
                    ExpirationDateTo = dataDeExpiracao
                };

                // Cria a preferência usando o client
                var client = new PreferenceClient();
                var requestOptions = new RequestOptions();
                requestOptions.CustomHeaders.Add("x-idempotency-key", UniqueId.CreateRandomId());
                Preference preference = await client.CreateAsync(request, requestOptions);

                pedido.StatusPagamento = "pending";

                DateTime startTime = DateTime.Now;
                double elapsed = 0;
                int timeout = 1;

                using (var webBrowser = Program.ServiceProvider.GetRequiredService<TelaCartaoCreditoMP>())
                {
                    webBrowser.CarregaPaginaMP(preference.InitPoint, pedido.IdPedido);

                    webBrowser.StartPosition = FormStartPosition.CenterScreen;
                    webBrowser.ShowDialog();
                    timerStatusPedido.Start();
                    if(webBrowser.statusPagamento == "")
                    {
                        rbtnCartao.Enabled = true;
                        rbtnPix.Enabled = true;
                        btnConfirmarPedido.Enabled = true;
                    }
                    webBrowser.Close();
                }

            }

        
        }

        private void webBrowser_click(object? sender, HtmlElementEventArgs e)
        {
            
        }

        public void AguardaStatusPagamento(object? sender, EventArgs e, PedidosCliente pedido)
        {
            var statusPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido).StatusPagamento;

            progressBarPedido.SetState(1);
            if (statusPedido == "approved" && progressBarPedido.Value < 65)
            {
                //timerStatusPedido.Stop();
                progressBarPedido.Value = 65;
                MessageBox.Show("Pedido pago com sucesso");
                painelAcompanhamento.BringToFront();
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                this.valorTotal = 0;
                //dgvResumoPedido.Rows.Clear();
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                ultimoPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido);
                carrinho.Clear();
                pictureBoxNotaFiscal.Enabled = true;
                linkLabel1.Enabled = true;
                rbtnPix.Checked = false;
                rbtnCartao.Checked = false;
            }
            else if (statusPedido == "cancelled" || statusPedido == "rejected")
            {
                progressBarPedido.SetState(2);
                progressBarPedido.Value = 10;
                timerStatusPedido.Stop();
                MessageBox.Show("Pagamento não realizado, favor realizar a compra novamente");
                carrinho.ForEach(e =>
                {
                    var produto = genesisContext.Produtos.AsNoTracking().First(produto => produto.NomeProduto == e.Nome);

                    produto.QtdEmEstoque += e.Qtd;

                    CarregaProdutos();

                    genesisContext.ChangeTracker.Clear();
                    genesisContext.Produtos.Update(produto);
                    genesisContext.SaveChanges();
                    genesisContext.Entry<Produto>(produto).State = EntityState.Detached;
                    genesisContext.ChangeTracker.Clear();
                });
                carrinho.Clear();

                painelCatalogo.BringToFront();
                this.valorTotal = 0;
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                dgvResumoPedido.Rows.Clear();
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                painelPix.SendToBack();
                painelCartao.SendToBack();
                rbtnPix.Checked = false;
                rbtnCartao.Checked = false;

            }
            else if (statusPedido == "available")
            {
                timerStatusPedido.Stop();
                progressBarPedido.Value = 100;
                MessageBox.Show("Pedido disponível para retirada");
                painelAcompanhamento.BringToFront();
                textBoxCopiaECola.Text = string.Empty;
                pictureBoxQrCode.Image = null;
                this.valorTotal = 0;
                //dgvResumoPedido.Rows.Clear();
                this.textBoxValorResumo.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                this.textBoxPreco.Text = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                ultimoPedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == pedido.IdPedido);
                carrinho.Clear();
                rbtnPix.Checked = false;
                rbtnCartao.Checked = false;

            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxCopiaECola.Text);
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            
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

                        genesisContext.ChangeTracker.Clear();
                        genesisContext.Produtos.Update(produto);
                        genesisContext.SaveChanges();
                        genesisContext.Entry<Produto>(produto).State = EntityState.Detached;
                        genesisContext.ChangeTracker.Clear();
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
                        genesisContext.ChangeTracker.Clear();
                        genesisContext.PedidosClientes.Update(ultimoPedido);
                        genesisContext.SaveChanges();
                        genesisContext.Entry<PedidosCliente>(ultimoPedido).State = EntityState.Detached;
                        genesisContext.ChangeTracker.Clear();
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

            if (ultimoPedido is not null)
            {
                if (ultimoPedido.StatusPagamento == "created")
                {
                    rbtnCartao.Enabled = true;
                    rbtnPix.Enabled = true;
                }
                else if(ultimoPedido.StatusPagamento == "pending")
                {
                    btnCancelarPedido.Enabled = true;
                }
                else if (ultimoPedido.StatusPagamento == "cancelled")
                {
                    btnCancelarPedido.Enabled = false;
                }
                else
                {
                    rbtnCartao.Enabled = false;
                    rbtnPix.Enabled = false;
                    btnCancelarPedido.Enabled = false;
                }
            }

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

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CarregaProdutos();
        }
    }
}
