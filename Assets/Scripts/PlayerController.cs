using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rigidbody2d;
    public bool gravityChange = false;
    private float direction = 1f;

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update()
    {

        SwapGravity();

        //anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }        

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveSpeed;
        }

        Move(moveVelocity);

        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, direction, 1f);
        }
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, direction, 1f);
        }

    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    private void Move(float direction)
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction, GetComponent<Rigidbody2D>().velocity.y);
    }
    
    public void SwapGravity()
    {
        if (gravityChange)
        {
            gravityChange = false;
            rigidbody2d.gravityScale = -rigidbody2d.gravityScale;
            if (rigidbody2d.gravityScale < 0)
            {
                direction = -1f;
            }
            else
            {
                direction = 1f;
            }
            transform.localScale = new Vector3(1f, direction, 1f);
            jumpHeight = -jumpHeight;
        }
    }
}
