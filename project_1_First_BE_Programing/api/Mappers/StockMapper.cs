using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Stock;
using api.Models;

namespace api.Mappers{
  public static class StockMapper{
    public static StockDto ToStockDto(this Stock stockModel){
      return new StockDto{
        ID = stockModel.ID,
        symbol = stockModel.symbol,
        companyName = stockModel.companyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap,
        Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList(),
      };
    }

    public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto){
      return new Stock{
        ID = stockDto.ID,
        symbol = stockDto.symbol,
        companyName = stockDto.companyName,
        Purchase = stockDto.Purchase,
        LastDiv = stockDto.LastDiv,
        Industry = stockDto.Industry,
        MarketCap = stockDto.MarketCap,
      };
    }
  }
}