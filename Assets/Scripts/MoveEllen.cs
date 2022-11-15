using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEllen : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float sprintSpeed = 5f;
    public float rotationSpeed = 0.2f;
    public float AnimationBlendSpeed = 0.2f;
    public float jumpSpeed = 5f;
    public string RandomAttacks;


    CharacterController controller;
    Animator animator;
    Camera characterCamera;
    float rotationAngle = 0.0f;
    float targetAnimationSpeed = 0f;
    bool isSprint = false;
    bool isJumping = false;
    bool isDead = false;
    bool isScript = false;
    float gravity = -9.81f;
    float speedY = 0f;
    


    public CharacterController Controller { get { return controller = controller ?? GetComponent<CharacterController>(); } }
    public Camera CharacterCamera;
    public Camera Camera { get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); } }
    public Animator CharacterAnimator { get { return animator = animator ?? GetComponent<Animator>(); } }

    void Start()
    {
       
        spawn();
        
    }

    void Update()
    {   
        if (isScript && !isDead)
        {
            jump();
            move();
            Death();
            Attack();    
        }     
    }

    private void spawn()
    {
        CharacterAnimator.SetTrigger("Spawn");
    }

    public void spawnfinish()
    {
      
        isScript = true;
    }

    private void move()
    {
            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            Vector3 rotatedMovement = Quaternion.Euler(0.0f, CharacterCamera.transform.rotation.eulerAngles.y, 0.0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;
            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
            Controller.Move((verticalMovement + rotatedMovement * currentSpeed) * Time.deltaTime);

            if (rotatedMovement.sqrMagnitude > 0.0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0f;
            }

            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, AnimationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0.0f, rotationAngle, 0.0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);       
    }

    private void jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            CharacterAnimator.SetTrigger("Jump");
            speedY += jumpSpeed;
        }
        if (!Controller.isGrounded)
        {
            speedY += gravity * Time.deltaTime;
        }
        else if (speedY < 0f)
        {
            speedY = 0f;
        }

        CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);

        if (isJumping && speedY < 0.0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, LayerMask.GetMask("Default")))
            {
                Debug.Log(Controller.isGrounded);
                isJumping = false;
                CharacterAnimator.SetTrigger("Land");
            }
        }
 
    }

    private void Death()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDead)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            animator.SetInteger(RandomAttacks, Random.Range(1, 5)); 
        }
        
    }
}
