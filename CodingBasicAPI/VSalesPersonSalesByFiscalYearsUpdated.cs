using System;
using System.Collections.Generic;

namespace CodingBasicAPI;

public partial class VSalesPersonSalesByFiscalYearsUpdated
{
    public int? SalesPersonId { get; set; }

    public string? FullName { get; set; }

    public string JobTitle { get; set; } = null!;

    public string SalesTerritory { get; set; } = null!;

    public decimal? _2011 { get; set; }

    public decimal? _2012 { get; set; }

    public decimal? _2013 { get; set; }
}
