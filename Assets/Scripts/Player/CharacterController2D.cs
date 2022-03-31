using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] public float moveSpeed;
    [SerializeField] private float groundRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private GameObject swordCollider;
    [SerializeField] private GameManager gameManager;

    private float moveInput;
    [SerializeField] private bool isGrounded;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerMove();
        playerJump();
        playerFlip();
        playerAttack();
    }

    private void playerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isGrounded)
            {
                anim.SetTrigger("attack");
                moveSpeed = 0f;
                SpeedChange();
            }
        }
    }

    private void playerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (isGrounded)
        {
            anim.SetBool("fall", false);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("jump");
        }
    }

    private void playerMove()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(moveInput));
    }

    private void playerFlip()
    {
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    private async void SpeedChange()
    {
        await new WaitForSeconds(0.7f);
        moveSpeed = 5f;
    }

    private void Fall()
    {
        anim.SetBool("fall", true);
    }

    private void EnableSword()
    {
        swordCollider.SetActive(true);
    }

    private void DisableSword()
    {
        swordCollider.SetActive(false);
    }

    public void Death()
    {
        anim.SetTrigger("death");
        StopMovement();
        gameManager.onPlayerDeath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("teleporter"))
        {
            gameManager.onPlayerWin();
            StopMovement();
        }
        if (other.CompareTag("axe") || other.CompareTag("blade"))
        {
            Death();
        }
    }

    private void StopMovement()
    {
        moveSpeed = 0;
    }
}