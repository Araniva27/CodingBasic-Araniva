using CodingBasicAPI.Models;
using CodingBasicAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasicAPI.Controller;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    PersonService _service;

    public PersonController(PersonService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves a paginated list of persons using a GET request with exception handling.
    /// </summary>
    /// <param name="pageNumber">Page number for result retrieval.</param>
    /// <param name="pageSize">Number of items per page in the results.</param>
    /// <returns>ActionResult<List<Person>>. Returns a paginated list on success; handles exceptions by logging
    /// errors to the console and returning a BadRequest result with an error message.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAll(int pageNumber, int pageSize)
    {        
        try{
            var people = await _service.GetAll(pageNumber, pageSize);
            return Ok(people);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }                
    }

    /// <summary>
    /// Retrieves a list of people by name with exception handling.
    /// </summary>
    /// <param name="name">The method handles an HTTP GET request to fetch a list of people with the specified name.</param>
    /// <returns>
    /// Returns an `Ok` response with the list of people on success. If an exception occurs during the retrieval,
    /// it logs the error to the console and returns a `BadRequest` response with an error message.
    /// </returns>
    [HttpGet("{name}")]
    public async Task<ActionResult<List<EmployeeData>>> GetPersonByName(string name)
    {         
        try{
            var people = await _service.GetPersonByName(name);
            return Ok(people);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }    
    }

    /// <summary>
    /// Retrieves a paginated list of people by person type using a GET request, with exception handling.
    /// </summary>
    /// <param name="personType">Specifies the person type for filtering.</param>
    /// <returns>
    /// ActionResult<List<Person>>. Returns a paginated list of people on success, and handles exceptions by
    /// logging errors to the console and returning a BadRequest result with an error message.
    /// </returns>
    [HttpGet("personType/{personType}")]
    public async Task<ActionResult<List<EmployeeData>>> GetPersonByPersonType(string personType)
    {           
        try{
            var people = await _service.GetPersonByPersonType(personType); 
            return Ok(people);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        } 
    }

    /// <summary>
    /// Retrieves a list of people by name and person type using a GET request, with exception handling.
    /// </summary>
    /// <param name="name">Specifies the name for filtering.</param>
    /// <param name="personType">Specifies the person type for filtering.</param>
    /// <returns>
    /// ActionResult<List<Person>>. Returns a list of people on success, and handles exceptions by
    /// logging errors to the console and returning a BadRequest result with an error message.
    /// </returns>
    [HttpGet("personByNameAndPersonType")]
    public async Task<ActionResult<List<EmployeeData>>> GetPersonByPersonType(string name, string personType)
    {              
        try{
            var people = await _service.GetPersonByNameAndType(name, personType);
            return Ok(people);
        }catch(Exception ex){
            Console.WriteLine($"Error: {ex.Message}");
            return BadRequest("An error occurred while retrieving persons");
        }  
    }
}


