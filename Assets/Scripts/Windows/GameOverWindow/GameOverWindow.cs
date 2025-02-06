using System;
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
        
        public void Init(Action<string> onRestart, Action<string> onMenu)
        {
            _onRestart = onRestart;
            _onMenu = onMenu;
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
            bool active = text.Length is >= 4 and <= 10;

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