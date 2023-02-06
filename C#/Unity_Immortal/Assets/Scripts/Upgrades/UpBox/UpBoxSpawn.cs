using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBoxSpawn : MonoBehaviour
{
    public float timeLine = 0;
    public GameObject box;
    public GameObject grid;
    // Update is called once per frame
    void Update()
    {
        timeLine += Time.deltaTime;
        if (timeLine > 15)
        {
            timeLine = 0;
            Instantiate(box,transform.position,transform.rotation, grid.transform);
        }
    }
}
