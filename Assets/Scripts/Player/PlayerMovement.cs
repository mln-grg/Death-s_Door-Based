using UnityEngine;
namespace MilanGeorge
{
    public class PlayerMovement : MonoBehaviour
    {
        PlayerManager playerManager;

        Vector3 moveDirection;
        Rigidbody playerRb;
        //TargetAnimation Names
        const string DodgeBack = "DodgeBack";
        const string DodgeRoll = "DodgeRoll";
        const string Landing = "Landing";
        const string Falling = "Falling";

        [Header("GroundCheck & Landing")]
        [SerializeField] float rayOffset = 0.5f;
        [SerializeField] float minTimeNeededToLand = 1;
        [SerializeField] float minTimeNeededToFall = 1;
        float inAirTimer = 0f;

        [Header("Dodge")]
        [SerializeField] float dodgeInterval = 0f;
        float nextDodge =0f;
        private void Awake()
        {
            playerRb = GetComponent<Rigidbody>();
            playerManager = GetComponent<PlayerManager>();
        }
        
        void HandleMovement()
        {
            if (playerManager.GetMoveAmount() <= 0.5)
            {
                playerManager.SetPlayerSpeed(playerManager.GetWalkingSpeed());
            }
            else
            {
                playerManager.SetPlayerSpeed(playerManager.GetDefaultSpeed());
            }

            moveDirection = GetDirection();
            
            Vector3 moveVelocity = moveDirection * playerManager.GetPlayerSpeed();
            playerRb.velocity = moveVelocity;
        }

        void HandleRotation()
        {
            Vector3 targetDirection = GetDirection();

            if (targetDirection == Vector3.zero)
            {
                targetDirection = transform.forward;
            }
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, playerManager.GetRotationSpeed() * Time.deltaTime);

            transform.rotation = playerRotation;

        }

        void HandleDodging()
        {
            if (playerManager.GetIsInteracting())
                return;


            if (Time.time >= nextDodge)
            {
                nextDodge = Time.time + dodgeInterval;

                moveDirection = GetDirection();

                if (playerManager.GetMoveAmount() > 0)
                {
                    playerManager.PlayTargetAnimation(DodgeRoll, true);
                    Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = targetRotation;
                }
                else
                    playerManager.PlayTargetAnimation(DodgeBack, true);
            }

        }

        Vector3 GetDirection()
        {
            moveDirection = playerManager.GetCameraForward() * playerManager.GetVerticalInput();
            moveDirection += playerManager.GetCameraRight()* playerManager.GetHorizontalInput();
            moveDirection.Normalize();
            moveDirection.y = 0;

            return moveDirection;
        }

        void HandleFallingAndLanding()
        {

            //Animations Disabled[Buggy Behaviour fix later!]

            RaycastHit hit;
            Vector3 rayOrigin;
            Vector3 targetPosition;
            targetPosition = transform.position;
            rayOrigin = transform.position;
            rayOrigin.y += rayOffset;
            if (!playerManager.GetIsGrounded())
            {
                if (!playerManager.GetIsInteracting())
                {
                    /*if (inAirTimer > minTimeNeededToFall)
                        playerManager.PlayTargetAnimation(Falling, true);*/
                }

                inAirTimer += Time.deltaTime;
                playerRb.AddForce(transform.forward * playerManager.GetLeapingSpeed());
                playerRb.AddForce(-Vector3.up * inAirTimer * playerManager.GetFallingSpeed());
            }

            if(Physics.SphereCast(rayOrigin,0.2f,-Vector3.up,out hit,0.2f, playerManager.GetGroundLayerMask()))
            {
                
                if(!playerManager.GetIsGrounded() /*&& playerManager.GetIsInteracting()*/)
                {
                    /*if (inAirTimer >= minTimeNeededToLand)
                        playerManager.PlayTargetAnimation(Landing, true);
                    else
                        playerManager.PlayTargetAnimation("Empty", false);*/

                }
                Vector3 RaycastHitPoint = hit.point;
                targetPosition.y = RaycastHitPoint.y;

                inAirTimer = 0;
                playerManager.SetIsGrounded(true);
            }
            else
            {
                playerManager.SetIsGrounded(false);
            }

            if (playerManager.GetIsGrounded())
            {
                if (playerManager.GetIsInteracting() || playerManager.GetMoveAmount() > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
                }
                else
                    transform.position = targetPosition;
            }

        }
        public void HandleAllMovement()
        {
            HandleFallingAndLanding();

            if (playerManager.GetIsInteracting())
                return;

            if (!playerManager.GetIsDodging())
            {
                HandleMovement();
                HandleRotation();
                
            }
            else
            {
                HandleDodging();
            }

        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Vector3 origin = transform.position;
            origin.y += rayOffset;
            Gizmos.DrawSphere(origin, 0.2f);
        }
    }
}
