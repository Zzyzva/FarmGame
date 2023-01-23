using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorStall : Interactable
{
    public string standName;
    public override void Interact() {
        Time_Manager.instance.Pause();
        if(standName == "left"){
            Menu_Manager.instance.OpenVendorMenu(Vendor_Manager.instance.leftStallInventory);
        } else if(standName == "right"){
            Menu_Manager.instance.OpenVendorMenu(Vendor_Manager.instance.rightStallInventory);
        } else if(standName == "mountain"){
            Menu_Manager.instance.OpenVendorMenu(Vendor_Manager.instance.mineUpgrades);
        }
    }
}
