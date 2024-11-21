using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Comment;

namespace api.DTOs.Stock{
  public class StockDto{
    public int ID { get; set; }
    public string symbol {get; set; } = string.Empty;
    public string companyName {get; set; } = string.Empty;
    public decimal Purchase {get; set; }
    public decimal LastDiv {get; set; }
    public string Industry {get; set; } = string.Empty;
    public long MarketCap {get; set; }
    public List<CommentDto> Comments {get; set; }
  }
}