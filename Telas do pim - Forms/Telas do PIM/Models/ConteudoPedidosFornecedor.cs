﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class ConteudoPedidosFornecedor
{
    public int? IdPedido { get; set; }

    public int? IdInsumo { get; set; }

    public int? QtdInsumo { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; }

    public virtual TodosPedidosFornecedore IdPedidoNavigation { get; set; }
}