using UnityEngine;


    public class Move : MonoBehaviour
    {
        public bool useCharacterForward = false;
        public bool lockToCameraForward = false;
        public float turnSpeed = 10f;
        public KeyCode sprintJoystick = KeyCode.JoystickButton2;
        public KeyCode sprintKeyboard = KeyCode.LeftShift;
        public KeyCode jumpkeyboard = KeyCode.Space;
        public float movespeed = 1f;
        public Camera mainCamera;
        public float jumpHeight = 1.0f;
        public float gravityValue = -9.81f;

        [HideInInspector]

        private GameObject Enemytarget;
        private float turnSpeedMultiplier;
        private float speed = 0f;
        private float direction = 0f;
        private bool isDown = false;
        private bool isSprinting = false;
        private Animator anim;
        private Vector3 targetDirection;
        private Vector2 input;
        private Quaternion freeRotation;
        
        private float velocity;


        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float attacktingnow=0;
        private CharacterStates States;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            controller = GetComponent<CharacterController>();
            States = GetComponent<CharacterStates>();
            States.currentHealth = States.maxHealth;
        }


        // Use this for initialization
        void Start()
        {
            if(mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }
        public void ActiveMouse(bool active)
        {
            Cursor.visible = active;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

            if (Input.GetKeyDown(KeyCode.H))
            {
                ActiveMouse(false);
            }
            // set speed to both vertical and horizontal inputs
            if (useCharacterForward)
                speed = Mathf.Abs(input.x) + input.y;
            else
                speed = Mathf.Abs(input.x) + Mathf.Abs(input.y);

            speed = Mathf.Clamp(speed, 0f, 1f);
            speed = Mathf.SmoothDamp(anim.GetFloat("Speed"), speed, ref velocity, 0.1f);
            anim.SetFloat("Speed", speed);

            if (input.y < 0f && useCharacterForward)
                direction = input.y;
            else
                direction = 0f;


            anim.SetFloat("Direction", direction);

            // set sprinting
            isSprinting = ((Input.GetKey(sprintJoystick) || Input.GetKey(sprintKeyboard)) && input != Vector2.zero && direction >= 0f);
            anim.SetBool("isSprinting", isSprinting);



            if (Input.GetMouseButtonDown(0))
            {
                attack();
                attacktingnow = anim.GetFloat("Attacking");
            }
            else if(attacktingnow<0)
            {
                positionmove();
                // Update target direction relative to the camera view (or not if the Keep Direction option is checked)
                UpdateTargetDirection();
                if (input != Vector2.zero && targetDirection.magnitude > 0.1f)
                {
                    Vector3 lookDirection = targetDirection.normalized;
                    freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
                    var diferenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
                    var eulerY = transform.eulerAngles.y;

                    if (diferenceRotation < 0 || diferenceRotation > 0) eulerY = freeRotation.eulerAngles.y;
                    var euler = new Vector3(0, eulerY, 0);

                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(euler), turnSpeed * turnSpeedMultiplier * Time.deltaTime);
                }
            }
            
            attacktingnow -= Time.deltaTime;
            //anim.SetFloat("Attacking",attacktingnow);

        }

        public void attack()
        {

            FoundEnemy();
            attackAnimationUpdate();
        }

        void FoundEnemy()
        {
            var colliders = Physics.OverlapSphere(transform.position, States.characterAttack.attackRange);
            foreach (var target in colliders)
            {
                if (target.CompareTag("Enemy"))
                {
                    Enemytarget = target.gameObject;
                    transform.LookAt(Enemytarget.transform.position);
                    return;
                }
            }
            Enemytarget = null;
            return ;
        }

        void attackAnimationUpdate()
        {
            anim.SetTrigger("Attack");
            float statetime = anim.GetFloat("Statetime");
            //Debug.Log(statetime);
            if (statetime > 0)
            {
                statetime -= Time.deltaTime;
                anim.SetFloat("Statetime", statetime);
            }
        }

        public void positionmove()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            //Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
            if (input != Vector2.zero && !isSprinting&&direction==0)
            {
                controller.Move(transform.forward * Time.deltaTime * movespeed);
            }
            else if(input != Vector2.zero && !isSprinting && direction != 0)
            {
                controller.Move(-transform.forward * Time.deltaTime * 2);
            }


            // Changes the height position of the player..
            if (Input.GetKeyDown(jumpkeyboard) && groundedPlayer)
            {
                if (input == Vector2.zero)
                {
                    anim.SetTrigger("Jump");
                }
                else
                {
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                }


                //Debug.Log(playerVelocity.y);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }


        public virtual void UpdateTargetDirection()
        {
            if (!useCharacterForward)
            {
                turnSpeedMultiplier = 1f;
                var forward = mainCamera.transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = mainCamera.transform.TransformDirection(Vector3.right);

                // determine the direction the player will face based on input and the referenceTransform's right and forward directions
                targetDirection = input.x * right + input.y * forward;
            }
            else
            {
                turnSpeedMultiplier = 0.2f;
                var forward = transform.TransformDirection(Vector3.forward);
                forward.y = 0;

                //get the right-facing direction of the referenceTransform
                var right = transform.TransformDirection(Vector3.right);
                targetDirection = input.x * right + Mathf.Abs(input.y) * forward;
            }
        }


        void Hit()
        {
            if (Enemytarget != null)
            {
                var targetStats = Enemytarget.GetComponent<CharacterStates>();
                targetStats.TakeDamage(States, targetStats);
                //Debug.Log("Hurt");
            }
        }





    }

