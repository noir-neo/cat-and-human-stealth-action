using Characters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyAi : MonoBehaviour
    {
        [SerializeField] private EnemyCore _enemyCore;

        [Inject]
        void Initialize(ICharacterPosition playerPosition)
        {
            playerPosition.Position
                .Subscribe(x =>  _enemyCore.UpdateDirection((x - transform.position + Vector3.forward).normalized.XZ()))
                .AddTo(this);
        }
    }
}
