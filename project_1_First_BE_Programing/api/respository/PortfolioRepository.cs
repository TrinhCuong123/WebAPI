using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class PortfolioRepository : IPortfolioRepository
  {
    private readonly ApplicationDBContext _context;
    public PortfolioRepository(ApplicationDBContext context)
    {
      _context = context;
    }

    public async Task<Portfolio> CreateAsync(Portfolio portfolio)
    {
      await _context.Portfolio.AddAsync(portfolio);
      await _context.SaveChangesAsync();
      return portfolio;
    }

    public async Task<Portfolio> DeleteAsync(AppUser appUser, string symbol)
    {
      var portfolioModel = await _context.Portfolio.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.symbol.ToLower() == symbol.ToLower());
      if (portfolioModel == null) return null;
      _context.Portfolio.Remove(portfolioModel);
      await _context.SaveChangesAsync();
      return portfolioModel;
    }

    public async Task<List<Stock>> GetUserPortfolio(AppUser user)
    {
      return await _context.Portfolio.Where(u => u.AppUserId == user.Id)
      .Select(stock => new Stock
      {
        ID = stock.StockID,
        symbol = stock.Stock.symbol,
        companyName = stock.Stock.companyName,
        Purchase = stock.Stock.Purchase,
        LastDiv = stock.Stock.LastDiv,
        Industry = stock.Stock.Industry,
        MarketCap = stock.Stock.MarketCap
      }).ToListAsync();
    }
  }
}