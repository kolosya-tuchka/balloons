using Configs;

namespace Core.Services.ConfigProvider
{
    public interface IConfigProvider
    {
        BalloonConfig BalloonConfig { get; }
        RecordsConfig RecordsConfig { get; }

        void LoadConfigs();
    }
}