using UnityEngine;

namespace OttomanDisc.Art
{
    public class PlayerAnimatorHandler : AnimatorHandler
    {
        public void Move(Vector3 direction)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.z);
        }

        public void Attack()
        {
            animator.SetTrigger("AttackTrigger");
        }
    }
}
