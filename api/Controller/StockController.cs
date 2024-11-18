using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
    [Route("api/stock")]
    [ApiController]
  public class StrockController: ControllerBase{
    private readonly ApplicationDBContext _context;
    public StrockController(ApplicationDBContext context){
      _context = context;
    }

    [HttpGet]
    public IActionResult GetAll(){
      var stocks = _context.Stock.ToList().Select(s => s.ToStockDto());
      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id){
      var stocks = _context.Stock.Find(id);
      if (stocks == null) return NotFound();
      return Ok(stocks.ToStockDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStockRequestDto stockDto){
      var stockModel = stockDto.ToStockFromCreateDTO();
      _context.Stock.Add(stockModel);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id=stockModel.ID }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody]  UpdateStockRequestDto updateDto){
      var stockModel = _context.Stock.FirstOrDefault(x => x.ID == id);
      if(stockModel == null) return NotFound();
        stockModel.symbol = updateDto.symbol;
        stockModel.companyName = updateDto.companyName;
        stockModel.Purchase = updateDto.Purchase;
        stockModel.LastDiv = updateDto.LastDiv;
        stockModel.Industry = updateDto.Industry;
        stockModel.MarketCap = updateDto.MarketCap;
        _context.SaveChanges();
        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id){
      var stockModel = _context.Stock.FirstOrDefault(x => x.ID == id);
      if(stockModel == null) return NotFound();
      _context.Stock.Remove(stockModel);
      _context.SaveChanges();
      return NoContent();
    }
  }
}