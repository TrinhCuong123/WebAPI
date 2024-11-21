using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace api.Models{
  [Table("Stocks")]
  public class Stock{
    public int ID { get; set; }
    public string symbol {get; set; } = string.Empty;
    public string companyName {get; set; } = string.Empty;
    [Column(TypeName="decimal(18,2)")]
    public decimal Purchase {get; set; }
    [Column(TypeName="decimal(18,2)")]
    public decimal LastDiv {get; set; }
    public string Industry {get; set; } = string.Empty;
    public long MarketCap {get; set; }
    public List<Comment> Comments {get; set; } = new List<Comment>();
    public List<Portfolio> portfolios { get; set; } = new List<Portfolio>();

  }
}