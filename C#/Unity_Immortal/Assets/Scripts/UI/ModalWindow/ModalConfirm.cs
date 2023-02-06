using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalConfirm : MonoBehaviour
{
    public GameObject modalForm;
    public GameObject buyModal;
    public GameObject infoModal;

    public GameObject nomObjPlayer;
    public GameObject nomObjMap;
    public Text coinText;
    public bool cond;

    public void OnModalConfirmClick() 
    {
        if (cond)
        {
            PlayerUnlock();
        }
        else 
        {
            MapUnlock();
        }

        modalForm.SetActive(false);
        buyModal.SetActive(false);
    }

    public bool CkeckPlayerUnlock() 
    {
        switch (Mathf.Abs(nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().GetCurrentHeroNum()) % 4)
        {
            case 1:
                if (PlayerPrefs.GetInt("Coin") <= 10000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("Coin") <= 20000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Coin") <= 30000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }
                break;
        }

        return true;
    }
    public bool CheckMapUnlock()
    {
        switch (Mathf.Abs(nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().GetCurrentHeroNum()) % 4)
        {
            case 1:
                if (PlayerPrefs.GetInt("Coin") <= 10000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("Coin") <= 20000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Coin") <= 30000)
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                    return false;
                }
                break;
        }
        return true;

    }
    public void PlayerUnlock() 
    {
        switch (Mathf.Abs(nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().GetCurrentHeroNum()) % 4)
        {
            case 1:
                if (PlayerPrefs.GetInt("Coin") >= 10000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 10000);
                    PlayerPrefs.SetInt("Player1", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 10000).ToString();
                    nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().AnimatorChange();
                }
                else { 
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("Coin") >= 20000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 20000);
                    PlayerPrefs.SetInt("Player2", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 20000).ToString();
                    nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().AnimatorChange();
                }
                else
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Coin") >= 30000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 30000);
                    PlayerPrefs.SetInt("Player3", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 30000).ToString();
                    nomObjPlayer.GetComponent<LeftRightArrowsPlayer>().AnimatorChange();
                }
                else
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }
                break;
        }

    }

    public void MapUnlock()
    {
        switch (Mathf.Abs(nomObjMap.GetComponent<LeftRightArrowsMap>().GetMapType()) % 4)
        {
            case 1:
                if (PlayerPrefs.GetInt("Coin") >= 10000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 10000);
                    PlayerPrefs.SetInt("Map1", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 10000).ToString();
                    nomObjMap.GetComponent<LeftRightArrowsMap>().OnMapChange();
                }
                else
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }

                break;
            case 2:
                if (PlayerPrefs.GetInt("Coin") >= 20000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 20000);
                    PlayerPrefs.SetInt("Map2", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 20000).ToString();
                    nomObjMap.GetComponent<LeftRightArrowsMap>().OnMapChange();
                }
                else
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("Coin") >= 30000)
                {
                    PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") - 30000);
                    PlayerPrefs.SetInt("Map3", 1);
                    PlayerPrefs.Save();
                    coinText.text = (Int32.Parse(coinText.text) - 30000).ToString();
                    nomObjMap.GetComponent<LeftRightArrowsMap>().OnMapChange();
                }
                else
                {
                    infoModal.SetActive(true);
                    buyModal.SetActive(false);
                }
                break;

        }

    }

}
