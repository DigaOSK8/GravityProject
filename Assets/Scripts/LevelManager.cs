using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    public Collider2D[] checkpoint;

    public PlayerController player1;

    public PlayerController player2;

    public GameObject deathParticle;
    public GameObject lifeParticle;

    public float respawnDelay;

    public int pointPenaltOnDeath;

    private float gravityStore;

    // Use this for initialization
    void Awake()
    {     
        player1.transform.position = checkpoint[Random.Range(0, 6)].transform.position;
        player2.transform.position = checkpoint[Random.Range(0, 6)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer(Collider2D player)
    {
        StartCoroutine("RespawnPlayerCo", player);
        
    }

    public IEnumerator RespawnPlayerCo(Collider2D player)
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
