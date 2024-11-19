using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository{
    public class StockRepository : IStockRepository
    {
      private readonly ApplicationDBContext _context;
      public StockRepository(ApplicationDBContext context){
        _context = context;
      }

      public async Task<List<Stock>> GetALLAsync(QueryObject query)
      {
          // throw new NotImplementedException();
          var stocks = _context.Stock.Include(c => c.Comments).AsQueryable();
          if (!string.IsNullOrWhiteSpace(query.CompanyName)){
            stocks = stocks.Where(c => c.companyName.Contains(query.CompanyName));
          }
          if (!string.IsNullOrWhiteSpace(query.Symbol)){
            stocks = stocks.Where(s => s.symbol.Contains(query.Symbol));
          }
          if (!string.IsNullOrWhiteSpace(query.SortBy)){
            if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
              stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.symbol) : stocks.OrderBy(s => s.symbol);
          }

          var skipNumber = (query.pageNumber - 1) * query.pageSize;
          return await stocks.Skip(skipNumber).Take(query.pageSize).ToListAsync();
      }

      public async Task<List<Stock>> GetALLAsync1()
      {
          // throw new NotImplementedException();
          return await _context.Stock.Include(c => c.Comments).ToListAsync();
      }

      public async Task<Stock?> GetByIDAsync(int id)
        {
            return await _context.Stock.Include(c => c.Comments).FirstOrDefaultAsync(i => i.ID == id);
        }

      public async Task<Stock> CreateAsync(Stock stockModel)
      {
          // throw new NotImplementedException();
          await _context.Stock.AddAsync(stockModel);
          await _context.SaveChangesAsync();
          return stockModel;
      }

      public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
      {
        var existingStock = await _context.Stock.FirstOrDefaultAsync(x => x.ID == id);
        if (existingStock == null)
        {
            return null;
        }
        existingStock.symbol = stockDto.symbol;
        existingStock.companyName = stockDto.companyName;
        existingStock.Purchase = stockDto.Purchase;
        existingStock.LastDiv = stockDto.LastDiv;
        existingStock.Industry = stockDto.Industry;
        existingStock.MarketCap = stockDto.MarketCap;
        await _context.SaveChangesAsync();
        return existingStock;
      }

      public async Task<Stock?> DeleteAsync(int id)
      {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.ID == id);

        if (stockModel == null)
        {
            return null;
        }

        _context.Stock.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
      }

        public Task<bool> StockExists(int id)
        {
          return _context.Stock.AnyAsync(s => s.ID == id);
        }
    }
}