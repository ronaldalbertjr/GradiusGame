using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public GameObject cam;
    int speed;
    void Start()
    {
        speed = 10;
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
            Destroy(col.gameObject);
        }
    }
}
