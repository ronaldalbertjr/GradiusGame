using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour
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
            player.GetComponent<PlayerMovement>().weaponBuff = true;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player2")
        {
            col.GetComponent<PlayerMovement2>().weaponBuff = true;
            Destroy(this.gameObject);
        }
    }
}
