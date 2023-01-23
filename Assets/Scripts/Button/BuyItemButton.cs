using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItemButton : MonoBehaviour
{
    public VendorInventory.VendorItem item;


    public void ButtonPress(){
        Vendor_Manager.instance.BuyItem(item);
    }
}
