using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rigidbody2d;
    public bool gravityChange = false;
    public float direction = 1f;

    public int qualPlayer;  

    public float moveSpeed;
    public float maxVelocityY;
    public float jumpHeight;
    private float moveVelocity;
    private string axisX;
    private KeyCode buttonA;
    private KeyCode buttonB;
    private KeyCode buttonC;

    public Transform groundCheck;
    public float groundCheckRadius;
    private LayerMask whatIsGround;
    public LayerMask whatIsPlatUp;
    public LayerMask whatIsPlatDown;
    private bool grounded;

    public LayerMask player1;
    public LayerMask player2;

    private Animator anim;

    private Shooter teco;

    void Start()
    {
        anim = GetComponent<Animator>();

        teco = GetComponent<Shooter>();



        rigidbody2d = GetComponent<Rigidbody2D>();

        if(name == "Player 1")
        {
            anim.SetBool("Red", true);
            whatIsGround = whatIsPlatUp;
            Physics2D.IgnoreLayerCollision(8, 12, true);
            Physics2D.IgnoreLayerCollision(10, 11, false);
            gameObject.layer = 8;

            axisX = "Horizontal1";
            buttonA = KeyCode.Joystick1Button0;
            buttonB = KeyCode.Joystick1Button1;
        }
        else if(name == "Player 2")
        {
            anim.SetBool("Red", false);
            whatIsGround = whatIsPlatDown;
            Physics2D.IgnoreLayerCollision(8, 11, true);
            Physics2D.IgnoreLayerCollision(10, 12, false);
            gameObject.layer = 10;

            axisX = "Horizontal2";
            buttonA = KeyCode.Joystick2Button0;
            buttonB = KeyCode.Joystick2Button1;
        }
    }

    void FixedUpdate()
    {       
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);     
    }
    void Update()
    {
        
        SwapGravity();
        
        if (rigidbody2d.velocity.y < maxVelocityY && rigidbody2d.gravityScale < 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, maxVelocityY);
        }else if(rigidbody2d.velocity.y > maxVelocityY && rigidbody2d.gravityScale > 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, -maxVelocityY);
        } 
       
        if (Input.GetKeyDown(buttonA) && grounded)
        {
            Jump();
        }

        Move();

        SwapDirect();

        if (Input.GetKeyDown(buttonB))
        {
            anim.SetTrigger("Shot");
            teco.Shot(transform.localScale.x > 0 ? true : false);
        }

        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    private void SwapDirect()
    {
        if (rigidbody2d.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, direction, 1f);
        }
        else if (rigidbody2d.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, direction, 1f);
        }
    }

    private void Jump()
    {
        rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpHeight);
    }

    private void Move()
    {
        rigidbody2d.velocity = new Vector2(Input.GetAxis(axisX) * moveSpeed, rigidbody2d.velocity.y);
    }
    
    public void SwapGravity()
    {
        if (gravityChange)
        {
            gravityChange = false;
            
            rigidbody2d.gravityScale = -rigidbody2d.gravityScale;

            if (rigidbody2d.gravityScale < 0)
            {
                whatIsGround = whatIsPlatDown;
                Physics2D.IgnoreLayerCollision(8, 12, true);
                Physics2D.IgnoreLayerCollision(10, 11, false);
                gameObject.layer = 10;
                direction = -1f;
            }
            else if(rigidbody2d.gravityScale > 0)
            {
                whatIsGround = whatIsPlatUp;
                Physics2D.IgnoreLayerCollision(10, 11, true);
                Physics2D.IgnoreLayerCollision(8, 12, false);
                gameObject.layer = 8;
                direction = 1f;
            }

            transform.localScale = new Vector3(1f, direction, 1f);

            jumpHeight = -jumpHeight;
            maxVelocityY = -maxVelocityY;
        }
    }
}
