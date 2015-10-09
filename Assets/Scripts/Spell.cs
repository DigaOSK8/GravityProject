using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    float _speed;
    float _distance;

    public LayerMask objs;
    public LayerMask players;

    float lifeTime = 0.0f;

    public void Config(float speed, float distance)
    {
        _distance = distance;
        _speed = speed;
        
    }    
    

    void Update()
    {
        lifeTime += Time.deltaTime;

        if(lifeTime >= _distance)
        {
            Destroy(gameObject);
        }        

        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        Debug.Log(obj);
        if (obj.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }       
    }
}
