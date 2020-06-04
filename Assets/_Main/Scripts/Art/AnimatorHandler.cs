using UnityEngine;

namespace OttomanDisc.Art
{
    public class AnimatorHandler : MonoBehaviour
    {
        protected Animator animator;
        protected SpriteRenderer spriteRenderer;

        protected virtual void Awake()
        {
            animator = this.GetComponent<Animator>();
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        protected virtual void FlipHorizontal(float x)
        {
            var flip = x < 0 ? true : false;
            spriteRenderer.flipX = flip;
        }
    }
}
