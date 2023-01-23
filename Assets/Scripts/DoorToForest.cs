using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToForest : MonoBehaviour
{
    
   void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            if(Forest_Manager.instance.hasGenerated){
                LevelLoader.instance.LoadLevel("Forest", new Vector3(0,0,0));
            } else{
                Time_Manager.instance.Pause();
                Menu_Manager.instance.OpenForestMenu();
            }
            
       }
   }
}
