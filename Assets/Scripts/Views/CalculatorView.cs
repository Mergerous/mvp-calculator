using System;
using Scripts.Interfaces;
using UnityEngine.UIElements;

namespace Scripts.Views
{
    public class CalculatorView : View, ICalculatorView
    {
        private const string ResultButtonName = "result-button";
        private const string InputFieldName = "input-field";

        private readonly Button _resultButton;
        private readonly TextField _textField;

        public event Action ButtonClicked;
        public event Action<string> InputChanged;

        public string Input
        {
            get => _textField.value;
            set => _textField.value = value;
        }

        public CalculatorView(UIDocument document, VisualTreeAsset asset) : base(document, asset)
        {
            _resultButton = _container.Q<Button>(ResultButtonName);
            _textField = _container.Q<TextField>(InputFieldName);

            _resultButton.clicked += OnResultButtonClicked;
            _textField.RegisterCallback<ChangeEvent<string>>(OnInputChanged);
        }

        private void OnInputChanged(ChangeEvent<string> changeEvent)
        {
            InputChanged?.Invoke(changeEvent.newValue);
        }

        private void OnResultButtonClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}