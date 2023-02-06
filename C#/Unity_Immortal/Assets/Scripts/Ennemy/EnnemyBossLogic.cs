using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyBossLogic : MonoBehaviour
{
    public float speed = 3f;
    public GameObject fireBallEn;
    public bool isFire = false;
    public int health = 10;
    public Slider healthBar;

    private GameObject grid;
    private GameObject player;
    private float timeline = 0;
    private float hitTime = 0.4f;
    private float fireTime = 0;

    private void OnDestroy()
    {
        GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerLogic>().mobKill++;
        GameObject.FindGameObjectsWithTag("DieSong")[0].GetComponent<AudioSource>().time = 0;
        GameObject.FindGameObjectsWithTag("DieSong")[0].GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ennemy" && collision.gameObject.tag != "EnPatron")
        {
            health--;
            healthBar.value--;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag != "Ennemy" && collision.gameObject.tag != "EnPatron")
        {

            timeline += Time.deltaTime;
            if (timeline > hitTime)
            {
                health--;
                healthBar.value--;
                timeline = 0;

                if (health == 0)
                {
                    Destroy(this.gameObject);
                }
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

        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    int cond = 1;
    void Update()
    {
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

            if (fireTime > 3)
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
