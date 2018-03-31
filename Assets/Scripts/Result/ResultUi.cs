using Characters;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Result
{
    public class ResultUi : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Image _bg;
        [SerializeField] private Transform _goal; // FIXME

        public void ShowResult(bool isClear)
        {
            var color = _bg.color;
            color.a = 1f;
            _bg.color = color;
            _animator.SetTrigger(isClear ? "Success" : "Failed");
        }

        [Inject]
        void Initialize(ICharacterPosition playerPosition)
        {
            var goalPosition = _goal.position;
            playerPosition.Position.First()
                .Select(x => (goalPosition - x).sqrMagnitude)
                .CombineLatest(playerPosition.Position.Select(x => (goalPosition - x).sqrMagnitude),
                    (max, current) => Mathf.Pow(1 - current / max, 3))
                .Subscribe(x =>
                {
                    var color = _bg.color;
                    color.a = x;
                    _bg.color = color;
                })
                .AddTo(this);
        }
    }
}
