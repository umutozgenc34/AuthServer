

using AuthServer.Model.Dtos;
using Core.ReturnModels;

namespace AuthServer.Service.Abstract;

public interface IProductService
{
    Task<ReturnModel<List<ProductDto>>> GetAllAsync();
    Task<ReturnModel<ProductDto>> CreateAsync(CreateProductRequest request);
}
