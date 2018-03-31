using UnityEngine;
using UnityEngine.SceneManagement;
using GameManagers;

namespace Result
{
    public class ResultLoader: MonoBehaviour, IMainGameEndObserver {
        public void MainGameEnd()
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
