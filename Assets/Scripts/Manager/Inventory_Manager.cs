using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory_Manager : MonoBehaviour
{
    public Transform itemsParent;
    public Transform chestParent;
    public Transform hotbarParent;
    public Slider slider;
    public TextMeshProUGUI goldText;
    public GameObject ItemDrop;

    public InventorySlot[] inventorySlots;
    public InventorySlot[] chestSlots;
    public HotbarSlot[] hotbarSlots;
    //public List<Item> inventory = new List<Item>();
    public List<Item> toSell = new List<Item>();
    //private int maxInventory = 10;
    public static Inventory_Manager instance;
    private int selectedSlot = 0;


    public List<Item> startInventory = new List<Item>();

    public float energy;
    public float maxEnergy = 150;

    public int gold;

    public string playerName;

    public bool canChangeSelected =true;

    //Moving items in inventory
    public Item cursorItem;
    public GameObject cursor;
    public bool cursorHolding = false;

    //Hovering items
    public GameObject hoverText;

    public bool selectingGift = false;

    public InventorySlot trashSlot;
    public InventorySlot shippingSlot;

    public bool chestOpen = false;
    public bool shippingOpen = false;

    public Object[] items;


    private void Awake() {
        if(instance == null){
            instance = this;
            items = Resources.LoadAll("Items");
            inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
            chestSlots = chestParent.GetComponentsInChildren<InventorySlot>();
            hotbarSlots = hotbarParent.GetComponentsInChildren<HotbarSlot>();
            energy = maxEnergy;
            slider.maxValue = maxEnergy;
            slider.value = energy;

            foreach( HotbarSlot slot in hotbarSlots){
                slot.Unselect();
            }
            hotbarSlots[0].Select();
        } else{
            Destroy(gameObject);
        }
        
    }

    public void StartGame(){
        

        foreach(InventorySlot slot in inventorySlots){
            slot.ClearSlot();
        }

        foreach(InventorySlot slot in chestSlots){
            slot.ClearSlot();
        }

        foreach(Item item in startInventory){
            AddItem(item, 1);
        }

        gold = 500;

    }

    // Update is called once per frame
    void Update()
    {
        //Change highlight
         #region INPUT
        
        if(!Time_Manager.instance.pause && canChangeSelected){
           
            if(Input.GetKeyDown("1"))
                ChangeSelected(0);

            if(Input.GetKeyDown("2"))
                ChangeSelected(1);

            if(Input.GetKeyDown("3"))
                ChangeSelected(2);

            if(Input.GetKeyDown("4"))
                ChangeSelected(3);

            if(Input.GetKeyDown("5"))
                ChangeSelected(4);

            if(Input.GetKeyDown("6"))
                ChangeSelected(5);

            if(Input.GetKeyDown("7"))
                ChangeSelected(6);

            if(Input.GetKeyDown("8"))
                ChangeSelected(7);

            if(Input.GetKeyDown("9"))
                ChangeSelected(8);

            if(Input.GetKeyDown("0"))
                ChangeSelected(9);

            if(Input.mouseScrollDelta.y < 0){
                if(selectedSlot != 9){
                    ChangeSelected(selectedSlot + 1);
                } else {
                    ChangeSelected(0);
                }
            }
            if(Input.mouseScrollDelta.y > 0){
                if(selectedSlot != 0){
                    ChangeSelected(selectedSlot - 1);
                } else {
                    ChangeSelected(9);
                }
            }
            
        }
        #endregion
    


        //Check for using item
        if(!Time_Manager.instance.pause && Input.GetMouseButtonDown(1)){
            if(inventorySlots[selectedSlot].item){
                inventorySlots[selectedSlot].item.OnUse();

            }
        }
        if(!Time_Manager.instance.pause && Input.GetMouseButtonUp(1)){
            if(inventorySlots[selectedSlot].item){
                inventorySlots[selectedSlot].item.OnUseUp();
            }
        }

        if(inventorySlots[selectedSlot].item){
            inventorySlots[selectedSlot].item.Update();
        }
    




        //Check Energy
        slider.value = energy;
        if(energy <= 0){
            Time_Manager.instance.Sleep();
            energy = maxEnergy;
            Mines_Manager.instance.ExitMines();
        }

        //Check gold
        goldText.text = gold + " g";
    
    
    }

    void ChangeSelected(int select){
        if(Player_Manager.player.GetComponent<Player_Movement>().canMove){
            hotbarSlots[selectedSlot].Unselect();
            hotbarSlots[select].Select();
            selectedSlot = select;
        }    
    }

    public Item AddItemToChest(Item item, int count){
        return AddItemToSlots(item, count, chestSlots);
    }


    public Item AddItem(Item item, int count){
        Item overflow = AddItemToSlots(item, count, inventorySlots);
        if(chestOpen){
            return overflow;
        }
        if(overflow){
            for( int i = 0; i < item.count; i++){
                GameObject drop = Instantiate(ItemDrop, Player_Manager.player.transform.position, Quaternion.identity);
                drop.GetComponent<ItemDrop>().item = item;
            }
        }
        return null;
    }

    //Returns any overflow items
    public Item AddItemToSlots(Item item, int count, InventorySlot[] slots){
        //Search for an existing stack
        foreach(InventorySlot slot in slots){
            if(slot.item != null && slot.item.name == item.name && slot.item.count < slot.item.stackSize){
                //If an existing stack can hold all of it, add it and quit
                if(count + slot.item.count <= slot.item.stackSize){
                    slot.item.count += count;
                    UpdateSlots();
                    return null;

                //If there is an existing stack but it can't hold all of it, fill that stack then find the next stack
                } else {
                    count = slot.item.count + count - slot.item.stackSize;
                    slot.item.count = slot.item.stackSize;
                    UpdateSlots();
                    return AddItemToSlots(item, count, slots);
                }
            }
        }

   
        //If we made it here there are no non full stacks. Make a new stack
        foreach(InventorySlot slot in slots){
            if(!slot.item){
                Item newItem = Instantiate(item) as Item;
                slot.SetItem(newItem);
                newItem.slot = slot;
                //If the item count can fit, add it then break
                if(count <= item.stackSize){
                    newItem.count = count;
                    count = 0;
                    break;
                
                //If the count of the item is to much, add one stack at max then keep looking
                } else{
                    newItem.count = newItem.stackSize;
                    count -= newItem.stackSize;
                }
            }
        }
        //If all slots are filled and we still have stuff to add
        if(count != 0){
            item.count = count;
            UpdateSlots();
            return item;           
        }
        UpdateSlots();
        return null;
    }

    public bool RemoveItem(string name, int count){
        //First, check if we have enough of the item to remove
        if(!CanRemoveItem(name, count)){
            Debug.Log("Error Removing Item");
            return false;
        }
        //Loop through again, but this time removing the item
        //We don't want to remove anything until we know we can remove it all
        foreach(InventorySlot slot in inventorySlots){
            if(slot.item != null && slot.item.name == name){
                //Stack has more than enough
                if(slot.item.count > count){
                    slot.item.count -= count;
                    break;
                //Stack does not have enough
                } else{
                    count -= slot.item.count;
                    slot.ClearSlot();
                    //Case where stack had exactly enough
                    if(count == 0){
                        break;
                    }
                }
            }
        }
        UpdateSlots();
        return true;
    }


    public bool CanRemoveItem(string name, int count){
        int total = GetTotalItemAmount(name);
        if(total >= count){
            return true;
        } else{
            return false;
        }
    }

    public int GetTotalItemAmount(string name){
        int total = 0;
        foreach(InventorySlot slot in inventorySlots){
            if(slot.item != null && slot.item.name == name){
                total += slot.item.count;
            }
        }
        return total;
    }

    public bool CanAddItem(Item item, int count){
        int total = 0;
        foreach(InventorySlot slot in inventorySlots){
            if(slot.item != null && slot.item.name == item.name){
                total += slot.item.stackSize - slot.item.count;
            }
            if(!slot.item){
                total += item.stackSize;
            }
            if(total >= count){
                return true;
            }
        }
        return false;
    }

    public bool CheckForItemInHotbar(Item item, int count){
        int total = 0;
        foreach(HotbarSlot hotSlot in hotbarSlots){
            if(hotSlot.slot.item != null && hotSlot.slot.item.name == item.name){
                total += hotSlot.slot.item.count;
            }
        }
        if(total >= count){
            return true;
        }
        return false;
    }

    public Item GetItemByName(string name){
        foreach(Object obj in Inventory_Manager.instance.items){
            Item item = (Item) obj;
            if(item.name == name){
                return item;
            }
        }
        return null;
    }


    public void SellItem(Item item){
        toSell.Add(item);  
    }







    //left - true if left click, false if right
    public void SlotClick(InventorySlot slot, bool left, bool ctrl){

        //Left Click
        if (left) {
            //In gift select mode
            if(selectingGift){
                if(slot.item && slot.item.canSell){
                    slot.item.count--;
                    if(slot.item.count == 0){
                        slot.ClearSlot();
                    }
                    Dialogue_Manager.instance.AcceptGift(slot.item);
                    Menu_Manager.instance.ClosePauseMenu();
                    selectingGift = false;
                    UpdateSlots();
                }
                return;
            }
            //If ctrl clicking to chest
            if(chestOpen && ctrl){
                if(slot.item){
                    Item overflow = null;
                    if(slot.slotType == InventorySlot.SlotType.inventory){
                        overflow = AddItemToChest(slot.item, slot.item.count);
                    } else if(slot.slotType == InventorySlot.SlotType.chest){
                        overflow = AddItem(slot.item, slot.item.count);
                    }
                    if(overflow == null){
                        slot.ClearSlot();
                    } else{
                        slot.SetItem(overflow);
                    }
                }
                UpdateSlots();
                return;
            }

            //If ctrl clicking to shipping
            if(shippingOpen && ctrl){
                if(slot.item && slot.item.canSell){
                    Item overflow = null;
                    if(slot.slotType == InventorySlot.SlotType.inventory){
                        if(shippingSlot.item == null){
                            shippingSlot.SetItem(slot.item);
                        } else{
                            toSell.Add(shippingSlot.item);
                            shippingSlot.ClearSlot();
                            shippingSlot.SetItem(slot.item);
                        }
                    } else if(slot.slotType == InventorySlot.SlotType.shipping){
                        overflow = AddItem(slot.item, slot.item.count);
                    }
                    if(overflow == null){
                        slot.ClearSlot();
                    } else{
                        slot.SetItem(overflow);
                    }
                }
                UpdateSlots();
                return;

            }

            //Something in hand
            if(cursorHolding){
                //Clicking on inventory slot
                if(slot.slotType == InventorySlot.SlotType.inventory || slot.slotType == InventorySlot.SlotType.chest){
                    //Nothing already in slot
                    if(slot.item == null){
                        slot.SetItem(cursorItem);
                        ClearCursor(slot);
                    //Something in slot
                    } else{
                        if(slot.item.name == cursorItem.name && slot.item.count < slot.item.stackSize){
                            if(cursorItem.count + slot.item.count <= cursorItem.stackSize){
                                slot.item.count += cursorItem.count;
                                ClearCursor(slot);
                            } else{
                                int toMove = slot.item.stackSize - slot.item.count;
                                slot.item.count += toMove;
                                cursorItem.count -= toMove;
                                cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                            }
                        } else{
                            Item temp = cursorItem;
                            cursorItem = slot.item;
                            cursor.GetComponent<CursorItem>().SetActive(slot.item);
                            slot.SetItem(temp);
                        }
                        
                    }    
                //Clicking on shipping slot
                } else if(slot.slotType == InventorySlot.SlotType.shipping && cursorItem.canSell){
                    //Nothing already in slot
                    if(slot.item == null){
                        slot.SetItem(cursorItem);
                        ClearCursor(slot);
                    //Something in slot
                    } else{
                        toSell.Add(slot.item);
                        slot.ClearSlot();
                        slot.SetItem(cursorItem);
                        ClearCursor(slot);
                    }
                //Clicking on trash slot           
                } else if(slot.slotType == InventorySlot.SlotType.trash && cursorItem.canSell){
                    slot.ClearSlot();
                    slot.SetItem(cursorItem);
                    ClearCursor(slot);
                } 
                
            //Nothing in hand
            } else{
                if(slot.item != null){
                    cursorHolding = true;
                    cursor.GetComponent<CursorItem>().SetActive(slot.item);
                    cursorItem = slot.item;
                    slot.ClearSlot();
                }
            }
             
        //Right Click
        } else{
            //If ctrl clicking to chest
            
            if(chestOpen && ctrl){
                if(slot.item){
                    Item overflow = null;
                    Item newItem = Instantiate(slot.item) as Item;
                    if(slot.slotType == InventorySlot.SlotType.inventory){ 
                        overflow = AddItemToChest(newItem, 1);
                    } else if(slot.slotType == InventorySlot.SlotType.chest){
                        overflow = AddItem(newItem, 1);
                    }
                    
                    if(overflow == null){
                        slot.item.count--;
                    }
                    if(slot.item.count == 0){
                        slot.ClearSlot();
                    }
                }               
                UpdateSlots();
                return;
            }
            //Something in hand
            if(cursorHolding){
                //Clicking on inventory slot
                if(slot.slotType == InventorySlot.SlotType.inventory || slot.slotType == InventorySlot.SlotType.chest){
                    //Nothing in Slot
                    if(slot.item == null){
                        cursorItem.count--;
                        Item newItem = Instantiate(cursorItem) as Item;
                        newItem.count = 1;
                        slot.SetItem(newItem);
                        cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    //Same Item in slot
                    } else if(slot.item.name == cursorItem.name && slot.item.count < slot.item.stackSize){
                        cursorItem.count--;
                        slot.item.count++;
                        cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    //Different Item in slot
                    } else{
                        Item temp = cursorItem;
                        cursorItem = slot.item;
                        cursor.GetComponent<CursorItem>().SetActive(slot.item);
                        slot.SetItem(temp);
                    }
                    if(cursorItem.count == 0){
                        ClearCursor(slot);
                    }
                //Clicking on shipping slot
                } else if(slot.slotType == InventorySlot.SlotType.shipping && cursorItem.canSell){
                    //Nothing in Slot
                    if(slot.item == null){
                        cursorItem.count--;
                        Item newItem = Instantiate(cursorItem) as Item;
                        newItem.count = 1;
                        slot.SetItem(newItem);
                        cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    //Something in slot
                    } else{
                        toSell.Add(slot.item);
                        slot.ClearSlot();
                        cursorItem.count--;
                        Item newItem = Instantiate(cursorItem) as Item;
                        newItem.count = 1;
                        slot.SetItem(newItem);
                        cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    }
                    if(cursorItem.count == 0){
                        ClearCursor(slot);
                    }
                //Clicking on trash slot           
                } else if(slot.slotType == InventorySlot.SlotType.trash && cursorItem.canSell){
                    slot.ClearSlot();
                    cursorItem.count--;
                    Item newItem = Instantiate(cursorItem) as Item;
                    newItem.count = 1;
                    slot.SetItem(newItem);
                    cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    if(cursorItem.count == 0){
                        ClearCursor(slot);
                    }
                } 
            //Nothing in hand
            } else{
                if(slot.item != null){
                    if(slot.item.count > 1){
                        cursorHolding = true;
                        Item newItem = Instantiate(slot.item) as Item;
                        cursorItem = newItem;
                        cursorItem.count = slot.item.count / 2;
                        slot.item.count -= cursorItem.count;
                        cursor.GetComponent<CursorItem>().SetActive(cursorItem);
                    } else{
                        cursorHolding = true;
                        cursor.GetComponent<CursorItem>().SetActive(slot.item);
                        cursorItem = slot.item;
                        slot.ClearSlot();
                    }
                }
            }
            
        }
        
       UpdateSlots();
       if(cursorHolding){
            OnHoverExit();
       }
    }

    public void QuickStack(){
        foreach(InventorySlot invSlot in inventorySlots){
            foreach(InventorySlot chestSlot in chestSlots){
                if(invSlot.item != null && chestSlot.item != null){
                    if(invSlot.item.name == chestSlot.item.name){
                        Item overflow = AddItemToChest(invSlot.item, invSlot.item.count);
                        if(overflow == null){
                            invSlot.ClearSlot();
                        } else{
                            invSlot.SetItem(overflow);
                        }
                    }
                }
            }
        }
        UpdateSlots();
    }

    public void Sort(InventorySlot[] slots){
        List<Item> tempList = new List<Item>();
        foreach(InventorySlot slot in slots){
            if(slot.item){
                tempList.Add(slot.item);
                slot.ClearSlot();
            }  
        }
        tempList.Sort(Item.SortByCategory);
        for(int i = 0; i < tempList.Count; i++){
            slots[i].SetItem(tempList[i]);
        }
        UpdateSlots();
    }

    void ClearCursor(InventorySlot slot){
        cursorHolding = false;
        cursor.GetComponent<CursorItem>().SetInactive();
        cursorItem = null;
        if(slot){
            OnHoverEnter(slot.item);
        }
        
    }

    public void CloseMenu(){
        if(cursorHolding){
            AddItem(cursorItem, cursorItem.count);
            ClearCursor(null);
        }
        selectingGift = false;
        trashSlot.ClearSlot();
        chestOpen = false;
        shippingOpen = false;
    }

    public void OnHoverEnter(Item item){
        if(item && !cursorHolding){
            hoverText.SetActive(true);
            hoverText.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.name;
            hoverText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.GetDescription();
        }
        
    }

    public void OnHoverExit(){
        hoverText.SetActive(false);
    }


    public void UpdateSlots(){
        foreach(InventorySlot slot in inventorySlots){
            slot.UpdateSlot();
        }
        foreach(HotbarSlot slot in hotbarSlots){
            slot.UpdateSlot();
        }
        trashSlot.UpdateSlot();
        shippingSlot.UpdateSlot();
        if(chestOpen){
            UpdateChestSlots();
        }
    }

    public void UpdateChestSlots(){
        foreach(InventorySlot slot in chestSlots){
            slot.UpdateSlot();
        }
    }
    
}
