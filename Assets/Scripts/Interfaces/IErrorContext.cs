using System;

namespace Scripts.Interfaces
{
    public interface IErrorContext
    {
        event Action ErrorShown;
        void Continue();
        void Cancel();
    }
}