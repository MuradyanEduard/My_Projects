using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class X2Up : MonoBehaviour
{
    public GameObject player;
    public GameObject upgradePanel;
    public Slider lvlSlider;

    public void OnX2Click()
    {
        if (upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[0] >= 3)
            return;

        upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[0]++;
        player.GetComponent<PlayerMovment>().count++;
        lvlSlider.value = upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[0];
        Time.timeScale = 1;
        upgradePanel.SetActive(false);
    }
}
