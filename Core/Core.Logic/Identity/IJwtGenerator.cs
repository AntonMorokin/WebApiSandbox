namespace Core.Logic.Identity
{
    public interface IJwtGenerator
    {
        string Generate(string userId);
    }
}