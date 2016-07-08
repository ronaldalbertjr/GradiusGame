using UnityEngine;
using System.Collections;

public class EnemyMovement2 : MonoBehaviour
{
    Vector3 aux;
    float speed;
    double time;
    double deathtime;
    public bool dying;
    GameObject player;
    public GameObject speedBuff;
    public GameObject weaponBuff;
    public GameObject shieldBuff;
    void Start()
    {
        speed = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
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
                else if (Random.Range(0, 100) < 10)
                {
                    Instantiate(weaponBuff, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
                else if (Random.Range(0, 100) < 10)
                {
                    Instantiate(shieldBuff, this.transform.position, Quaternion.Euler(0f, 0f, 0f));
                }
            }
        }
       transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Shield" && !dying)
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Player" && !dying)
        {
            col.gameObject.GetComponent<PlayerMovement>().dying = true;
        }
        else if (col.gameObject.tag == "Player2" && !dying)
        {
            col.gameObject.GetComponent<PlayerMovement2>().dying = true;
        }
    }
}
