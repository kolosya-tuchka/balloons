using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainGame.GameField
{
    public class SpawnRange : MonoBehaviour
    {
        [SerializeField] private Vector2 Size;

        public Vector2 GetSpawnPoint()
        {
            var x = Random.Range(-Size.x, Size.x);
            var y = Random.Range(-Size.y, Size.y);
            return (Vector2)transform.position + new Vector2(x, y) / 2;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, Size);
        }
    }
}