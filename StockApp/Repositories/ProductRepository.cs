﻿using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockApp.DTOs;

namespace StockApp.Repositories
{
    public class ProductRepository(DbContextStock _context) : IProductRepository
    {
        public async Task<PagedResult<Product>> GetPagedAsync(int page, int pageSize)
        {
            var totalItems = await _context.Products.CountAsync();
            var items =  await _context.Products
                                        .OrderBy(p => p.Id)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
                                                                                                              
            return new PagedResult<Product>
            {
                Items = items,
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page
            };
        }

        public async Task<List<Product>> SearchAsync(string? productId, int? providerId, string? description)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(productId))
                query = query.Where(p => p.ProductId.ToLower().Contains(productId.ToLower()));
            
            if (providerId.HasValue)
                query = query.Where(p => p.ProviderId == providerId.Value);
            
            if (!string.IsNullOrWhiteSpace(description))
                query = query.Where(p => p.Description.ToLower().Contains(description.ToLower()));

            return await query.ToListAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> EditProductAsync(EditProductDTO editDto)
        {
            var product = await _context.Products.FindAsync(editDto.ProductId);
            if (product == null)
                return false;

            if (!string.IsNullOrWhiteSpace(editDto.Description))
                product.Description = editDto.Description;

            if (editDto.Quantity.HasValue)
                product.Quantity = editDto.Quantity.Value;

            await _context.SaveChangesAsync();
            return true;    

        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
