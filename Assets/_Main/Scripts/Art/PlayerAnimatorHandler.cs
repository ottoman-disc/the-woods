using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OttomanDisc.Art
{
    public class PlayerAnimatorHandler : AnimatorHandler
    {
        [SerializeField]
        private GameObject arms;

        [SerializeField]
        private float bowAimRange = 30f; // the range of motion the bow may make whilst aiming

        [SerializeField]
        private float bowIdleAfterSeconds = 3f; // how long after shooting idle animation should be triggered

        [SerializeField]
        private GameObject arrowPrefab;

        private Animator armsAnimator;
        private SpriteRenderer armsSpriteRenderer;
        private PlayerInputActions inputActions;
        private bool aiming = false; // flags that arms should be rotated to aim
        private bool nocked = false; // flags that player intends to release an arrow
        private GameObject nockedArrow;
        private SpriteRenderer nockedArrowSpriteRenderer;
        private Arrow nockedArrowScript;

        protected override void Awake()
        {
            base.Awake();
            armsAnimator = arms.GetComponent<Animator>();
            armsSpriteRenderer = arms.GetComponent<SpriteRenderer>();
            inputActions = new PlayerInputActions();
        }

        protected override void FlipHorizontal(float x)
        {
            var flip = x < 0 ? true : false;
            spriteRenderer.flipX = flip;
            armsSpriteRenderer.flipX = flip;
            nockedArrowSpriteRenderer.flipX = flip;
        }

        private void OnEnable()
        {
            inputActions.Game.Enable();
            inputActions.Game.Move.performed += OnMove;
            inputActions.Game.Move.canceled += OnMoveStop;
            inputActions.Game.Attack.performed += Nock;
            inputActions.Game.Attack.canceled += Release;
        }

        private void OnDisable()
        {
            inputActions.Game.Enable();
            inputActions.Game.Move.performed -= OnMove;
            inputActions.Game.Move.canceled -= OnMoveStop;
            inputActions.Game.Attack.performed -= Nock;
            inputActions.Game.Attack.canceled -= Release;
        }

        private void Update()
        {
            if (aiming)
            {
                MouseAim();
            }
        }

        private void MouseAim()
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float angleClamped = Mathf.Clamp(angle, -bowAimRange, bowAimRange);
            RotateArms(angleClamped);
        }

        private void RotateArms(float angle)
        {
            armsSpriteRenderer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var direction2D = context.ReadValue<Vector2>();
            animator.SetBool("Walking", true);
            armsAnimator.SetBool("Walking", true);
            this.FlipHorizontal(direction2D.x);
        }

        private void OnMoveStop(InputAction.CallbackContext context)
        {
            animator.SetBool("Walking", false);
            armsAnimator.SetBool("Walking", false);
        }

        private void Nock(InputAction.CallbackContext context)
        {
            armsAnimator.SetTrigger("Nock");
            nockedArrow = Instantiate(arrowPrefab, this.transform.position, this.transform.rotation, this.transform);
            nockedArrowScript = nockedArrow.GetComponent<Arrow>();
            nockedArrowSpriteRenderer = nockedArrow.GetComponent<SpriteRenderer>();
            aiming = nocked = true;
            StopAllCoroutines(); // prevents overlapped coroutines interupting animation
        }

        private void Release(InputAction.CallbackContext context)
        {
            armsAnimator.SetTrigger("Release");
            nockedArrowScript.Loose();
            nocked = false;
            StartCoroutine("BowIdle");
        }

        // resets player to idle after three seconds if not nocked
        IEnumerator BowIdle()
        {
            yield return new WaitForSeconds(bowIdleAfterSeconds);
            if (!nocked)
            {
                aiming = false;
                RotateArms(0f);
                armsAnimator.Play("player-arms-idle", -1);
            }
        }

    }
}
