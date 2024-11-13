
namespace AuthServer.Model.Dtos;

public class ClientTokenDto
{
    public string AccessToken { get; set; }

    public DateTime AccessTokenExpiration { get; set; }
}
