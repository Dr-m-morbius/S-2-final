using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject Coin;
    public float Area = 20f;
    public int CoinAmount = 10;

    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnRandomEnemy();
        StartCoroutine(SpawnRandomNumber());
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        Instantiate(Enemy, (CreateSpawnLocation()), Enemy.transform.rotation);
    }

    void SpawnCoin()
    {
        Instantiate(Coin, CreateSpawnLocation(), Coin.transform.rotation);
    }

    Vector3 CreateSpawnLocation()
    {
        float xValue = Random.Range(-Area, Area);
        float zValue = Random.Range(-Area, Area);
        Vector3 randomPosition = new Vector3(xValue, 1f, zValue);

        return randomPosition;

    }

    IEnumerator SpawnRandomNumber()
    {
        while (true)
        {
        int randomSeconds = Random.Range(1, 8);
        yield return new WaitForSeconds(randomSeconds);

        int NumberofEnemy = Random.Range(1, 3);
        for (int i = 0; i < NumberofEnemy; i++) 
        {
                SpawnRandomEnemy();
                SpawnCoin();

            }
        }
       
    }
}