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
    public VendorInventory oliviaFishing;

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

    public void UpdateVendors(int hours, int minutes, string meridiem, string day){
        if(hours == 8 && minutes == 30 && meridiem == "am" && (day == "Mon" || day == "Tue" || day == "Wed" || day == "Thu" || day == "Fri")){
            leftStallInventory = dinsSeeds;
            rightStallInventory = toddsTools;

        } else if(hours == 8 && minutes == 30 && meridiem == "am" && (day == "Sat" || day == "Sun")){
            leftStallInventory = dinsSeeds;
            rightStallInventory = oliviaFishing;
        } else if( hours == 5 && minutes == 0 && meridiem == "pm"){
            leftStallInventory = null;
            rightStallInventory = null;
        }
    }

    public void BuyItem(VendorItem item){
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

    public bool CanBuyItem(VendorItem item){
        if(
        (item.reqRank == ReqRank.noviceFarming && !Skills_Manager.instance.farmingNovice) ||
        (item.reqRank == ReqRank.intermediateFarming && !Skills_Manager.instance.farmingIntermediate) ||
        (item.reqRank == ReqRank.advancedFarming && !Skills_Manager.instance.farmingAdvanced) ||
        (item.reqRank == ReqRank.expertFarming && !Skills_Manager.instance.farmingExpert) ||
        (item.reqRank == ReqRank.masterFarming && !Skills_Manager.instance.farmingMaster) ||
        (item.reqRank == ReqRank.legendaryFarming && !Skills_Manager.instance.farmingLegendary) ||
        (item.reqRank == ReqRank.noviceFishing && !Skills_Manager.instance.fishingNovice) ||
        (item.reqRank == ReqRank.intermediateFishing && !Skills_Manager.instance.fishingIntermediate) ||
        (item.reqRank == ReqRank.advancedFishing && !Skills_Manager.instance.fishingAdvanced) ||
        (item.reqRank == ReqRank.expertFishing && !Skills_Manager.instance.fishingExpert) ||
        (item.reqRank == ReqRank.masterFishing && !Skills_Manager.instance.fishingMaster) ||
        (item.reqRank == ReqRank.legendaryFishing && !Skills_Manager.instance.fishingLegendary) ||
        (item.reqRank == ReqRank.noviceForestry && !Skills_Manager.instance.forestryNovice) ||
        (item.reqRank == ReqRank.intermediateForestry && !Skills_Manager.instance.forestryIntermediate) ||
        (item.reqRank == ReqRank.advancedForestry && !Skills_Manager.instance.forestryAdvanced) ||
        (item.reqRank == ReqRank.expertForestry && !Skills_Manager.instance.forestryExpert) ||
        (item.reqRank == ReqRank.masterForestry && !Skills_Manager.instance.forestryMaster) ||
        (item.reqRank == ReqRank.legendaryForestry && !Skills_Manager.instance.forestryLegendary) ||
        (item.reqRank == ReqRank.noviceMining && !Skills_Manager.instance.miningNovice) ||
        (item.reqRank == ReqRank.intermediateMining && !Skills_Manager.instance.miningIntermediate) ||
        (item.reqRank == ReqRank.advancedMining && !Skills_Manager.instance.miningAdvanced) ||
        (item.reqRank == ReqRank.expertMining && !Skills_Manager.instance.miningExpert) ||
        (item.reqRank == ReqRank.masterMining && !Skills_Manager.instance.miningMaster) ||
        (item.reqRank == ReqRank.legendaryMining && !Skills_Manager.instance.miningLegendary)
        ){
            return false;
        }
        if(item.special == 1){
            if(Mines_Manager.instance.lightFloors == 0){
                return true;
            }
            return false;
        } else if(item.special == 2){
            if(Mines_Manager.instance.startingFloors == 0){
                return true;
            }
            return false;
        }
        return true;
    }


}
