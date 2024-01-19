using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public PlayerInputActions PlayerControls;
    public SpriteRenderer spriteRenderer;

    private InputAction Move;
    public InputAction Interact;
    private static PlayerControl instance;
    private bool interactPressed = false;
    private Animator animator= null;
    

    Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        PlayerControls = new PlayerInputActions();
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
        animator = GetComponent<Animator>();
    }

    public static PlayerControl GetInstance()
    {
        return instance;
    }

    public void OnEnable()
    {
        Move = PlayerControls.Player.Move;
        Move.Enable();
        Interact = PlayerControls.Player.Interact;
        Interact.Enable();
        Interact.performed += interact;
    }

    public void OnDisable()
    {
        Move.Disable();
        Interact.Disable();
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }

    void Update()
    {
        moveDirection = Move.ReadValue<Vector2>();
        
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        
    }

    /*private void flipSprite(float Move)
    {
        if(moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.flipX=false;
        }
    }*/

    public void interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}
