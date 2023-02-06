using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovment : MonoBehaviour
{
    public GameObject grid;
    public GameObject player;
    public GameObject playerComponents;

    //public Transform player;
    public Transform circle;
    public Transform outerCircle;
    public float speed = 5.0f;

    //borders
    public GameObject borderL;
    public GameObject borderR;

    //fireball
    public GameObject fireBall;
    public float timeFBSpawn;
    public float timeline = 0f;
    public int count = 1;
    public float fbSpeed = 0.5f; //per sec
    public GameObject laser;

    private Animator anim;
    private int currentCount = 1;
    private float currentCountTime = 0f;
    private float countTime = 0;

    private Vector2 windowSize = new Vector2(1f, 3f);
    private Vector2 direction = new Vector2(0, 0);
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        currentCountTime = 5 * Time.deltaTime;

        timeFBSpawn = (float)(1 / (float)fbSpeed);

    }

    private int rtIndex = 1;

    void Update()
    {

        if (Math.Abs(player.transform.position.y - Camera.main.transform.position.y) > windowSize.y)
        {
            if (player.transform.position.y - Camera.main.transform.position.y > 0)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + Math.Abs(direction.y) * speed * Time.deltaTime, Camera.main.transform.position.z);
            else
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - Math.Abs(direction.y) * speed * Time.deltaTime, Camera.main.transform.position.z);
        }
        if (Math.Abs(player.transform.position.x - Camera.main.transform.position.x) > windowSize.x)
        {
            if (player.transform.position.x - Camera.main.transform.position.x > 0)
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + Math.Abs(direction.x) * speed * Time.deltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
            else
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - Math.Abs(direction.x) * speed * Time.deltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

        if (player.GetComponent<PlayerLogic>().health <= 0)
        {
            touchStart = false;
            return;
        }

        playerComponents.transform.position = player.transform.position;

        if (direction.x < 0 && rtIndex == 1)
        {
            player.transform.Rotate(0, -180, 0);
            rtIndex = -1;
        }
        if (direction.x > 0 && rtIndex == -1)
        {
            player.transform.Rotate(0, 180, 0);
            rtIndex = 1;
        }
        timeline += Time.deltaTime;

        if (timeline > timeFBSpawn)
        {
            currentCountTime += Time.deltaTime;

            if (currentCountTime > countTime)
            {
                currentCountTime = 0;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Instantiate(fireBall, player.transform.position, Quaternion.AngleAxis(angle, Vector3.forward),grid.transform);
                this.gameObject.GetComponent<Animator>().Play("Fire");
                currentCount++;

                if (currentCount > count)
                {
                    timeline = 0;
                    countTime = 5 * Time.deltaTime;
                    currentCountTime = 0;
                    currentCount = 1;
                }

            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA;
            outerCircle.transform.position = pointA;

            anim.SetBool("IsRun", true);
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
            laser.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }


    }

    private void FixedUpdate()
    {
        if (touchStart)
        {

            pointA = outerCircle.transform.position;

            Vector2 offset = pointB - pointA;
            direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);

            circle.transform.position = outerCircle.transform.position + new Vector3(direction.x, direction.y);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            laser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            laser.transform.position =player.transform.position + Vector3.ClampMagnitude(offset, 0.6f);

        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
            laser.SetActive(false);

            if (rtIndex == -1)
                direction = new Vector2(-1, 1);
            else
                direction = new Vector2(1, 1);

            anim.SetBool("IsRun", false);
        }

    }
    void moveCharacter(Vector2 direction)
    {
        player.transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
        borderL.transform.Translate(new Vector2(0, direction.y * speed * Time.deltaTime));
        borderR.transform.Translate(new Vector2(0, direction.y * speed * Time.deltaTime));
    }


}
