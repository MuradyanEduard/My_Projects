using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject spawnPos;
    public void OnWindClick()
    {
        spawnPos.SetActive(true);
        Time.timeScale = 1;
        upgradePanel.SetActive(false);
    }

}
