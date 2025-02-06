using System.Collections.Generic;
using Configs;
using Core.Services.ConfigProvider;
using UnityEngine;
using Zenject;

namespace Core.Services.AudioService
{
    public class AudioService : IAudioService
    {
        private readonly AudioSource _musicSource, _soundSource;
        private readonly AudioConfig _audioConfig;
        
        [Inject]
        public AudioService(AudioSource musicSource, AudioSource soundSource, IConfigProvider configProvider)
        {
            _musicSource = musicSource;
            _soundSource = soundSource;

            _audioConfig = configProvider.AudioConfig;
        }

        public void PlayMusic()
        {
            _musicSource.clip = _audioConfig.MusicClip;
            _musicSource.Play();
        }

        public void PlaySoundByType(SoundType soundType)
        {
            var soundConfig = _audioConfig.SoundConfigs.Find(soundConfig => soundConfig.SoundType == soundType);
            if (soundConfig is null)
            {
                Debug.LogError($"No sound of type {soundType}");
                return;
            }
            _soundSource.PlayOneShot(soundConfig.Sound);
        }
    }
}