using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject player;
    public GameObject liveTimeGameUI;
    public GameObject[] DisapearObj;
    public GameObject spawnController;
    public GameObject spawnPointers;
    public GameObject spawnBox;
    public GameObject arrowMap;
    public GameObject arrowPlayer;

    public GameObject inputTxt;
    public GameObject playerLight;
    public GameObject infoCanvas;

    public Text highScore;
    public Text coins;
    public Text playerText;

    private float[] duration = { 0.15f, 0.3f, 0.45f, 0.6f, 0.75f, 0.9f, 1.05f, 1.2f, 1.4f };
    private float time = 0;
    private int speed = 1500;
    private bool cond = false;

    private void Start()
    {
        FirstInitPrefs();

        inputTxt.GetComponent<InputField>().text = PlayerPrefs.GetString("PlayerNickName");


        arrowMap.GetComponent<LeftRightArrowsMap>().SetMapType(0);
        arrowMap.GetComponent<LeftRightArrowsMap>().OnMapChange();
        arrowPlayer.GetComponent<LeftRightArrowsPlayer>().SetCurrentHeroNum(0);
        arrowPlayer.GetComponent<LeftRightArrowsPlayer>().AnimatorChange();

        Time.timeScale = 1;
        highScore.text = "RECORD: " + PlayerPrefs.GetInt("HighScore");
        coins.text = "" + PlayerPrefs.GetInt("Coin");

        playerLight.GetComponent<Light2D>().pointLightInnerRadius = 0f;
        playerLight.GetComponent<Light2D>().pointLightOuterRadius = 0f;

    }

    public GameObject mapUnlcok;
    public GameObject playerUnlcok;
    public void OnPlayClick()
    {
        if (mapUnlcok.active == true || playerUnlcok.active == true)
        {
            return;
        }

        cond = true;
        liveTimeGameUI.SetActive(true);

        infoCanvas.SetActive(true);
        PlayerPrefs.SetString("PlayerNickName", playerText.text);
        inputTxt.SetActive(false);
        playerText.gameObject.SetActive(true);
        spawnController.SetActive(true);
        spawnPointers.SetActive(true);
        spawnBox.SetActive(true);

        player.GetComponent<PlayerLogic>().enabled = true;
        player.GetComponent<PlayerMovment>().enabled = true;
        player.GetComponent<PlayerLogic>().coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        player.GetComponent<PlayerLogic>().mobKill = 0;
        player.GetComponent<PlayerLogic>().health = 6;
        player.GetComponent<PlayerLogic>().healthSlider.maxValue = 6;
        player.GetComponent<PlayerLogic>().healthSlider.value = 6;
        player.GetComponent<PlayerLogic>().armor = 0;
        player.GetComponent<PlayerLogic>().armorSlider.maxValue = 6;
        player.GetComponent<PlayerLogic>().armorSlider.value = 0;
        player.GetComponent<PlayerLogic>().time = 0;
        player.GetComponent<PlayerMovment>().fbSpeed = 0.5f;
        player.GetComponent<PlayerMovment>().count = 1;
        player.GetComponent<PlayerMovment>().timeline = 0;

    }

    private void Update()
    {

        if (cond)
        {
            if (playerLight.GetComponent<Light2D>().pointLightOuterRadius < 4)
            {
                playerLight.GetComponent<Light2D>().pointLightOuterRadius += 0.025f;

                if (playerLight.GetComponent<Light2D>().pointLightOuterRadius > 2)
                    playerLight.GetComponent<Light2D>().pointLightInnerRadius += 0.025f;

            }

            time = time + Time.deltaTime;
            for (int i = 0; i < DisapearObj.Length; i++)
            {
                if (duration[i] < time)
                {
                    DisapearObj[i].gameObject.transform.position = new Vector2(DisapearObj[i].transform.position.x + speed * Time.deltaTime, DisapearObj[i].transform.position.y);
                }
            }

            if (time > 4)
            {
                cond = false;
                this.gameObject.SetActive(false);
            }

            if (Camera.main.orthographicSize < 8f)
                Camera.main.orthographicSize += 0.05f;
        }


    }

    private void FirstInitPrefs()
    {
        if (PlayerPrefs.GetFloat("AdvTime", 0) == 0)
        {
            PlayerPrefs.SetFloat("AdvTime", 0);
            PlayerPrefs.Save();
        }


        if (PlayerPrefs.GetInt("Map0", 1) == 1)
        {
            PlayerPrefs.SetInt("Map0", 1);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("Player0", 1) == 1)
        {
            PlayerPrefs.SetInt("Player0", 1);
            PlayerPrefs.Save();
        }

        for (int i = 1; i < 4; i++)
        {
            if (PlayerPrefs.GetInt("Map" + i, 0) == 0)
            {
                PlayerPrefs.SetInt("Map" + i, 0);
                PlayerPrefs.Save();
            }
        }

        for (int i = 1; i < 4; i++)
        {
            if (PlayerPrefs.GetInt("Player" + i, 0) == 0)
            {
                PlayerPrefs.SetInt("Player" + i, 0);
                PlayerPrefs.Save();
            }
        }

        if (PlayerPrefs.GetInt("Coin", 0) == 0)
        {
            PlayerPrefs.SetInt("Coin", 0);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("HighScore", 0) == 0)
        {
            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetString("PlayerNickName", "") == "")
        {
            PlayerPrefs.SetString("PlayerNickName", "");
            PlayerPrefs.Save();
        }

        //PlayerPrefs.SetInt("Map1", 0);
        //PlayerPrefs.SetInt("Coin", 100000);

    }
}