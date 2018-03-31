using System;
using System.Collections;
using System.Collections.Generic;
using Players;
using Sounds;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(PlayerCore))]
public class PlayerSeEmitter : MonoBehaviour, ISeEventProvider
{
    [SerializeField] private PlayerCore _playerCore;
    [SerializeField] private string _jumpSeName;

    public IObservable<string> PlaySeTriggerAsObservable()
    {
        return Jump();
    }

    private IObservable<string> Jump()
    {
        return _playerCore.Jump.Select(_ => _jumpSeName);
    }
}
