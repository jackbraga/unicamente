namespace Unicamente.Application.Interfaces
{
    public interface ILoginService
    {
        void ConfirmarEmail(string hash);
    }
}
