using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.respository{
    public class StockRespository : IStockRepository
    {
      private readonly ApplicationDBContext _context;
      public StockRespository(ApplicationDBContext context){
        _context = context;
      }

      public Task<List<Stock>> GetALLAsync()
      {
          // throw new NotImplementedException();
          return _context.Stock.ToListAsync();
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
    }
}