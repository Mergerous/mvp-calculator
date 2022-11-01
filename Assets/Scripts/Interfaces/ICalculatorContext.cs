using System;

namespace Scripts.Interfaces
{
    public interface ICalculatorContext
    {
        event Action Started;
        event Action OnQuit;
        event Action Continued;
        void ShowError();
    }
}