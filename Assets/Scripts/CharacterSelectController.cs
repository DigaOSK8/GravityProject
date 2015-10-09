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
        }
        axisInput = Input.GetAxis(axisX);

        if(axisInput < -0.1f)
        {
            MoveToLeft(TriangleP1);
            MoveToRight(TriangleP2);
        }
        else if(axisInput > 0.1f)
        {
            MoveToLeft(TriangleP2);
            MoveToRight(TriangleP1);
        }
        axisInput = 0.0f;
    }
    private void MoveToRight(GameObject player)
    {
        player.transform.position = new Vector3(5.5f, 32f, 85);
    }
    private void MoveToLeft(GameObject player)
    {
        player.transform.position = new Vector3(-5.5f, 32f, 85);
    }
}
