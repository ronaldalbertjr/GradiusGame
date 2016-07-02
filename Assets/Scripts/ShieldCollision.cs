using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour
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
            col.GetComponent<PlayerMovement>().shieldBuff = true;
            Destroy(this.gameObject);
        }
    }
}
