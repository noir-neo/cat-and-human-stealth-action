using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Players.InputImpls
{
    public class KeyboardInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IObservable<float> MoveDirection =>
            this.UpdateAsObservable()
                .Select(_ =>
                {
                    var left = Input.GetKey(KeyCode.W) ? -1f : 0f;
                    var right = Input.GetKey(KeyCode.S) ? 1f : 0f;
                    return left + right;
                });
    }
}
