using AuthServer.Model.Dtos;
using AuthServer.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts() => Ok(await productService.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request) => Ok(await productService
    .CreateAsync(request));
}
