using Framework.Authentication;

namespace Framework.Classes;

public class AuthConfig
{
    public string Authority { get; set; }
    public string ClientId { get; set; }
    public string RedirectUri { get; set; }
    public string Scope { get; set; }
    public string ClientSecret { get; set; }
}
