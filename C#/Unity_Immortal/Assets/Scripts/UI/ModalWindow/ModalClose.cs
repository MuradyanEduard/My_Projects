using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalClose : MonoBehaviour
{
    public GameObject modalWindow;
    public GameObject currentModal;
    public void OnModalCloseClick()
    {
        currentModal.SetActive(false);
        modalWindow.SetActive(false);
    }
}
