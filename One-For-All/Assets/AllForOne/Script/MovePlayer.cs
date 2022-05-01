using UnityEngine;

public class MovePlayer : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;

	public bool isJumping = false;
	public bool isGrounded;
	public bool isGrimp;

	public Rigidbody2D rb;
	public Animator anim;
	private Vector3 velocity = Vector3.zero;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask collisionLayers;
	public SpriteRenderer spriteRenderer;
	private float horizontalMovement;
	private float verticalMovement;

	public Animator BL;

	void Update()
	{

		horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
		verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

		if(Input.GetButtonDown("Jump") && isGrounded)
		{
			isJumping = true;
			anim.Play("Jump");
		}

		Flip(rb.velocity.x);

		float characterVelocity = Mathf.Abs(rb.velocity.x);
		anim.SetFloat("Speed", characterVelocity);
		anim.SetBool("isGrimp", isGrimp);

	}

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
		MoPlayer(horizontalMovement, verticalMovement);

	}

	void MoPlayer(float _horizontalMovement, float _verticalMovement)
	{
		if(!isGrimp)
		{
			Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

			if(isJumping == true)
			{
				rb.AddForce(new Vector2(0f, jumpForce));
				isJumping = false;

			}
		}
		else
		{
			Vector3 targetVelocity = new Vector2(0, _verticalMovement);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
		}

	}

	void Flip(float _velocity)
	{
		if(_velocity > 0.1f)
		{
			spriteRenderer.flipX = false;
			BL.Play("Y");
		}
		else if(_velocity < -0.1f)
		{
			spriteRenderer.flipX = true;
			BL.Play("X");
		}

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}

}
