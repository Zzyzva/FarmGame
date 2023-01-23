using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabButton : MonoBehaviour
{
    public CanvasGroup questMenu;
    public CanvasGroup relationshipMenu;
    public CanvasGroup fishingMenu;
    public CanvasGroup inventoryMenu;
    public CanvasGroup skillsMenu;
    public CanvasGroup exitMenu;

    

    public void ButtonPressInventory(){
        ClearAll();
        inventoryMenu.alpha = 1f;
        inventoryMenu.interactable = true;
        inventoryMenu.blocksRaycasts = true;
    }
    
    public void ButtonPressQuests(){
        ClearAll();
        Menu_Manager.instance.UpdateQuestMenu();
        Inventory_Manager.instance.CloseMenu();
        questMenu.alpha = 1f;
        questMenu.interactable = true;
        questMenu.blocksRaycasts = true;
    }

    public void ButtonPressRelationship(){
        ClearAll();
        Menu_Manager.instance.UpdateRelationshipMenu();
        Inventory_Manager.instance.CloseMenu();
        relationshipMenu.alpha = 1f;
        relationshipMenu.interactable = true;
        relationshipMenu.blocksRaycasts = true;
    }

    public void ButtonPressFishing(){
        ClearAll();
        Menu_Manager.instance.UpdateFishingMenu();
        Inventory_Manager.instance.CloseMenu();
        fishingMenu.alpha = 1f;
        fishingMenu.interactable = true;
        fishingMenu.blocksRaycasts = true;
    }


    public void ButtonPressSkills(){
        ClearAll();
        Menu_Manager.instance.UpdateSkillsMenu();
        Inventory_Manager.instance.CloseMenu();
        skillsMenu.alpha = 1f;
        skillsMenu.interactable = true;
        skillsMenu.blocksRaycasts = true;
    }

    public void ButtonPressExit(){
        ClearAll();
        exitMenu.alpha = 1f;
        exitMenu.interactable = true;
        exitMenu.blocksRaycasts = true;
    }


    public void ClearAll(){
        inventoryMenu.alpha = 0f;
        inventoryMenu.interactable = false;
        inventoryMenu.blocksRaycasts = false;

        questMenu.alpha = 0f;
        questMenu.interactable = false;
        questMenu.blocksRaycasts = false;

        relationshipMenu.alpha = 0f;
        relationshipMenu.interactable = false;
        relationshipMenu.blocksRaycasts = false;

        fishingMenu.alpha = 0f;
        fishingMenu.interactable = false;
        fishingMenu.blocksRaycasts = false;

        skillsMenu.alpha = 0f;
        skillsMenu.interactable = false;
        skillsMenu.blocksRaycasts = false;

        exitMenu.alpha = 0f;
        exitMenu.interactable = false;
        exitMenu.blocksRaycasts = false;
    }
}
