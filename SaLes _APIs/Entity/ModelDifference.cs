﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaLes__APIs.Entity;

public partial class ModelDifference
{
    [Key]
    public Guid Oid { get; set; }

    public string UserId { get; set; }

    public string ContextId { get; set; }

    public int? Version { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public virtual ICollection<ModelDifferenceAspect> ModelDifferenceAspects { get; set; } = new List<ModelDifferenceAspect>();
}