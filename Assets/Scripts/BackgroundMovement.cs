using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = 0.1f;
	void Start ()
    {
	
	}
	void Update ()
    {
        Vector2 offset = new Vector2(speed * Time.time, 0);
        this.GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
