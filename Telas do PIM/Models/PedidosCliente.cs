﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class PedidosCliente
{
    public int? IdCliente { get; set; }

    public int? IdPedido { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }

    public virtual TodosPedidosCliente IdPedidoNavigation { get; set; }
}