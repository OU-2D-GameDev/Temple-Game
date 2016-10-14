using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    bool facingRight = true;
    private Rigidbody2D rb;
    bool grounded = false;
    float groundRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float jumpForce = 700f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            flip();
        else if (move < 0 && facingRight)
            flip();
    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(new Vector2(0, jumpForce));
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
