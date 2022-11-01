using System;
using Scripts.Interfaces;
using UnityEngine.UIElements;

namespace Scripts.Views
{
    public class ErrorView : View, IErrorView
    {
        private const string ContinueButtonName = "continue-button";
        private const string QuitButtonName = "quit-button";
        private const string ErrorLabelName = "error-label";
        
        private readonly Button _continueButton;
        private readonly Button _quitButton;
        private readonly Label _errorLabel;
        
        public event Action QuitButtonClicked;
        public event Action ContinueButtonClicked;
        
        public string ErrorMessage
        {
            set => _errorLabel.text = value;
        }
        
        public ErrorView(UIDocument document, VisualTreeAsset asset) : base(document, asset)
        {
            _continueButton = _container.Q<Button>(ContinueButtonName);
            _quitButton = _container.Q<Button>(QuitButtonName);
            _errorLabel = _container.Q<Label>(ErrorLabelName);

            _continueButton.clicked += OnContinueButtonClicked;
            _quitButton.clicked += OnQuitButtonClicked;
        }

        ~ErrorView()
        {
            _continueButton.clicked -= OnContinueButtonClicked;
            _quitButton.clicked -= OnQuitButtonClicked;
        }
        
        private void OnContinueButtonClicked() => ContinueButtonClicked?.Invoke();
        private void OnQuitButtonClicked() => QuitButtonClicked?.Invoke();
    }
}