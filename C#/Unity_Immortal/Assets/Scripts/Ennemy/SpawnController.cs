using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public float timeLine = 0;
    public int nom = 0;

    void Update()
    {
        timeLine += Time.deltaTime;

        if (timeLine > 30)
        {
            timeLine = 0;

            if (nom >= spawnPoints.Length)
            {
                for (int i = 0; i < spawnPoints.Length; i++)
                {
                    if (i == spawnPoints.Length - 1)
                        spawnPoints[i].GetComponent<KingQueenSpawn>().timeSpawn -= 0.5f;
                    else
                        spawnPoints[i].GetComponent<EnnemySpawn>().timeSpawn -= 0.5f;
                }

                return;
            }

            spawnPoints[nom].SetActive(true);
            nom++;

        }
    }
}