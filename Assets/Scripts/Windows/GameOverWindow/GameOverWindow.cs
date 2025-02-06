using System;
using Configs;
using Core.Services.AudioService;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.GameOverWindow
{
    public class GameOverWindow : BaseWindow
    {
        [SerializeField] private TMP_InputField NameInputField;
        [SerializeField] private ButtonWithClickSound RestartButton, MenuButton;

        private Action<string> _onRestart, _onMenu;
        private int _minNameLength, _maxNameLength;

        private IAudioService _audioService;
        
        public void Init(Action<string> onRestart, Action<string> onMenu, RecordsConfig recordsConfig,
            IAudioService audioService)
        {
            _audioService = audioService;
            
            _onRestart = onRestart;
            _onMenu = onMenu;

            _minNameLength = recordsConfig.MinNameLength;
            _maxNameLength = recordsConfig.MaxNameLength;
        }

        public override void Show()
        {
            NameInputField.onValueChanged.AddListener(OnNameInputValueChanged);
            RestartButton.Init(_audioService, OnRestartButtonClicked);
            MenuButton.Init(_audioService, OnMenuButtonClicked);
            
            NameInputField.text = "";
            
            base.Show();
        }

        public override void Hide()
        {
            NameInputField.onValueChanged.RemoveListener(OnNameInputValueChanged);
            RestartButton.DeInit();
            MenuButton.DeInit();
            
            base.Hide();
        }

        private void OnNameInputValueChanged(string text)
        {
            bool active = text.Length >= _minNameLength && text.Length <= _maxNameLength;

            RestartButton.Interactable = active;
            MenuButton.Interactable = active;
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