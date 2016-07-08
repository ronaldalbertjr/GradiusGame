using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

    public GameObject[] enemyprefab = new GameObject[5];
    GameObject boss;
    double time;
    void Start ()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }
	void Update ()
    {
        time += Time.deltaTime;
        if (boss != null)
        {
            if (time > 3 && boss.GetComponent<BossScript>().enemycounter < 20)
            {
                Instantiate(enemyprefab[Random.Range(0, 3)], new Vector3(6, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                time = 0;
            }
        }
    }
}
