using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.AudioSettings;

public class UnlockMap : MonoBehaviour
{
    public GameObject modalForm;
    public GameObject buyModal;
    public GameObject modalConfirm;

    public void OnUnlockClick()
    {
        modalForm.SetActive(true);

        if (modalConfirm.GetComponent<ModalConfirm>().CkeckPlayerUnlock() == true)
        {
            buyModal.SetActive(true);
            modalConfirm.GetComponent<ModalConfirm>().cond = false;
        }
    }
}
