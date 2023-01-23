﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/WateringCan")]
public class WateringCan : UseableItem
{

    public GameObject noWater;
    GameObject nowWaterInstance;

    float noWaterSignTime = 1;
    float lastTick;
    bool noWaterSignUp = false;


    public override void ItemUse(string facing, Vector3 origin){
        Farming_Manager.instance.waterInCan--;
        base.ItemUse(facing, origin);
        
        
        if(Farming_Manager.instance.waterInCan < 0){
            Farming_Manager.instance.waterInCan = 0;
            nowWaterInstance = Instantiate(noWater);
            origin.y += 1;
            nowWaterInstance.transform.position = origin;

            noWaterSignUp = true;
            lastTick = Time.time;
        }
        


    }


    public override bool Update(){
        bool ret = base.Update();
        if(noWaterSignUp && Time.time > lastTick + noWaterSignTime){
            noWaterSignUp = false;
            Destroy(nowWaterInstance);
        }
        return ret;
    }
}
