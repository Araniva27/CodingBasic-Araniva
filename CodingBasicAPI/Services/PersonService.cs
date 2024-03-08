using CodingBasicAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingBasicAPI.Services;

public class PersonService
{
    private readonly AdventureWorks2019Context _context;

    
    public PersonService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    
    /// <summary>
    /// Asynchronously retrieves a list of Person objects from a database based on the specified
    /// page number and page size.
    /// </summary>
    /// <param name="pageNumber">Specifies the page number for result retrieval, used to calculate
    /// the skip count based on the page size.</param>
    /// <param name="pageSize">Specifies the number of records per page when paginating through
    /// a list of Person entities.</param>
    /// <returns>A List<Person> is returned asynchronously.</returns>
    public async Task<List<Person>> GetAll(int pageNumber, int pageSize)
    {
        try{
            return await _context.People
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }       
        return null;                          
    }

    /// <summary>
    /// Asynchronously retrieves a list of people with a specific first name from a database context.
    /// </summary>
    /// <param name="name">Filters `Person` objects based on the provided first name.</param>
    /// <returns>A `List<Person>` is returned asynchronously.</returns>
    public async Task<List<Person>> GetPersonByName(string name)
    {
        try{
            return await _context.People
                        .Where(p => p.FirstName == name)
                        .ToListAsync();
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }
        return null;
    }


    /// <summary>
    /// Retrieves a paginated list of people based on their specified type.
    /// </summary>
    /// <param name="personType">Filters people based on their type.</param>
    /// <param name="pageNumber">Specifies the page number of results to retrieve.</param>
    /// <param name="pageSize">Represents the number of records per page for pagination.</param>
    /// <returns>A list of `Person` objects based on the specified criteria. In case of an exception,
    /// returns `null` after logging an error message to the console.</returns>
    public async Task<List<Person>> GetPersonByPersonType(string personType, int pageNumber, int pageSize)
    {
        try{        
            return await _context.People
                        .Where(p => p.PersonType == personType)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");            
        }
        return null;
    }

    /// <summary>
    /// Asynchronously retrieves a list of people by their first name and person type.
    /// </summary>
    /// <param name="name">Filters the list of people based on their first name.</param>
    /// <param name="personType">Represents the type of person to search for in the database.</param>
    /// <returns>A `Task<List<Person>>` is returned asynchronously.</returns>
    public async Task<List<Person>> GetPersonByNameAndPersonType(string name, string personType)
    {
        try{
            return await _context.People
                        .Where(p => p.FirstName == name)
                        .Where(p => p.PersonType == personType)
                        .ToListAsync();
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");            
        }
        return null;
    }


}