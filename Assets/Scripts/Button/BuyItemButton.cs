using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuyItemButton : MonoBehaviour
{
    public VendorItem item;


    public void ButtonPress(){
        Vendor_Manager.instance.BuyItem(item);
    }
}
