using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float mvx;
    float mvy;
    public float speed;
	void Start ()
    {
        speed = 5;
	}
	void Update ()
    {
        mvx = Input.GetAxis("Horizontal");
        mvy = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(mvx * speed * Time.deltaTime, mvy * speed * Time.deltaTime);
	}
}
