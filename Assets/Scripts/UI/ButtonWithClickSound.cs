﻿using System;
using Core.Services.AudioService;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ButtonWithClickSound : MonoBehaviour
    {
        [SerializeField] private SoundType SoundType = SoundType.Click;
        [SerializeField] private Button Button;
        
        private IAudioService _audioService;
        private Action _onClickEvent;
        
        public bool Interactable
        {
            get => Button.interactable;
            set => Button.interactable = value;
        }

        public void Init(IAudioService audioService, Action onClickEvent)
        {
            _audioService = audioService;
            _onClickEvent = onClickEvent;
            Button.onClick.AddListener(OnButtonClick);
        }
        
        public void DeInit()
        {
            Button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _audioService.PlaySoundByType(SoundType);
            _onClickEvent?.Invoke();
        }
    }
}