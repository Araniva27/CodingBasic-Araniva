using CodingBasicAPI.Data;
using CodingBasicAPI.Models;
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
    public async Task<List<VEmployee>> GetAll(int pageNumber, int pageSize)
    {
        try{
            return await _context.VEmployees
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
    /// <param name="EmployeeName">Filters `Person` objects based on the provided first name.</param>
    /// <returns>A `List<Person>` is returned asynchronously.</returns>
    public async Task<List<EmployeeData>> GetPersonByName(string EmployeeName)
    {
        try
        {            
            var query = (from e in _context.Employees
                        join p in _context.People on e.BusinessEntityId equals p.BusinessEntityId
                        where (p.FirstName+ " " + p.LastName).Contains(EmployeeName)
                        select new EmployeeData
                        {
                            BusinessEntityID = e.BusinessEntityId,
                            EmployeeName = p.FirstName + " " + p.LastName,
                            PersonType = p.PersonType,
                            Gender = e.Gender,
                            DateOfBirth = e.BirthDate.ToString(),
                            MaritalStatus = e.MaritalStatus,
                            JobTitle = e.JobTitle,
                            VacationHours = e.VacationHours,
                            HireDate = e.HireDate.ToString()
                        });

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return null;
    }


    /// <summary>
    /// Retrieves a paginated list of people based on their specified type.
    /// </summary>
    /// <param name="personType">Filters people based on their type.</param>
    /// <returns>A list of `Person` objects based on the specified criteria. In case of an exception,
    /// returns `null` after logging an error message to the console.</returns>
    public async Task<List<EmployeeData>> GetPersonByPersonType(string personType)
    {
        try
        {
            var employees = await _context.Employees
                                .Join(_context.People, e => e.BusinessEntityId,p => p.BusinessEntityId, (e, p) => new { e, p })
                                .Where(ep => ep.p.PersonType == personType)
                                .Select(ep => new EmployeeData
                                {
                                    BusinessEntityID = ep.e.BusinessEntityId,
                                    EmployeeName = ep.p.FirstName + " " + ep.p.LastName,
                                    PersonType = ep.p.PersonType,
                                    Gender = ep.e.Gender,
                                    DateOfBirth = ep.e.BirthDate.ToString(),
                                    MaritalStatus = ep.e.MaritalStatus,
                                    JobTitle = ep.e.JobTitle,
                                    VacationHours = ep.e.VacationHours,
                                    HireDate = ep.e.HireDate.ToString()
                                })
                                .ToListAsync();
            
            return employees;
        }                
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return null;
    }

    /// <summary>
    /// Asynchronously retrieves a list of people by their first name and person type.
    /// </summary>
    /// <param name="employeeName">Filters the list of people based on their first name.</param>
    /// <param name="personType">Represents the type of person to search for in the database.</param>
    /// <returns>A `Task<List<Person>>` is returned asynchronously.</returns>
    public async Task<List<EmployeeData>> GetPersonByNameAndType(string employeeName, string personType)
    {
        try
        {
            var employees = await _context.Employees
                                    .Join(_context.People, e => e.BusinessEntityId, p => p.BusinessEntityId, (e, p) => new { e, p })
                                    .Where(ep => ep.p.FirstName.Contains(employeeName) && ep.p.PersonType == personType)
                                    .Select(ep => new EmployeeData
                                    {
                                        BusinessEntityID = ep.e.BusinessEntityId,
                                        EmployeeName = ep.p.FirstName + " " + ep.p.LastName,
                                        Gender = ep.e.Gender,
                                        DateOfBirth = ep.e.BirthDate.ToString(),
                                        MaritalStatus = ep.e.MaritalStatus,
                                        JobTitle = ep.e.JobTitle,
                                        VacationHours = ep.e.VacationHours,
                                        HireDate = ep.e.HireDate.ToString()
                                    })
                                    .ToListAsync();

            return employees;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return null;
    }


}