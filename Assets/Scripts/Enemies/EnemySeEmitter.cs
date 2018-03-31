using System;
using Sounds;
using UniRx;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(EnemyCore))]
    public class EnemySeEmitter : MonoBehaviour, ISeEventProvider
    {
        [SerializeField] private EnemyCore _enemyCore;
        [SerializeField] private string _zawaSeName;

        public IObservable<string> PlaySeTriggerAsObservable()
        {
            return Zawa();
        }

        private IObservable<string> Zawa()
        {
            return _enemyCore.NudgeAsObservable().Select(_ => _zawaSeName);
        }
    }
}
