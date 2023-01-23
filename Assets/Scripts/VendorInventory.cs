using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public struct ReqItem{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName = "Vendor")]
public class VendorInventory : ScriptableObject
{
    


    [Serializable]
    public struct VendorItem {
        public Item item;
        public int price;
        public List<ReqItem> reqItems; //No more than four to fit in UI
        public int special;
    }
    public VendorItem[] inventory;
    public String standName;
}
