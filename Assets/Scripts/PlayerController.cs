using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rigidbody2d;
    public bool gravityChange = false;
    public float direction = 1f;

    public int qualPlayer;  

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    void Start()
    {
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
        if (name == "Player 1")
        {
            Debug.Log("Player 1");

            if (Input.GetKeyDown(KeyCode.Joystick1Button0) && grounded)
            {
                Jump();
            }

           

            GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal1") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

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

        if (name == "Player 2")
        {
            Debug.Log("Player 2");

            if (Input.GetKeyDown(KeyCode.Joystick2Button0) && grounded)
            {
                Jump();
            }



            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + Input.GetAxis("Horizontal2") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

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
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    private void Move(float direction)
    {
        
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
