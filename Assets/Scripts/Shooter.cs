using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject spell;
    public Transform shootingPosition;

    public float spell_speed;
    public float spell_distance;

    public float reloadTime = 1.0f;
    float reload_timer = 0.0f;

    bool canShot = true;
	
	// Update is called once per frame
	void Update () {


        if (canShot) return;

        reload_timer += Time.deltaTime;
        if(reload_timer >= reloadTime)
        {
            canShot = true;
        }
	}

    public void Shot(bool isRight)
    {
        if (!canShot) return;

        GetComponent<Animator>().SetTrigger("Shot");

        canShot = false;
        reload_timer = 0.0f;

        GameObject tiro = Instantiate(spell) as GameObject;
        tiro.GetComponent<Spell>().Config(isRight?spell_speed:-spell_speed,spell_distance);

        tiro.transform.position = shootingPosition.position;
    }
}
