﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using BuildingBricks.Inventory.Models;

namespace BuildingBricks.Inventory.Models
{
    public partial class InventoryContext
    {

        [DbFunction("ufnGetProductInventoryOnHand", "Inventory")]
        public static int? ufnGetProductInventoryOnHand(string ProductId)
        {
            throw new NotSupportedException("This method can only be called from Entity Framework Core queries");
        }

        [DbFunction("ufnGetReservedProductCount", "Inventory")]
        public static int? ufnGetReservedProductCount(string ProductId)
        {
            throw new NotSupportedException("This method can only be called from Entity Framework Core queries");
        }

        protected void OnModelCreatingGeneratedFunctions(ModelBuilder modelBuilder)
        {
        }
    }
}
