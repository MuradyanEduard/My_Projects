using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRender : MonoBehaviour
{
    public GameObject grid;
    public GameObject[] ground;
    public GameObject[] leftGround;
    public GameObject[] rightGround;
    public GameObject water;

    public Sprite[] floatSprites;
    public GameObject floatItems;
    public GameObject floatItemsPos;

    public GameObject borderLeft;
    public GameObject borderRight;

    private List<List<GameObject>> mapGmList = new List<List<GameObject>>();

    private float size = 1.8f;
    void Start()
    {
        for (int i = 0; i < ground.Length; i++)
            ground[i].transform.localScale = new Vector3(0.5f, 0.5f);

        for (int i = 0; i < leftGround.Length; i++)
            leftGround[i].transform.localScale = new Vector3(0.5f, 0.5f);

        for (int i = 0; i < rightGround.Length; i++)
            rightGround[i].transform.localScale = new Vector3(0.5f, 0.5f);

        water.transform.localScale = new Vector3(0.5f, 0.5f);
        size = size * 0.5f;

        MapGenerate();
    }

    public void MapGenerate()
    {
        currentRow = 0;
        cond = new Vector2(0, 0);
        mapGmList.Clear();


        foreach (Transform child in grid.transform)
        {
            Destroy(child.gameObject);
        }

        borderLeft.transform.position = new Vector3(Camera.main.transform.position.x - 14.24f, Camera.main.transform.position.y);
        borderRight.transform.position = new Vector3(Camera.main.transform.position.x + 14.24f, Camera.main.transform.position.y);

        float StartPos = 3f;
        for (int i = 0; i < 5; i++)
        {
            CreateWaterObjects(StartPos, 0);
            StartPos += 4f;
        }


        for (int j = -19; j < 20; j++)
        {
            mapGmList.Add(new List<GameObject>());

            for (int i = -19; i < 20; i++)
            {
                int randNum = UnityEngine.Random.Range(0, 6);
                Vector2 pos = new Vector2(Camera.main.transform.position.x + i * size, Camera.main.transform.position.y + j * size);

                if (i == -15)
                {
                    mapGmList[j + 19].Add(Instantiate(leftGround[randNum % leftGround.Length], pos, leftGround[randNum % leftGround.Length].transform.rotation, grid.transform));
                }
                else if (i == 15)
                {
                    mapGmList[j + 19].Add(Instantiate(rightGround[randNum % rightGround.Length], pos, rightGround[randNum % rightGround.Length].transform.rotation, grid.transform));
                }
                else if (i < -15 || i > 15)
                    mapGmList[j + 19].Add(Instantiate(water, pos, water.transform.rotation, grid.transform));
                else
                {
                    mapGmList[j + 19].Add(Instantiate(ground[randNum % ground.Length], pos, ground[randNum % ground.Length].transform.rotation, grid.transform));
                }
            }
        }

    }
    //CreateLeave
    public void CreateWaterObjects(float interval, int cond)
    {
        floatItems.GetComponent<SpriteRenderer>().sprite = floatSprites[UnityEngine.Random.Range(0, floatSprites.Length)];

        switch (cond)
        {
            case 0:
                Instantiate(floatItems, new Vector3(floatItemsPos.transform.position.x + ((float)(UnityEngine.Random.Range(-14, 14)) / 10),
                    floatItemsPos.transform.position.y + interval), floatItems.transform.rotation, grid.transform);

                Instantiate(floatItems, new Vector3(-1 * (floatItemsPos.transform.position.x + ((float)(UnityEngine.Random.Range(-14, 14)) / 10)),
                    floatItemsPos.transform.position.y + interval), floatItems.transform.rotation, grid.transform);
                break;
            case 1:
                Instantiate(floatItems, new Vector3(floatItemsPos.transform.position.x + ((float)(UnityEngine.Random.Range(-14, 14)) / 10),
                    floatItemsPos.transform.position.y + interval), floatItems.transform.rotation, grid.transform);
                break;
            case 2:
                Instantiate(floatItems, new Vector3(-1 * (floatItemsPos.transform.position.x + ((float)(UnityEngine.Random.Range(-14, 14)) / 10)),
                    floatItemsPos.transform.position.y + interval), floatItems.transform.rotation, grid.transform);
                break;
        }
    }



    private Vector2 cond = new Vector2(0, 0);
    private int currentRow = 0;

    void Update()
    {
        PlayerPrefs.SetFloat("AdvTime",PlayerPrefs.GetFloat("AdvTime", 0)+Time.deltaTime);

        int index = 1;
        if (Math.Abs(Camera.main.transform.position.y - cond.y) > size)
        {

            if (Camera.main.transform.position.y - cond.y < 0)
            {
                currentRow--;
                index = -1;
            }

            if (currentRow < 0)
                currentRow = mapGmList.Count - 1;

            if (currentRow > mapGmList.Count - 1)
                currentRow = 0;

            for (int j = 0; j < mapGmList[currentRow].Count; j++)
                mapGmList[currentRow][j].transform.position = new Vector3(mapGmList[currentRow][j].transform.position.x, mapGmList[currentRow][j].transform.position.y + (mapGmList.Count * size * index));

            if (Camera.main.transform.position.y - cond.y > 0)
            {
                index = 1;
                currentRow++;
            }

            cond = new Vector2(cond.x, cond.y + (size * index));
        }
    }

}
