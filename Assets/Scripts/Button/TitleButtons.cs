using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtons : MonoBehaviour
{

    public void OnNewClick(){
        Save_Manager.instance.StartNewGame();
    }

    public void OnLoadClick(){
        Menu_Manager.instance.OpenLoadMenu();
    }
}
