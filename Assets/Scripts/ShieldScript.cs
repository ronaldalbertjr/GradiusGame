using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour
{

    GameObject player;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.parent = player.transform;
    }
	void Update ()
    {
	}
}
