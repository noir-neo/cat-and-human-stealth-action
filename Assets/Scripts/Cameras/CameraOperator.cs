﻿using Characters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CameraOperator : MonoBehaviour
    {

        [Inject]
        private void Initialize(ICharacterPosition characterPosition)
        {
            var y = transform.position.y;
            characterPosition.Position.First()
                .Select(x => transform.position - x)
                .CombineLatest(characterPosition.Position, (offset, target) => target + offset)
                .Select(x =>
                {
                    x.y = y;
                    return x;
                })
                .Subscribe(x => transform.position = x)
                .AddTo(this);
        }
    }
}
