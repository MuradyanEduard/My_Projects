using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditText : MonoBehaviour
{
    public InputField inputTxt;
    public Text txt;
    public void OnTextExit()
    {
        if (inputTxt.text == "")
        {
            txt.text = "PLAYER";
        }
        else { 
            txt.text = inputTxt.text;
        }

    }
}
