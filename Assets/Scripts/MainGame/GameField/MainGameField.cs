using UnityEngine;

namespace MainGame.GameField
{
    public class MainGameField : MonoBehaviour
    {
        [field: SerializeField] public BalloonDespawnTrigger BalloonDespawnTrigger { get; private set; }
        [field: SerializeField] public SpawnRange SpawnRange { get; private set; }
    }
}
