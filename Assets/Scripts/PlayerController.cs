using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Use this for initialization

    private Rigidbody2D rigidbody2d;
    public bool gravityChange = false;
    public float direction = 1f;

    public int qualPlayer;

    public int LeftPlayerNumber = 0; // 0 - if gamepad1 = left / 1 - if gamepad1 = right

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity;
    private string axisX;
    private KeyCode buttonA;
    private KeyCode buttonB;
    private KeyCode buttonC;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        var result = GameObject.Find("CharacterSelectController").GetComponent<CharacterSelectController>() as CharacterSelectController;
        if(result.GetSelectResultByPlayer1()==0 && name == "Player 1")
        {
            axisX = "Horizontal1";
            buttonA = KeyCode.Joystick1Button0;
        }
        else if (result.GetSelectResultByPlayer1() == 0 && name == "Player 2")
        {
            axisX = "Horizontal2";
            buttonA = KeyCode.Joystick2Button0;
        }
        else if (result.GetSelectResultByPlayer1() == 1 && name == "Player 1")
        {
            axisX = "Horizontal2";
            buttonA = KeyCode.Joystick2Button0;
        }
        else if (result.GetSelectResultByPlayer1() == 1 && name == "Player 2")
        {
            axisX = "Horizontal1";
            buttonA = KeyCode.Joystick1Button0;
        }
        //if(name == "Player 1")
        //{
        //    axisX = "Horizontal1";
        //    buttonA = KeyCode.Joystick1Button0;
        //}else if(name == "Player 2")
        //{
        //    axisX = "Horizontal2";
        //    buttonA = KeyCode.Joystick2Button0;
        //}
    }
    public void SetPlayerAs1()
    {
        axisX = "Horizontal1";
        buttonA = KeyCode.Joystick1Button0;
    }
    public void SetPlayerAs2()
    {
        axisX = "Horizontal2";
        buttonA = KeyCode.Joystick2Button0;
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Update()
    {

        SwapGravity();

        //anim.SetBool("Grounded", grounded);
       
        if (Input.GetKeyDown(buttonA) && grounded)
        {
            Jump();
        }

        rigidbody2d.velocity = new Vector2(Input.GetAxis(axisX) * moveSpeed, rigidbody2d.velocity.y);

        //anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

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
