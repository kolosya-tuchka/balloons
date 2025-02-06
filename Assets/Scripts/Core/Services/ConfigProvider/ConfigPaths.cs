using Configs;

namespace Core.Services.ConfigProvider
{
    public static class ConfigPaths
    {
        public const string BalloonsConfigPath = "Configs/" + nameof(BalloonConfig);
        public const string RecordsConfigPath = "Configs/" + nameof(RecordsConfig);
    }
}