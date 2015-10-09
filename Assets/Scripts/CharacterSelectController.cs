using UnityEngine;
using System.Collections;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject TriangleP1;
    public GameObject TriangleP2;
    public GameObject CharactersBW;
    public GameObject CharactersColor;
    public GameObject ScreenSwitcher;

    private string axisX;
    private KeyCode buttonA;
    private float axisInput = 0.0f;
    private int selectedByPlayer1 = 0;


    // Use this for initialization
    void Start()
    {
        axisX = "Horizontal";
        buttonA = KeyCode.Joystick1Button0;
        CharactersBW = Instantiate(CharactersBW);
        TriangleP1 = Instantiate(TriangleP1);
        TriangleP2 = Instantiate(TriangleP2);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(buttonA))
        {
            CharactersColor = Instantiate(CharactersColor);
            Destroy(CharactersBW);
            ((ScreenSwitcher)ScreenSwitcher.GetComponent(typeof(ScreenSwitcher))).Play();
            Destroy(this);
        }
        axisInput = Input.GetAxis(axisX);

        if(axisInput < -0.1f)
        {
            MoveToLeft(TriangleP1);
            MoveToRight(TriangleP2);
            selectedByPlayer1 = 0;

            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                var script = player.GetComponent<PlayerController>() as PlayerController;
                if (player.name == "Player 1")
                {
                    script.SetPlayerAs1();
                }
                else if(player.name == "Player 2")
                {
                    script.SetPlayerAs2();
                }
            }
        }
        else if(axisInput > 0.1f)
        {
            MoveToLeft(TriangleP2);
            MoveToRight(TriangleP1);
            selectedByPlayer1 = 1;
            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                var script = player.GetComponent<PlayerController>() as PlayerController;
                if (player.name == "Player 1")
                {
                    script.SetPlayerAs2();
                }
                else if (player.name == "Player 2")
                {
                    script.SetPlayerAs1();
                }
            }
        }
        axisInput = 0.0f;
    }
    private void MoveToRight(GameObject player)
    {
        //set player to right position
        player.transform.position = new Vector3(5.5f, 32f, 85);
    }
    private void MoveToLeft(GameObject player)
    {
        //set player to left position
        player.transform.position = new Vector3(-5.5f, 32f, 85);
    }
    public int GetSelectResultByPlayer1()
    {
        return selectedByPlayer1; // return 0 when left and 1 when right
    }
}
