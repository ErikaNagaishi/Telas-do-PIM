﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class Encomendum
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public string Produto { get; set; }

    public int? ClienteId { get; set; }

    public virtual Cliente Cliente { get; set; }
}