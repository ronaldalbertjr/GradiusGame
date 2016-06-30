using UnityEngine;
using System.Collections;

public class SpeedCollision : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().speedBuff = true;
            Destroy(this.gameObject);
        }
    }
}
