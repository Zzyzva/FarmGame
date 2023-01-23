using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarSlot : MonoBehaviour
{
    public Image highLight;
    public Image icon;
    public TextMeshProUGUI countText;
    public InventorySlot slot;
    
    private void Start() {
        icon.enabled = false;
    }

    public void Select(){
        highLight.enabled = true;
    }

    public void Unselect(){
        highLight.enabled = false;
    }


    public void UpdateSlot(){
        if(slot.item){
            icon.sprite = slot.item.icon;
            icon.enabled = true;
            if(slot.item.count == 1 || slot.item.count == 0){
                countText.text = "";
            } else{
                countText.text = slot.item.count.ToString();
            }
        } else{
            ClearSlot();
        }
    }

    //Removes an item from the slot visually
    public void ClearSlot(){
        icon.sprite = null;
        icon.enabled = false;
        countText.text = "";
    }
}