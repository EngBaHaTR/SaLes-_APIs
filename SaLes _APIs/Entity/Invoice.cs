﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SaLes__APIs.Entity;

public partial class Invoice
{
    public Invoice()
    {
        Oid = Guid .NewGuid();
    }
    public Guid Oid { get; set; }

    public double? TotalInvoices { get; set; }

    public Guid? Customer { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsPosted { get; set; }

    public double? ProfitMargin { get; set; }

    public bool? IsDeletion { get; set; }

    public string ResDeletion { get; set; }
    [JsonIgnore]
    public int? OptimisticLockField { get; set; }
    [JsonIgnore]
    public int? GCRecord { get; set; }
    [JsonIgnore]
    public virtual Customer CustomerNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<RowInvoice> RowInvoices { get; set; } = new List<RowInvoice>();
}