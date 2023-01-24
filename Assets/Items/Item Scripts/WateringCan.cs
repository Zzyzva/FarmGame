using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/WateringCan")]
public class WateringCan : UseableItem
{





    public override void ItemUse(string facing, Vector3 origin){
        Farming_Manager.instance.waterInCan--;
        base.ItemUse(facing, origin);
        
        
        if(Farming_Manager.instance.waterInCan < 0){
            Farming_Manager.instance.waterInCan = 0;
            Emote_Manager.instance.SpawnEmoteOnPlayer("NoWater");

        }
        


    }
}
