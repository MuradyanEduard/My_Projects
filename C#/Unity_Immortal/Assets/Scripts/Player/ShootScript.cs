using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public float speed = 6f;

    private float deathTime = 1.8f;
    private float timeLine = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            collision.gameObject.GetComponent<EnnemyLogic>().health--;
            collision.gameObject.GetComponent<EnnemyLogic>().healthBar.value--;
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    void Update()
    {
        GameObject[] allEnnemys = allEnnemys = GameObject.FindGameObjectsWithTag("Ennemy");

        if (allEnnemys.Length == 0)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else
        {
            float distanceMin = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                new Vector2(allEnnemys[0].transform.position.x, allEnnemys[0].transform.position.y));

            int currentIndex = 0;

            for (int i = 1; i < allEnnemys.Length; i++)
            {
                float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.y),
                    new Vector2(allEnnemys[i].transform.position.x, allEnnemys[i].transform.position.y));

                if (distanceMin > distance)
                {
                    distanceMin = distance;
                    currentIndex = i;
                }
            }

            Vector2 direction = new Vector2(allEnnemys[currentIndex].transform.position.y - transform.position.y,
                allEnnemys[currentIndex].transform.position.x - transform.position.x);
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector2.MoveTowards(transform.position, allEnnemys[currentIndex].transform.position, speed * Time.deltaTime);

        }

        timeLine += Time.deltaTime;

        if (timeLine > deathTime)
        {
            Destroy(this.gameObject);
        }
    }

}