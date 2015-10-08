using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{
    public GameObject Camera;
    public GameObject DestinationScreen;
    public GameObject MiddleScreen; //like splash screen
    public float TimeInMiddleScreen;

    private bool started;
    private bool inMiddle;
    private bool done;
    // Use this for initialization
    void Start()
    {
        started = true;
    }

    // Update is called once per frame
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
        Camera.transform.position = new Vector3(DestinationScreen.transform.position.x,
            DestinationScreen.transform.position.y,
             Camera.transform.position.z);
    }

    void MoveCameraToMiddle()
    {
        Camera.transform.position = new Vector3(MiddleScreen.transform.position.x,
            MiddleScreen.transform.position.y,
             Camera.transform.position.z);
        inMiddle = true;
    }
}
