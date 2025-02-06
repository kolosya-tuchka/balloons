using UnityEngine;

namespace MainGame.GameField
{
    public class MainGameField : MonoBehaviour
    {
        [field: SerializeField] public BalloonDespawnTrigger BalloonDespawnTrigger { get; private set; }
        [field: SerializeField] public SpawnRange SpawnRange { get; private set; }
        [field: SerializeField] public Transform BalloonsParent { get; private set; }
        [field: SerializeField] public int FieldHeight { get; private set; }
    }
}
