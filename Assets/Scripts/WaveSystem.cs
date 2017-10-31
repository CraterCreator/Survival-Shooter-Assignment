using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public GameObject enemy, ogre;
    public Transform[] spawnPoints;
    public Transform spawnPoint;
    public float timer = 3f;
    public int enemyNum = 0;
    public int ogreNum = 0;

    // Update is called once per frame
    void Update()
    {

        if (timer <= 0)
        {
            timer = 20.1f;
            StartCoroutine(SpawnWave());
        }

        timer -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        if (enemyNum <= 50)
        {
            enemyNum += 5;
        }
        for (int i = 0; i < enemyNum; i++)
        {
            EnemySpawn();
            yield return new WaitForSeconds(1f);
        }
        enemyNum -= 3;

        if (ogreNum <= 35)
        {
            ogreNum += 1;
        }
        for (int i = 0; i < ogreNum; i++)
        {
            OgreSpawn();
            yield return new WaitForSeconds(1f);
        }
    }

    void EnemySpawn()
    {
        spawnPoint = spawnPoints[Random.Range(0, 7)];
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void OgreSpawn()
    {
        spawnPoint = spawnPoints[Random.Range(0, 7)];
        Instantiate(ogre, spawnPoint.position, spawnPoint.rotation);
    }
}
