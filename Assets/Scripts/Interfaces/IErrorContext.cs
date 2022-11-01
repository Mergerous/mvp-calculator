using System;

namespace Scripts.Interfaces
{
    public interface IErrorContext
    {
        event Action ErrorOpen;
        void Continue();
        void Quit();
    }
}