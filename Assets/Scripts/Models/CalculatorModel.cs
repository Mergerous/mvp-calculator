using System;
using System.Linq;
using System.Text.RegularExpressions;
using Scripts.Configs;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Models
{
    public class CalculatorModel : ICalculatorModel
    {
        private const string InputSaveKey = "input";
        private const string RegexPattern = @"(?<![-.])\b[0-9]+\b(?!\.[0-9])/(?<![-.])\b[0-9]+\b(?!\.[0-9])";

        private readonly CalculatorConfigurationSO _configuration;
        private readonly Regex _regex;

        public event Action<string> AnswerCalculated;
        public event Action ErrorOccured;

        public string Input
        {
            get => PlayerPrefs.GetString(InputSaveKey, _configuration.DefaultInputValue);
            set => PlayerPrefs.SetString(InputSaveKey, value);
        }

        public CalculatorModel(CalculatorConfigurationSO configuration)
        {
            _configuration = configuration;
            _regex = new Regex(RegexPattern);
        }

        public void Clear() => PlayerPrefs.DeleteKey(InputSaveKey);

        public void Calculate(string input)
        {
            if (_regex.IsMatch(input))
            {
                var answer = $"{input.Split("/").ToList().Select(float.Parse).Aggregate((x, y) => x / y)}";
                AnswerCalculated?.Invoke(answer);
                return;
            }

            ErrorOccured?.Invoke();
        }
    }
}