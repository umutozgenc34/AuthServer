

using Microsoft.AspNetCore.Identity;

namespace AuthServer.Model.Entity;

public class UserApp : IdentityUser
{
    public string City { get; set; }
}
