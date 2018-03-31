using System;
using Sounds;
using UniRx;
using UnityEngine;

public class BgmEmitter : MonoBehaviour, IBgmEventProvider
{
    [SerializeField] private StringReactiveProperty _bgmName = new StringReactiveProperty();

    public IObservable<string> PlayBgmTriggerAsObservable()
    {
        return _bgmName;
    }
}
