using UnityEngine;
using UnityEngine.InputSystem;

namespace OttomanDisc.Art
{
    public class PlayerAnimatorHandler : AnimatorHandler
    {
        private PlayerInputActions inputActions;

        protected override void Awake()
        {
            base.Awake();
            inputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            inputActions.Game.Enable();
            inputActions.Game.Move.performed += OnMove;
            inputActions.Game.Move.canceled += OnMoveStop;
            inputActions.Game.Attack.performed += OnAttack;
        }

        private void OnDisable()
        {
            inputActions.Game.Enable();
            inputActions.Game.Move.performed -= OnMove;
            inputActions.Game.Move.canceled -= OnMoveStop;
            inputActions.Game.Attack.performed -= OnAttack;
        }

        private void Update()
        {

        }

        private void OnMove(InputAction.CallbackContext context)
        {
            var direction2D = context.ReadValue<Vector2>();
            animator.SetFloat("Horizontal", direction2D.x);
            animator.SetFloat("Vertical", direction2D.y);
            this.FlipHorizontal(direction2D.x);
        }

        private void OnMoveStop(InputAction.CallbackContext context)
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
        }

        private void OnAttack(InputAction.CallbackContext context)
        {
            animator.SetTrigger("AttackTrigger");
        }
    }
}
