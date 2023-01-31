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
        Quest startQuest = new Quest("Bring supplies to Sophia", "Sophia", 3);
        startQuest.SetActive();
        startQuest.mainQuest = true;
        startQuest.items.Add(new QuestItem("Wood", 2));
        quests.Add(startQuest);

    }

    //If an npc has two completable quests it will only show one
    public Quest CheckQuests(string npc){
        foreach(Quest quest in quests){
            if(quest.npc == npc && quest.active){
                if(CanCompleteQuest(quest)){
                    return quest;
                }
            }
        }
        return null;
    }

    public bool CanCompleteQuest(Quest quest){
        foreach(QuestItem item in quest.items){
            int total = Inventory_Manager.instance.GetTotalItemAmount(item.name);
            if(total < item.count){
                return false;
            } 
        }
        return true;
    }


    //If the quest can't actually be completed this is buggy
    public void CompleteQuest(Quest quest){
        if(CanCompleteQuest(quest)){
            foreach(QuestItem item in quest.items){
                Inventory_Manager.instance.RemoveItem(item.name, item.count);
            }
            quests.Remove(quest);
        }
    }

    public void NewDay(){
        List<Quest> toRemove = new List<Quest>();
        foreach(Quest quest in quests){
            if(quest.deadline.CompareDate(Time_Manager.instance.date) < 0){
                toRemove.Add(quest);
            }
        }
        foreach(Quest quest in toRemove){
            quests.Remove(quest);
        }
    }
}
