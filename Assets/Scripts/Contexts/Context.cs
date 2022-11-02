using System;
using Scripts.Interfaces;

namespace Scripts.Contexts
{
    public class Context : ICalculatorContext, IErrorContext
    {
        public event Action Started;
        public event Action Quit;
        public event Action Continued;
        public event Action ErrorShown;

        public void Start() => Started?.Invoke();
        public void Continue() => Continued?.Invoke();
        public void Cancel() => Quit?.Invoke();
        public void ShowError() => ErrorShown?.Invoke();
    }
}