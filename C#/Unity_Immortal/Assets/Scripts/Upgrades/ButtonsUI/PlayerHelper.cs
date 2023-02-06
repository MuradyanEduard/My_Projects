using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHelper : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject playerHelper;
    public GameObject playerHelperPos;
    public Slider lvlSlider;

    public void OnPlayerHelper()
    {
        if (upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[6] >= 3)
            return;

        upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[6]++;
        Instantiate(playerHelper, new Vector3(playerHelperPos.transform.position.x, playerHelperPos.transform.position.y), playerHelper.transform.rotation, playerHelperPos.transform);
        lvlSlider.value = upgradePanel.GetComponent<UpgradeGeneration>().upgradesLvl[6];
        Time.timeScale = 1;
        upgradePanel.SetActive(false);
    }
}
