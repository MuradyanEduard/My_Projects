using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suriken : MonoBehaviour
{

    public GameObject upgradePanel;
    public GameObject suriken;
    public GameObject surikenPos;
    public Slider lvlSlider;

    public void OnSurikenClick()
    {

        if (upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[3] >= 3)
            return;

        upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[3]++;
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

        Instantiate(suriken, surikenPos.transform.position, player.transform.rotation, surikenPos.transform);

        int count = 360 / surikenPos.transform.childCount;
        float angle = 0;
        foreach (Transform child in surikenPos.transform)
        {
            child.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            angle += count;
        }

        lvlSlider.value = upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[3];
        Time.timeScale = 1;
        upgradePanel.SetActive(false);

    }
}