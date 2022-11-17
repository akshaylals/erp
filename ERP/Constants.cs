using static System.Formats.Asn1.AsnWriter;

namespace ERP;

public static class Constants
{
#if ANDROID
    public static string apiEndpoint = "http://172.20.0.1:3000";
#else
    public static string apiEndpoint = "http://localhost:3000";
#endif

    ////OidcClient Options - AWS
    //public static string authority = "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_Z3HizOtuq/";
    //public static string clientId = "6inagfr1f90pv903vvtd7out3k";
    //public static string redirectUri = "erp://";
    //public static string scope = "openid email profile";
    //public static string clientSecret = "1gi4j6jptekcdptasjsfb5cfrn71avl1u48qohf0uavlr8apgl1l";

    //OidcClient Options - Okta
    public static AuthConfig authConfig = new AuthConfig
    {
        Authority = "https://dev-1ipheitoccjnh67e.us.auth0.com",
        ClientId = "yNZ1SyOXtgWJ6QwyxRADZjl82dKkpCcn",
        RedirectUri = "erp://callback",
        Scope = "openid email profile",
        ClientSecret = "JdJFadUXHdmMvhjgCDMugP_rOvrbcC7hmIr-b6KSnvJJuzRRssS8_TJ5gmhXFgwI"
    };
}
