using Configs;
using UnityEngine;

namespace Core.Services.ConfigProvider
{
    public class ResourceConfigProvider : IConfigProvider
    {
        public BalloonConfig BalloonConfig { get; private set; }
        public RecordsConfig RecordsConfig { get; private set; }
        
        public void LoadConfigs()
        {
            BalloonConfig = Resources.Load<BalloonConfig>(ConfigPaths.BalloonsConfig);
            RecordsConfig = Resources.Load<RecordsConfig>(ConfigPaths.RecordsConfig);
        }
    }
}