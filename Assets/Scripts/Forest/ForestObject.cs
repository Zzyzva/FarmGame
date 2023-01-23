using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestObject : Interactable
{
    public int forestPosX;
    public int forestPosY;

    public void SetForestPos(int x, int y){
        forestPosX = x;
        forestPosY = y;
    }

    public override void Interact(){}
}
