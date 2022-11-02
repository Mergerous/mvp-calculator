using Scripts.Interfaces;

namespace Scripts.Presenters
{
    public class CalculatorPresenter
    {
        private readonly ICalculatorView _view;
        private readonly ICalculatorModel _model;
        private readonly ICalculatorContext _context;

        public CalculatorPresenter(ICalculatorContext context, ICalculatorView view, ICalculatorModel model)
        {
            _view = view;
            _model = model;
            _context = context;

            _view.Input = _model.Input;
            _view.ButtonClicked += Calculate;
            _view.InputChanged += SetInput;

            _model.AnswerCalculated += SetOutput;
            _model.ErrorOccured += ShowError;

            _context.Continued += Continue;
            _context.Quit += Quit;
            _context.Started += _view.Open;
        }

        private void ShowError()
        {
            _view.Close();
            _context.ShowError();
        }

        private void Continue()
        {
            _model.Clear();
            _view.Input = _model.Input;
            _view.Open();
        }

        private void Quit()
        {
            _view.Close();
            _model.Clear();
        }

        private void SetOutput(string output) => _view.Input = output;
        private void SetInput(string input) => _model.Input = input;
        private void Calculate() => _model.Calculate(_view.Input);
    }
}