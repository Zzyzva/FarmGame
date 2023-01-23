using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageButtons : MonoBehaviour
{

    public void OnQuickStackClick(){
        Inventory_Manager.instance.QuickStack();
    }

    public void OnSortClick(){
        Inventory_Manager.instance.Sort(Inventory_Manager.instance.chestSlots);
    }
}
