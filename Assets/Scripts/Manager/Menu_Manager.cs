using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class Menu_Manager : MonoBehaviour
{
    
    public static Menu_Manager instance;

    public bool UIopen = false;
    public bool canClose = true;

    public CanvasGroup menu;
    public GameObject menuTransform;

    public GameObject relationshipUIPrefab;
    public GameObject relationshipMenuContent;

    public GameObject fishingUIPrefab;
    public GameObject fishingMenuContent;

    public GameObject questUIPrefab;
    public GameObject questMenuContent;

    public GameObject skillsUIPrefab;
    public GameObject skillsMenuContent;

    public MenuTabButton tabs;

    public CanvasGroup shippingMenu;
    public InventorySlot shippingSlot;

    public CanvasGroup giftMenu;

    public CanvasGroup storageMenu;

    //Bulletin
    public CanvasGroup bulletinMenu;
    public GameObject bulletinUIPrefab;
    public GameObject bulletinMenuContent;
    public bool bulletinMenuOpen = false;

    //Forest
    public CanvasGroup forestMenu;
    public GameObject innerForestButton;

    //Mines
    public CanvasGroup minesMenu;
    public Transform minesButtons;

    //Vendor Menu
    public CanvasGroup vendorMenu;
    public GameObject vendorMenuContent;
    public GameObject vendorUIPrefab;
    public bool vendorMenuOpen = false;
    public TextMeshProUGUI vendorTitle;

    //Load Menu
    public CanvasGroup loadMenu;
    public GameObject loadMenuContent;
    public GameObject loadUIPrefab;
    public bool loadMenuOpen = false;

    //New Day
    public CanvasGroup newDay;
    public CanvasGroup rankUpDisplay;
    public TextMeshProUGUI rankUpTitle;
    public TextMeshProUGUI rankUpText;





    public Sprite emptyHeart;
    public Sprite fullHeart;

    void Awake()
    {
        if(instance){
            Destroy(this);
        } else{
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape)){
            if(UIopen){
                if(canClose){
                    if(!Dialogue_Manager.instance.dialogueActive){
                        Time_Manager.instance.Unpause();
                    }
                    
                    ClosePauseMenu();
                    
                    if(shippingSlot.item){
                        Inventory_Manager.instance.toSell.Add(shippingSlot.item);
                    }
                    shippingSlot.ClearSlot();
                }
            } else {
                if(Time_Manager.instance.Pause()){
                    OpenPauseMenu();
                }
            }
            if(vendorMenuOpen){
                CloseVendorMenu();
                Time_Manager.instance.Unpause();
            }
            if(bulletinMenuOpen){
                CloseBulletinMenu();
                Time_Manager.instance.Unpause();
            }
            if(loadMenuOpen){
                CloseLoadMenu();
            }   
        }
        
    }


    public void UpdateRelationshipMenu(){

        for(int i = 0; i < relationshipMenuContent.transform.childCount; i++){
            Destroy(relationshipMenuContent.transform.GetChild(i).gameObject);
        }
        foreach(Script npc in NPC_Manager.instance.npcs){
            GameObject UI = Instantiate(relationshipUIPrefab);
            UI.transform.transform.SetParent(relationshipMenuContent.transform, false);
            TextMeshProUGUI text = UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            
            if(npc.metPlayer == true){
                text.text = npc.npcName;
                UI.transform.GetChild(2).GetComponent<Image>().sprite = npc.icon;
                int hearts = npc.relationship / npc.relationshipPerHeart;
                if(hearts > 4){
                    hearts = 4;
                }
                for(int i = 0; i < 4; i++){
                    UI.transform.GetChild(3).GetChild(i).GetComponent<Image>().sprite = emptyHeart;
                }
                for(int i = 0; i < hearts; i++){
                    UI.transform.GetChild(3).GetChild(i).GetComponent<Image>().sprite = fullHeart;
                }


                
            }else{
                text.text = "???";
            }
        }
    }

    //Fishing menu does not currently support multiple catch locations
    public void UpdateFishingMenu(){
        for(int i = 0; i < fishingMenuContent.transform.childCount; i++){
            Destroy(fishingMenuContent.transform.GetChild(i).gameObject);
        }
        foreach(Fish fish in Fishing_Manager.instance.fishTable){
            GameObject UI = Instantiate(fishingUIPrefab);
            UI.transform.transform.SetParent(fishingMenuContent.transform, false);
            if(fish.numCaught > 0){
                UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = fish.name;
                UI.transform.GetChild(2).GetComponent<Image>().sprite = fish.icon;

                if(fish.waterTypes.Contains(Water.Type.river)){
                    UI.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "River";
                }
                if(fish.waterTypes.Contains(Water.Type.mountain_lake)){
                    UI.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Mountain Lake";
                }
                if(fish.waterTypes.Contains(Water.Type.forest_lake)){
                    UI.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Forest Lake";
                }

                if(fish.time == Fish.CatchTime.any){
                    UI.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Any Time";
                }
                if(fish.time == Fish.CatchTime.day){
                    UI.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Day";
                }
                if(fish.time == Fish.CatchTime.night){
                    UI.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Night";
                }

                UI.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = "Caught: " + fish.numCaught;

            } 
        }
    }


    public void UpdateQuestMenu(){
        for(int i = 0; i < questMenuContent.transform.childCount; i++){
            Destroy(questMenuContent.transform.GetChild(i).gameObject);
        }
        foreach(Quest quest in Quest_Manager.instance.quests){
            if(quest.active == true){
                GameObject UI = Instantiate(questUIPrefab);
                UI.transform.transform.SetParent(questMenuContent.transform, false);
                TextMeshProUGUI nameText = UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                nameText.text = quest.questName;
                Script npc = NPC_Manager.instance.GetNPCByName(quest.npc);
                UI.transform.GetChild(2).GetComponent<Image>().sprite = npc.icon;

                for(int i = 0; i < quest.items.Count; i++){
                    UI.transform.GetChild(3).GetChild(i).gameObject.SetActive(true);
                    Image reqIcon = UI.transform.GetChild(3).GetChild(i).GetChild(0).GetComponent<Image>();
                    reqIcon.sprite = Inventory_Manager.instance.GetItemByName(quest.items[i].name).icon;
                    TextMeshProUGUI reqName = UI.transform.GetChild(3).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>();
                    reqName.text = quest.items[i].count.ToString();
                }
                TextMeshProUGUI timeText = UI.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
                timeText.text = "Deadline: " + quest.deadline.month + " " + quest.deadline.date + " Year " + quest.deadline.year;
                if(quest.mainQuest){
                     UI.transform.GetChild(5).gameObject.SetActive(true);
                }
            } 
        }
    }

    public class Skill{
        public string name;
        public int level;
        public int xp;
        public Skill(string name, int level, int xp){
            this.name = name;
            this.level = level;
            this.xp = xp;
        }
    }

    public void UpdateSkillsMenu(){
        for(int i = 0; i < skillsMenuContent.transform.childCount; i++){
            Destroy(skillsMenuContent.transform.GetChild(i).gameObject);
        }
        Skill[] skills = new Skill[4];
        skills[0] = new Skill("Farming", Skills_Manager.instance.farmingLevel, Skills_Manager.instance.farmingXP);
        skills[1] = new Skill("Fishing", Skills_Manager.instance.fishingLevel, Skills_Manager.instance.fishingXP);
        skills[2] = new Skill("Forestry", Skills_Manager.instance.forestryLevel, Skills_Manager.instance.forestryXP);
        skills[3] = new Skill("Mining", Skills_Manager.instance.miningLevel, Skills_Manager.instance.miningXP);


        //Farming Skill
        foreach(Skill skill in skills){
            GameObject UI = Instantiate(skillsUIPrefab);
            UI.transform.transform.SetParent(skillsMenuContent.transform, false);
            UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = skill.name;
            UI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = skill.level.ToString();
            Slider xpSlider = UI.transform.GetChild(3).GetComponent<Slider>();
            int maxValue = Skills_Manager.GetLevelsMaxXP(skill.level);
            xpSlider.maxValue = maxValue;
            xpSlider.value = maxValue - Skills_Manager.GetXPToLevel(skill.xp);
        }
    }

    public void OpenBulletinMenu(){
        bulletinMenuOpen = true;
        //Destroys old quests on the board
        for(int i = 0; i < bulletinMenuContent.transform.childCount; i++){
            Destroy(bulletinMenuContent.transform.GetChild(i).gameObject);
        }
        //Loads new quests
        foreach(Quest quest in Quest_Manager.instance.quests){
            if(quest.active == false){
                GameObject UI = Instantiate(bulletinUIPrefab);
                UI.transform.transform.SetParent(bulletinMenuContent.transform, false);
                UI.transform.GetChild(2).GetComponent<AcceptQuestButton>().quest = quest;
                TextMeshProUGUI nameText = UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                nameText.text = quest.questName;
                Script npc = NPC_Manager.instance.GetNPCByName(quest.npc);
                UI.transform.GetChild(3).GetComponent<Image>().sprite = npc.icon;

                for(int i = 0; i < quest.items.Count; i++){
                    UI.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
                    Image reqIcon = UI.transform.GetChild(4).GetChild(i).GetChild(0).GetComponent<Image>();
                    reqIcon.sprite = Inventory_Manager.instance.GetItemByName(quest.items[i].name).icon;
                    TextMeshProUGUI reqName = UI.transform.GetChild(4).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>();
                    reqName.text = quest.items[i].count.ToString();
                }
                TextMeshProUGUI timeText = UI.transform.GetChild(5).GetComponent<TextMeshProUGUI>();
                timeText.text = quest.timeToComplete + " Days";

            } 
        }
        bulletinMenu.alpha = 1;
        bulletinMenu.interactable = true;
        bulletinMenu.blocksRaycasts = true;
    }

    public void CloseBulletinMenu(){
        bulletinMenuOpen = false;
        bulletinMenu.alpha = 0;
        bulletinMenu.interactable = false;
        bulletinMenu.blocksRaycasts = false;
    }


    public void OpenPauseMenu(){
        menu.alpha = 1f;
        menu.blocksRaycasts = true;
        menu.interactable = true;
        UIopen = true;
        UpdateQuestMenu();
        UpdateRelationshipMenu();
        UpdateFishingMenu();
        tabs.ButtonPressInventory();
        Inventory_Manager.instance.UpdateSlots();
    }

    public void ClosePauseMenu(){
        menu.alpha = 0f;
        menu.blocksRaycasts = false;
        menu.interactable = false;
        storageMenu.alpha = 0f;
        storageMenu.interactable = false;
        storageMenu.blocksRaycasts = false;
        shippingMenu.alpha = 0f;
        shippingMenu.interactable = false;
        shippingMenu.blocksRaycasts = false;
        giftMenu.alpha = 0f;
        giftMenu.interactable = false;
        giftMenu.blocksRaycasts = false;
        UIopen = false;
        Inventory_Manager.instance.CloseMenu();
        tabs.ClearAll();
        Vector3 pos = new Vector3(0,0,0);
        menuTransform.GetComponent<RectTransform>().anchoredPosition = pos;
    }

    public void PauseMenuInteractable(bool interact){
        menu.blocksRaycasts = interact;
        menu.interactable = interact;
    }

    public void OpenShippingMenu(){
        shippingMenu.alpha = 1;
        shippingMenu.interactable = true;
        shippingMenu.blocksRaycasts = true;
        Inventory_Manager.instance.shippingOpen = true;
    }

    public void OpenStorageMenu(){
        storageMenu.alpha = 1;
        storageMenu.interactable = true;
        storageMenu.blocksRaycasts = true;
        Vector3 pos = new Vector3(-250,0,0);
        menuTransform.GetComponent<RectTransform>().anchoredPosition = pos;
        Inventory_Manager.instance.chestOpen = true;
    }

    public void OpenForestMenu(){
        forestMenu.alpha = 1;
        forestMenu.interactable = true;
        forestMenu.blocksRaycasts = true;
        innerForestButton.SetActive(false);
        if(Skills_Manager.instance.forestryNovice){
            innerForestButton.SetActive(true);
        }
    }

    public void CloseForestMenu(){
        forestMenu.alpha = 0;
        forestMenu.interactable = false;
        forestMenu.blocksRaycasts = false;
    }

    public void OpenMinesMenu(){
        minesMenu.alpha = 1;
        minesMenu.interactable = true;
        minesMenu.blocksRaycasts = true;
        for(int i = 1; i <= Mines_Manager.instance.startingFloors; i++){
            minesButtons.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void CloseMinesMenu(){
        minesMenu.alpha = 0;
        minesMenu.interactable = false;
        minesMenu.blocksRaycasts = false;
    }

    public void OpenLoadMenu(){
        loadMenuOpen = true;
        UpdateLoadMenu();
        loadMenu.alpha = 1;
        loadMenu.interactable = true;
        loadMenu.blocksRaycasts = true;
    }

    public void CloseLoadMenu(){
        loadMenuOpen = false;
        loadMenu.alpha = 0;
        loadMenu.interactable = false;
        loadMenu.blocksRaycasts = false;
    }

    public void LoadMenuInteractable(bool interact){
        loadMenu.interactable = interact;
        loadMenu.blocksRaycasts = interact;
    }

    public void UpdateLoadMenu(){
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        FileInfo[] info = dir.GetFiles("*.*");
        BinaryFormatter formatter = new BinaryFormatter();

        for(int i = 0; i < loadMenuContent.transform.childCount; i++){
            Destroy(loadMenuContent.transform.GetChild(i).gameObject);
        }
        
        foreach (FileInfo f in info){
            FileStream stream = new FileStream(f.FullName, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            GameObject UI = Instantiate(loadUIPrefab);
            UI.transform.transform.SetParent(loadMenuContent.transform, false);
            TextMeshProUGUI nameText = UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            nameText.text = data.playerName;
            TextMeshProUGUI dateText = UI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            dateText.text = data.day + " " + data.date.date;
            UI.GetComponent<LoadSaveButtons>().data = data;
            UI.GetComponent<LoadSaveButtons>().path = f.FullName;
            stream.Close();
        }
    }

    public void OpenVendorMenu(VendorInventory inv){
        vendorMenuOpen = true;
        Vendor_Manager.instance.openInventory = inv;
        for(int i = 0; i < vendorMenuContent.transform.childCount; i++){
            Destroy(vendorMenuContent.transform.GetChild(i).gameObject);
        }
        vendorTitle.text = "Stall Closed";
        if(inv){
            vendorTitle.text = inv.standName;
            foreach(VendorItem item in inv.inventory){
                if(!Vendor_Manager.instance.CanBuyItem(item)){
                    continue;
                }
                GameObject UI = Instantiate(vendorUIPrefab);
                UI.transform.transform.SetParent(vendorMenuContent.transform, false);
                TextMeshProUGUI nameText = UI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                Image icon = UI.transform.GetChild(3).GetComponent<Image>();
                if(item.item){
                    nameText.text = item.item.name;
                    icon.sprite = item.item.icon;
                } else{
                    nameText.text = Vendor_Manager.instance.GetSpecialName(item.special);
                    icon.gameObject.SetActive(false);
                }
                
                UI.transform.GetChild(2).GetComponent<BuyItemButton>().item = item;          
                TextMeshProUGUI priceText = UI.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
                priceText.text = item.price + "g";
                //req items
                for(int i = 0; i < item.reqItems.Count; i++){
                    UI.transform.GetChild(5).GetChild(i).gameObject.SetActive(true);
                    Image reqIcon = UI.transform.GetChild(5).GetChild(i).GetChild(0).GetComponent<Image>();
                    reqIcon.sprite = item.reqItems[i].item.icon;
                    TextMeshProUGUI reqName = UI.transform.GetChild(5).GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>();
                    reqName.text = item.reqItems[i].count.ToString();
                }

            }
        }
        vendorMenu.alpha = 1f;
        vendorMenu.interactable = true;
        vendorMenu.blocksRaycasts = true;
    }

    public void CloseVendorMenu(){
        Vendor_Manager.instance.openInventory = null;
        vendorMenuOpen = false;
        vendorMenu.alpha = 0;
        vendorMenu.interactable = false;
        vendorMenu.blocksRaycasts = false;
    }

    public void OpenNewDay(){
        newDay.alpha = 1;
        newDay.blocksRaycasts = true;
        newDay.interactable = true;
    }

    public void CloseNewDay(){
        newDay.alpha = 0;
        newDay.blocksRaycasts = false;
        newDay.interactable = false;
        CloseRankUp();
    }

    public void DisplayRankUp(SkillRankUp skill){
        rankUpDisplay.alpha = 1;
        rankUpDisplay.interactable = true;
        rankUpDisplay.blocksRaycasts = true;
        rankUpTitle.text = skill.title;
        rankUpText.text = skill.rewards;
    }

    public void CloseRankUp(){
        rankUpDisplay.alpha = 0;
        rankUpDisplay.interactable = false;
        rankUpDisplay.blocksRaycasts = false;
    }
}
