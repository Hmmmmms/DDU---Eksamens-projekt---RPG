using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource AttackSound;
    float cooldown = 0.3f; //seconds
    private float lastAttackedAt = -9999f;

    [SerializeField] private AudioSource RunningSound;
    //Sounds

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }
    public bool IsBlocking
    {
        set
        {
            isBlocking = value;
            animator.SetBool("isBlocking", isBlocking);
        }
    }

    private Vector2 moveInput = Vector2.zero;

    Rigidbody2D rb;

    Animator animator;

    SpriteRenderer spriteRenderer;

    DamagableCharacter _damageableCharacter;

    public SpriteRenderer InteractNotify;

    public StaminaBar staminaBar;

    public float idleFriction = 0.9f;

    public float moveSpeed = 500f;

    public float maxSpeed = 5f;

    private bool isMoving = false;

    private bool isBlocking = false;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    bool canMove = true;

    bool _swordEquipped = false;
    bool _shieldEquipped = false;

    bool _dialogueActive = false;


    private void OnEnable()
    {
        Sword.SwordEquipped += swordEquipped;
        Shield.ShieldEquipped += shieldEquipped;
    }
    private void OnDisable()
    {
        Sword.SwordEquipped -= swordEquipped;
        Shield.ShieldEquipped -= shieldEquipped;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _damageableCharacter = GetComponent<DamagableCharacter>();
        staminaBar = GetComponent<StaminaBar>();
        animator.SetFloat("Last_Horizontal", 1);
        animator.SetFloat("Last_Vertical", 0);
        _swordEquipped = false;
        _shieldEquipped = false;

    }
    private void FixedUpdate()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        //Set which way player is facing
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);

        //Set last direction the player is facing, so that attack anim, doesn't bug.
        if (moveInput.x == 1 ||
       moveInput.x == -1 ||
       moveInput.y == 1 ||
       moveInput.y == -1)
        {
            animator.SetFloat("Last_Horizontal", moveInput.x);
            animator.SetFloat("Last_Vertical", moveInput.y);
        }

        if (canMove == true && moveInput != Vector2.zero && !_dialogueActive)
        {
            //If movement input is not 0, try to move
            rb.AddForce(moveInput * moveSpeed * Time.fixedDeltaTime);

            
            if (rb.velocity.magnitude > maxSpeed)
            {
                float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                rb.velocity = rb.velocity.normalized * limitedSpeed;
            }


            IsMoving = true;
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            IsMoving = false;
        }

        if(!isMoving) RunningSound.Play();

    }
    private void Update()
    {
        if (_damageableCharacter.isAlive == true)
        {
            if (_swordEquipped == true && !_dialogueActive)
            {
                //Sword Attack
                if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown("space")))
                {
                    while (Time.time > lastAttackedAt + cooldown)
                    {
                        AttackSound.Play();
                        lastAttackedAt += cooldown;
                    }
                    animator.SetTrigger("swordAttack");
                }
            }

            if (_shieldEquipped == true && !_dialogueActive)
            {
                //Block With Shield
                if ((Input.GetMouseButton(1)) || Input.GetKey(KeyCode.LeftControl))
                {
                    if (staminaBar.CanUseStamina == true)
                    {
                        Blocking();
                        staminaBar.DecreaseEnergy();
                    }
                    else
                    {
                        StoppedBlocking();
                    }

                }
                if ((Input.GetMouseButtonUp(1)) || Input.GetKeyUp(KeyCode.LeftControl))
                {
                    StoppedBlocking();
                }
            }

            if (Input.GetKey(KeyCode.LeftShift) && !_dialogueActive)
            {
                if (staminaBar.CanUseStamina == true)
                {
                    moveSpeed = 1000f;
                    staminaBar.DecreaseEnergy();
                }
                else
                {
                    moveSpeed = 500f;
                }

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                moveSpeed = 500f;
            }
        }
    }


    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            //Check for potential collision
            int count = rb.Cast(
                   direction, //X and Y values between -1 and 1 that responds the direction from the body to look for collisions
                   movementFilter, //The settings that determine where a collision can occur on such as layers to collide with
                   castCollisions, //List of collisions to store the found collisions into after the Cast is finished
                   moveSpeed * Time.fixedDeltaTime + collisionOffset); //The amount to cast equal to the movement plus an offset

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);


                return true;

            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void swordEquipped()
    {
        _swordEquipped = true;
    }

    public void shieldEquipped()
    {
        _shieldEquipped = true;
    }


    public void Blocking()
    {
        LockMovement();
        IsBlocking = true;
        _damageableCharacter.ToggleInvincibleEnabled();
    }
    public void StoppedBlocking()
    {
        UnlockLockMovement();
        IsBlocking = false;
        _damageableCharacter.ToggleInvincibleDisabled();
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockLockMovement()
    {
        canMove = true;
    }

    public void DialogueOn()
    {
        _dialogueActive = true;
        IsBlocking = false;
        _damageableCharacter.ToggleInvincibleEnabled();
    }

    public void DialogueOff()
    {
        _dialogueActive = false;
        _damageableCharacter.ToggleInvincibleDisabled();
    }

    public void NotifyPlayer()
    {
        InteractNotify.enabled = true;
    }
    public void DeNotifyPlayer()
    {
        InteractNotify.enabled = false;
    }

}
