﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string CnpjCliente { get; set; }

    public string SenhaCliente { get; set; }

    public string RazaoSocial { get; set; }

    public string EnderecoCliente { get; set; }

    public string Email { get; set; }

    public string Cep { get; set; }

    public string Numero { get; set; }

    public bool SenhaCriptografada { get; set; }

    public virtual ICollection<Encomendum> Encomenda { get; set; } = new List<Encomendum>();

    public virtual ICollection<PedidosCliente> PedidosClientes { get; set; } = new List<PedidosCliente>();
}