namespace _130926_Kuharica_Project.Auth
{
    public interface ITokenService
    {
        string CreateToken(string username, string role);
    }
}
