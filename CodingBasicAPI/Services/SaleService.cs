using CodingBasicAPI.Data;
using CodingBasicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingBasicAPI.Services;

public class SaleService
{
    private readonly AdventureWorks2019Context _context;

    public SaleService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    
    /// <summary>
    /// Retrieves a list of salespeople from the database based on the specified page number and page size.
    /// </summary>
    /// <param name="pageNumber">The page number of results to retrieve.</param>
    /// <param name="pageSize">The number of items to include on each page of results.</param>
    /// <returns>A list of VSalesPerson objects.</returns>
    public async Task<List<VSalesPerson>> GetAllSales(int pageNumber, int pageSize)
    {
        return await _context.VSalesPeople
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<SalesByPerson>> getSalesByPerson(string personName, int year, int pageNumber, int pageSize)
    {
        try{
            var SqlQuery = from sp in _context.SalesPeople
                            join p in _context.People on sp.BusinessEntityId equals p.BusinessEntityId
                            join soh in _context.SalesOrderHeaders on sp.BusinessEntityId equals soh.SalesPersonId
                            join st in _context.SalesTerritories on sp.TerritoryId equals st.TerritoryId
                            where(p.FirstName + " " + p.LastName).Contains(personName) && soh.OrderDate.AddMonths(6).Year == year
                            select new SalesByPerson {
                                BusinessEntityID = sp.BusinessEntityId,
                                SalesOrderNumber = soh.SalesOrderNumber,
                                SalesPersonName = p.FirstName + " " + p.LastName,
                                TerritoryName = st.Name,
                                DueDate = soh.DueDate,
                                SubTotal = soh.SubTotal,
                                TotalDue = soh.TotalDue
                            };
            
            return await SqlQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }
        return null;
    }
    
}