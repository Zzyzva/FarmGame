using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //Cutscene
    public List<string> sceneNames = new List<string>();
    public List<bool> sceneWatched = new List<bool>();

    //Farming
    public float waterInCan;
    public List<bool> cropTilled = new List<bool>();
    public List<int> cropGrowthDays = new List<int>();
    public List<string> cropName = new List<string>();

    //Fishing
    public List<string> fishNames = new List<string>();
    public List<int>  fishNumCaught = new List<int>();

    //Inventory
    public string playerName;
    public int gold;
    public List<string> invItemNames = new List<string>();
    public List<int> invItemCount = new List<int>();
    public List<string> chestItemNames = new List<string>();
    public List<int> chestItemCount = new List<int>();

    //Mines
    public int lightFloors;
    public int startingFloors;

    //NPC
    public List<string> npcNames = new List<string>();
    public List<bool> npcHasMet = new List<bool>();
    public List<int> npcRelationship = new List<int>();

    //Quest
    public List<Quest> quests = new List<Quest>();

    //Save
    public string saveName;
    public string directoryName;

    //Skills
    public int farmingXP;
    public int miningXP;
    public int fishingXP;
    public int forestryXP;

    //Time
    public string day;
    public Date date;
        

    public void Save(){
        SaveCutscene();
        SaveFarming();
        SaveFishing();
        SaveInventory();
        SaveMines();
        SaveNPC();
        SaveQuest();
        SaveSave();
        SaveSkills();
        SaveTime();
    }

    void SaveCutscene(){
        foreach(Cutscene scene in Cutscene_Manager.instance.cutscenes){
            sceneNames.Add(scene.sceneName);
            sceneWatched.Add(scene.hasBeenSeen);
        }
    }

    void SaveFarming(){
        waterInCan = Farming_Manager.instance.waterInCan;
        foreach(GameObject obj in Farming_Manager.instance.dirt){
            Dirt dirt = obj.GetComponent<Dirt>();
            cropTilled.Add(dirt.tilled);
            cropGrowthDays.Add(dirt.growthDays);
            if(dirt.crop != null){
                cropName.Add(dirt.crop.name);
            } else{
                cropName.Add(null);
            }
        }
    }

    void SaveFishing(){
        foreach(Fish fish in Fishing_Manager.instance.fishTable){
            fishNames.Add(fish.name);
            fishNumCaught.Add(fish.numCaught);
        }
    }

    void SaveInventory(){
        playerName = Inventory_Manager.instance.playerName;
        gold = Inventory_Manager.instance.gold;
        foreach(InventorySlot slot in Inventory_Manager.instance.inventorySlots){
            if(slot.item != null){
                invItemNames.Add(slot.item.name);
                invItemCount.Add(slot.item.count);
            } else{
                invItemNames.Add(null);
                invItemCount.Add(0);
            }
        }

        foreach(InventorySlot slot in Inventory_Manager.instance.chestSlots){
            if(slot.item != null){
                chestItemNames.Add(slot.item.name);
                chestItemCount.Add(slot.item.count);
            } else{
                chestItemNames.Add(null);
                chestItemCount.Add(0);
            }
        }
    }

    void SaveMines(){
        lightFloors = Mines_Manager.instance.lightFloors;
        startingFloors = Mines_Manager.instance.startingFloors;
    }

    void SaveNPC(){
        foreach(Script npc in NPC_Manager.instance.npcs){
            npcNames.Add(npc.name);
            npcHasMet.Add(npc.metPlayer);
            npcRelationship.Add(npc.relationship);
        }
    }

    void SaveQuest(){    
        quests = Quest_Manager.instance.quests;
    }

    void SaveSave(){
        saveName = Save_Manager.instance.saveFile;
        directoryName = Save_Manager.instance.directoryPath;
    }

    void SaveSkills(){
        farmingXP = Skills_Manager.instance.farmingXP;
        miningXP = Skills_Manager.instance.miningXP;
        fishingXP = Skills_Manager.instance.fishingXP;
        forestryXP = Skills_Manager.instance.forestryXP;
    }

    void SaveTime(){
        day = Time_Manager.instance.day;
        date = Time_Manager.instance.date;
    }




    public void Load(){
        LoadCutscene();
        LoadFarming();
        LoadFishing();
        LoadInventory();
        LoadMines();
        LoadNPC();
        LoadQuest();
        LoadSave();
        LoadSkills();
        LoadTime();
    }

    void LoadCutscene(){
        for(int i = 0; i < sceneNames.Count; i++){
            foreach(Cutscene scene in Cutscene_Manager.instance.cutscenes){
                if(sceneNames[i] == scene.sceneName){
                    scene.hasBeenSeen = sceneWatched[i];
                }
            }
        }
    }

    void LoadFarming(){
        Farming_Manager.instance.waterInCan = waterInCan;
        for(int i = 0; i < cropTilled.Count; i++){
            Dirt dirt = Farming_Manager.instance.dirt[i].GetComponent<Dirt>();
            dirt.tilled = cropTilled[i];
            dirt.growthDays = cropGrowthDays[i];
            if(cropName[i] != null){
                foreach(GameObject obj in Farming_Manager.instance.crops){
                    Crop crop = obj.GetComponent<Crop>();
                    if(crop.name == cropName[i]){
                        dirt.crop = crop;
                        dirt.planted = true;
                        if(cropGrowthDays[i] == crop.growth[crop.growth.Count - 1].day){
                            dirt.ready = true;
                        }
                    }
                }
            }
            
            
        }
    }

    void LoadFishing(){
        for(int i = 0; i < fishNames.Count; i++){
            foreach(Fish fish in Fishing_Manager.instance.fishTable){
                if(fishNames[i] == fish.name){
                    fish.numCaught = fishNumCaught[i];
                }
            }
        }
    }

    void LoadInventory(){
        Inventory_Manager.instance.playerName = playerName;
        Inventory_Manager.instance.gold = gold;

        foreach(InventorySlot slot in Inventory_Manager.instance.inventorySlots){
            slot.ClearSlot();
        }

        foreach(InventorySlot slot in Inventory_Manager.instance.chestSlots){
            slot.ClearSlot();
        }

        for(int i = 0; i < invItemNames.Count; i++){
            if(invItemNames[i] != null){
                foreach(Object obj in Inventory_Manager.instance.items){
                    Item item = (Item) obj;
                    if(item.name == invItemNames[i]){
                        Inventory_Manager.instance.inventorySlots[i].item = item;
                        Inventory_Manager.instance.inventorySlots[i].item.count = invItemCount[i];
                    }
                }
            }
        }
        for(int i = 0; i < chestItemNames.Count; i++){
            if(chestItemNames[i] != null){
                foreach(Object obj in Inventory_Manager.instance.items){
                    Item item = (Item) obj;
                    if(item.name == chestItemNames[i]){
                        Inventory_Manager.instance.chestSlots[i].item = item;
                        Inventory_Manager.instance.chestSlots[i].item.count = chestItemCount[i];
                    }
                }
            }
        }


    }

    void LoadMines(){
        Mines_Manager.instance.lightFloors = lightFloors;
        Mines_Manager.instance.startingFloors = startingFloors;
    }

    void LoadNPC(){
        for(int i = 0; i < npcNames.Count; i++){
            foreach(Script npc in NPC_Manager.instance.npcs){
                if(npcNames[i] == npc.npcName){
                    npc.metPlayer = npcHasMet[i];
                    npc.relationship = npcRelationship[i];
                }
            }
        }
    }

    void LoadQuest(){
        Quest_Manager.instance.quests.Clear();
        Quest_Manager.instance.quests = quests;

    }

    void LoadSave(){
        Save_Manager.instance.saveFile = saveName;
        Save_Manager.instance.directoryPath = directoryName;
    }

    void LoadSkills(){
        Skills_Manager.instance.farmingXP = farmingXP;
        Skills_Manager.instance.miningXP = miningXP;
        Skills_Manager.instance.fishingXP = fishingXP;
        Skills_Manager.instance.forestryXP = forestryXP;
        Skills_Manager.instance.CalculateAllLevels();
    }

    void LoadTime(){
        Time_Manager.instance.day = day;
        Time_Manager.instance.date = date;
    }
}
