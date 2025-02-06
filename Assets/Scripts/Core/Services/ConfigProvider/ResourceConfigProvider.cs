using Configs;
using UnityEngine;
using Zenject;

namespace Core.Services.ConfigProvider
{
    public class ResourceConfigProvider : IConfigProvider
    {
        public BalloonConfig BalloonConfig { get; private set; }
        public RecordsConfig RecordsConfig { get; private set; }
        public AudioConfig AudioConfig { get; private set; }

        [Inject]
        public ResourceConfigProvider()
        {
            LoadConfigs();
        }
        
        public void LoadConfigs()
        {
            BalloonConfig = Resources.Load<BalloonConfig>(ConfigPaths.BalloonsConfigPath);
            RecordsConfig = Resources.Load<RecordsConfig>(ConfigPaths.RecordsConfigPath);
            AudioConfig = Resources.Load<AudioConfig>(ConfigPaths.AudioConfigPath);
        }
    }
}