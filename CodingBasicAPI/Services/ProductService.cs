
using CodingBasicAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingBasicAPI.Services;

public class ProductService
{
    private readonly AdventureWorks2019Context _context;
    
    public ProductService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Asynchronously retrieves a list of products from the database based on the specified
    /// page number and page size.
    /// </summary>
    /// <param name="pageNumber">Represents the page number of the results to retrieve. It
    /// determines the skip count in the database query based on the page size.</param>
    /// <param name="pageSize">Represents the number of products per page in the results.
    /// It determines the size of each page when paginating through the products.</param>
    /// <returns>A `List<Product>` is returned asynchronously.</returns>
    public async Task<List<Product>> GetAll(int pageNumber, int pageSize)
    {
        try{
            return await _context.Products
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();            
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }       
        return null;                          
    }

    /// <summary>
    /// Asynchronously retrieves a list of products by name from a database context.
    /// </summary>
    /// <param name="name">The asynchronous method `GetProductByName` takes a `string` parameter
    /// named `name` to filter products by their name.</param>
    /// <returns>A `Task<List<Product>>` is returned from the `GetProductByName` method.</returns>
    public async Task<List<Product>> GetProductByName(string name)
    {
        try{
            return await _context.Products
                        .Where(p => p.Name == name)
                        .ToListAsync();            
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }       
        return null;                          
    }

    /// <summary>
    /// Retrieves a list of products based on a specified category type asynchronously.
    /// </summary>
    /// <param name="categoryTypeName">The method `GetProductByCategoryType` takes a `categoryTypeName`
    /// parameter, representing the name of the product category type. It retrieves a list of products
    /// belonging to the specified category type from the database.</param>
    /// <returns>A `Task<List<Product>>` is returned from the `GetProductByCategoryType` method.</returns>
    public async Task<List<Product>> GetProductByCategoryType(string categoryTypeName)
    {
        try{
            return await _context.Products
                                .Where(p => p.ProductSubcategory.ProductCategory.Name == categoryTypeName)
                        .ToListAsync();            
        }catch(Exception ex){
            Console.WriteLine($"Just error {ex.Message}");
        }       
        return null;                          
    }
}