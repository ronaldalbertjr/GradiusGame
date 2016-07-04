using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossScript : MonoBehaviour
{
    GameObject camera;
    GameObject player;
    GameObject background;
    public AudioSource audio;
    public GameObject prefab;
    public int enemycounter;
    public bool shot;
    float life;
    float time;
	void Start ()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        background = GameObject.Find("Background");
        audio.Pause();
        life = 1;
    }
	void Update ()
    {
	    if(enemycounter >= 20)
        {
            background.GetComponent<AudioSource>().Stop();
            if(this.transform.position.x > 4)
            {
                this.transform.position += Vector3.left * Time.deltaTime;
            }
            else
            {
                audio.UnPause();
                time += Time.deltaTime;
                if(time > 1 && life > 0)
                {
                    time = 0;
                    Instantiate(prefab, new Vector3(2f, player.transform.position.y), Quaternion.Euler(0f, 0f, 180f));
                }
                if (shot && life > 0)
                {
                    life -= 0.05f;
                    this.GetComponent<SpriteRenderer>().color = Color.red;
                    shot = false;
                }
                if (this.GetComponent<SpriteRenderer>().color != Color.white && life > 0)
                {
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.white, 0.2f);
                }
                if (life <= 0)
                {
                    audio.Stop();
                    this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.black, 0.1f);
                    if(this.GetComponent<SpriteRenderer>().color ==  Color.black)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
        }

	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerMovement>().dying = true;
        }
        else if(col.gameObject.tag == "Player2")
        {
            col.gameObject.GetComponent<PlayerMovement2>().dying = true;
        }
    }
}
