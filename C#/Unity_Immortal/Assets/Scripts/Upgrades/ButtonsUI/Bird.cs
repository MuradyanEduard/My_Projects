using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject bird;
    public GameObject birdPos;
    public Slider lvlSlider;


    public void OnBirdClick()
    {

        if (upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[4] >= 3)
            return;

        upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[4]++;
        Instantiate(bird, new Vector3(birdPos.transform.position.x, birdPos.transform.position.y), bird.transform.rotation, birdPos.transform);
        lvlSlider.value = upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[4];
        Time.timeScale = 1;
        upgradePanel.SetActive(false);

    }
}