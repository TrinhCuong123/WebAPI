using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Stock;
using api.helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/stock")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDBContext _context;
    private readonly IStockRepository _stockRespo;
    public StockController(ApplicationDBContext context, IStockRepository stockRespo)
    {
      _stockRespo = stockRespo;
      _context = context;
    }

    // [HttpGet]
    // public IActionResult GetAll(){
    //   var stocks = _context.Stock.ToList().Select(s => s.ToStockDto());
    //   return Ok(stocks);
    // }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
      var stocks = await _stockRespo.GetALLAsync(query); ;
      var stockDto = stocks.Select(s => s.ToStockDto());
      return Ok(stocks);
    }

    [HttpGet("GetFuLLData")]
    [Authorize]
    public async Task<IActionResult> GetAll1()
    {
      var stocks = await _stockRespo.GetALLAsync1(); ;
      var stockDto = stocks.Select(s => s.ToStockDto());
      return Ok(stocks);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var stocks = await _stockRespo.GetByIDAsync(id);
      if (stocks == null) return NotFound();
      return Ok(stocks.ToStockDto());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
      var stockModel = stockDto.ToStockFromCreateDTO();
      await _stockRespo.CreateAsync(stockModel);
      return CreatedAtAction(nameof(GetById), new { id = stockModel.ID }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
      var stockModel = await _stockRespo.UpdateAsync(id, updateDto);
      if (stockModel == null) return NotFound();

      return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var stockModel = await _stockRespo.DeleteAsync(id);

      if (stockModel == null)
      {
        return NotFound();
      }

      return NoContent();
    }
  }
}