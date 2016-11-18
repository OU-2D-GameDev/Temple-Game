using UnityEngine;
using Fungus;
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

	public bool tutorialMode;
	public Flowchart flowchart;
	public float distanceMoved = 0f;

	private bool controlEnabled = false;

	private Animator animator;
	private BoxCollider2D boxCollider;
	private SpriteRenderer playerSprite;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
		playerSprite = GetComponent<SpriteRenderer> ();
    }

    void FixedUpdate()
    {
		if (controlEnabled) {
			grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

			float move = Input.GetAxis("Horizontal");

			rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
			flowchart.SetFloatVariable ("distanceMoved", flowchart.GetFloatVariable ("distanceMoved")
			+ Mathf.Abs (rb.velocity.x * Time.fixedDeltaTime));
			
			if (move > 0 && !facingRight)
				flip();
			else if (move < 0 && facingRight)
				flip();
		}
    }

    void Update()
    {
		if (grounded && Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (new Vector2 (0, jumpForce));
			if (tutorialMode)
				flowchart.SetBooleanVariable ("jumped", true);
		}

		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			animator.SetBool ("playerIsCrouching", true);
			if (tutorialMode)
				flowchart.SetBooleanVariable ("crouched", true);
		}
		
		OnCrouching ();

		if (flowchart.GetBooleanVariable ("jumped") && flowchart.GetBooleanVariable ("crouched"))
			flowchart.SetBooleanVariable ("jumpedAndCrouched", true);
			
    }

	public void EnableControl() {
		controlEnabled = true;
	}

	public void DisableControl() {
		controlEnabled = false;
	}

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
	}
	
	void OnCrouching() 
	{
		if (animator.GetBool("playerIsCrouching")) 
		{
			// Adjust the BoxCollider2D dimensions for crouching
			Vector3 newColliderSize = playerSprite.bounds.size;
			boxCollider.size = new Vector2(newColliderSize.x, newColliderSize.y);
			
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
				bool pc1 = animator.GetBool ("playerCrouch1");
				animator.SetBool ("playerCrouch1", !pc1);
			}
		}
		
		if (!Input.GetKey(KeyCode.LeftShift)) 
		{
			// Adjust the BoxCollider2D dimensions for standing up
			Vector3 newColliderSize = playerSprite.bounds.size;
			boxCollider.size = new Vector2(newColliderSize.x, newColliderSize.y);
			
			animator.SetBool ("playerIsCrouching", false);
		}
	}
}
