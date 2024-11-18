using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Stock{
  public class UpdateStockRequestDto{
    public int ID { get; set; }
    public string symbol {get; set; } = string.Empty;
    public string companyName {get; set; } = string.Empty;
    public decimal Purchase {get; set; }
    public decimal LastDiv {get; set; }
    public string Industry {get; set; } = string.Empty;
    public long MarketCap {get; set; }
  }
}