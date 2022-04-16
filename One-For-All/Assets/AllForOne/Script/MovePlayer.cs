using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;

	public bool isJumping = false;
	public bool isGrounded;

	public Rigidbody2D rb;
	public Animator anim;
	private Vector3 velocity = Vector3.zero;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask collisionLayers;
	public SpriteRenderer spriteRenderer;
	private float horizontalMovement;

	void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

		 horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			isJumping = true;

		}
			

		Flip(rb.velocity.x);

		float characterVelocity = Mathf.Abs(rb.velocity.x);
		anim.SetFloat("Speed", characterVelocity);

	}

	void FixedUpdate()
	{

		MoPlayer(horizontalMovement);

	}

	void MoPlayer(float _horizontalMovement)
	{
		Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

		if(isJumping == true)
		{
			rb.AddForce(new Vector2(0f, jumpForce));
			isJumping = false;

		}
	}

	void Flip(float _velocity)
	{
		if(_velocity > 0.1f)
		{
			spriteRenderer.flipX = false;
		}
		else if(_velocity < -0.1f)
		{
			spriteRenderer.flipX = true;
		}

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}

}
