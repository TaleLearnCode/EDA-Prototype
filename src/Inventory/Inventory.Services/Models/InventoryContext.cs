﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using BuildingBricks.Core;
using BuildingBricks.Core.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace BuildingBricks.Inventory.Models;

public partial class InventoryContext : DbContext
{

	private ConfigServices _configServices;

	public InventoryContext()
	{
	}

	public InventoryContext(ConfigServices configServices) => _configServices = configServices;

	public InventoryContext(DbContextOptions<InventoryContext> options)
			: base(options)
	{
	}

	public virtual DbSet<InventoryAction> InventoryActions { get; set; }

	public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<VwProductInventory> VwProductInventories { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer(_configServices.AzureSqlConnectionString(BuildingBrickSystem.Inventory));

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<InventoryAction>(entity =>
		{
			entity.HasKey(e => e.InventoryActionId).HasName("pkcInventoryAction");

			entity.ToTable("InventoryAction", "Inventory", tb => tb.HasComment("Represents a type of action taken on the inventory of a product."));

			entity.Property(e => e.InventoryActionId)
							.ValueGeneratedNever()
							.HasComment("Identifier for the inventory action.");
			entity.Property(e => e.InventoryActionName)
							.HasMaxLength(100)
							.HasComment("Name for the inventory action.");
		});

		modelBuilder.Entity<InventoryTransaction>(entity =>
		{
			entity.HasKey(e => e.InventoryId).HasName("pkcInventory");

			entity.ToTable("InventoryTransaction", "Inventory", tb => tb.HasComment("Represents the inventory status of a product."));

			entity.Property(e => e.InventoryId).HasComment("Identifier for the product inventory transaction.");
			entity.Property(e => e.ActionDateTime)
							.HasDefaultValueSql("(getutcdate())")
							.HasComment("The date and time of the product inventory transaction.");
			entity.Property(e => e.InventoryActionId).HasComment("Identifier for the associated product inventory action.");
			entity.Property(e => e.InventoryCredit).HasComment("The number of items to credit the product inventory by.");
			entity.Property(e => e.InventoryDebit).HasComment("The number of items to debit the product inventory by.");
			entity.Property(e => e.InventoryReserve).HasComment("The number of items to put on product inventory hold.");
			entity.Property(e => e.OrderNumber)
							.HasMaxLength(100)
							.IsUnicode(false)
							.HasComment("Identifier for any associated product.");
			entity.Property(e => e.ProductId)
							.IsRequired()
							.HasMaxLength(5)
							.IsUnicode(false)
							.IsFixedLength()
							.HasComment("Identifier for the product.");

			entity.HasOne(d => d.InventoryAction).WithMany(p => p.InventoryTransactions)
							.HasForeignKey(d => d.InventoryActionId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("fkInventory_InventoryAction");

			entity.HasOne(d => d.Product).WithMany(p => p.InventoryTransactions)
							.HasForeignKey(d => d.ProductId)
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("fkInventory_Product");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.ProductId).HasName("pkcProduct");

			entity.ToTable("Product", "Product", tb => tb.HasComment("Represents a product in inventory."));

			entity.Property(e => e.ProductId)
							.HasMaxLength(5)
							.IsUnicode(false)
							.IsFixedLength()
							.HasComment("Identifier for the product.");
			entity.Property(e => e.ProductName)
							.IsRequired()
							.HasMaxLength(100)
							.HasComment("Name for the product.");
		});

		modelBuilder.Entity<VwProductInventory>(entity =>
		{
			entity
							.HasNoKey()
							.ToView("vwProductInventory", "Inventory");

			entity.Property(e => e.ProductId)
							.IsRequired()
							.HasMaxLength(5)
							.IsUnicode(false)
							.IsFixedLength();
			entity.Property(e => e.ProductName)
							.IsRequired()
							.HasMaxLength(100);
		});

		OnModelCreatingGeneratedFunctions(modelBuilder);
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}