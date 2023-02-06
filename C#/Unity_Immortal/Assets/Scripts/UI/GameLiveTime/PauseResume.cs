using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject imgPause;
    public GameObject imgResume;
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        imgPause.SetActive(false);
        imgResume.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        imgPause.SetActive(true);
        imgResume.SetActive(false);
    }
}
