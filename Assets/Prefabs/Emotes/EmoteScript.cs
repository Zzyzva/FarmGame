using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoteScript : MonoBehaviour
{
    public bool waiting = false;
    public bool followPlayer = false;
    public string emoteName;
    public void EndAnimation(){
        if(waiting && Cutscene_Manager.instance.cutsceneIsRunning){
            Cutscene_Manager.instance.RunCutscene();
        }
        Destroy(gameObject);
    }

    public void Update(){
        if(followPlayer){
            Vector3 pos = Player_Manager.player.transform.position;
            pos.y += 1;
            transform.position = pos;
        }
    }
}
