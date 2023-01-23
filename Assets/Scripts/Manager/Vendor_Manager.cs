using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Vendor_Manager : MonoBehaviour
{

    public static Vendor_Manager instance;
    public VendorInventory leftStallInventory;
    public VendorInventory rightStallInventory;

    public VendorInventory dinsSeeds;
    public VendorInventory toddsTools;
    public VendorInventory mineUpgrades;

    public VendorInventory openInventory;
    
    public CanvasGroup vendorMenu;
    public GameObject vendorMenuContent;
    public GameObject vendorUIPrefab;

    private void Awake() {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    public void UpdateVendors(int hours, int minutes, string meridiem){
        if(hours == 7 && minutes == 30 && meridiem == "am"){
            leftStallInventory = dinsSeeds;
            rightStallInventory = toddsTools;
        } else if( hours == 5 && minutes == 0 && meridiem == "pm"){
            leftStallInventory = null;
            rightStallInventory = null;
        }
    }

    public void BuyItem(VendorInventory.VendorItem item){
        if(Inventory_Manager.instance.gold >= item.price){
            if(item.reqItems.Count != 0){
                //Check for all items
                foreach(ReqItem reqItem in item.reqItems){
                    if(!Inventory_Manager.instance.CanRemoveItem(reqItem.item.name, reqItem.count)){
                        return;
                    }
                }
                //Remove all Items
                foreach(ReqItem reqItem in item.reqItems){
                    Inventory_Manager.instance.RemoveItem(reqItem.item.name, reqItem.count);
                }
            }
            Inventory_Manager.instance.gold -= item.price;
            if(item.item){
                Inventory_Manager.instance.AddItem(item.item, 1);
            }
            if(item.special != 0){
                Vendor_Manager.instance.BuySpecial(item.special);
            }
        }
    }

    public void BuySpecial(int special){
        if(special == 1){
            Mines_Manager.instance.lightFloors = 5;
        } else if(special == 2){
            Mines_Manager.instance.startingFloors = 1;
        }
        Menu_Manager.instance.OpenVendorMenu(openInventory);
    }

    public string GetSpecialName(int special){
        if(special == 1){
            return "Torches Through Floor Five";
        } else if(special == 2){
            return "Path to Floor Five";
        }
        return null;
    }

    public bool CanBuySpecial(int special){
        if(special == 1){
            if(Mines_Manager.instance.lightFloors == 0){
                return true;
            }
            return false;
        } else if(special == 2){
            if(Mines_Manager.instance.startingFloors == 0){
                return true;
            }
            return false;
        }
        return true;
    }


}
