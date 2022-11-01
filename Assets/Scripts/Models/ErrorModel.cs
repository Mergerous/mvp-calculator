using Scripts.Configs;
using Scripts.Interfaces;

namespace Scripts.Models
{
    public class ErrorModel : IErrorModel
    {
        private readonly ErrorConfigurationSO _configuration;
        
        public string ErrorMessage => _configuration.ErrorText;
        
        public ErrorModel(ErrorConfigurationSO configuration)
        {
            _configuration = configuration;
        }

        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}