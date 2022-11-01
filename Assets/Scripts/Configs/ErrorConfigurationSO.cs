using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Error Configuration SO")]
    public class ErrorConfigurationSO : ScriptableObject
    {
        [TextArea] [SerializeField] private string _errorText;
        public string ErrorText => _errorText;
    }
}