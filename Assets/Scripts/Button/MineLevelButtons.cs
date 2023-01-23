using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLevelButtons : MonoBehaviour
{
    public void OnOneClick(){
        AnyButtonClick();
    }

    public void OnFiveClick(){
        Mines_Manager.instance.floor = 4; //Minus 1 since it goes up when you enter
        AnyButtonClick();
    }

    public void AnyButtonClick(){
        Time_Manager.instance.Unpause();
        LevelLoader.instance.LoadLevel("Mines", new Vector3(0, 0, 0));
        Menu_Manager.instance.CloseMinesMenu();
    }
}
