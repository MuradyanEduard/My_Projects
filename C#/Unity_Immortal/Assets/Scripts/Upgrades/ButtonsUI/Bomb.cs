using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject player;
    public GameObject UpgradePanel;
    public GameObject bomb;

    private GameObject[] allEnnemys;

    public void OnBombClick()
    {
        allEnnemys = GameObject.FindGameObjectsWithTag("Ennemy");

        if (allEnnemys.Length == 0)
        {
            Time.timeScale = 1;
            UpgradePanel.SetActive(false);
            return;
        }
 
        float[] distance = new float[allEnnemys.Length];

        for (int i = 0; i < allEnnemys.Length; i++)
        {
            distance[i] = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y),
                new Vector2(allEnnemys[i].transform.position.x, allEnnemys[i].transform.position.y));
        }

        int nom = 0;

        if (distance.Length == 0)
            return;

        float distanceMin = distance[nom];
        for (int i = 1; i < distance.Length; i++)
        {
            if (distanceMin > distance[i])
            {
                distanceMin = distance[i];
                nom = i;
            }
        }

        Instantiate(bomb, new Vector3(allEnnemys[nom].transform.position.x, allEnnemys[nom].transform.position.y), bomb.transform.rotation);

        Time.timeScale = 1;
        UpgradePanel.SetActive(false);
    }

}
