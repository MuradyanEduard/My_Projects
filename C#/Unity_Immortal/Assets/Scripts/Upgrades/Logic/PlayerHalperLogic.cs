using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHalperLogic : MonoBehaviour
{
    public GameObject grid;

    public float timeFBSpawn;
    public float timeline = 0f;
    public float fbSpeed = 0.5f;

    public GameObject fireBall;
    private GameObject upgradePanel;
    

    private Vector3[] pos = new Vector3[8];

    bool move = false;
    public static bool[] freePos = new bool[8]
    {false, false , false , false , false , false , false , false };

    private float moveTimeLine = 0;
    private int posNom;

    private float dstn = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy" || collision.gameObject.tag == "EnPatron")
        {
            upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[6]--;
            upgradePanel.GetComponent<UpgradeGeneration>().upgrades[6].GetComponent<PlayerHelper>().lvlSlider.value =
                upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[6];
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }

    void Start()
    {
        upgradePanel =  GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerLogic>().upgradePanel;
        timeFBSpawn = (float)(1 / (float)fbSpeed);
        grid = GameObject.FindGameObjectsWithTag("Grid")[0];

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
            else {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180));
            }
        }


        timeline += Time.deltaTime;

        if (timeline > timeFBSpawn)
        {
            timeline = 0;
            Instantiate(fireBall, this.transform.position, fireBall.transform.rotation);
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
                if (posNom >= 4)
                    this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
                else
                    this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
                return posNom;
            }
        }

    }

}
