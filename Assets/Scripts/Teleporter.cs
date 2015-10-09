using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public Transform goToPosition;
    public bool isHorizontal;

    void OnTriggerEnter2D(Collider2D col)
    {       
        if (col.gameObject.tag.Equals("Player"))
        {
            if (isHorizontal)
            {
                col.transform.position = new Vector3(goToPosition.position.x,col.transform.position.y,0);
            }
            else
            {
                col.transform.position = new Vector3(col.transform.position.x, goToPosition.transform.position.y, 0);
            }
        }
    }
}
