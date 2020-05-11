using UnityEngine;

namespace OttomanDisc.Art
{
    public class AnimatorHandler : MonoBehaviour
    {
        protected Animator animator;

        protected virtual void Awake()
        {
            animator = this.GetComponent<Animator>();
        }
    }
}
