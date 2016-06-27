using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public GameObject cam;
    GameObject enemy;
    GameObject player;
    int speed;
    void Start()
    {
        if(this.gameObject.tag == "PlayerShot")
        {
            speed = 10;
        }
        else
        {
            speed = -10;
        }
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	void Update ()
    {
            this.transform.position += Vector3.right * Time.deltaTime * speed;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
        {
            Destroy(this.gameObject);
        }
        else if(col.tag == "Enemy")
        {
            Destroy(this.gameObject);
            enemy.GetComponent<EnemyMovement>().dying = true;
        }
        else if(col.tag == "Player")
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerMovement>().dying = true;
        }
    }
}
