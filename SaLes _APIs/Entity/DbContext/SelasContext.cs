﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SaLes__APIs.Entity;

public partial class SelasContext : DbContext
{
    public SelasContext(DbContextOptions<SelasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<Invoice> Invoice { get; set; }

    public virtual DbSet<MediaDataObject> MediaDataObject { get; set; }

    public virtual DbSet<ModelDifference> ModelDifference { get; set; }

    public virtual DbSet<ModelDifferenceAspect> ModelDifferenceAspect { get; set; }

    public virtual DbSet<PermissionPolicyActionPermissionObject> PermissionPolicyActionPermissionObject { get; set; }

    public virtual DbSet<PermissionPolicyMemberPermissionsObject> PermissionPolicyMemberPermissionsObject { get; set; }

    public virtual DbSet<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObject { get; set; }

    public virtual DbSet<PermissionPolicyObjectPermissionsObject> PermissionPolicyObjectPermissionsObject { get; set; }

    public virtual DbSet<PermissionPolicyRole> PermissionPolicyRole { get; set; }

    public virtual DbSet<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObject { get; set; }

    public virtual DbSet<PermissionPolicyUser> PermissionPolicyUser { get; set; }

    public virtual DbSet<PermissionPolicyUserLoginInfo> PermissionPolicyUserLoginInfo { get; set; }

    public virtual DbSet<PermissionPolicyUserUsers_PermissionPolicyRoleRole> PermissionPolicyUserUsers_PermissionPolicyRoleRole { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<RowInvoice> RowInvoice { get; set; }

    public virtual DbSet<Supplier> Supplier { get; set; }

    public virtual DbSet<XPObjectType> XPObjectType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomId);

            entity.ToTable("Customer");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_Customer");

            entity.Property(e => e.CustomId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Invoice");

            entity.HasIndex(e => e.Customer, "iCustomer_Invoice");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_Invoice");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.ResDeletion).HasMaxLength(100);

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK_Invoice_Customer");
        });

