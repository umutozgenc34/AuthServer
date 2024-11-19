

using AuthServer.Model.Dtos;
using AuthServer.Model.Entity;
using AuthServer.Repository.Abstracts;
using AuthServer.Service.Abstract;
using AutoMapper;
using Core.ReturnModels;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Service.Concrete;

public class ProductService(IProductRepository productRepository,IMapper mapper, IUnitOfWork unitOfWork) : IProductService
{
    public async Task<ReturnModel<ProductDto>> CreateAsync(CreateProductRequest request)
    {
        var product = mapper.Map<Product>(request);
        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        var productAsDto = mapper.Map<ProductDto>(product);

        return ReturnModel<ProductDto>.Success(productAsDto);

    }

    public async Task<ReturnModel<List<ProductDto>>> GetAllAsync()
    {
        var products = await productRepository.GetAll().ToListAsync();
        var productsAsDto = mapper.Map<List<ProductDto>>(products);

        return ReturnModel<List<ProductDto>>.Success(productsAsDto);
    }
}
