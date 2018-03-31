using UnityEngine;

namespace Players
{
    public interface IPlayerJumpAdjuster {
        void ConfigureAnimator(Rigidbody playerRigidBody, Vector3 targetPosition);
    }
}
