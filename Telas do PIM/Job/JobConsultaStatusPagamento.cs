using MercadoPago.Client;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Telas_do_PIM.Models;

namespace Telas_do_PIM.Job
{
    public class JobConsultaStatusPagamento : BackgroundService
    {
        private readonly GenesisSolutionsContext _genesisSolutionsContext;

        public JobConsultaStatusPagamento(GenesisSolutionsContext genesisSolutionsContext)
        {
            _genesisSolutionsContext = genesisSolutionsContext; 
        }

        private readonly TimeSpan _period = TimeSpan.FromSeconds(10);
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new PeriodicTimer(_period);
            while (
                !stoppingToken.IsCancellationRequested &&
                await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    var pedidosPendente = _genesisSolutionsContext.PedidosClientes.AsNoTracking().Where(e => e.StatusPagamento == "pending" && e.FormaPagamento == "pix").ToList();

                    if (pedidosPendente.Count > 0) 
                    {
                        MercadoPagoConfig.AccessToken = "APP_USR-5286284997561521-111720-45e6a340d207fb36452a2fdb462bc55f-260945420";

                        pedidosPendente.ForEach(pedido =>
                        {
                            var client = new PaymentClient();

                            Thread.Sleep(100);
                            var requestOptions = new RequestOptions();
                            requestOptions.CustomHeaders.Add("x-idempotency-key", UniqueId.CreateRandomId());

                            var resultado = client.Get(pedido.IdPagamentoMp.Value);

                            if(resultado.Status != pedido.StatusPagamento)
                            {
                                pedido.StatusPagamento = resultado.Status;

                                _genesisSolutionsContext.ChangeTracker.Clear();
                                _genesisSolutionsContext.PedidosClientes.Update(pedido);

                                if (resultado.Status == "approved") 
                                {
                                    pedido.DataPagamento = DateTime.Now;
                                }
                                _genesisSolutionsContext.SaveChanges();
                                _genesisSolutionsContext.ChangeTracker.Clear();
                                if (resultado.Status == "cancelled" || resultado.Status == "rejected")
                                {
                                    var itensPedido = pedido.PedidosClienteDetalhes.ToList();

                                    itensPedido.ForEach(item =>
                                    {
                                        var produto = item.IdProdutoNavigation;

                                        produto.QtdEmEstoque += item.Quantidade;
                                        _genesisSolutionsContext.Produtos.Update(produto);
                                    });
                                    _genesisSolutionsContext.SaveChanges();
                                    _genesisSolutionsContext.ChangeTracker.Clear();
                                }
                            }

                        });
                    }
                    var pedidosCriados = _genesisSolutionsContext.PedidosClientes.AsNoTracking().Where(e => e.StatusPagamento == "created").ToList();

                    pedidosCriados.ForEach(a =>
                    {
                        if(a.DataLimitePagamento.Value.Subtract(DateTime.Now).TotalMinutes < 0)
                        {
                            a.StatusPagamento = "cancelled";
                            _genesisSolutionsContext.ChangeTracker.Clear();
                            _genesisSolutionsContext.PedidosClientes.Update(a);
                            _genesisSolutionsContext.SaveChanges();
                            _genesisSolutionsContext.ChangeTracker.Clear();
                        }
                    });

                    var pedidosPagos = _genesisSolutionsContext.PedidosClientes.AsNoTracking().Where(e => e.StatusPagamento == "approved").ToList();

                    pedidosPagos.ForEach(a =>
                    {
                        if (a.DataPagamento.Value.Subtract(DateTime.Now).TotalMinutes < -1)
                        {
                            a.StatusPagamento = "available";
                            _genesisSolutionsContext.ChangeTracker.Clear();
                            _genesisSolutionsContext.PedidosClientes.Update(a);
                            _genesisSolutionsContext.SaveChanges();
                            _genesisSolutionsContext.ChangeTracker.Clear();
                        }
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Failed to execute PeriodicHostedService with exception message {ex.Message}. Good luck next round!");
                }
            }
        }
    }
}
