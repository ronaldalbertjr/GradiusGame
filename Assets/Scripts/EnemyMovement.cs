using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Vector3 aux;
    float speedx;
    float speedy;
    double time;
    double deathtime;
    public bool dying;
    public GameObject prefab;
    AudioSource playeraudio;
    void Start ()
    {
        speedx = -1;
        speedy = 5;
        playeraudio = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
	}
	void Update ()
    {
        time += Time.deltaTime;
        if(dying)
        {
            deathtime += Time.deltaTime;
            this.GetComponent<Animator>().SetBool("EnemyDeath", true);
            if(deathtime > 0.5)
            {
                this.transform.position = new Vector3(6, Random.Range(-5, 5));
                this.GetComponent<Animator>().SetBool("EnemyDeath", false);
                dying = false;
            }
        }
        else if(time > 1)
        {
            time = 0;
            playeraudio.Play();
            Instantiate(prefab, this.transform.position + new Vector3(-2, 0), Quaternion.Euler(0, 0, 180f));
        }
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
                this.transform.position = new Vector3(6, Random.Range(-5, 5));
            }
        }
        else if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().dying = true;
        }
    }        
}
