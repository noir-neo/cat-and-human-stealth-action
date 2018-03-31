using UnityEngine;

namespace Result
{
    public class ResultUi : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void ShowResult(bool isClear)
        {
            _animator.SetTrigger(isClear ? "Success" : "Failed");
        }
    }
}
