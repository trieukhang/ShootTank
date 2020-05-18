using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int maxEnemy = 4; //the number of enemy-tank in the feild
    int counter = 0;

    public GameObject[] tankPrefabs;
    public Transform[] spawnPoints;

    public static SpawnEnemy instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine("CoSetupEnemy");
    }
    IEnumerator CoSetupEnemy()
    {
        while (counter < maxEnemy)
        {
            counter++;
            SpawnTank();
            yield return new WaitForSeconds(5f); 
        }
    }
    public void SpawnTank()
    {
        int tankIndex = Random.Range(0, tankPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(tankPrefabs[tankIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
}
