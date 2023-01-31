using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletin : Interactable
{

    public CanvasGroup bulletinMenu;

    public void Start(){
        bulletinMenu = Quest_Manager.instance.bulletinMenu;
    }


    public override void Interact() {
        if(Time_Manager.instance.Pause()){
            Menu_Manager.instance.OpenBulletinMenu();
        }
    }
}
