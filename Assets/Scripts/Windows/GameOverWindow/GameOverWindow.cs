using System;
using Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.GameOverWindow
{
    public class GameOverWindow : BaseWindow
    {
        [SerializeField] private TMP_InputField NameInputField;
        [SerializeField] private Button RestartButton, MenuButton;

        private Action<string> _onRestart, _onMenu;
        private int _minNameLength, _maxNameLength;
        
        public void Init(Action<string> onRestart, Action<string> onMenu, RecordsConfig recordsConfig)
        {
            _onRestart = onRestart;
            _onMenu = onMenu;

            _minNameLength = recordsConfig.MinNameLength;
            _maxNameLength = recordsConfig.MaxNameLength;
        }

        public override void Show()
        {
            NameInputField.onValueChanged.AddListener(OnNameInputValueChanged);
            RestartButton.onClick.AddListener(OnRestartButtonClicked);
            MenuButton.onClick.AddListener(OnMenuButtonClicked);
            
            NameInputField.text = "";
            
            base.Show();
        }

        public override void Hide()
        {
            NameInputField.onValueChanged.RemoveListener(OnNameInputValueChanged);
            RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            MenuButton.onClick.RemoveListener(OnMenuButtonClicked);
            
            base.Hide();
        }

        private void OnNameInputValueChanged(string text)
        {
            bool active = text.Length >= _minNameLength && text.Length <= _maxNameLength;

            RestartButton.interactable = active;
            MenuButton.interactable = active;
        }

        private void OnRestartButtonClicked()
        {
            Hide();
            _onRestart?.Invoke(NameInputField.text);
        }

        private void OnMenuButtonClicked()
        {
            Hide();
            _onMenu?.Invoke(NameInputField.text);
        }
    }
}