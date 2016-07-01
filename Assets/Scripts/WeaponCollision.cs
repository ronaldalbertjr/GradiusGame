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
    }
}
