using UnityEngine;
using System.Collections;

public class EnemyMovement2 : MonoBehaviour
{
    Vector3 aux;
    float speed;
    double time;
    double deathtime;
    public bool dying;
    AudioSource playeraudio;
    GameObject player;
    public GameObject speedBuff;
    void Start()
    {
        speed = 5;
        playeraudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        time += Time.deltaTime;
        if (dying)
        {
            deathtime += Time.deltaTime;
            this.GetComponent<Animator>().SetTrigger("EnemyDeath");
            if (deathtime > 0.5)
            {
                Destroy(this.gameObject);
                if (Random.Range(0, 100) < 10)
                {
                    Instantiate(speedBuff, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
            }
        }
       transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().dying = true;
        }
    }
}
