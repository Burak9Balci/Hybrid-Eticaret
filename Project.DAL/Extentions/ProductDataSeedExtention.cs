﻿using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Extentions
{
    public static class ProductDataSeedExtention
    {
        public static void SeedProducts(ModelBuilder modelBuilder)
        {
            List<Product> products = new();
            for (int i = 1; i < 11; i++)
            {
                Product p = new()
                {
                    ID = i,
                    ProductName = new Commerce("tr").ProductName(),
                    UnitPrice = Convert.ToDecimal(new Commerce("tr").Price()),
                    UnitInStock = 100,
                    CategoryID = i,
                    ImagePath = new Images().Nightlife()
                };
                products.Add(p);
            }
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
