namespace Scripts.Interfaces
{
    public interface IErrorModel
    {
        string ErrorMessage { get; }
        void Quit();
    }
}