using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EnemyPrefabs;
    private int indexRange=0;
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnManager", 3, 4.5F);
    }

    // Update is called once per frame
    void Update()
    {
        if (indexRange >=EnemyPrefabs.Length)
        {
            indexRange = 0;
        }
    }
    void SpawnManager()
    {
       
            indexRange=Random.Range(0,EnemyPrefabs.Length);
            Instantiate(EnemyPrefabs[indexRange], transform.position, Quaternion.identity);
            
      
        
    }
}
