using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Vector3 aux;
    float speedx;
    float speedy;
    void Start ()
    {
        speedx = -5;
        speedy = 10;
	}
	void Update ()
    {
        aux = new Vector3(Time.deltaTime * speedx, Time.deltaTime * speedy);
        this.transform.position += aux;
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            speedy *= -1;
            if(this.transform.position.x  < -6)
            {
                this.transform.position = new Vector3(6, new System.Random().Next(-5, 5));
            }
        }
        else if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }        
}
