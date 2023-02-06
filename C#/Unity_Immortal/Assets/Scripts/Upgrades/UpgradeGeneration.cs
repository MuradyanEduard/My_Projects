using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeGeneration : MonoBehaviour
{
    public GameObject[] upgradePos;
    public GameObject[] upgrades;
    public GameObject wind;
    public int[] upgradesLvl;
    public void GenerateUpgrades()
    {
        int len = 0;
        GameObject[] newUpgrades = new GameObject[upgrades.Length];
        wind.SetActive(false);

        for (int i = 0; i < upgrades.Length; i++) {
                upgrades[i].SetActive(false);
        }

        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgradesLvl[i] >= 3)
                continue;

            if (i == 7){
                newUpgrades[len] = upgrades[i + Random.RandomRange(0, 3)];
                len++;
                break;
            }
            else {
                newUpgrades[len] = upgrades[i];
                len++;
            }

        }


        for (int i= 0; i < 3;i++)
        {
            int randNum = Random.RandomRange(0, len);

            newUpgrades[randNum].SetActive(true);
            newUpgrades[randNum].transform.position = upgradePos[i].transform.position;

            GameObject ptrn = newUpgrades[randNum];
            newUpgrades[randNum] = newUpgrades[len-1];
            newUpgrades[len - 1] = ptrn;

            len--;
        }

    }

    public GameObject[] advUpgradePos;
    public GameObject[] advUpgrades;
    public GameObject advUpgradesPanel;

    public void AdvGenerateUpgrades()
    {

        if (advUpgrades[0].active == false && advUpgrades[1].active == false)
            advUpgradesPanel.SetActive(false);

        if (advUpgrades[0].active == false)
        {
            advUpgrades[1].transform.position = advUpgradePos[2].transform.position;
        }
        else if (advUpgrades[1].active == false)
        {
            advUpgrades[0].transform.position = advUpgradePos[2].transform.position;
        }
        else
        {
            advUpgrades[0].transform.position = advUpgradePos[0].transform.position;
            advUpgrades[1].transform.position = advUpgradePos[1].transform.position;
        }

    }
}
