using UnityEngine;
using System.Collections;

//it's move camera from one screen to another,
//it's possible to add some splash screen in middle.
//if middle is empty it will go to destination after some seconds (set up)
public class ScreenSwitcher : MonoBehaviour
{
    public GameObject Camera;
    public GameObject DestinationScreen;
    public GameObject MiddleScreen; //like splash screen
    public float TimeInMiddleScreen;
    public bool Automatic = true;
    public float OffsetX = 0.0f;
    public float OffsetY = 0.0f;

    private bool started;
    private bool inMiddle;
    private bool done;

    void Start()
    {
        if(Automatic == true)
        {
            started = true;
        }
        
    }

    void Update()
    {
        if (started == true)
        {
            if (inMiddle == false)
            {
                if(MiddleScreen !=null)
                {
                    MoveCameraToMiddle();
                }
                else
                {
                    inMiddle = true;
                }
                
            }
            if (inMiddle == true)
            {
                StartCoroutine("CountTheTime");
                if (done == true)
                {
                    MoveCameraToFinalDestination();
                }
            }
        }
    }

    IEnumerator CountTheTime()
    {
        yield return new WaitForSeconds(TimeInMiddleScreen);
        done = true;
    }

    void MoveCameraToFinalDestination()
    {
        Camera.transform.position = new Vector3(DestinationScreen.transform.position.x + OffsetX,
            DestinationScreen.transform.position.y + OffsetY,
             Camera.transform.position.z);
    }

    void MoveCameraToMiddle()
    {
        Camera.transform.position = new Vector3(MiddleScreen.transform.position.x,
            MiddleScreen.transform.position.y,
             Camera.transform.position.z);
        inMiddle = true;
    }
    public void Play()
    {
        started = true;
    }
}
