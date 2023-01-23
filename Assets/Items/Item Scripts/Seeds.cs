using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Seeds")]
public class Seeds : UseableItem
{

    public Crop crop;
    bool planted = false;
    public override void ItemUse(string facing, Vector3 origin){
        planted = false;
        Collider2D[] hitColliders = ItemUseLocation(facing, origin);
        foreach (var hitCollider in hitColliders){
            if(hitCollider.gameObject.GetComponent<Dirt>()){
                if(hitCollider.gameObject.GetComponent<Dirt>().PlantSeeds(crop)){
                    planted = true;
                } else{
                    planted = false;
                }
            }
        }
    }


    public override bool Update() {
        if(base.Update() && planted == true){
            Inventory_Manager.instance.RemoveItem(this.name, 1);
            return true;
        }
        return false;
    
    }
    
}
