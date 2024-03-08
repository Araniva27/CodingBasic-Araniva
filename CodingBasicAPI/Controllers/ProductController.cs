using CodingBasicAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasicAPI.Controller;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    /// <summary>
    /// Uses HTTP GET request to asynchronously retrieve a paginated list of persons with exception handling.
    /// </summary>
    /// <param name="pageNumber">Specifies the page number for result retrieval.</param>
    /// <param name="pageSize">Specifies the number of items per page in the results.</param>
    /// <returns>ActionResult<List<Person>>. Returns Ok result with the list of persons on success, and
    /// BadRequest result with an error message on exception, logging the error to the console.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAll(int pageNumber, int pageSize)
    {        
        try{
            var products = await _service.GetAll(pageNumber, pageSize);
            return Ok(products);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }

    /// <summary>
    /// Uses a GET request to retrieve a list of persons by name with exception handling.
    /// </summary>
    /// <param name="name">The `HttpGet` attribute specifies that the `GetAll` method can be accessed via
    /// a GET request with a route parameter named `name`. When making a GET request, provide a value
    /// for the `name` parameter.</param>
    /// <returns>ActionResult<List<Person>>. Returns a list of `Person` objects on success, and handles
    /// any exceptions that may occur.</returns>
    [HttpGet("{name}")]
    public async Task<ActionResult<List<Person>>> GetAll(string name)
    {        
        try{
            var products = await _service.GetProductByName(name);
            return Ok(products);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }

    /// <summary>
    /// Retrieves a list of persons based on a specified category type using a GET request,
    /// with exception handling.
    /// </summary>
    /// <param name="categoryType">The category type parameter obtained from the route in the GET request.
    /// Specifies the type of category for filtering persons.</param>
    /// <returns>
    /// ActionResult<List<Person>>. Returns a list of persons on success, and handles exceptions by logging
    /// the error to the console and returning a BadRequest result with an error message.
    /// </returns>
    [HttpGet("ProductByCategoryType/{categoryType}")]
    public async Task<ActionResult<List<Person>>> GetProductByCategoryType(string categoryType)
    {        
        try{
            var products = await _service.GetProductByCategoryType(categoryType);
            return Ok(products);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }
}