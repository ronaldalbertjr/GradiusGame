using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float mvx;
    float mvy;
    float speedTime;
    float weaponTime;
    GameObject boss;
    public bool speedBuff;
    GameObject player2;
    double deathtime;
    public GameObject prefab;
    public GameObject[] enemyprefab =  new GameObject[5];
    GameObject[] shot = new GameObject[5];
    public GameObject shield;
    public AudioSource audio;
    public float speed;
    public bool dying;
    double time;
    public bool weaponBuff;
    public bool shieldBuff;
	void Start ()
    {
        speed = 5;
        boss = GameObject.FindGameObjectWithTag("Boss");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        audio.Pause();
	}
	void Update ()
    {
        time += Time.deltaTime;
        if (dying)
        {
            deathtime += Time.deltaTime;
            this.GetComponent<Animator>().SetTrigger("Death");
            if(deathtime > 1)
            {
                Destroy(this.gameObject);
                if (player2 == null)
                {
                    Application.LoadLevel("Lose");
                }
            }
        }
        if (boss != null)
        {
            if (time > 3 && boss.GetComponent<BossScript>().enemycounter < 20)
            {
                Instantiate(enemyprefab[Random.Range(0, 3)], new Vector3(6, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                time = 0;
            }
        }
        if(speedBuff)
        {
            speed = 8;
            speedTime += Time.deltaTime;
            if(speedTime >= 20)
            {
                speedBuff = false;
                speedTime = 0;
            }
        }
        if(weaponBuff)
        {
            weaponTime += Time.deltaTime;
            if(weaponTime >= 10)
            {
                weaponBuff = false;
                weaponTime = 0;
            }
        }
        if(shieldBuff)
        {
            Instantiate(shield, this.transform.position + Vector3.right, new Quaternion(0f, 0f, 0f, 0f));
            shieldBuff = false;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            for (int i = 0; i < shot.Length; i++)
            {
                if (shot[i] == null)
                {
                    this.GetComponent<AudioSource>().Play();
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
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position += Vector3.down * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            audio.UnPause();
            this.transform.position += Vector3.right * Time.deltaTime;
            if(this.transform.position.x > 8)
            {
                Application.LoadLevel("Win");
            }
        }
    }
}
