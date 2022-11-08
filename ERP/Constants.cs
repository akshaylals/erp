namespace ERP;

public static class Constants
{
    public static string apiEndpoint = "http://localhost:3000";

    ////OidcClient Options - AWS
    //public static string authority = "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_Z3HizOtuq/";
    //public static string clientId = "6inagfr1f90pv903vvtd7out3k";
    //public static string redirectUri = "erp://";
    //public static string scope = "openid email profile";
    //public static string clientSecret = "1gi4j6jptekcdptasjsfb5cfrn71avl1u48qohf0uavlr8apgl1l";

    //OidcClient Options - Okta
    public static string authority = "https://dev-1ipheitoccjnh67e.us.auth0.com";
    public static string clientId = "yNZ1SyOXtgWJ6QwyxRADZjl82dKkpCcn";
    public static string redirectUri = "erp://callback";
    public static string scope = "openid email profile";
    public static string clientSecret = "JdJFadUXHdmMvhjgCDMugP_rOvrbcC7hmIr-b6KSnvJJuzRRssS8_TJ5gmhXFgwI";
}
