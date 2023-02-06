using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnShoot : MonoBehaviour
{
    public float speed = 6f;

    private float deathTime = 7f;
    private float timeLine = 0;

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;

        timeLine += Time.deltaTime;

        if (timeLine > deathTime)
        {
            Destroy(this.gameObject);
        }
    }
}