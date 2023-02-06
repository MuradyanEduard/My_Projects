using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurikenLogic : MonoBehaviour
{

    float timeLine = 0;
    float hitTime = 0.5f;

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
        timeLine += Time.deltaTime;
        if (collision.gameObject.tag == "Ennemy")
        {
            if (timeLine > hitTime)
            {
                timeLine = 0;
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
        this.transform.parent.Rotate(0, 0, 100 * Time.deltaTime);
        this.transform.Rotate(0, 0, 350 * Time.deltaTime);
    }
}
