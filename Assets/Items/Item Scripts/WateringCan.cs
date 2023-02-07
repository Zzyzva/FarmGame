using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/WateringCan")]
public class WateringCan : UseableItem
{




    public override void ItemUse(string facing, Vector3 origin){
        base.ItemUse(facing, origin);
        Farming_Manager.instance.waterInCan--;
        if(Farming_Manager.instance.waterInCan < 0){
            Farming_Manager.instance.waterInCan = 0;
            Emote_Manager.instance.SpawnEmoteOnPlayer("NoWater");

        }
    }

    public override string GetDescription(){
        return "Water: " + Farming_Manager.instance.waterInCan;
    }
}
