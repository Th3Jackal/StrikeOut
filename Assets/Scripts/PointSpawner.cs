using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] GameObject pointPrefab;

    float time;

    void Start()
    {
        SpawnPointOverTime();
    }

    void SpawnPointOverTime()
    {
        StartCoroutine(SpawnPointOverTimeRoutine());
        IEnumerator SpawnPointOverTimeRoutine()
        {
            while(true)
            {
                time = Random.Range(0.0f,0.75f);
                yield return new WaitForSeconds(time);
                Instantiate(pointPrefab,new Vector3(Random.Range(-8.57f,8.57f),6,0),Quaternion.identity);
            }
        }
    }
}