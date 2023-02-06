using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{

    public GameObject player;
    public GameObject upgradePanel;
    public GameObject liveTimeGameUI;
    public GameObject gameOverUI;
    public Text gameOverText;

    //health
    public int health = 6;
    public Slider healthSlider;
    public int armor = 6;
    public Slider armorSlider;

    //Score
    public Text timeText;
    public Text mobText;
    public Text coinText;
    public Text bestScoreText;

    public float time = 0;
    public int mobKill = 0;

    private Animator anim;
    private float timeline = 0;
    private float hitTime = 0.7f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinText.text = (Int32.Parse(coinText.text) + 1).ToString();
            PlayerPrefs.SetInt("Coin", Int32.Parse(coinText.text));
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnPatron")
        {
            if (armor > 0)
            {
                armor--;
                armorSlider.value = armor;
            }
            else
            {
                health--;
                healthSlider.value = health;
            }

            Destroy(collision.gameObject);
            anim.Play("Hit");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health <= 0)
            return;

        if (collision.gameObject.tag == "Ennemy")
        {
            if (armor > 0)
            {
                armor--;
                armorSlider.value = armor;
            }
            else
            {
                health--;
                healthSlider.value = health;
            }

            anim.Play("Hit");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (health <= 0)
            return;

        if (collision.gameObject.tag == "Ennemy")
        {

            timeline += Time.deltaTime;
            if (timeline > hitTime)
            {
                if (armor > 0)
                {
                    armor--;
                    armorSlider.value = armor;
                }
                else
                {
                    health--;
                    healthSlider.value = health;
                }

                timeline = 0;
                anim.Play("Hit");
            }
        }
    }

    void Start()
    {
        player.layer = LayerMask.NameToLayer("Ignore Raycast");
        anim = player.GetComponent<Animator>();
    }

    private float deadTime = 0;

    void Update()
    {

        if (health <= 0)
        {
            if (deadTime < 1.5)
            {
                deadTime += Time.deltaTime;
                if (deadTime <= 0.2)
                    anim.Play("Die");
            }
            else
            {
                deadTime = 0;
                Time.timeScale = 0;
                int highScore = PlayerPrefs.GetInt("HighScore");


                if (mobKill > highScore)
                {
                    PlayerPrefs.SetInt("HighScore", (int)mobKill);
                    PlayerPrefs.Save();
                    gameOverText.text = "YOUR SCORE\n" + (int)mobKill;
                    bestScoreText.text = "NEW RECORD\n" + (int)mobKill;
                }
                else
                {
                    bestScoreText.text = "RECORD\n" + (int)highScore;
                    gameOverText.text = "YOUR SCORE\n" + (int)mobKill;
                }

                liveTimeGameUI.SetActive(false);
                upgradePanel.SetActive(false);
                gameOverUI.SetActive(true);
                player.GetComponent<PlayerMovment>().timeFBSpawn = 1;

            }
        }

        time += Time.deltaTime;

        int minute = (int)(time / 60);
        int sec = (int)(time % 60);

        timeText.text = (minute < 10 ? "0" + minute : minute) + ":" + (sec < 10 ? "0" + sec : sec);
        mobText.text = "MOB: " + mobKill;

    }
}