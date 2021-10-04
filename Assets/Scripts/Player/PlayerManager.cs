using UnityEngine;
namespace MilanGeorge
{
    public class PlayerManager : MonoBehaviour
    {
        PlayerMovement playerMovement;
        InputManager inputManager;
        AnimatorManager animatorManager;
        PlayerCombatManager playerCombatManager;
        WeaponSlotManager weaponSlotManager;
        PlayerInventory playerInventory;

        Rigidbody playerRb;
        [SerializeField] Transform cameraObject;

        [Header("LayerMasks")]
        [SerializeField] private LayerMask GroundLayerMask;

        [Header("Movement Stats")]
        [SerializeField] private float speed;
        [SerializeField] private float walkingSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float fallingSpeed;
        [SerializeField] private float leapingSpeed;
        float playerSpeed;

        //Flags
        bool isGrounded;
        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            inputManager = GetComponent<InputManager>();
            animatorManager = GetComponent<AnimatorManager>();
            playerRb = GetComponent<Rigidbody>();
            playerCombatManager = GetComponent<PlayerCombatManager>();
            playerInventory = GetComponent<PlayerInventory>();
            weaponSlotManager = GetComponent<WeaponSlotManager>();
        }

        private void Start()
        {
            playerSpeed = speed;
            isGrounded = true;
        }
        private void FixedUpdate()
        {
            inputManager.HandleAllInput();
            playerMovement.HandleAllMovement();
            playerCombatManager.HandleLightAttack();

        }
        private void LateUpdate()
        {
            CameraManager.instance.FollowTarget(transform.position);
            //inputManager.resetBool();
        }

        #region Getters
        public bool GetIsInteracting()
        {
           return animatorManager.animator.GetBool("isInteracting");
        }

        public bool GetIsDodging()
        {
            return inputManager.GetDodging();
        }

        public float GetMoveAmount()
        {
            return inputManager.GetMoveAmount();
        }
        public float GetVerticalInput()
        {
            return inputManager.GetVerticalInput();
        }

        public float GetHorizontalInput()
        {
            return inputManager.GetHorizontalInput();
        }

        public Vector3 GetCameraForward()
        {
            return cameraObject.forward;
        }
        public Vector3 GetCameraRight()
        {
            return cameraObject.right;
        }
        
        public float GetPlayerSpeed()
        {
            return playerSpeed;
        }

        public float GetDefaultSpeed()
        {
            return speed;
        }

        public float GetRotationSpeed()
        {
            return rotationSpeed;
        }

        public float GetWalkingSpeed()
        {
            return walkingSpeed;
        }

        public bool GetIsGrounded()
        {
            return isGrounded;
        }     
        public LayerMask GetGroundLayerMask()
        {
            return GroundLayerMask;
        }

        public float GetLeapingSpeed()
        {
            return leapingSpeed;
        }

        public float GetFallingSpeed()
        {
            return fallingSpeed;
        }

        public bool GetLightAttack()
        {
           return inputManager.GetLightAttack();
        }

        public WeaponItem GetRightHandWeapon()
        {
            return playerInventory.GetRightHandWeapon();
        }
        #endregion

        #region Setters
        public void SetPlayerSpeed(float newSpeed)
        {
            playerSpeed = newSpeed;
        }
        public void SetIsGrounded(bool value)
        {
            isGrounded = value;
        }
        #endregion

        #region Actions
        public void PlayTargetAnimation(string animation,bool isInteracting)
        {
            animatorManager.PlayTargetAnimation(animation, isInteracting);
        }
        #endregion
    }
}
