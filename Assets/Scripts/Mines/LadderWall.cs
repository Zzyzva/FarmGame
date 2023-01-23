using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderWall : Interactable
{
    public override void Interact(){
        LevelLoader.instance.LoadLevel("Mountain Path", new Vector3(9.5f, 5.5f, 0));
    }
}
