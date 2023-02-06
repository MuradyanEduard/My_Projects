using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCond : MonoBehaviour
{
    public GameObject SoundOnImg;
    public GameObject SoundOffImg;
    public GameObject[] muteObjects;
    private static bool cond = false;

    public void OnSoundClick()
    {
        if (cond)
        {
            SoundOnImg.SetActive(true);
            SoundOffImg.SetActive(false);

            for (int i = 0; i < muteObjects.Length; i++)
            {
                muteObjects[i].GetComponent<AudioSource>().mute = false;
            }
            cond = !cond;
        }
        else
        {
            SoundOnImg.SetActive(false);
            SoundOffImg.SetActive(true);

            for (int i = 0; i < muteObjects.Length; i++)
            {
                muteObjects[i].GetComponent<AudioSource>().mute = true;
            }

            cond = !cond;
        }
    }

    private void Start()
    {
        if (cond)
        {
            SoundOnImg.SetActive(false);
            SoundOffImg.SetActive(true);

            for (int i = 0; i < muteObjects.Length; i++)
            {
                muteObjects[i].GetComponent<AudioSource>().mute = true;
            }
        }
        else
        {
            SoundOnImg.SetActive(true);
            SoundOffImg.SetActive(false);

            for (int i = 0; i < muteObjects.Length; i++)
            {
                muteObjects[i].GetComponent<AudioSource>().mute = false;
            }
        }
    }
}
