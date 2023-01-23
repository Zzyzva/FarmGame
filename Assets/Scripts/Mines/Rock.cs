using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public int dropCount;
    public int dropXP;
    public Item drop;
    public float rockStrength;

    public bool dropLadder = false;
    public GameObject ladder;

    public void PickaxeHit(float strength){
        rockStrength -= strength;
        if(rockStrength <= 0){
            if(drop){
                Inventory_Manager.instance.AddItem(drop, dropCount);
                Skills_Manager.instance.AddMiningXP(dropXP);
            }
            if(dropLadder){
                Instantiate(ladder, gameObject.transform.position, Quaternion.identity);
                 Skills_Manager.instance.AddMiningXP(dropXP);
            }
            Destroy(gameObject);

        }
    }
}
