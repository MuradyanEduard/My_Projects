using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ThunderStrike : MonoBehaviour
{
    public GameObject player;
    public GameObject UpgradePanel;
    public GameObject Thunder;

    private GameObject[] allEnnemys;

    public void OnTunderStrikeClick()
    { 
        allEnnemys = allEnnemys = GameObject.FindGameObjectsWithTag("Ennemy");

        if (allEnnemys.Length == 0)
        {
            Time.timeScale = 1;
            UpgradePanel.SetActive(false);
            return;
        }

        float[] distance = new float[allEnnemys.Length];
        int[] index = new int[allEnnemys.Length];

        for (int i = 0; i < allEnnemys.Length; i++)
        {
            distance[i] = Vector2.Distance(new Vector2(player.transform.position.x,player.transform.position.y),
                new Vector2(allEnnemys[i].transform.position.x, allEnnemys[i].transform.position.y));        
            
            index[i] = i;
        }

        for (int i = 0; i < distance.Length; i++)
        {
            for (int j = 0; j < distance.Length-1; j++)
            {
                if (distance[j] > distance[j + 1])
                {
                    float cng = distance[j];
                    distance[j] = distance[j + 1];
                    distance[j + 1] = cng;

                    int ix = index[j];
                    index[j] = index[j + 1];
                    index[j + 1] = ix;

                }

            }
        }


        if (index.Length <= 3)
        {
            for (int i = 0; i < allEnnemys.Length; i++)
            {
                Instantiate(Thunder, new Vector3(allEnnemys[index[i]].transform.position.x, allEnnemys[i].transform.position.y + 2), Thunder.transform.rotation);
            }
        }
        else {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Thunder, new Vector3(allEnnemys[index[i]].transform.position.x, allEnnemys[index[i]].transform.position.y + 2), Thunder.transform.rotation);

            }
        }

        Time.timeScale = 1;
        UpgradePanel.SetActive(false);
    }
}
