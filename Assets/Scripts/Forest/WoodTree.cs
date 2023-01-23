using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodTree : ForestObject
{
    public float totalChops = 5;
    public float chops = 0;
    public Item wood;


    public void AxeHit(float strength) {
        chops += strength;

        if(chops >= totalChops){
            int count = Random.Range(10,15);
            Inventory_Manager.instance.AddItem(wood, count);
            Skills_Manager.instance.AddForestryXP(7);
            Forest_Manager.instance.map[forestPosX, forestPosY] = null;
            Destroy(gameObject);
            
        }
    }

    
}
