using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObjectLogic : MonoBehaviour
{

    public GameObject leave;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadFloatObjects")
        {
            Destroy(this.gameObject);
            if (this.gameObject.transform.position.x > 0)
                Camera.main.GetComponent<MapRender>().CreateWaterObjects(3f, 1);
            else
                Camera.main.GetComponent<MapRender>().CreateWaterObjects(3f, 2);

        }
        
        if (collision.gameObject.tag == "SpawnFloatObjects")
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                this.gameObject.transform.position.y + 20f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        leave.transform.position = new Vector3(leave.transform.position.x, leave.transform.position.y+1*Time.deltaTime);
    }
}
