using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Players.InputImpls
{
    public class KeyboardInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        public IObservable<Vector2> MoveDirection =>
            this.FixedUpdateAsObservable()
                .Select(_ =>
                {
                    var left = Input.GetKey(KeyCode.W) ? Vector2.left : Vector2.zero;
                    var right = Input.GetKey(KeyCode.S) ? Vector2.right : Vector2.zero;
                    return left + right;
                });
    }
}
