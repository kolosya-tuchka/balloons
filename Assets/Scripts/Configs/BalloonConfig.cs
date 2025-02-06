using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(BalloonConfig), fileName = nameof(BalloonConfig))]
    public class BalloonConfig : ScriptableObject
    {
        public float BalloonSpeed = 5f;
        public float ShakeStrength = 0.2f;
        public float ShakeDuration = 0.5f;

        public float BalloonSpawnTime = 1f;
    }
}