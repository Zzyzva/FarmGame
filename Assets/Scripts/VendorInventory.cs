using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public struct ReqItem{
    public Item item;
    public int count;
}

public enum ReqRank {
    none,
    noviceFarming, intermediateFarming, advancedFarming, expertFarming, masterFarming, legendaryFarming,
    noviceFishing, intermediateFishing, advancedFishing, expertFishing, masterFishing, legendaryFishing,
    noviceForestry, intermediateForestry, advancedForestry, expertForestry, masterForestry, legendaryForestry,
    noviceMining, intermediateMining, advancedMining, expertMining, masterMining, legendaryMining,
};

[Serializable]
    public struct VendorItem {
        public Item item;
        public int price;
        public List<ReqItem> reqItems; //No more than four to fit in UI
        public int special;
        public ReqRank reqRank;
    }

[CreateAssetMenu(menuName = "Vendor")]
public class VendorInventory : ScriptableObject
{
    public VendorItem[] inventory;
    public String standName;
}
