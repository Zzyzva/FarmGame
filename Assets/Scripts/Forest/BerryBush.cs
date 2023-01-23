using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : ForestObject
{
    bool picked;
    public Sprite pickedBush;
    public Item berry;
    public override void Interact()
    {  
        if(!picked){
            SetPicked();
            int count = Random.Range(2,5);
            Inventory_Manager.instance.AddItem(berry, count);
            Skills_Manager.instance.AddForestryXP(3);
            Forest_Manager.instance.map[forestPosX,forestPosY] = "picked bush";
        }  
    }

    public void SetPicked(){
        picked = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = pickedBush;
    }
}
