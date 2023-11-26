namespace NajotTalim.Application.Abstractions
{
    public interface IHashProvider
    {
        string GetHash(string password);
    }
}
