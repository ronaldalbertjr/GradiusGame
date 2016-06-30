using UnityEngine;
using System.Collections;

public class EnemyMovement1 : MonoBehaviour
{
    Vector3 aux;
    float speedx;
    float speedy;
    double time;
    double deathtime;
    public bool dying;
    public GameObject prefab;
    AudioSource playeraudio;
    public GameObject speedBuff;
    void Start()
    {
        speedx = -1;
        speedy = 5;
        playeraudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
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
        else if (time > 1)
        {
            time = 0;
            playeraudio.Play();
            Instantiate(prefab, this.transform.position + new Vector3(-4, 0), Quaternion.Euler(0, 0, 180f));
        }
        aux = new Vector3(Time.deltaTime * speedx, 0);
        this.transform.position += aux;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MainCamera")
        {
            speedy *= -1;
            if (this.transform.position.x < -6)
            {
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().dying = true;
        }
    }
}
