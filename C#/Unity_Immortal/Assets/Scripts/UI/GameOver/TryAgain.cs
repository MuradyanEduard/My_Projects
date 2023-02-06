using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    public GameObject grid;
    public GameObject player;
    public GameObject playerComponents;

    public GameObject liveTimeGameUI;
    public GameObject gameOverUI;

    public GameObject surikens;
    public GameObject bird;
    public GameObject playerHelper;
    public GameObject boxUp;

    public GameObject SpawnController;
    public GameObject[] spawnPoint;

    public GameObject resumeAdv;
    public GameObject advUpgradesPanel;
    public GameObject[] advUpgrades;

    public void OnTryAgainClick()
    {
        resumeAdv.SetActive(true);
        advUpgrades[0].SetActive(true);
        advUpgrades[1].SetActive(true);
        advUpgradesPanel.SetActive(true);

        Time.timeScale = 1;
        player.GetComponent<PlayerLogic>().mobKill = 0;

        foreach (Transform child in grid.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in surikens.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in bird.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in playerHelper.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            spawnPoint[i].SetActive(false);
            switch (i) {
                case 0:
                case 2:
                case 3:
                    spawnPoint[i].GetComponent<EnnemySpawn>().timeSpawn = 4;
                    break;
                case 1:
                case 4:
                case 5:
                    spawnPoint[i].GetComponent<EnnemySpawn>().timeSpawn = 10;
                    break;
                case 6:
                    spawnPoint[i].GetComponent<KingQueenSpawn>().timeSpawn = 15;

                    break;
            }
        }

        Camera.main.transform.position = new Vector3(0, 0,Camera.main.transform.position.z);
        player.transform.position = new Vector3(0, 0);
        playerComponents.transform.position = new Vector3(0, 0);

        Camera.main.GetComponent<MapRender>().MapGenerate();

        player.GetComponent<Animator>().Play("Idle");
        player.GetComponent<PlayerLogic>().health = 6;
        player.GetComponent<PlayerLogic>().healthSlider.maxValue = 6;
        player.GetComponent<PlayerLogic>().healthSlider.value = 6;
        player.GetComponent<PlayerLogic>().armor = 0;
        player.GetComponent<PlayerLogic>().armorSlider.maxValue = 6;
        player.GetComponent<PlayerLogic>().armorSlider.value = 0;
        player.GetComponent<PlayerLogic>().time = 0;
        player.GetComponent<PlayerMovment>().fbSpeed = 0.5f;
        player.GetComponent<PlayerMovment>().timeFBSpawn = (float)(1 / player.GetComponent<PlayerMovment>().fbSpeed);
        player.GetComponent<PlayerMovment>().count = 1;
        player.GetComponent<PlayerMovment>().timeline = 0;

        boxUp.GetComponent<UpBoxSpawn>().timeLine = 0;
        SpawnController.GetComponent<SpawnController>().timeLine = 0;
        SpawnController.GetComponent<SpawnController>().nom = 0;

        liveTimeGameUI.SetActive(true);
        gameOverUI.SetActive(false);

    }
}
