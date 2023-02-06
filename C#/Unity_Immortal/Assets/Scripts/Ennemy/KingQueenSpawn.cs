using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingQueenSpawn : MonoBehaviour
{
    public GameObject grid;
    public GameObject player;
    public GameObject king;
    public GameObject kingGuard;
    public GameObject queen;
    public GameObject queenGuard;
    public float timeSpawn = 15f;

    private float distance = 7.5f;
    private float timeNow = 3f;
    private float size = 2 * 0.124f;

    private void Start()
    {
        size = size * 2;
    }

    void Update()
    {
        timeNow += Time.deltaTime;

        if (timeNow > timeSpawn)
        {
            timeNow = 0;

            for (int i = 0; i < 4; i++)
            {
                Instantiate(kingGuard, new Vector3(this.transform.position.x, this.transform.position.y - size), this.transform.rotation, grid.transform);
            }
            Instantiate(king, new Vector3(this.transform.position.x, this.transform.position.y), this.transform.rotation, grid.transform);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(kingGuard, new Vector3(this.transform.position.x, this.transform.position.y + size), this.transform.rotation, grid.transform);
            }
            Instantiate(kingGuard, new Vector3(this.transform.position.x - size, this.transform.position.y), this.transform.rotation, grid.transform);
            Instantiate(kingGuard, new Vector3(this.transform.position.x + size, this.transform.position.y), this.transform.rotation, grid.transform);

            for (int i = 0; i < 4; i++)
            {
                Instantiate(queenGuard, new Vector3(this.transform.position.x, this.transform.position.y - size - (2 * distance)), this.transform.rotation, grid.transform);
            }
            Instantiate(queen, new Vector3(this.transform.position.x, this.transform.position.y - (2 * distance)), this.transform.rotation, grid.transform);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(queenGuard, new Vector3(this.transform.position.x, this.transform.position.y + size - (2 * distance)), this.transform.rotation, grid.transform);
            }
            Instantiate(queenGuard, new Vector3(this.transform.position.x - size, this.transform.position.y - (2 * distance)), this.transform.rotation, grid.transform);
            Instantiate(queenGuard, new Vector3(this.transform.position.x + size, this.transform.position.y - (2 * distance)), this.transform.rotation, grid.transform);
        }
    }
}