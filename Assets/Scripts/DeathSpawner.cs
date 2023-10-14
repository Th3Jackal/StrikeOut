using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpawner : MonoBehaviour
{
    [SerializeField] GameObject deathPrefab;

    float time = 0;

    void Start()
    {
        SpawnDeathOverTime();
    }

    void SpawnDeathOverTime()
    {
        StartCoroutine(SpawnDeathOverTimeRoutine());
        IEnumerator SpawnDeathOverTimeRoutine()
        {
            while(true)
            {
                time = Random.Range(0.25f,1.00f);
                yield return new WaitForSeconds(time);
                Instantiate(deathPrefab,new Vector3(Random.Range(-7.85f,7.85f),6,0),Quaternion.identity);
            }
        }
    }
}
