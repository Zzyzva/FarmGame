using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepWarningButtons : MonoBehaviour
{

    public CanvasGroup warning;
    public void OnYesClick(){
        Time_Manager.instance.Sleep();
        warning.alpha = 0;
        warning.interactable = false;
        warning.blocksRaycasts = false;
    }

    public void OnNoCLick(){
        warning.alpha = 0;
        warning.interactable = false;
        warning.blocksRaycasts = false;
        Time_Manager.instance.Unpause();
    }
}
