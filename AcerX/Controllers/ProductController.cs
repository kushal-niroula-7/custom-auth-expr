using AcerX.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AcerX.Controllers;

public class ProductController : Controller
{
    public async Task<IActionResult> IndexAsync()
    {
        using var connection = ConnectionProvider.GetDbConnection();

        var query = "select * from \"Products\" p";

        var products = await connection.QueryAsync<Product>(query);

        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        using var connection = ConnectionProvider.GetDbConnection();

        var query = $"select * from \"Products\" p WHERE \"Id\" = @paramId";

        var product = await connection.QueryFirstOrDefaultAsync<Product>(query, new
        {
            paramId = id
        });

        return View(product);
    }


}
