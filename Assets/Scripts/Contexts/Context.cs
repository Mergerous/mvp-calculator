using System;
using Scripts.Interfaces;

namespace Scripts.Contexts
{
    public class Context : ICalculatorContext, IErrorContext
    {
        public event Action Started;
        public event Action OnQuit;
        public event Action Continued;
        public event Action ErrorOpen;

        public void Start() => Started?.Invoke();
        public void Continue() => Continued?.Invoke();
        public void Quit() => OnQuit?.Invoke();
        public void ShowError() => ErrorOpen?.Invoke();
    }
}