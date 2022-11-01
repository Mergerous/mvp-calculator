using System;
using Scripts.Models;

namespace Scripts.Interfaces
{
    public interface ICalculatorView : IView
    {
        event Action ButtonClicked;
        event Action<string> InputChanged;
        string Input { get; set; }
    }
}