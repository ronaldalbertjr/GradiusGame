using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public GameObject cam;
    GameObject enemy;
    GameObject enemy1;
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
        enemy1 = GameObject.FindGameObjectWithTag("Enemy1");
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
        else if(col.tag == "Enemy1")
        {
            Destroy(this.gameObject);
            enemy1.GetComponent<EnemyMovement1>().dying = true;
        }
        else if(col.tag == "Player")
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerMovement>().dying = true;
        }
    }
}
