using Scripts.Configs;
using Scripts.Contexts;
using Scripts.Models;
using Scripts.Presenters;
using Scripts.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField] private ErrorConfigurationSO _errorConfigurationSo;
        [SerializeField] private CalculatorConfigurationSO _calculatorConfigurationSo;
        
        [Header("UI")]
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _calculatorTreeAsset;
        [SerializeField] private VisualTreeAsset _errorTreeAsset;
        
        private Context _context;
        
        private void Awake()
        {
            _context = new Context();
            
            var calculatorView = new CalculatorView(_uiDocument, _calculatorTreeAsset);
            var calculatorModel = new CalculatorModel(_calculatorConfigurationSo);
            var presenter = new CalculatorPresenter(_context, calculatorView, calculatorModel);

            var errorView = new ErrorView(_uiDocument, _errorTreeAsset);
            var errorModel = new ErrorModel(_errorConfigurationSo);
            var errorPresenter = new ErrorPresenter(_context, errorView, errorModel);
        }

        private void Start()
        {
            _context.Start();
        }
    }
}