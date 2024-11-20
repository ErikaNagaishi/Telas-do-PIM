﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Telas_do_PIM.Models;

public partial class GenesisSolutionsContext : DbContext
{
    public GenesisSolutionsContext(DbContextOptions<GenesisSolutionsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorizacao> Categorizacaos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConteudoPedidosCliente> ConteudoPedidosClientes { get; set; }

    public virtual DbSet<ConteudoPedidosFornecedor> ConteudoPedidosFornecedors { get; set; }

    public virtual DbSet<Encomendum> Encomenda { get; set; }

    public virtual DbSet<EntregaPedido> EntregaPedidos { get; set; }

    public virtual DbSet<Entregadore> Entregadores { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<FornecedoresInsumo> FornecedoresInsumos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<LotesProduto> LotesProdutos { get; set; }

    public virtual DbSet<PedidosCliente> PedidosClientes { get; set; }

    public virtual DbSet<PedidosClienteDetalhe> PedidosClienteDetalhes { get; set; }

    public virtual DbSet<PedidosFornecedor> PedidosFornecedors { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<PerfilTela> PerfilTelas { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Tela> Telas { get; set; }

    public virtual DbSet<TodosPedidosCliente> TodosPedidosClientes { get; set; }

    public virtual DbSet<TodosPedidosFornecedore> TodosPedidosFornecedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorizacao>(entity =>
        {
            entity.HasKey(e => e.IdCategorizacao).HasName("PK__categori__35F078943E1DD003");

            entity.ToTable("categorizacao");

            entity.Property(e => e.IdCategorizacao).HasColumnName("id_categorizacao");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__9BB2655BFE434EA2");

            entity.Property(e => e.IdCliente).HasColumnName("ID_cliente");
            entity.Property(e => e.Cep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.CnpjCliente)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CNPJ_cliente");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EnderecoCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco_cliente");
            entity.Property(e => e.Numero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUMERO");
            entity.Property(e => e.RazaoSocial)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razao_social");
            entity.Property(e => e.SenhaCliente)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("senha_cliente");
            entity.Property(e => e.SenhaCriptografada).HasColumnName("senha_criptografada");
        });

        modelBuilder.Entity<ConteudoPedidosCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Conteudo_Pedidos_Cliente");

            entity.Property(e => e.IdLote).HasColumnName("ID_lote");
            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
            entity.Property(e => e.IdProduto).HasColumnName("ID_produto");
            entity.Property(e => e.QtdProduto).HasColumnName("qtd_produto");

            entity.HasOne(d => d.IdLoteNavigation).WithMany()
                .HasForeignKey(d => d.IdLote)
                .HasConstraintName("FK__Conteudo___ID_lo__6FE99F9F");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany()
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Conteudo___ID_pe__6E01572D");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany()
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Conteudo___ID_pr__6EF57B66");
        });

        modelBuilder.Entity<ConteudoPedidosFornecedor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Conteudo_Pedidos_Fornecedor");

            entity.Property(e => e.IdInsumo).HasColumnName("ID_insumo");
            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
            entity.Property(e => e.QtdInsumo).HasColumnName("qtd_insumo");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany()
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK__Conteudo___ID_in__7B5B524B");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany()
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Conteudo___ID_pe__7A672E12");
        });

        modelBuilder.Entity<Encomendum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Encomend__3214EC0768A79BA3");

