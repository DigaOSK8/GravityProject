using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject lifeParticle;

    public float respawnDelay;

    public int pointPenaltOnDeath;

    private float gravityStore;

    // Use this for initialization
    void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
        
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;

        ScoreManager.AddPoints(-pointPenaltOnDeath);

        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = currentCheckpoint.transform.position;
        Instantiate(lifeParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
    }
}
