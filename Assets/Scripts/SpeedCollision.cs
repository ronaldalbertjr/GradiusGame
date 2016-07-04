using UnityEngine;
using System.Collections;

public class SpeedCollision : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().speedBuff = true;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player2")
        {
            col.gameObject.GetComponent<PlayerMovement2>().speedBuff = true;
            Destroy(this.gameObject);
        }
    }
}
