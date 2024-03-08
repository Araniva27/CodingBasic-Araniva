using CodingBasicAPI.Services;
using CodingBasicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasicAPI.Controller;

[ApiController]
[Route("[controller]")]

public class SaleController : ControllerBase
{
    SaleService _service;

    public SaleController(SaleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAllSales(int pageNumber, int pageSize)
    {        
        try{
            var allSales = await _service.GetAllSales(pageNumber, pageSize);
            return Ok(allSales);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }

    [HttpGet("getSalesByPerson")]
    public async Task<ActionResult<List<Person>>> GetAllSales(string personName, int year ,int pageNumber, int pageSize)
    {        
        try{
            var sales = await _service.getSalesByPerson(personName, year, pageNumber, pageSize);
            return Ok(sales);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }
}