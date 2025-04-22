using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask ground;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("TryJump", 0f, 1f); 
    }

    void Update()
    {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        TryJump();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { isGrounded = true; }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { isGrounded = true; }
    }
    void TryJump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

}
