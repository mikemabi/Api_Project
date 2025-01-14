﻿using ApiProject.Core.Entities;
using ApiProject.Core.Interfaces;
using ApiProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchExample.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _dbContext;
        public ProductRepository(MyDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task EditProduct(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }
        public IQueryable<Product> GetProducts()
        {
            return _dbContext.Products.AsQueryable();
        }
    }
}
