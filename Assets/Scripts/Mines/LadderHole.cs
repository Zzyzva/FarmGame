using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderHole : Interactable
{
    public override void Interact(){
        if(Mines_Manager.instance.floor == 0){
            Time_Manager.instance.Pause();
            Menu_Manager.instance.OpenMinesMenu();
        } else{
            LevelLoader.instance.LoadLevel("Mines", new Vector3(0, 0, 0));
        }
        
    }
}
