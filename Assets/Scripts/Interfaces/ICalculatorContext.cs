using System;

namespace Scripts.Interfaces
{
    public interface ICalculatorContext
    {
        event Action Started;
        event Action Quit;
        event Action Continued;
        void ShowError();
    }
}