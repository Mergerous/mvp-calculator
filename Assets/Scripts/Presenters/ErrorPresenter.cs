using Scripts.Interfaces;

namespace Scripts.Presenters
{
    public class ErrorPresenter
    {
        private readonly IErrorContext _context;
        private readonly IErrorView _view;
        private readonly IErrorModel _model;
        
        public ErrorPresenter(IErrorContext context, IErrorView view, IErrorModel model)
        {
            _context = context;
            _view = view;
            _model = model;

            _view.ContinueButtonClicked += Continue;
            _view.QuitButtonClicked += Quit;
            _context.ErrorShown += OpenDialog;
        }

        private void Continue()
        {
            _view.Close();
            _context.Continue();
        }
        private void Quit()
        {
            _view.Close();
            _context.Cancel();
            _model.Quit();
        }
        private void OpenDialog()
        {
            _view.Open();
            _view.ErrorMessage = _model.ErrorMessage;
        }
    }
}