using System;
using System.Collections.Generic;
using Core.Services.AudioService;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(AudioConfig), fileName = nameof(AudioConfig))]
    public class AudioConfig : ScriptableObject
    {
        public AudioClip MusicClip;
        public List<SoundConfig> SoundConfigs;
    }

    [Serializable]
    public class SoundConfig
    {
        public SoundType SoundType;
        public AudioClip Sound;
    }
}