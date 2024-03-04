﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Data.Models;

public partial class Transaccion
{
    public int Id { get; set; }

    public float Monto { get; set; }

    public long? NumeroOperacion { get; set; }

    public DateOnly? Fecha { get; set; }

    public int CuentaOrigenId { get; set; }

    public int CuentaDestinoId { get; set; }

    public int TipoTransaccionId { get; set; }
    [JsonIgnore]
    public virtual Cuenta CuentaDestino { get; set; }
    [JsonIgnore]
    public virtual Cuenta CuentaOrigen { get; set; }
    [JsonIgnore]
    public virtual TipoTransaccion TipoTransaccion { get; set; }
}