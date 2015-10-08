using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {

    private ParticleSystem particleSystem;
	// Use this for initialization
	void Start ()
    {
        particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (particleSystem.isPlaying)
        {
            return;
        }
        Destroy(gameObject);
	}
}
