using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Manager : MonoBehaviour
{


    public static Quest_Manager instance;
    public List<Quest> quests;
    public CanvasGroup questMenu;
    public GameObject questUIPrefab;
    public GameObject questMenuContent;

    public CanvasGroup bulletinMenu;
    public GameObject bulletinUIPrefab;
    public GameObject bulletinMenuContent;

    
    void Awake()
    {
       if(instance){
           Destroy(this);
       }else{
           instance = this;
       }
    }

    public void StartGame(){
        quests = new List<Quest>();
        quests.Add(new Quest("Wood", 2, "Sophia", false));
    }

    //If an npc has two completable quests it will only show one
    public Quest CheckQuests(string npc){
        foreach(Quest quest in quests){
            if(quest.npc == npc && quest.active){
                int total = Inventory_Manager.instance.GetTotalItemAmount(quest.itemName);
                if(total >= quest.quantity){
                    return quest;
                }      
            }
        }
        return null;
    }


    //If the quest can't actually be completed this is buggy
    public void CompleteQuest(Quest quest){
        Inventory_Manager.instance.RemoveItem(quest.itemName, quest.quantity);
        quests.Remove(quest);
    }   

    public void loadBulletinQuests(){
        //Destroys old quests on the board
        for(int i = 0; i < bulletinMenuContent.transform.childCount; i++){
            Destroy(bulletinMenuContent.transform.GetChild(i).gameObject);
        }
        //Loads new quests
        foreach(Quest quest in quests){
            if(quest.active == false){
                GameObject UI = Instantiate(bulletinUIPrefab);
                UI.transform.transform.SetParent(bulletinMenuContent.transform, false);
                UI.transform.GetChild(2).GetComponent<AcceptQuestButton>().quest = quest;
                Text text = UI.transform.GetChild(1).GetComponent<Text>();
                text.text = "Bring " + quest.quantity + " " + quest.itemName + " to " + quest.npc;
            } 
        }
    }
}
