using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour
{
    public GameObject coli;
    public bool alreadyshot;
	void Start ()
    {
	
	}
	void Update ()
    {
	    if(!alreadyshot)
        {
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        else
        {
            this.transform.position += Vector3.right * Time.deltaTime * 5;
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        alreadyshot = false;
    }
}
