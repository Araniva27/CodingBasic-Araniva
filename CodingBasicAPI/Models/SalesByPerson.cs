
namespace CodingBasicAPI.Models;

public class SalesByPerson
{
    /// <summary>
    /// Primary key
    /// </summary>
    public int BusinessEntityID { get; set; }
    
    /// <summary>
    /// Unique sales order identification number.
    /// </summary>
    public string? SalesOrderNumber { get; set; }

    /// <summary>
    /// Name of the person responsible for the sale
    /// </summary>
    public string? SalesPersonName { get; set; }

    /// <summary>
    /// Name of the territory in which the sale was made
    /// </summary>
    public string? TerritoryName { get; set; }

    /// <summary>
    /// Date the order is due to the customer
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Sales subtotal
    /// </summary>
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Total due from customer
    /// </summary>
    public decimal TotalDue { get; set; }
}