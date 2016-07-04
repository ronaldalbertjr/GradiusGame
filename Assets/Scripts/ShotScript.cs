using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public GameObject cam;
    GameObject enemy;
    GameObject enemy1;
    GameObject enemy2;
    GameObject player;
    GameObject boss;
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
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
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
            boss.GetComponent<BossScript>().enemycounter++;
        }
        else if(col.tag == "Enemy1")
        {
            Destroy(this.gameObject);
            enemy1.GetComponent<EnemyMovement1>().dying = true;
            boss.GetComponent<BossScript>().enemycounter++;
        }
        else if(col.tag == "Enemy2")
        {
            Destroy(this.gameObject);
            enemy2.GetComponent<EnemyMovement2>().dying = true;
            boss.GetComponent<BossScript>().enemycounter++;
        }
        else if(col.tag == "Player" && this.tag != "PlayerShot")
        {
            Destroy(this.gameObject);
            player.GetComponent<PlayerMovement>().dying = true;
        }
        else if(this.tag != "PlayerShot" && col.tag == "Shield")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
        else if(this.tag == "PlayerShot" && col.tag == "Boss")
        {
            Destroy(this.gameObject);
            col.GetComponent<BossScript>().shot = true;
        }
        else if (col.tag == "Player2" && this.tag != "PlayerShot")
        {
            Destroy(this.gameObject);
            col.GetComponent<PlayerMovement2>().dying = true;
        }
    }
}
