using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.Rendering.Universal;

public class LeftRightArrowsMap : MonoBehaviour
{
    public GameObject[] summerGround;
    public GameObject[] summerLeftGround;
    public GameObject[] summerRightGround;
    public GameObject summerWater;
    public Sprite[] shipSprites;
    public GameObject ship;

    public GameObject[] outmnGround;
    public GameObject[] outmnLeftGround;
    public GameObject[] outmnRightGround;
    public GameObject outmnWater;
    public Sprite[] leavesSprites;
    public GameObject leave;

    public GameObject[] winterGround;
    public GameObject[] winterLeftGround;
    public GameObject[] winterRightGround;
    public GameObject winterWater;
    public Sprite[] iceCubSprites;
    public GameObject iceCub;

    public GameObject[] nightGround;
    public GameObject[] nightLeftGround;
    public GameObject[] nightRightGround;
    public GameObject nightWater;
    public GameObject nightShip;

    static int mapType = 0;

    public GameObject unlockObj;
    public bool unlock = false;
    public Text unlockText;

    public GameObject mapImg;
    public Sprite[] mapSptites;

    public GameObject Rain;
    public GameObject Snow;

    public GameObject[] lightObjects;
    public GameObject globalLight;
    public GameObject playerLight;
    public void OnLeftClick()
    {
        if (mapType == 0)
            mapType += mapSptites.Length;

        mapType--;
        OnMapChange();
    }

    public void OnRightClick()
    {
        mapType++;
        OnMapChange();
    }

    public void OnMapChange()
    {
        for (int i = 0; i < lightObjects.Length; i++)
        {
            lightObjects[i].transform.GetChild(0).GetComponent<Light2D>().intensity = 0;
        }

        globalLight.GetComponent<Light2D>().intensity = 1;
        playerLight.SetActive(false);

        if (PlayerPrefs.GetInt("Map" + (Mathf.Abs(mapType) % mapSptites.Length)) == 1)
            unlockObj.SetActive(false);
        else
            unlockObj.SetActive(true);

        mapImg.GetComponent<Image>().sprite = mapSptites[Math.Abs(mapType) % mapSptites.Length];

        switch (Math.Abs(mapType) % mapSptites.Length)
        {
            case 1:
                unlockText.text = 10000.ToString();
                break;
            case 2:
                unlockText.text = 20000.ToString();
                break;
            case 3:
                unlockText.text = 30000.ToString();
                break;
        }

        switch (Mathf.Abs(mapType) % mapSptites.Length)
        {
            case 0:
                Rain.SetActive(false);
                Snow.SetActive(false);

                Camera.main.GetComponent<MapRender>().ground = new GameObject[summerGround.Length];

                for (int i = 0; i < summerGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().ground[i] = summerGround[i];

                Camera.main.GetComponent<MapRender>().leftGround = new GameObject[summerLeftGround.Length];

                for (int i = 0; i < summerLeftGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().leftGround[i] = summerLeftGround[i];

                Camera.main.GetComponent<MapRender>().rightGround = new GameObject[summerRightGround.Length];

                for (int i = 0; i < summerRightGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().rightGround[i] = summerRightGround[i];

                Camera.main.GetComponent<MapRender>().water = summerWater;

                Camera.main.GetComponent<MapRender>().floatSprites = new Sprite[shipSprites.Length];

                for (int i = 0; i < shipSprites.Length; i++)
                    Camera.main.GetComponent<MapRender>().floatSprites[i] = shipSprites[i];

                Camera.main.GetComponent<MapRender>().floatItems = ship;
                break;
            case 1:
                Rain.SetActive(true);
                Snow.SetActive(false);

                Camera.main.GetComponent<MapRender>().ground = new GameObject[outmnGround.Length];

                for (int i = 0; i < outmnGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().ground[i] = outmnGround[i];

                Camera.main.GetComponent<MapRender>().leftGround = new GameObject[outmnLeftGround.Length];

                for (int i = 0; i < outmnLeftGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().leftGround[i] = outmnLeftGround[i];

                Camera.main.GetComponent<MapRender>().rightGround = new GameObject[outmnRightGround.Length];

                for (int i = 0; i < outmnRightGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().rightGround[i] = outmnRightGround[i];

                Camera.main.GetComponent<MapRender>().water = outmnWater;

                Camera.main.GetComponent<MapRender>().floatSprites = new Sprite[leavesSprites.Length];

                for (int i = 0; i < leavesSprites.Length; i++)
                    Camera.main.GetComponent<MapRender>().floatSprites[i] = leavesSprites[i];

                Camera.main.GetComponent<MapRender>().floatItems = leave;
                break;
            case 2:
                Rain.SetActive(false);
                Snow.SetActive(true);

                Camera.main.GetComponent<MapRender>().ground = new GameObject[winterGround.Length];

                for (int i = 0; i < winterGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().ground[i] = winterGround[i];

                Camera.main.GetComponent<MapRender>().leftGround = new GameObject[winterLeftGround.Length];

                for (int i = 0; i < winterLeftGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().leftGround[i] = winterLeftGround[i];

                Camera.main.GetComponent<MapRender>().rightGround = new GameObject[winterRightGround.Length];

                for (int i = 0; i < winterRightGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().rightGround[i] = winterRightGround[i];

                Camera.main.GetComponent<MapRender>().water = winterWater;

                Camera.main.GetComponent<MapRender>().floatSprites = new Sprite[iceCubSprites.Length];

                for (int i = 0; i < iceCubSprites.Length; i++)
                    Camera.main.GetComponent<MapRender>().floatSprites[i] = iceCubSprites[i];

                Camera.main.GetComponent<MapRender>().floatItems = iceCub;
                break;
            case 3:
                Rain.SetActive(false);
                Snow.SetActive(false);

                for (int i = 0; i < lightObjects.Length; i++)
                {
                    lightObjects[i].transform.GetChild(0).GetComponent<Light2D>().intensity = 0.7f;
                }

                globalLight.GetComponent<Light2D>().intensity = 0.3f;

                Camera.main.GetComponent<MapRender>().ground = new GameObject[nightGround.Length];

                for (int i = 0; i < nightGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().ground[i] = nightGround[i];

                Camera.main.GetComponent<MapRender>().leftGround = new GameObject[nightLeftGround.Length];

                for (int i = 0; i < nightLeftGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().leftGround[i] = nightLeftGround[i];

                Camera.main.GetComponent<MapRender>().rightGround = new GameObject[nightRightGround.Length];

                for (int i = 0; i < nightRightGround.Length; i++)
                    Camera.main.GetComponent<MapRender>().rightGround[i] = nightRightGround[i];

                Camera.main.GetComponent<MapRender>().water = nightWater;

                Camera.main.GetComponent<MapRender>().floatSprites = new Sprite[shipSprites.Length];

                for (int i = 0; i < shipSprites.Length; i++)
                    Camera.main.GetComponent<MapRender>().floatSprites[i] = shipSprites[i];

                Camera.main.GetComponent<MapRender>().floatItems = nightShip;
                playerLight.SetActive(true);
                break;

        }

        Camera.main.GetComponent<MapRender>().MapGenerate();

    }

    public int GetMapType()
    {
        return mapType;
    }

    public void SetMapType(int nom)
    {
        mapType = nom;
    }


}