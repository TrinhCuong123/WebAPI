using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.helpers;
using api.Models;

namespace api.Interfaces{
  public interface IStockRepository{
    Task<List<Stock>> GetALLAsync(QueryObject query);
    Task<List<Stock>> GetALLAsync1();
    Task<Stock> GetByIDAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> StockExists(int id);
    }
}