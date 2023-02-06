using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLogic : MonoBehaviour
{
    private float timeMax = 1.2f;
    private float timeLine = 0f;

    private float hitTime = 0.4f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
                collision.gameObject.GetComponent<EnnemyLogic>().health--;
                collision.gameObject.GetComponent<EnnemyLogic>().healthBar.value--;
        }

        if (collision.gameObject.tag == "EnPatron")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            if (timeLine > hitTime)
            {
                hitTime += 0.4f;
                collision.gameObject.GetComponent<EnnemyLogic>().health--;
                collision.gameObject.GetComponent<EnnemyLogic>().healthBar.value--;
            }
        }

        if (collision.gameObject.tag == "EnPatron")
        {
            Destroy(collision.gameObject);
        }

    }

    void Update()
    {
        timeLine += Time.deltaTime;
        if (timeMax < timeLine)
        {
            Destroy(this.gameObject);
        }
    }
}