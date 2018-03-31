using Characters;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(CharacterCore))]
    public class EnemyCore : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;

        void Start()
        {
            _characterCore.Direction = Vector2.up;
        }

        public void UpdateDirection(Vector2 direction)
        {
            _characterCore.Direction = direction;
        }
    }
}
