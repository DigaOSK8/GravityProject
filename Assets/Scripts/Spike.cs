using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player 1") 
        {
            levelManager.RespawnPlayer(other);
        } else if (other.name == "Player 2")
        {
            levelManager.RespawnPlayer(other);
        }
    }
}
