using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnnemySpawn : MonoBehaviour
{
    public GameObject grid;
    public GameObject player;
    public GameObject Ennemy;
    public float timeSpawn = 4f;

    private float distance = 7.5f;
    private float timeNow = 3f;

    void Update()
    {
        timeNow += Time.deltaTime;

        if (timeNow > timeSpawn)
        {
            timeNow = 0;

            if (Mathf.Abs(transform.position.x) < 14.24)
            {
                Instantiate(Ennemy, new Vector3(this.transform.position.x, this.transform.position.y - (2*distance)), this.transform.rotation,grid.transform);
                Instantiate(Ennemy, new Vector3(this.transform.position.x, this.transform.position.y), this.transform.rotation,grid.transform);
            }
        }
    }

}
