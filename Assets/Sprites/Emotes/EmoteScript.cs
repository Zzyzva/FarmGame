using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteScript : MonoBehaviour
{
    public bool waiting = false;
    public void EndAnimation(){
        if(waiting && Cutscene_Manager.instance.cutsceneIsRunning){
            Cutscene_Manager.instance.RunCutscene();
        }
        Destroy(gameObject);
    }
}
