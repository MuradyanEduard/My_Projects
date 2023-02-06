using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class EnnemyLogic : MonoBehaviour
{
    public int health = 10;
    public Slider healthBar;
    public GameObject coin;
    public GameObject fireBallEn;
    public float speed = 3f;
    public bool isFire = false;

    private GameObject grid;
    private GameObject player;
    private float timeline = 0;
    private float hitTime = 2f;
    private float fireTime = 0;


    private void OnCollisionStay2D(Collision2D collision)
    {
        timeline += Time.deltaTime;

        if (collision.gameObject.tag == "BorderTop")
        {
            if (timeline > hitTime)
            {
                timeline = 0;
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, player.gameObject.transform.position.y - 20);
            }
        }

        if (collision.gameObject.tag == "BorderBottom")
        {
            if (timeline > hitTime)
            {
                timeline = 0;
                this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, player.gameObject.transform.position.y + 20);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        timeline = 0;
    }
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        grid = GameObject.FindGameObjectsWithTag("Grid")[0];
        cond = -1;
    }

    // Update is called once per frame
    int cond = 1;
    void Update()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerLogic>().mobKill++;
            GameObject.FindGameObjectsWithTag("DieSong")[0].GetComponent<AudioSource>().time = 0;
            GameObject.FindGameObjectsWithTag("DieSong")[0].GetComponent<AudioSource>().Play();
            Instantiate(coin, this.gameObject.transform.position, coin.transform.rotation, grid.transform);
            Destroy(this.gameObject);
        }

        float index = transform.position.x - player.transform.position.x;
        if (index < 0 && cond > 0)
        {
            this.gameObject.transform.Rotate(0, -180, 0);
            cond = -1;
        }
        else if (index > 0 && cond < 0)
        {
            this.gameObject.transform.Rotate(0, 180, 0);
            cond = 1;
        }


        if (isFire)
        {
            fireTime += Time.deltaTime;

            if (fireTime > 4.5f)
            {
                fireTime = 0;
                Vector2 direction = new Vector2(player.transform.position.x - transform.position.x,
                    player.transform.position.y - transform.position.y);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Instantiate(fireBallEn, transform.position, Quaternion.AngleAxis(angle, Vector3.forward), grid.transform);

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}