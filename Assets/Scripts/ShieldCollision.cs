using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour
{
    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<PlayerMovement>().shieldBuff = true;
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Player2")
        {
            col.GetComponent<PlayerMovement2>().shieldBuff = true;
            Destroy(this.gameObject);
        }
    }
}
