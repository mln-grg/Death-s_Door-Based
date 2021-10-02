using UnityEngine;

namespace MilanGeorge
{
    public class InputManager : MonoBehaviour
    {
        PlayerControls playerControls;
        AnimatorManager animatorManager;

        Vector2 movementInput;
        private bool isDodging;

        float horizontalInput;
        float verticalInput;
        float moveAmount;
        private void Awake()
        {
            animatorManager = GetComponent<AnimatorManager>();
        }
        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();
                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            }
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }
        
        private void HandleMovementInput()
        {
            horizontalInput = movementInput.x;
            verticalInput = movementInput.y;

            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
            animatorManager.UpdateAnimatorValues(0, moveAmount);
        }
        private void HandleRollInput()
        {
            isDodging = playerControls.PlayerActions.Dodge.phase == UnityEngine.InputSystem.InputActionPhase.Started;

        }
        public void HandleAllMovementInput()
        {
            HandleRollInput();
            HandleMovementInput();
        }

        public float GetHorizontalInput()
        {
            return horizontalInput;
        }
        public float GetVerticalInput()
        {
            return verticalInput;
        }
        public float GetMoveAmount()
        {
            return moveAmount;
        }
        public bool GetDodging()
        {
            return isDodging;
        }
    }
}
