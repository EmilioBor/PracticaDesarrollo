﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Models;

public partial class Direccion
{
    public int Id { get; set; }

    public string Calle { get; set; }

    public string Departamento { get; set; }

    public int Idlocalidad { get; set; }

    public int Numero { get; set; }
    [JsonIgnore]
    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();
    [JsonIgnore]
    public virtual Localidad IdlocalidadNavigation { get; set; }
}