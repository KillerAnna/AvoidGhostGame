using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject scoreGhoPre;
    public GameObject enemyGhoPre;
    //public GameObject helpGhoPre;
    public float spawnRateMin = .5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawRate;//span
    private float timeAfterSpawn;//delta

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
        //targetHome = GameObject.Find
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawRate)
        {
            timeAfterSpawn = 0f;

            float randomGhost = Random.Range(0, 8);
            if(randomGhost > 1)
            {
                GameObject enemyGho = Instantiate(enemyGhoPre, transform.position
                    , transform.rotation);
                enemyGho.transform.LookAt(target);//LootAt = 내 정면이 타켓을 바라보게끔 회전한다.
            }//프리팹,위치,회전값
            else
            {
                GameObject scoreGho = Instantiate(scoreGhoPre, transform.position,
                    transform.rotation);
                scoreGho.transform.LookAt(target);
            }
            spawRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
