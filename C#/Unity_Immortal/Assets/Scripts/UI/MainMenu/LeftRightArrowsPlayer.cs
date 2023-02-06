using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightArrowsPlayer : MonoBehaviour
{
    public Animator[] playerAnimators;
    public Animator[] fireBallAnimators;

    public GameObject player;
    public GameObject unlockObj;
    public Sprite[] imgSprites;
    public GameObject playerImg;
    static int currentHeroNum;
    public Text unlockText;

    public GameObject playerHelper;
    public GameObject fireBall;
    public GameObject fireBallHelper;
    public GameObject playerHelperIcon;

    private void Start()
    {
        playerImg.GetComponent<Image>().sprite = imgSprites[Mathf.Abs(currentHeroNum) % imgSprites.Length];
        playerHelperIcon.GetComponent<Image>().sprite = imgSprites[Mathf.Abs(currentHeroNum) % imgSprites.Length];
        playerHelper.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0].runtimeAnimatorController;// as RuntimeAnimatorController;
    }


    public void OnLeftClick()
    {
        if (currentHeroNum == 0)
            currentHeroNum += imgSprites.Length;

        currentHeroNum--;
        AnimatorChange();

    }

    public void OnRightClick()
    {
        currentHeroNum++;
        AnimatorChange();
    }

    public void AnimatorChange()
    {
        if (PlayerPrefs.GetInt("Player" + (Mathf.Abs(currentHeroNum) % playerAnimators.Length)) == 1)
            unlockObj.SetActive(false);
        else
            unlockObj.SetActive(true);

        playerImg.GetComponent<Image>().sprite = imgSprites[Mathf.Abs(currentHeroNum) % imgSprites.Length];
        playerHelperIcon.GetComponent<Image>().sprite = imgSprites[Mathf.Abs(currentHeroNum) % imgSprites.Length];

        switch (Mathf.Abs(currentHeroNum) % playerAnimators.Length)
        {
            case 1:
                unlockText.text = 10000.ToString();
                break;
            case 2:
                unlockText.text = 20000.ToString();
                break;
            case 3:
                unlockText.text = 30000.ToString();
                break;
        }

        /*if (unlockObj.active == true)
        {
            return;
        }*/

        switch (Mathf.Abs(currentHeroNum) % playerAnimators.Length)
        {
            case 0:
                player.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0].runtimeAnimatorController;// as RuntimeAnimatorController;
                playerHelper.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[0].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBall.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[0].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBallHelper.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[0].runtimeAnimatorController;// as RuntimeAnimatorController;
                player.GetComponent<BoxCollider2D>().size = new Vector2(0.73f, 0.9f);
                player.transform.localScale = new Vector2(1f, 1f);
                break;
            case 1:
                player.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[1].runtimeAnimatorController;// as RuntimeAnimatorController;
                playerHelper.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[1].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBall.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[1].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBallHelper.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[1].runtimeAnimatorController;// as RuntimeAnimatorController;
                player.GetComponent<BoxCollider2D>().size = new Vector2(1.05f, 1.22f);
                player.transform.localScale = new Vector2(0.8f, 0.8f);
                break;
            case 2:
                player.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[2].runtimeAnimatorController;// as RuntimeAnimatorController;
                playerHelper.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[2].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBall.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[2].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBallHelper.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[2].runtimeAnimatorController;// as RuntimeAnimatorController;
                player.GetComponent<BoxCollider2D>().size = new Vector2(1.05f, 1.16f);
                player.transform.localScale = new Vector2(0.8f, 0.8f);
                break;
            case 3:
                player.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[3].runtimeAnimatorController;// as RuntimeAnimatorController;
                playerHelper.GetComponent<Animator>().runtimeAnimatorController = playerAnimators[3].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBall.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[3].runtimeAnimatorController;// as RuntimeAnimatorController;
                fireBallHelper.GetComponent<Animator>().runtimeAnimatorController = fireBallAnimators[3].runtimeAnimatorController;// as RuntimeAnimatorController;
                player.GetComponent<BoxCollider2D>().size = new Vector2(1.02f, 1.43f);
                player.transform.localScale = new Vector2(0.7f, 0.7f);
                break;

        }
    }

    public int GetCurrentHeroNum()
    {
        return currentHeroNum;
    }

    public void SetCurrentHeroNum(int nom)
    {
        currentHeroNum = nom;
    }
}
