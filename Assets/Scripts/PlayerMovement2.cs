using UnityEngine;
using System.Collections;

public class PlayerMovement2 : MonoBehaviour 
{
    float speedTime;
    float weaponTime;
    public bool speedBuff;
    double deathtime;
    public GameObject prefab;
    GameObject player;
    GameObject boss;
    GameObject[] shot = new GameObject[5];
    public AudioSource audioshot;
    public float speed;
    public bool dying;
    double time;
    public bool weaponBuff;
    public bool shieldBuff;
	void Start () 
    {
        speed = 5;
        boss = GameObject.FindGameObjectWithTag("Boss");
        player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update () 
    {
        time += Time.deltaTime;
        if (dying)
        {
            deathtime += Time.deltaTime;
            this.GetComponent<Animator>().SetTrigger("Death");
            if (deathtime > 1)
            {
                Destroy(this.gameObject);
                if (player == null)
                {
                    Application.LoadLevel("Lose");
                }
            }
        }
        if (speedBuff)
        {
            speed = 8;
            speedTime += Time.deltaTime;
            if (speedTime >= 20)
            {
                speedBuff = false;
                speedTime = 0;
            }
        }
        if (weaponBuff)
        {
            weaponTime += Time.deltaTime;
            if (weaponTime >= 10)
            {
                weaponBuff = false;
                weaponTime = 0;
            }
        }
        if (shieldBuff)
        {
            this.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < shot.Length; i++)
            {
                if (shot[i] == null)
                {
                    audioshot.GetComponent<AudioSource>().Play();
                    shot[i] = (GameObject)Instantiate(prefab, this.transform.position + new Vector3(3, 0), new Quaternion(0f, 0f, 0f, 0f));
                    if (weaponBuff)
                    {
                        Instantiate(prefab, this.transform.position + new Vector3(2.5f, 1), new Quaternion(0, 0, 0, 0));
                        Instantiate(prefab, this.transform.position + new Vector3(2.5f, -1), new Quaternion(0, 0, 0, 0));
                    }
                    break;
                }
            }
        }
        if (boss != null)
        {
            if(Input.GetKey(KeyCode.W))
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            this.transform.position += Vector3.right * Time.deltaTime;
            if (this.transform.position.x > 8)
            {
                Application.LoadLevel("Win");
            }
        }
	}
}
