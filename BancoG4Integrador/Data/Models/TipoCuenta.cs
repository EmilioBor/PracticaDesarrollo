﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Models;

public partial class TipoCuenta
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public DateOnly Alta { get; set; }
    [JsonIgnore]
    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}