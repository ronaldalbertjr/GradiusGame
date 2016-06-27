using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float mvx;
    float mvy;
    double deathtime;
    public GameObject prefab;
    GameObject[] shot = new GameObject[5];
    public float speed;
    public bool dying;
	void Start ()
    {
        speed = 5;
	}
	void Update ()
    {
        if(dying)
        {
            deathtime = Time.deltaTime;
            this.GetComponent<Animator>().SetTrigger("Death");
            if(deathtime > 0.5)
            {
                Destroy(this.gameObject);
            }
        }
        mvx = Input.GetAxis("Horizontal");
        mvy = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(mvx * speed * Time.deltaTime, mvy * speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < shot.Length; i++)
            {
                if(shot[i] == null)
                {
                    this.GetComponent<AudioSource>().Play();
                    shot[i] = (GameObject)Instantiate(prefab, this.transform.position + new Vector3(3, 0), new Quaternion(0f, 0f, 0f, 0f));
                    break;
                }
            }
        }
    }
}
