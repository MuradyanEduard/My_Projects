using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLogic : MonoBehaviour
{
    private float timeLine = 0f;
    public GameObject patron;
    public GameObject grid;
    private Vector3[] pos = new Vector3[8];

    bool move = false;
    static bool[] freePos = new bool[8] 
    {false, false , false , false , false , false , false , false };

    private float dstn = 1.2f;    
    private float moveTimeLine = 0;
    private int posNom;
    void Start()
    {
        posNom = GetFreePos();
        freePos[posNom] = true;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

        pos[0] = new Vector3(player.transform.position.x - dstn, player.transform.position.y + dstn);
        pos[1] = new Vector3(player.transform.position.x, player.transform.position.y + dstn);
        pos[2] = new Vector3(player.transform.position.x + dstn, player.transform.position.y + dstn);
        pos[3] = new Vector3(player.transform.position.x + dstn, player.transform.position.y);
        pos[4] = new Vector3(player.transform.position.x + dstn, player.transform.position.y - dstn);
        pos[5] = new Vector3(player.transform.position.x, player.transform.position.y - dstn);
        pos[6] = new Vector3(player.transform.position.x - dstn, player.transform.position.y - dstn);
        pos[7] = new Vector3(player.transform.position.x - dstn, player.transform.position.y);

        moveTimeLine += Time.deltaTime;

        if (move)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos[posNom], 3 * Time.deltaTime);

            if (transform.position == pos[posNom])
            {
                move = false;
            }
        }

        if (moveTimeLine > 2)
        {
            int oldPos = posNom;
            freePos[posNom] = false;
            posNom = GetFreePos();
            freePos[posNom] = true;
            move = true;
            moveTimeLine = 0;

            if (pos[oldPos].x - pos[posNom].x < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180));
            }

        }

        timeLine += Time.deltaTime;

        if (timeLine > 5)
        {
            timeLine = 0;
            Instantiate(patron, this.transform.position, patron.transform.rotation);
        }
    }

    private int GetFreePos()
    {
        while (true)
        {
            posNom = Random.RandomRange(0, pos.Length);
            if (!freePos[posNom])
            {
                freePos[posNom] = true;
                return posNom;
            }
        }

    }
}
