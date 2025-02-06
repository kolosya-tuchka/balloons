using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(RecordsConfig), fileName = nameof(RecordsConfig))]
    public class RecordsConfig : ScriptableObject
    {
        public int MinNameLength = 4;
        public int MaxNameLength = 10;
        public int MaxRecordsCount = 10;
    }
}