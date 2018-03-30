using Players;
using UniRx;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CameraOperator : MonoBehaviour
    {

        [Inject]
        private void Initialize(IPlayerPosition playerPosition)
        {
            playerPosition.Position.First()
                .Select(x => transform.position - x)
                .CombineLatest(playerPosition.Position, (offset, target) => target + offset)
                .Subscribe(x => transform.position = x)
                .AddTo(this);
        }
    }
}
