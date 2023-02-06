using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLogic : MonoBehaviour
{
    private float timeLine;
    public GameObject player;
    private float windSpeed = 0.035f;

    private void Update()
    {
        timeLine += Time.deltaTime;
        GameObject[] allEnnemys = GameObject.FindGameObjectsWithTag("Ennemy");

        for (int i = 0; i < allEnnemys.Length; i++)
        {
            if (allEnnemys[i].transform.position.x - player.transform.position.x > 0)
                allEnnemys[i].transform.position = new Vector3(allEnnemys[i].transform.position.x + windSpeed, allEnnemys[i].transform.position.y);
            else
                allEnnemys[i].transform.position = new Vector3(allEnnemys[i].transform.position.x - windSpeed, allEnnemys[i].transform.position.y);

            if (allEnnemys[i].transform.position.y - player.transform.position.y > 0)
                allEnnemys[i].transform.position = new Vector3(allEnnemys[i].transform.position.x, allEnnemys[i].transform.position.y + windSpeed);
            else
                allEnnemys[i].transform.position = new Vector3(allEnnemys[i].transform.position.x, allEnnemys[i].transform.position.y - windSpeed);
        }

        if (timeLine > 3)
        {
            timeLine = 0;
            this.gameObject.SetActive(false);
        }
    }
}
