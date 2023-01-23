using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBin : Interactable
{

    public override void Interact(){
        if(Time_Manager.instance.Pause()){
            StartCoroutine(ExampleCoroutine());
        }
    }

    //This is to deal with the issue of mouse down triggering before pointer down
    //By waiting a fraction of a second, we can switch the order of events
    //Not doing this led the click to open the menu to also interact with it
    IEnumerator ExampleCoroutine(){
        
            yield return new WaitForSeconds(0);
            Menu_Manager.instance.OpenPauseMenu();
            Menu_Manager.instance.OpenShippingMenu();

    }
}
