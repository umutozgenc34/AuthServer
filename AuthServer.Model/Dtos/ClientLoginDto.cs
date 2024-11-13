

using System.Globalization;

namespace AuthServer.Model.Dtos;

public class ClientLoginDto
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
}
