using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Dialogue : MonoBehaviour
{
    public string dialogueName;
    public Sprite icon;



    public Dialogue BuildDialogue(string lines){
        Dialogue ret = new Dialogue(dialogueName, lines, icon);
        return ret;
    }
}
