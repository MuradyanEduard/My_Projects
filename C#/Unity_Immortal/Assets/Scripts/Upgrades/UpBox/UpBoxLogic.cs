using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class UpBoxLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rnd2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject UpgradePanel = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerLogic>().upgradePanel;

            UpgradePanel.GetComponent<UpgradeGeneration>().GenerateUpgrades();
            UpgradePanel.SetActive(true);
            UpgradePanel.GetComponent<UpgradeGeneration>().AdvGenerateUpgrades();
            UpgradePanel.SetActive(true);

            Time.timeScale = 0;
            StartCoroutine(ExampleCoroutine());
            //Thread.Sleep(2000);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = rnd2.GetComponent<SpriteRenderer>().sprite;

        yield return new WaitForSeconds(0.35f);

        Destroy(this.gameObject);
    }

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
