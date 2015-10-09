using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public Collider2D[] checkpoint;

    public PlayerController player1;

    public PlayerController player2;

    //public GameObject deathParticle;
    //public GameObject lifeParticle;

    public float respawnDelay;

    private float swapDelay;

    private bool secondP = false;

    public int pointPenaltOnDeath;

    private float gravityStore;

    // Use this for initialization
    void Awake()
    {
        player1.transform.position = checkpoint[Random.Range(0, checkpoint.Length)].transform.position;
        secondP = (Random.Range(0, 2) == 1) ? true : false;
        swapDelay = Random.Range(3, 10);        
        
        //player2.transform.position = checkpoint[Random.Range(0, checkpoint.Length)].transform.position;
    }

    void Start()
    {
        GravitySwap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer(Collider2D player)
    {
        
        StartCoroutine("RespawnPlayerCo", player);        
    }


    public void GravitySwap()
    {        
        StartCoroutine("GravitySwapCo");
    }

    public IEnumerator GravitySwapCo()
    {
        if (secondP)
        {
            secondP = false;
            player1.gravityChange = !player1.gravityChange;
            player2.gravityChange = !player2.gravityChange;
            GravitySwap();

        }
        else
        {

            yield return new WaitForSeconds(swapDelay);



            player1.gravityChange = !player1.gravityChange;
            player2.gravityChange = !player2.gravityChange;
            swapDelay = Random.Range(3, 10);
            GravitySwap();
        }
    }

    public IEnumerator RespawnPlayerCo(Collider2D player)
    {
        //Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        player.enabled = false;
        player.GetComponentInChildren<Renderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;

        ScoreManager.AddPoints(-pointPenaltOnDeath);

        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = checkpoint[Random.Range(0, checkpoint.Length)].transform.position;
        //Instantiate(lifeParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

        player.enabled = true;
        player.GetComponentInChildren<Renderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
    }    
}
