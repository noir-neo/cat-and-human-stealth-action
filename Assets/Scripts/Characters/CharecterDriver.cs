using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using GameManagers;

namespace Characters
{
    [RequireComponent(typeof(CharacterCore))]
    public class CharecterDriver : MonoBehaviour, IMainGameStartObserver, IMainGameEndObserver
    {
        [SerializeField] private CharacterCore _characterCore;

        public void MainGameStart()
        {
            _characterCore.IsMovable = true;
        }

        public void MainGameEnd()
        {
            _characterCore.IsMovable = false;
        }
    }
}
