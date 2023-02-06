using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrikeLogic : MonoBehaviour
{
    private float timeMax = 1f;
    private float timeLine = 0f;

    float hitTime = 0.4f;
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
                hitTime += 0.2f;
                collision.gameObject.GetComponent<EnnemyLogic>().health--;
                collision.gameObject.GetComponent<EnnemyLogic>().healthBar.value--;
            }
        }

        if (collision.gameObject.tag == "EnPatron")
        {
            Destroy(collision.gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLine += Time.deltaTime;
        if (timeMax < timeLine)
        {
            Destroy(this.gameObject);
        }
    }
}
