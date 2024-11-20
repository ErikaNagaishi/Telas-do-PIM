using Microsoft.EntityFrameworkCore;
using Microsoft.Web.WebView2.Core;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Forms
{
    public partial class TelaCartaoCreditoMP : Form
    {
        private readonly GenesisSolutionsContext genesisContext;
        public string statusPagamento = "";
        public int idPagamento = 0;
        public TelaCartaoCreditoMP(GenesisSolutionsContext genesisSolutionsContext)
        {
            genesisContext = genesisSolutionsContext;
            InitializeComponent();
        }

        public async void CarregaPaginaMP(string url, int idPedido)
        {
            await this.InitializeAsync();

            webViewMP.CoreWebView2.Navigate(url);

            webViewMP.CoreWebView2.NavigationCompleted += AguardaCarregamentoPagina;

            double elapsed = 0;
            int timeout = 5;

            DateTime startTime = DateTime.Now;

            while (webViewMP.CoreWebView2 is not null && (!webViewMP.CoreWebView2.Source.Contains("approved") &&
                    !webViewMP.CoreWebView2.Source.Contains("rejected")) && (elapsed < timeout))
            {
                elapsed = DateTime.Now.Subtract(startTime).TotalMinutes;
                await Task.Delay(1000);
            }
            if(webViewMP.CoreWebView2 is null)
            {
                this.Close();
                return;
            }

            var pedido = genesisContext.PedidosClientes.AsNoTracking().First(e => e.IdPedido == idPedido);

            if (elapsed >= timeout || webViewMP.CoreWebView2.Source.Contains("rejected"))
            {
                statusPagamento = "cancelled";
                pedido.StatusPagamento = statusPagamento;

                var itensPedido = pedido.PedidosClienteDetalhes.ToList();

                itensPedido.ForEach(item =>
                {
                    var produto = item.IdProdutoNavigation;

                    produto.QtdEmEstoque += item.Quantidade;
                    genesisContext.Produtos.Update(produto);
                });
                genesisContext.SaveChanges();
                genesisContext.ChangeTracker.Clear();

                return;
            }
            else
            {
                var labelPagamento = await webViewMP.CoreWebView2.ExecuteScriptAsync("document.getElementById('group_card_ui_top').getElementsByClassName('group-row')[0].getElementsByTagName('p')[0].innerText");
                if (labelPagamento != null && labelPagamento.IndexOf('#') > 0)
                {
                    labelPagamento = labelPagamento.Replace("\"","");
                    idPagamento = int.Parse(labelPagamento.Substring(labelPagamento.IndexOf('#') + 1));

                    statusPagamento = "approved";
                    pedido.StatusPagamento = statusPagamento;

                    pedido.DataPagamento = DateTime.Now;

                    pedido.IdPagamentoMp = idPagamento;

                    genesisContext.PedidosClientes.Update(pedido);
                    genesisContext.SaveChanges();
                    genesisContext.ChangeTracker.Clear();

                    return;
                }
            }
        }

        private void AguardaCarregamentoPagina(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {

        }

        async Task InitializeAsync()
        {
            await webViewMP.EnsureCoreWebView2Async(null);
        }
    }
}
