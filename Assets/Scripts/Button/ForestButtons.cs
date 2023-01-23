using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestButtons : MonoBehaviour
{


    public void OnForestOutskirtsClick(){
        AnyButtonClick();
    }

    public void AnyButtonClick(){
        Forest_Manager.instance.hasGenerated = true;
        Time_Manager.instance.Unpause();
        LevelLoader.instance.LoadLevel("Forest", new Vector3(0,0,0));
        Menu_Manager.instance.CloseForestMenu();
    }
}
