﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class PedidosFornecedor
{
    public int IdPedido { get; set; }

    public int? IdFornecedor { get; set; }

    public virtual Fornecedore IdFornecedorNavigation { get; set; }
}