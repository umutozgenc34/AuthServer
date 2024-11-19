

namespace AuthServer.Model.Dtos;

public record CreateProductRequest(string Name,decimal Price , int Stock,string UserId);
