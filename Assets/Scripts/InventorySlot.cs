using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    public Image icon;
    public Item item;
    public TextMeshProUGUI countText;
    
    public enum SlotType {inventory, shipping, trash, chest};

    public SlotType slotType;
    
    private void Start() {
        icon.enabled = false;
    }


    public void SetItem(Item newItem){
        item = newItem;
        UpdateSlot();
    }

    public void UpdateSlot(){
        if(item){
            icon.sprite = item.icon;
            icon.enabled = true;
            if(item.count == 1 || item.count == 0){
                countText.text = "";
            } else{
                countText.text = item.count.ToString();
            }
        }
    }

    //Removes an item from the slot visually
    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        countText.text = "";
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(Menu_Manager.instance.UIopen){
            bool left;
            if (eventData.button == PointerEventData.InputButton.Right) {
                left = false;
            } else if (eventData.button == PointerEventData.InputButton.Left) {
                left = true;
            } else {
                return;
            }
            bool ctrl = Input.GetKey(KeyCode.LeftControl);
            Inventory_Manager.instance.SlotClick(this, left, ctrl);
        }
    }

    public void OnPointerEnter(){
        Inventory_Manager.instance.OnHoverEnter(item);
    }

    public void OnPointerExit(){
        Inventory_Manager.instance.OnHoverExit();
    }
}
