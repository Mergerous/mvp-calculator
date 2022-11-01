using System;

namespace Scripts.Interfaces
{
    public interface IErrorView : IView
    {
        string ErrorMessage { set; }
        event Action QuitButtonClicked;
        event Action ContinueButtonClicked;
    }
}