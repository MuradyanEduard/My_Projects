using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public GameObject player;
    public GameObject upgradePanel;
    public void OnHealthOneClick()
    {
        player.GetComponent<PlayerLogic>().health++;

        if (player.GetComponent<PlayerLogic>().health > 6)
            player.GetComponent<PlayerLogic>().health = 6;

        player.GetComponent<PlayerLogic>().healthSlider.value = player.GetComponent<PlayerLogic>().health;

        Time.timeScale = 1;
        upgradePanel.gameObject.SetActive(false);
    }

    public void OnHealthHalfClick()
    {
        player.GetComponent<PlayerLogic>().health += 3;

        if (player.GetComponent<PlayerLogic>().health > 6)
            player.GetComponent<PlayerLogic>().health = 6;

        player.GetComponent<PlayerLogic>().healthSlider.value = player.GetComponent<PlayerLogic>().health;

        Time.timeScale = 1;
        upgradePanel.gameObject.SetActive(false);
    }

    public void OnHealthFullClick()
    {
        //player.GetComponent<PlayerLogic>().health++;

        player.GetComponent<PlayerLogic>().health = 6;
        player.GetComponent<PlayerLogic>().healthSlider.value = 6;

        Time.timeScale = 1;
        upgradePanel.gameObject.SetActive(false);
    }

}