            entity.Property(e => e.Produto)
                .IsRequired()
                .HasColumnName("produto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Encomenda)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Encomenda_Cliente");
        });

        modelBuilder.Entity<EntregaPedido>(entity =>
        {
            entity.HasKey(e => e.IdEntrega).HasName("PK__Entrega___4AAEC707276CB085");

            entity.ToTable("Entrega_Pedido");

            entity.Property(e => e.IdEntrega).HasColumnName("ID_entrega");
            entity.Property(e => e.DataEntrega)
                .HasColumnType("date")
                .HasColumnName("data_entrega");
            entity.Property(e => e.EnderecoEntrega)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco_entrega");
            entity.Property(e => e.IdEntregador).HasColumnName("ID_entregador");
            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");

            entity.HasOne(d => d.IdEntregadorNavigation).WithMany(p => p.EntregaPedidos)
                .HasForeignKey(d => d.IdEntregador)
                .HasConstraintName("FK__Entrega_P__ID_en__628FA481");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.EntregaPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Entrega_P__ID_pe__6477ECF3");
        });

        modelBuilder.Entity<Entregadore>(entity =>
        {
            entity.HasKey(e => e.IdEntregador).HasName("PK__Entregad__6B277A7E3D339159");

            entity.Property(e => e.IdEntregador).HasColumnName("ID_entregador");
            entity.Property(e => e.CpfEntregador).HasColumnName("CPF_entregador");
            entity.Property(e => e.DataAdmissao)
                .HasColumnType("date")
                .HasColumnName("data_admissao");
            entity.Property(e => e.NomeEntregador)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_entregador");
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("PK__Forneced__082158042697C602");

            entity.Property(e => e.IdFornecedor).HasColumnName("ID_fornecedor");
            entity.Property(e => e.CnpjFornecedor).HasColumnName("CNPJ_fornecedor");
            entity.Property(e => e.Endereco)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("endereco");
            entity.Property(e => e.RazaoSocial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("razao_social");
        });

        modelBuilder.Entity<FornecedoresInsumo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Fornecedores_Insumo");

            entity.Property(e => e.IdFornecedor).HasColumnName("ID_fornecedor");
            entity.Property(e => e.IdInsumo).HasColumnName("ID_insumo");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany()
                .HasForeignKey(d => d.IdFornecedor)
                .HasConstraintName("FK__Fornecedo__ID_fo__7E37BEF6");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany()
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK__Fornecedo__ID_in__7D439ABD");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funciona__3214EC2774BD3EAB");

            entity.ToTable("Funcionario");

            entity.HasIndex(e => e.Email, "UQ__Funciona__161CF7248A8AE8A0").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Funciona__C1F897316CCBB145").IsUnique();

            entity.HasIndex(e => e.Telefone, "UQ__Funciona__D6F1694F244D1189").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Endereço)
                .IsRequired()
                .IsUnicode(false)
                .HasColumnName("ENDEREÇO");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SENHA");
            entity.Property(e => e.SenhaCriptografada).HasColumnName("senha_criptografada");
            entity.Property(e => e.Telefone)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONE");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK__Funcionar__id_pe__07C12930");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo).HasName("PK__Insumos__3827B826B092E2C7");

            entity.Property(e => e.IdInsumo).HasColumnName("ID_insumo");
            entity.Property(e => e.NomeInsumo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("nome_insumo");
            entity.Property(e => e.PrecoCusto)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("preco_custo");
        });

        modelBuilder.Entity<LotesProduto>(entity =>
        {
            entity.HasKey(e => e.IdLote).HasName("PK__Lotes_Pr__8F4FC3A07EA6465F");

            entity.ToTable("Lotes_Produtos");

            entity.Property(e => e.IdLote).HasColumnName("ID_lote");
            entity.Property(e => e.DataColheita)
                .HasColumnType("date")
                .HasColumnName("data_colheita");
            entity.Property(e => e.DataPlantio)
                .HasColumnType("date")
                .HasColumnName("data_plantio");
            entity.Property(e => e.IdProduto).HasColumnName("ID_produto");
            entity.Property(e => e.QtdProduzida).HasColumnName("qtd_produzida");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.LotesProdutos)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Lotes_Pro__ID_pr__693CA210");
        });

        modelBuilder.Entity<PedidosCliente>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos___6FF01489585045B0");

            entity.ToTable("Pedidos_Cliente");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.DataLimitePagamento)
                .HasColumnType("datetime")
                .HasColumnName("data_limite_pagamento");
            entity.Property(e => e.DataPagamento)
                .HasColumnType("datetime")
                .HasColumnName("data_pagamento");
            entity.Property(e => e.FormaPagamento)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("forma_pagamento");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdPagamentoMp).HasColumnName("id_pagamento_mp");
            entity.Property(e => e.QrCode)
                .IsUnicode(false)
                .HasColumnName("qr_code");
            entity.Property(e => e.QrCodeImage).HasColumnName("qr_code_image");
            entity.Property(e => e.StatusPagamento)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status_pagamento");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("valor_total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.PedidosClientes)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedidos_C__id_cl__503BEA1C");
        });

        modelBuilder.Entity<PedidosClienteDetalhe>(entity =>
        {
            entity.HasKey(e => e.IdDetalhe).HasName("PK__Pedidos___4F131145B8F68A5F");

            entity.ToTable("Pedidos_Cliente_Detalhe");

            entity.Property(e => e.IdDetalhe).HasColumnName("id_detalhe");
            entity.Property(e => e.Descricao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.ValorUnitario)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("valor_unitario");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.PedidosClienteDetalhes)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Pedidos_C__id_pe__531856C7");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.PedidosClienteDetalhes)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK_Pedidos_Cliente_Detalhe_Produto");
        });

        modelBuilder.Entity<PedidosFornecedor>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedidos___E337E2C34F222275");

            entity.ToTable("Pedidos_Fornecedor");

            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
            entity.Property(e => e.IdFornecedor).HasColumnName("ID_fornecedor");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.PedidosFornecedors)
                .HasForeignKey(d => d.IdFornecedor)
                .HasConstraintName("FK__Pedidos_F__ID_fo__74AE54BC");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Perfil__3214EC07D45F76FB");

            entity.ToTable("Perfil");

            entity.Property(e => e.Perfil1)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Perfil");
        });

        modelBuilder.Entity<PerfilTela>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Perfil_T__3214EC0753C84788");

            entity.ToTable("Perfil_Tela");

            entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");
            entity.Property(e => e.IdTela).HasColumnName("Id_Tela");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PerfilTelas)
                .HasForeignKey(d => d.IdPerfil)
                .HasConstraintName("FK__Perfil_Te__Id_Pe__0D7A0286");

            entity.HasOne(d => d.IdTelaNavigation).WithMany(p => p.PerfilTelas)
                .HasForeignKey(d => d.IdTela)
                .HasConstraintName("FK__Perfil_Te__Id_Te__0E6E26BF");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produtos__FD71723B4E30EA1A");

            entity.Property(e => e.IdProduto).HasColumnName("ID_produto");
            entity.Property(e => e.Excluido).HasColumnName("excluido");
            entity.Property(e => e.IdCategorizacao).HasColumnName("id_categorizacao");
            entity.Property(e => e.ImagemProduto).HasColumnName("imagem_produto");
            entity.Property(e => e.NomeProduto)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_produto");
            entity.Property(e => e.QtdEmEstoque).HasColumnName("qtd_em_estoque");
            entity.Property(e => e.ValorVenda)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_venda");

            entity.HasOne(d => d.IdCategorizacaoNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategorizacao)
                .HasConstraintName("FK_Produtos_Categorizacao");
        });

        modelBuilder.Entity<Tela>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tela__3214EC0767B41008");

            entity.ToTable("Tela");

            entity.Property(e => e.IdentificacaoTela)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Identificacao_Tela");
            entity.Property(e => e.NomeTela)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nome_Tela");
        });

        modelBuilder.Entity<TodosPedidosCliente>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Todos_Pe__E337E2C3FB6ADCD8");

            entity.ToTable("Todos_Pedidos_Clientes");

            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
            entity.Property(e => e.DataAquisicao)
                .HasColumnType("date")
                .HasColumnName("data_aquisicao");
            entity.Property(e => e.FormaPagto)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("forma_pagto");
            entity.Property(e => e.IdEntrega).HasColumnName("ID_entrega");
            entity.Property(e => e.ValorTotal).HasColumnName("valor_total");

            entity.HasOne(d => d.IdEntregaNavigation).WithMany(p => p.TodosPedidosClientes)
                .HasForeignKey(d => d.IdEntrega)
                .HasConstraintName("FK__Todos_Ped__ID_en__6383C8BA");
        });

        modelBuilder.Entity<TodosPedidosFornecedore>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Todos_Pe__E337E2C3EC55A63A");

            entity.ToTable("Todos_Pedidos_Fornecedores");

            entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
            entity.Property(e => e.DataAquisicao)
                .HasColumnType("date")
                .HasColumnName("data_aquisicao");
            entity.Property(e => e.FormaPagto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("forma_pagto");
            entity.Property(e => e.ValorTotal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("valor_total");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}