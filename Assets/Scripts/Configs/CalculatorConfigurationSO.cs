using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Calculator Configuration SO")]
    public class CalculatorConfigurationSO : ScriptableObject
    {
        [SerializeField] private string _defaultInputValue;
        public string DefaultInputValue => _defaultInputValue;
    }
}