using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float mvx;
    float mvy;
    public GameObject prefab;
    GameObject[] shot = new GameObject[5];
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < shot.Length; i++)
            {
                if(shot[i] == null)
                {
                    shot[i] = (GameObject)Instantiate(prefab, this.transform.position, new Quaternion(0f, 0f, 0f, 0f));
                    break;
                }
            }
        }
    }
}
