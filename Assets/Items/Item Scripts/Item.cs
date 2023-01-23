using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    public enum Favor{ hate, dislike, neutral, like, love};

    public Favor favor = Favor.neutral;

    //Only add onto the end of this, adding in the middle will mix up all existing items
    public enum Category{tool, seeds, fish, material, forage, crop, flower, animal};

    public Category category;

    new public string name = "NO NAME";
    public Sprite icon = null;

    public int stackSize = 99;

    [HideInInspector]
    public int count = 0;

    [HideInInspector]
    public InventorySlot slot;

    public int value = 0;
    public bool canSell = true;

    public void OnUse(){ 
        //Get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 origin = Player_Manager.player.transform.position;

        Vector3 direction = (mousePos - origin);
        string facing;
        //Check direction of cast
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                facing = "right";
            } else{
                facing = "left";
            }
        }else{
            if(direction.y > 0){
                facing = "up";
            } else{
                facing = "down";
            }
        }
        ItemUse(facing, origin);
    }

    public virtual void OnUseUp(){

    } 

    public virtual void ItemUse(string facing, Vector3 origin){

    }

    public virtual bool Update(){
        return true;
    }

    public static int SortByCategory(Item item1, Item item2){
        if(GetEnumOrder(item1) < GetEnumOrder(item2)){
            return -1;
        }
        else if(GetEnumOrder(item1) > GetEnumOrder(item2)){
            return 1;
        } else{
            return(item1.name.CompareTo(item2.name));
        }
    }

    //This is a strange way to sort the enums
    //I can't change the order of the initialization without reassigning every item
    //So instead, I sort the enums here
    public static int GetEnumOrder(Item item){
        if(item.category == Category.tool){
            return 0;
        }
        if(item.category == Category.seeds){
            return 1;
        }
        if(item.category == Category.crop){
            return 2;
        }
        if(item.category == Category.flower){
            return 3;
        }
        if(item.category == Category.forage){
            return 4;
        }
        if(item.category == Category.fish){
            return 5;
        }
        if(item.category == Category.animal){
            return 6;
        }
        if(item.category == Category.material){
            return 7;
        }
        return -1;
    }

}
