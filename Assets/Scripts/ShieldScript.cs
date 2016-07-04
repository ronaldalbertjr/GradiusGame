using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour 
{
    GameObject player;
    GameObject player2;
    bool player1o;
    bool player2o;
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1o = false;
        player2o = false;
	}
	void Update () 
    {
        Debug.Log("PLayer1:" + player1o);
        Debug.Log("PLayer2:" + player2o);
	    if(player1o)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.position += Vector3.up * player.GetComponent<PlayerMovement>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.position += Vector3.right * player.GetComponent<PlayerMovement>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.position += Vector3.down * player.GetComponent<PlayerMovement>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.position += Vector3.left * player.GetComponent<PlayerMovement>().speed * Time.deltaTime;
            }
        }
        else if(player2o)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += Vector3.up * player2.GetComponent<PlayerMovement2>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += Vector3.right * player2.GetComponent<PlayerMovement2>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += Vector3.down * player2.GetComponent<PlayerMovement2>().speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += Vector3.left * player2.GetComponent<PlayerMovement2>().speed * Time.deltaTime;
            }
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (!player2o)
            {
                player1o = true;
            }
        }
        else if (col.gameObject.tag == "Player2")
        {
            if (!player1o)
            {
                player2o = true;
            }
        }
    }
}
