using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
      public GameObject Coin;

         public int CoinAmount = 10;
           public float Area = 20f;

    // Start is called before the first frame update
    void Start()
    {
  
            SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoin()
    {
        for(int i = 0; i < CoinAmount; i++)
        Instantiate(Coin, CreateSpawnLocation(), Coin.transform.rotation);
    }

    Vector3 CreateSpawnLocation()
    {
        float xValue = Random.Range(-Area, Area);
        float zValue = Random.Range(-Area, Area);
        Vector3 randomPosition = new Vector3(xValue, 1f, zValue);

        return randomPosition;

    }

}
