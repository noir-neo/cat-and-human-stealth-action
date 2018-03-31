using Characters;
using UniRx; 
using UnityEngine;
using Zenject;

namespace Enemies
{
    public class EnemyAi : MonoBehaviour
    {
        [SerializeField] private EnemyCore _enemyCore;
        [SerializeField] private float _nudgeThreshold;

        [Inject]
        void Initialize(ICharacterPosition playerPosition)
        {
            playerPosition.Position
                .Subscribe(x =>  _enemyCore.UpdateDirection((x - transform.position + Vector3.forward).normalized.XZ()))
                .AddTo(this);

            playerPosition.Position
                .Where(x => (transform.position - x).sqrMagnitude < _nudgeThreshold)
                .First()
                .Subscribe(_ => _enemyCore.OnNudge());
        }
    }
}
