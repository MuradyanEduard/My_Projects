using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCond : MonoBehaviour
{
    public GameObject MusicOnImg;
    public GameObject MusicOffImg;
    
    private static bool cond = false;

    public  void OnMusicClick()
    {
        if (cond)
        {
            MusicOnImg.SetActive(true);
            MusicOffImg.SetActive(false);
            Camera.main.GetComponent<AudioSource>().mute = false;
            cond = !cond;
        }
        else 
        {
            MusicOnImg.SetActive(false);
            MusicOffImg.SetActive(true);
            Camera.main.GetComponent<AudioSource>().mute = true;
            cond = !cond;
        }
    }

    private void Start()
    {
        if (cond)
        {
            MusicOnImg.SetActive(false);
            MusicOffImg.SetActive(true);
            Camera.main.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            MusicOnImg.SetActive(true);
            MusicOffImg.SetActive(false);
            Camera.main.GetComponent<AudioSource>().mute = false;
        }
    }
}