        modelBuilder.Entity<MediaDataObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("MediaDataObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_MediaDataObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.MediaDataKey).HasMaxLength(100);
        });

       

        modelBuilder.Entity<PermissionPolicyActionPermissionObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyActionPermissionObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyActionPermissionObject");

            entity.HasIndex(e => e.Role, "iRole_PermissionPolicyActionPermissionObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.ActionId).HasMaxLength(100);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.PermissionPolicyActionPermissionObjects)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_PermissionPolicyActionPermissionObject_Role");
        });

        modelBuilder.Entity<PermissionPolicyMemberPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyMemberPermissionsObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyMemberPermissionsObject");

            entity.HasIndex(e => e.TypePermissionObject, "iTypePermissionObject_PermissionPolicyMemberPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.TypePermissionObjectNavigation).WithMany(p => p.PermissionPolicyMemberPermissionsObjects)
                .HasForeignKey(d => d.TypePermissionObject)
                .HasConstraintName("FK_PermissionPolicyMemberPermissionsObject_TypePermissionObject");
        });

        modelBuilder.Entity<PermissionPolicyNavigationPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyNavigationPermissionsObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyNavigationPermissionsObject");

            entity.HasIndex(e => e.Role, "iRole_PermissionPolicyNavigationPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.PermissionPolicyNavigationPermissionsObjects)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_PermissionPolicyNavigationPermissionsObject_Role");
        });

        modelBuilder.Entity<PermissionPolicyObjectPermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyObjectPermissionsObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyObjectPermissionsObject");

            entity.HasIndex(e => e.TypePermissionObject, "iTypePermissionObject_PermissionPolicyObjectPermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.TypePermissionObjectNavigation).WithMany(p => p.PermissionPolicyObjectPermissionsObjects)
                .HasForeignKey(d => d.TypePermissionObject)
                .HasConstraintName("FK_PermissionPolicyObjectPermissionsObject_TypePermissionObject");
        });

        modelBuilder.Entity<PermissionPolicyRole>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyRole");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyRole");

            entity.HasIndex(e => e.ObjectType, "iObjectType_PermissionPolicyRole");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.PermissionPolicyRoles)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_PermissionPolicyRole_ObjectType");
        });

        modelBuilder.Entity<PermissionPolicyTypePermissionsObject>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyTypePermissionsObject");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyTypePermissionsObject");

            entity.HasIndex(e => e.Role, "iRole_PermissionPolicyTypePermissionsObject");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.PermissionPolicyTypePermissionsObjects)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK_PermissionPolicyTypePermissionsObject_Role");
        });

        modelBuilder.Entity<PermissionPolicyUser>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyUser");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_PermissionPolicyUser");

            entity.HasIndex(e => e.ObjectType, "iObjectType_PermissionPolicyUser");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LockoutEnd).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.ObjectTypeNavigation).WithMany(p => p.PermissionPolicyUsers)
                .HasForeignKey(d => d.ObjectType)
                .HasConstraintName("FK_PermissionPolicyUser_ObjectType");
        });

        modelBuilder.Entity<PermissionPolicyUserLoginInfo>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("PermissionPolicyUserLoginInfo");

            entity.HasIndex(e => new { e.LoginProviderName, e.ProviderUserKey }, "iLoginProviderNameProviderUserKey_PermissionPolicyUserLoginInfo").IsUnique();

            entity.HasIndex(e => e.User, "iUser_PermissionPolicyUserLoginInfo");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.LoginProviderName).HasMaxLength(100);
            entity.Property(e => e.ProviderUserKey).HasMaxLength(100);

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.PermissionPolicyUserLoginInfos)
                .HasForeignKey(d => d.User)
                .HasConstraintName("FK_PermissionPolicyUserLoginInfo_User");
        });

        modelBuilder.Entity<PermissionPolicyUserUsers_PermissionPolicyRoleRole>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.HasIndex(e => new { e.Roles, e.Users }, "iRolesUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles").IsUnique();

            entity.HasIndex(e => e.Roles, "iRoles_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            entity.HasIndex(e => e.Users, "iUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            entity.Property(e => e.OID).ValueGeneratedNever();

            entity.HasOne(d => d.RolesNavigation).WithMany(p => p.PermissionPolicyUserUsers_PermissionPolicyRoleRoles)
                .HasForeignKey(d => d.Roles)
                .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Roles");

            entity.HasOne(d => d.UsersNavigation).WithMany(p => p.PermissionPolicyUserUsers_PermissionPolicyRoleRoles)
                .HasForeignKey(d => d.Users)
                .HasConstraintName("FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Product");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_Product");

            entity.HasIndex(e => e.Image, "iImage_Product");

            entity.HasIndex(e => e.RowInvoice, "iRowInvoice_Product");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.ImageNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Image)
                .HasConstraintName("FK_Product_Image");

            entity.HasOne(d => d.RowInvoiceNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.RowInvoice)
                .HasConstraintName("FK_Product_RowInvoice");
        });

        modelBuilder.Entity<RowInvoice>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("RowInvoice");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_RowInvoice");

            entity.HasIndex(e => e.Invoice, "iInvoice_RowInvoice");

            entity.HasIndex(e => e.Product, "iProduct_RowInvoice");

            entity.Property(e => e.Oid).ValueGeneratedNever();

            entity.HasOne(d => d.InvoiceNavigation).WithMany(p => p.RowInvoices)
                .HasForeignKey(d => d.Invoice)
                .HasConstraintName("FK_RowInvoice_Invoice");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.RowInvoices)
                .HasForeignKey(d => d.Product)
                .HasConstraintName("FK_RowInvoice_Product");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Oid);

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.GCRecord, "iGCRecord_Supplier");

            entity.Property(e => e.Oid).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
        });

        modelBuilder.Entity<XPObjectType>(entity =>
        {
            entity.HasKey(e => e.OID);

            entity.ToTable("XPObjectType");

            entity.HasIndex(e => e.TypeName, "iTypeName_XPObjectType").IsUnique();

            entity.Property(e => e.AssemblyName).HasMaxLength(254);
            entity.Property(e => e.TypeName).HasMaxLength(254);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}