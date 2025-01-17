﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaLes__APIs.Entity;

public partial class PermissionPolicyRole
{
    [Key]
    public Guid Oid { get; set; }

    public string Name { get; set; }

    public bool? IsAdministrative { get; set; }

    public bool? CanEditModel { get; set; }

    public int? PermissionPolicy { get; set; }

    public int? OptimisticLockField { get; set; }

    public int? GCRecord { get; set; }

    public int? ObjectType { get; set; }

    public virtual XPObjectType ObjectTypeNavigation { get; set; }

    public virtual ICollection<PermissionPolicyActionPermissionObject> PermissionPolicyActionPermissionObjects { get; set; } = new List<PermissionPolicyActionPermissionObject>();

    public virtual ICollection<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObjects { get; set; } = new List<PermissionPolicyNavigationPermissionsObject>();

    public virtual ICollection<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObjects { get; set; } = new List<PermissionPolicyTypePermissionsObject>();

    public virtual ICollection<PermissionPolicyUserUsers_PermissionPolicyRoleRole> PermissionPolicyUserUsers_PermissionPolicyRoleRoles { get; set; } = new List<PermissionPolicyUserUsers_PermissionPolicyRoleRole>();
}