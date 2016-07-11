using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour {

    public GameObject[] enemyprefab = new GameObject[5];
    GameObject boss;
    public AudioSource audioVictory;
    GameObject player2;
    double time;
    void Start ()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        audioVictory.Pause();
    }
	void Update ()
    {
        time += Time.deltaTime;
        if (boss != null)
        {
            if (time > 1.5 && boss.GetComponent<BossScript>().enemycounter < 40 && player2 == null)
            {
                Instantiate(enemyprefab[Random.Range(0, 3)], new Vector3(7, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                time = 0;
            }
            else if(time > 3 && boss.GetComponent<BossScript>().enemycounter < 40 && player2 != null)
            {
                Instantiate(enemyprefab[Random.Range(0, 3)], new Vector3(7, Random.Range(-4, 4)), new Quaternion(0f, 0f, 0f, 0f));
                time = 0;
            }
        }
        else
        {
            audioVictory.UnPause();
        }
    }
}
