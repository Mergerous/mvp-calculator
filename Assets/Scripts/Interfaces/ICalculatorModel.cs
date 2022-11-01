using System;

namespace Scripts.Interfaces
{
    public interface ICalculatorModel
    {
        event Action<string> AnswerCalculated;
        event Action ErrorOccured;
        void Calculate(string input);
        void Clear();
        string Input { get; set; }
    }
}