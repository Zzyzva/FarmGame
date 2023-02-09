using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{

    public CanvasGroup warning;

    private void OnMouseDown() {
        if(!Time_Manager.instance.pause){
            Time_Manager.instance.Pause();
            Menu_Manager.instance.OpenSleepWarning();
        }
    }
}
