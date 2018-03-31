using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameManagers;
using UniRx;

namespace Result
{
    public class ResultLoader: MonoBehaviour, IMainGameEndObserver
    {
        [SerializeField] private ResultUi _resultUi;
        [SerializeField] private float waitSecondsSuccess;
        [SerializeField] private float waitSecondsFailed;

        public void MainGameEnd(bool isClear)
        {
            _resultUi.ShowResult(isClear);
            Observable.Timer(TimeSpan.FromSeconds(isClear ? waitSecondsSuccess : waitSecondsFailed))
                .Subscribe(_ => SceneManager.LoadScene("MainScene"))
                .AddTo(this);
        }
    }
}
