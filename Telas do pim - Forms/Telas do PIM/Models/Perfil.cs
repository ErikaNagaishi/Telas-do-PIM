﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Telas_do_PIM.Models;

public partial class Perfil
{
    public int Id { get; set; }

    public string Perfil1 { get; set; }

    public virtual ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

    public virtual ICollection<PerfilTela> PerfilTelas { get; set; } = new List<PerfilTela>();
}